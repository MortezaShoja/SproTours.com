Imports System.Globalization
Imports System.Data

Partial Class Members_Receipts
    Inherits System.Web.UI.Page
    Private SE As SendEmail
    Private CHE As CreateHTMLEmail
    Private MC As MoneyCodec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If HttpContext.Current.Request.Cookies.Get("UserSettings") Is Nothing Then
            Response.Redirect("../Default.aspx")
        Else
            If IsPostBack = False Then
                FillgvReceipt()
            End If
        End If

    End Sub


    Private Sub FillgvReceipt(Optional ByVal FilterOption As String = "is null")
        Dim SumPrice As Decimal = 0
        MC = New MoneyCodec
        Try
            Dim Dvw As New Data.DataView
            Dim Tbl As New Data.DataTable
            Tbl.Clear()

            Tbl.Columns.Add("شماره سند")
            Tbl.Columns.Add("شماره پیگیری")
            Tbl.Columns.Add("تاریخ واریز")
            Tbl.Columns.Add("ساعت واریز")
            Tbl.Columns.Add("مبلغ (تومان)")
            'populating rows

            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Try
                Cmd.CommandText = "Select Code,TrackingNo,PayDate,PayTime,Amount from Payments Where MemberID='" & Request.Cookies("UserSettings")("ID").ToString & "' And Accepted " & FilterOption & " Order by PayDate Desc,PayTime Desc "
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                While sdr.Read
                    Dim row As DataRow = Tbl.NewRow
                    row(0) = sdr(0)
                    row(1) = sdr(1)
                    row(2) = sdr(2)
                    row(3) = sdr(3)
                    SumPrice += sdr(4)
                    row(4) = MC.Code(sdr(4))
                    Tbl.Rows.Add(row)
                End While
            Catch ex As Exception
                Dim ERM As New ErrorLog
                ERM.Log(Request, "Error", Request.Cookies("UserSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "FillgvUnderProcessOrders#1")
            Finally
                SqlCon.SqlCon.Close()
            End Try


            Dvw = New Data.DataView(Tbl)
            Me.gvReceips.DataSource = Dvw
            Me.gvReceips.DataBind()

        Catch ex As Exception


            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", Request.Cookies("UserSettings")("ID").ToString, ex.StackTrace, ex.Message, "", Request.Url.Segments.Last(), "FillgvUnderProcessOrders#2")
        Finally

        End Try

        Me.lblSumPrice.Text = " جمع کل : " & MC.CodeFixUp(SumPrice) & " تومان "
    End Sub


    Protected Sub gvReceips_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvReceips.RowCommand
        MC = New MoneyCodec
        If (e.CommandName = "btnView") Then
            Dim currentRowIndex As Integer = Int32.Parse(e.CommandArgument.ToString())
            Dim Code As String = Me.gvReceips.Rows(currentRowIndex.ToString).Cells(1).Text

            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Try
                '                          0    1           2           3       4       5       6         7        8        9           10
                Cmd.CommandText = "Select ID,MemberID,AccountOwner,AccountNo,PayDate,PayTime,TrackingNo,Amount,Accepted,Descriptions,OwnerSite From Payments Where Code=N'" & Code & "'"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                If sdr.Read Then

                    Try
                        If System.IO.File.Exists(Server.MapPath(Request.ApplicationPath) & "\Receipts\" & sdr(0).ToString & ".jpg") Then '
                            Me.imgReceipt.ImageUrl = "../Receipts/" & sdr(0).ToString & ".jpg"
                        Else
                            Me.imgReceipt.ImageUrl = Nothing
                        End If
                    Catch ex As Exception
                        Me.imgReceipt.ImageUrl = Nothing
                    End Try

                    If sdr(10).ToString = "TurkorderShop.ir" Then
                        Me.imgReceipt.ImageUrl = "http://www.TurkorderShop.ir/Receipts/" & sdr(0).ToString & ".jpg"
                    End If

                    Me.Receipt_ID.Text = sdr(0).ToString
                    Me.Receipt_AccountOwner.Text = sdr(2).ToString
                    Me.Receipt_AccountNo.Text = sdr(3).ToString
                    Me.Receipt_PayDate.Text = sdr(4).ToString
                    Me.Receipt_PayTime.Text = sdr(5).ToString
                    Me.Receipt_TarackingNo.Text = sdr(6).ToString
                    Me.Receipt_Amount.Text = MC.Code(sdr(7))
                    'Select Case sdr(8).ToString
                    '    Case Is = Nothing
                    '        Me.Receipt_Status.SelectedIndex = 0
                    '    Case Is = True
                    '        Me.Receipt_Status.SelectedIndex = 1
                    '    Case Is = False
                    '        Me.Receipt_Status.SelectedIndex = 2
                    'End Select
                    Me.Receipt_Descriptions.Text = sdr(9).ToString
                    Me.DivReceiptDetails.Visible = True
                End If
            Catch ex As Exception
                Dim ERM As New ErrorLog
                ERM.Log(Request, "Error", Request.Cookies("UserSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "gvNewRceipts_RowCommand")
            Finally
                SqlCon.SqlCon.Close()
            End Try
            'FillgvNewRceipts()
        End If
    End Sub

    Protected Sub ddlFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFilter.SelectedIndexChanged
        Select Case Me.ddlFilter.SelectedIndex
            Case Is = 0
                FillgvReceipt("is null")
            Case Is = 1
                FillgvReceipt("='1'")
            Case Is = 2
                FillgvReceipt("='0'")
        End Select
    End Sub

    Protected Sub btnSaveReceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveReceipt.Click

        Dim ReceiptID As String = Guid.NewGuid.ToString
        Dim ServerPath As String = Server.MapPath(Request.ApplicationPath)
        Try
            Me.uploadReceipt.SaveAs(ServerPath & "\Receipts\" & ReceiptID & ".jpg")
        Catch ex As Exception

        End Try

        '--------------------------------------
        Dim TmpMemberID As String = String.Empty
        Try
            TmpMemberID = Request.Cookies("UserSettings")("ID").ToString
        Catch ex As Exception

        End Try
        Try
            If TmpMemberID <> String.Empty Then
                Dim SqlCon As New SqlConnectionSite
                Dim Cmd As New SqlClient.SqlCommand
                Try
                    Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ReceiptID
                    Cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = TmpMemberID
                    Cmd.Parameters.Add("@RegDate", SqlDbType.DateTime).Value = Now.ToString
                    Cmd.Parameters.Add("@TrackingNo", SqlDbType.NVarChar).Value = Me.Receipt_TarackingNo_New.Text
                    Cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Integer.Parse(Me.Receipt_Amount_New.Text.Replace(".", "").Replace(",", ""))

                    Cmd.CommandText = "Insert Into Payments (ID,MemberID,RegDate,TrackingNo,Amount) values (@ID,@MemberID,@RegDate,@TrackingNo,@Amount)"
                    Cmd.Connection = SqlCon.SqlCon
                    SqlCon.SqlCon.Open()
                    Cmd.ExecuteNonQuery()


                    Try
                        SE = New SendEmail
                        CHE = New CreateHTMLEmail
                        'SE.Sender("Accounting@TurkOrder.com", "TurkOrder.com", "AccOrder2016", GetMemberInfo(TmpMemberID), CHE.CreatePaymentNotification(Me.Receipt_AccountOwner.Text, Me.Receipt_AccountNo.Text, Me.Receipt_PayDate.Text, Me.Receipt_PayTime.Text, Me.Receipt_TarackingNo.Text, Me.Receipt_Amount.Text, "", Server.MapPath("Email/PaymentOverView.htm")), "مشخصات فیش واریزی", "")
                        'SE.Sender("Accounting@TurkOrder.com", "TurkOrder.com", "AccOrder2016", GetMemberInfo(TmpMemberID), CHE.CreatePaymentNotification("", "", "", "", Me.Receipt_TarackingNo.Text, Me.Receipt_Amount.Text, "", ServerPath & "\Email\PaymentOverView.htm"), "مشخصات فیش واریزی", ServerPath & "\Receipts\" & ReceiptID & ".jpg")
                    Catch ex As Exception

                    End Try

                    'Me.Receipt_RequestCode.Text = String.Empty
                    'Me.Receipt_AccountOwner.Text = String.Empty
                    'Me.Receipt_AccountNo.Text = String.Empty
                    'Me.Receipt_PayDate.Text = String.Empty
                    'Me.Receipt_PayTime.Text = String.Empty
                    Me.Receipt_TarackingNo.Text = ""
                    Me.Receipt_Amount.Text = ""

                    'Me.Receipt_Message.ForeColor = Drawing.Color.Green
                    'Me.Receipt_Message.Text = "مشخصات فیش واریزی شما با موفقیت ثبت گریدی" & "<br />" & "پس از بررسی واحد مالی نتیجه آن از طریق ایمیل به شما اطلاع داده می شود"
                    'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "script", "$('#pageModalAddReceipt').modal('hide'); MessageBox('ثبت فیش واریزی','مشخصات فیش واریزی شما با موفقیت ثبت گریدی' + '<br />' + 'پس از بررسی واحد مالی نتیجه آن از طریق ایمیل به شما اطلاع داده می شود');", True)
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", "$(window).load(function(){ $('#pageModalAddReceipt').modal('hide'); MessageBox('ثبت فیش واریزی','مشخصات فیش واریزی شما با موفقیت ثبت گردید' + '<br />' + 'پس از بررسی و تایید واحد مالی مبلغ آن در حساب شما منظور خواهد شد'); });", True)

                    
                Catch ex As Exception
                    Dim tmpErrorMessage() As String = ex.Message.ToString.Split(vbCrLf)
                    If tmpErrorMessage(0) = "Violation of PRIMARY KEY constraint 'PK_Payments'. Cannot insert duplicate key in object 'dbo.Payments'." Then
                        'Me.Receipt_Message.ForeColor = Drawing.Color.Red
                        'Me.Receipt_Message.Text = "خطا" & "<br />" & "این فیش قبلاً در سیستم به ثبت رسیده" & "<br />" & "لطفا جهت رفع ایراد و بررسی بیشتر با واحد مالی از طریق ایمیل زیر هماهنگ کنید" & "<br />" & "Accounting@TurkOrdder.com"
                        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "script", "MessageBox('خطا','این فیش قبلاً در سیستم به ثبت رسیده' + '<br />' + 'لطفا جهت رفع ایراد و بررسی بیشتر با واحد مالی از طریق ایمیل زیر هماهنگ کنید' + '<br />' + 'Accounting@TurkOrdder.com');", True)
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", "$(window).load(function(){ MessageBox('خطا','این فیش قبلاً در سیستم به ثبت رسیده' + '<br />' + 'لطفا جهت رفع ایراد و بررسی بیشتر با واحد مالی از طریق ایمیل زیر هماهنگ کنید' + '<br />' + 'Accounting@TurkOrdder.com'); });", True)
                    Else
                        'Me.Receipt_Message.ForeColor = Drawing.Color.Red
                        'Me.Receipt_Message.Text = "خطا" & "<br />" & "به علت خطای نا معلوم امکان ثبت فیش واریزی شما میسر نمیباشد" & "<br />" & "لطفا جهت رفع ایراد و بررسی بیشتر با واحد پشتیبانی از طریق ایمیل زیر هماهنگ کنید" & "<br />" & "Support@TurkOrdder.com"
                        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "script", "MessageBox('خطا','به علت خطای نا معلوم امکان ثبت فیش واریزی شما میسر نمیباشد' + '<br />' + 'لطفا جهت رفع ایراد و بررسی بیشتر با واحد پشتیبانی از طریق ایمیل زیر هماهنگ کنید' + '<br />' + 'Support@TurkOrdder.com');", True)
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", "$(window).load(function(){ MessageBox('خطا','به علت بروز خطاامکان ثبت فیش واریزی شما میسر نمی باشد' + '<br />' + 'لطفا جهت رفع ایراد و بررسی بیشتر با واحد پشتیبانی از طریق ایمیل زیر هماهنگ کنید' + '<br />' + 'Support@TurkOrdder.com'); });", True)
                    End If
                    Dim ERM As New ErrorLog
                    ERM.Log(Request, "Error", TmpMemberID, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "btnAddReceipt_Click")
                Finally
                    SqlCon.SqlCon.Close()
                End Try
            Else
                'Me.Receipt_Message.ForeColor = Drawing.Color.Red
                'Me.Receipt_Message.Text = "خطا" & "<br />" & "کد پیگیری سفارش اشتباه می باشد"
                'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "script", "MessageBox('خطا','کد پیگیری سفارش اشتباه می باشد');", True)
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", "$(window).load(function(){ MessageBox('خطا','کد پیگیری سفارش اشتباه می باشد'); });", True)
                'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "alert", "MessageBox('خطا','کد پیگیری سفارش اشتباه می باشد');", True)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", TmpMemberID, ex.StackTrace, ex.Message, "", Request.Url.Segments.Last(), "btnAddReceipt_Click_#2")
        End Try

        Me.ddlFilter.SelectedIndex = 0
        FillgvReceipt()

    End Sub

    Private Function GetMemberInfo(ByVal MemberID As String) As String
        Dim value As String = String.Empty

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = MemberID
            Cmd.CommandText = "Select Email from Members where ID=@ID"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "GetMemberInfo")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function

End Class
