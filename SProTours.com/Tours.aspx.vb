Imports System.Data
Imports System.Reflection
Imports com.arianpal.merchant

Partial Class Tours
    Inherits System.Web.UI.Page
    Private LTDB As LogToDatabase
    Private RequestID As String
    Private TourID As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MemberID As String = String.empty

        Try
            MemberID = Request.Cookies("UserSettings")("ID").ToString.tostring
        Catch ex As Exception
        End Try

        'LTDB = New LogToDatabase
        'LTDB.UpdateTourPayment(113, 123456789, Server.MapPath(Request.ApplicationPath))

        If MemberID <> String.Empty Then

            Try

                Dim Action As String = String.Empty
                Action = Request.QueryString("Action")

                If Action = "done" Then
                    If Action = "done" And Session("submit") = "true" Then
                        'If Action = "done" Then
                        Session("submit") = "false"
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "peygham();", True)
                        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "openmessagebox(this);", True)
                    End If
                End If
            Catch ex As Exception

            End Try


            Dim HeadCategoryID As String = String.Empty

            'Try
            '    HeadCategoryID = Request.QueryString("hid")
            '    If HeadCategoryID <> String.Empty Then
            '        CreateToursSubcategory(HeadCategoryID)
            '    Else
            '        CreateToursHeadcategory()
            '    End If
            'Catch ex As Exception
            '    CreateToursHeadcategory()
            'End Try

            CreateTours()

            'Response.Write("<script language='javascript'> window.history.pushState('string', 'Title', 'tours.aspx'); </script>")
            Dim tmpHeadGroupID As Integer
            tmpHeadGroupID = GetHeadGroupID(HeadCategoryID)
            CreateToursHeader(tmpHeadGroupID)
        Else
            Response.Redirect("default.aspx?L=2")
        End If

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim FactorNo As String = String.Empty
            FactorNo = Request.QueryString("RC")
            If FactorNo <> String.Empty Then
                CheckPayment(FactorNo)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckPayment(ByVal PaymentCode As String)

        LTDB = New LogToDatabase
        Dim ws As New com.arianpal.merchant.WebService
        Dim MerchantID As String = "4352504"
        Dim Password As String = "g42WUKbQq"
        Dim refnum As String = Request("refnumber")
        Dim status As String = Request("status")
        Dim TotalPrice As Integer = 0
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "refnum", "window.onload = function () { alert('" & refnum & "');};", True)
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "FactorNo", "window.onload = function () { alert('" & FactorNo & "');};", True)

        Dim MemberID As String = String.Empty
        Try
            TotalPrice = LTDB.GetTourPaymentInfo(PaymentCode)
        Catch ex As Exception
        End Try

        'LTDB.UpdateTourPayment(FactorNo, "3456789", Server.MapPath("Email/Tour_Voucher.htm"))

        Try
            If status = 100 Then
                Dim v As VerifyPaymentResult = ws.verifyPayment(MerchantID, Password, TotalPrice, refnum)
                Dim VResult As String = String.Empty
                Select Case v.ResultStatus
                    Case Is = VerifyResult.GatewayInvalidInfo
                        VResult = "خطا در برقراری ارتباط با درگاه پرداخت"
                    Case Is = VerifyResult.InvalidRef
                        VResult = "شماره پیگیری صحیح نمی باشد"
                    Case Is = VerifyResult.NotMatchMoney
                        VResult = "مبلغ پرداختی با مبلغ فاکتور برابر نمی باشد"
                    Case Is = VerifyResult.Ready
                        VResult = " هیچ عملیاتی انجام نشده است"
                    Case Is = VerifyResult.Success
                        'VResult = "پرداخت با موفقیت انجام شد" & "<br /><br />" & "با تشکر از خرید شما"
                        VResult = "<br />" & "با تشکر از خرید شما"
                        'LTDB.UpdateTourPayment(PaymentCode, refnum, Server.MapPath("Email/Tour_Voucher.htm"))
                        LTDB.UpdateTourPayment(PaymentCode, refnum, Server.MapPath(Request.ApplicationPath))
                        Session("MSG") = "پرداخت با موفقیت انجام شد"
                    Case Is = VerifyResult.Verifyed
                        VResult = "تایید شد"
                End Select

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "VResult", "window.onload = function () { MessageBox('نتیجه پرداخت','" & Session("MSG") + " <br /> " + VResult & "');};", True)
            Else
                Dim ErRes As String = String.Empty
                Dim res As Integer = Integer.Parse(status)
                Select Case res
                    Case Is = -99
                        ErRes = "انصراف از پرداخت"
                    Case Is = -88
                        ErRes = "پرداخت ناموفق"
                    Case Is = -77
                        ErRes = "منقضی شدن زمان"
                    Case Is = -66
                        ErRes = "قبلا پرداخت شده است"
                End Select
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "ErRes", "window.onload = function () { MessageBox('خطا','" & ErRes & "');};", True)
            End If
        Catch ex As Exception
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "ErRes", "window.onload = function () { MessageBox('خطا','شناسه پرداخت صحیح نمی باشد');};", True)
            'Session("MSG") = "114" & "<br />" & ex.Message.ToString & "<br />" & refnum & "<br />" & status
            'Response.Redirect("Message.aspx")
        End Try

        '-------------------------------------------------------------
    End Sub

    Private Function GetHeadGroupID(ByVal HeadCategoryID As String) As Integer
        Dim value As Integer = 0
        Dim SqlCon As New SqlConnectionSite

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "select HeaderID from TourHeadCategory Where HeadCategoryID='" & HeadCategoryID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0)
            End If
        Catch ex As Exception

        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function

    Private Sub MessageBox(ByVal strMsg As String)

        ' generate a popup message using javascript alert function
        ' dumped into a label with the string argument passed in
        ' to supply the alert box text
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
        & "window.alert(" & "'" & strMsg & "'" & ")</script>"

        ' add the label to the page to display the alert
        Page.Controls.Add(lbl)

    End Sub

    Private Sub CreateToursHeader(ByVal Shart As String)
        Dim SqlCon As New SqlConnectionSite
        If Shart > 0 Then
            Shart = " Where Code=" & Shart
        Else
            Shart = String.Empty
        End If
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "select Code,Header from TourHeaders " & Shart & " order by Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Dim ArrID(0) As Integer
            Dim ArrHeader(0) As String
            While sdr.Read
                ArrID(ArrID.Length - 1) = sdr(0)
                ArrHeader(ArrHeader.Length - 1) = sdr(1).ToString
                ReDim Preserve ArrID(ArrID.Length)
                ReDim Preserve ArrHeader(ArrHeader.Length)
            End While
            ReDim Preserve ArrID(ArrID.Length - 2)
            ReDim Preserve ArrHeader(ArrHeader.Length - 2)
            Dim CTH As New CreateToursHeader.Generate(ArrID, ArrHeader, Shart)
            Me.ToursHeader.Controls.Add(CTH)
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub

    Private Sub CreateTours()
        Dim SqlCon As New SqlConnectionSite
        Dim CTI As CreateTourItems
        Me.SubCategory.InnerHtml = String.Empty

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "select MenuCode,ID,TourName From TourDetails Order by Code Desc"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Dim ArrID(0) As Integer
            Dim ArrHeader(0) As String
            While sdr.Read
                CTI = New CreateTourItems

                Dim TourImage As String = String.Empty
                Try
                    Dim OurServerPath As String = "C:\Inetpub\vhosts\sprotours.com\admin.sprotours.com"
                    Dim Images() As String = System.IO.Directory.GetFiles(OurServerPath & "\Packages\TourDetails\" & sdr(1).ToString)
                    Dim tmpSelectedIMG() As String = Images(0).Split("\")
                    TourImage = "http://admin.SproTours.com/" & "Packages/TourDetails/" & sdr(1).ToString & "/" & tmpSelectedIMG(tmpSelectedIMG.Length - 1)
                Catch ex As Exception
                    TourImage = "http://admin.SproTours.com/Packages/Tours/no-photo.png"
                End Try


                Me.SubCategory.InnerHtml += CTI.GenerateItem(sdr(0), sdr(1).ToString, sdr(2).ToString, TourImage)
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        'Try
        '    Dim Cmd As New SqlClient.SqlCommand
        '    Cmd.CommandText = "select H.HeaderID,D.ID as 'TourID',case when S.SubCategory IS NULL then D.HeadCategoryID else D.SubCategoryID end as 'ID',ISNULL(S.SubCategory, H.HeadCategory ) as TourName, case when S.SubCategory IS NULL then '0' else '1' end as 'Level' from TourDetails D inner join TourHeadCategory H on D.HeadCategoryID=H.HeadCategoryID left join TourSubCategory S on D.SubCategoryID=S.ID"
        '    Cmd.Connection = SqlCon.SqlCon
        '    SqlCon.SqlCon.Open()
        '    Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
        '    Dim ArrHeaderID(0) As Integer
        '    Dim ArrToursID(0) As String
        '    Dim ArrHeadCategoryID(0) As String
        '    Dim ArrSubCategory(0) As String
        '    Dim ArrHeadOrSub(0) As Boolean

        '    While sdr.Read
        '        ArrHeaderID(ArrHeaderID.Length - 1) = sdr(0).ToString
        '        ArrToursID(ArrToursID.Length - 1) = sdr(1).ToString
        '        ArrHeadCategoryID(ArrHeaderID.Length - 1) = sdr(2).ToString
        '        ArrSubCategory(ArrSubCategory.Length - 1) = sdr(3).ToString
        '        ArrHeadOrSub(ArrHeadOrSub.Length - 1) = sdr(4).ToString


        '        ReDim Preserve ArrHeaderID(ArrHeaderID.Length)
        '        ReDim Preserve ArrToursID(ArrToursID.Length)
        '        ReDim Preserve ArrHeadCategoryID(ArrHeadCategoryID.Length)
        '        ReDim Preserve ArrSubCategory(ArrSubCategory.Length)
        '        ReDim Preserve ArrHeadOrSub(ArrHeadOrSub.Length)
        '    End While

        '    ReDim Preserve ArrHeaderID(ArrHeaderID.Length - 2)
        '    ReDim Preserve ArrToursID(ArrToursID.Length - 2)
        '    ReDim Preserve ArrHeadCategoryID(ArrHeadCategoryID.Length - 2)
        '    ReDim Preserve ArrSubCategory(ArrSubCategory.Length - 2)
        '    ReDim Preserve ArrHeadOrSub(ArrHeadOrSub.Length - 2)

        '    Dim TSC As New CreateToursSubCategory.Generate(ArrHeaderID, ArrToursID, ArrSubCategory, ArrHeadCategoryID, Server.MapPath(Request.ApplicationPath), ArrHeadOrSub)
        '    Me.SubCategory.Controls.Add(TSC)
        'Catch ex As Exception
        '    Dim ERM As New ErrorLog
        '    'ERM.Log()
        'Finally
        '    SqlCon.SqlCon.Close()
        'End Try
    End Sub

    'Private Sub CreateToursHeadcategory()
    '    Dim SqlCon As New SqlConnectionSite

    '    Try
    '        Dim Cmd As New SqlClient.SqlCommand
    '        Cmd.CommandText = "select HeaderID,HeadCategoryID,HeadCategory from TourHeadCategory"
    '        Cmd.Connection = SqlCon.SqlCon
    '        SqlCon.SqlCon.Open()
    '        Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
    '        Dim ArrHeaderID(0) As Integer
    '        Dim ArrHeadCategoryID(0) As String
    '        Dim ArrSubCategory(0) As String

    '        While sdr.Read
    '            ArrHeaderID(ArrHeaderID.Length - 1) = sdr(0)
    '            ArrHeadCategoryID(ArrHeaderID.Length - 1) = sdr(1).ToString
    '            ArrSubCategory(ArrSubCategory.Length - 1) = sdr(2).ToString

    '            ReDim Preserve ArrHeaderID(ArrHeaderID.Length)
    '            ReDim Preserve ArrHeadCategoryID(ArrHeadCategoryID.Length)
    '            ReDim Preserve ArrSubCategory(ArrSubCategory.Length)
    '        End While

    '        ReDim Preserve ArrHeaderID(ArrHeaderID.Length - 2)
    '        ReDim Preserve ArrHeadCategoryID(ArrHeadCategoryID.Length - 2)
    '        ReDim Preserve ArrSubCategory(ArrSubCategory.Length - 2)
    '        Dim TSC As New CreateToursSubCategory.Generate(ArrHeaderID, ArrSubCategory, ArrHeadCategoryID, Server.MapPath(Request.ApplicationPath), True)
    '        Me.SubCategory.Controls.Add(TSC)
    '    Catch ex As Exception
    '        Dim ERM As New ErrorLog
    '        'ERM.Log()
    '    Finally
    '        SqlCon.SqlCon.Close()
    '    End Try
    'End Sub

    'Private Sub CreateToursSubcategory(ByVal HeadCategoryID As String)
    '    Dim SqlCon As New SqlConnectionSite

    '    Try
    '        Dim Cmd As New SqlClient.SqlCommand
    '        Cmd.CommandText = "select H.HeaderID,S.ID,S.SubCategory from TourHeadCategory H inner join TourSubCategory S on H.HeadCategoryID=S.HeadCategoryID where H.HeadCategoryID='" & HeadCategoryID & "'"
    '        Cmd.Connection = SqlCon.SqlCon
    '        SqlCon.SqlCon.Open()
    '        Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
    '        Dim ArrHeaderID(0) As Integer
    '        Dim ArrSubCategoryID(0) As String
    '        Dim ArrSubCategory(0) As String
    '        While sdr.Read
    '            ArrHeaderID(ArrHeaderID.Length - 1) = sdr(0)
    '            ArrSubCategoryID(ArrHeaderID.Length - 1) = sdr(1).ToString
    '            ArrSubCategory(ArrSubCategory.Length - 1) = sdr(2).ToString
    '            ReDim Preserve ArrHeaderID(ArrHeaderID.Length)
    '            ReDim Preserve ArrSubCategoryID(ArrSubCategoryID.Length)
    '            ReDim Preserve ArrSubCategory(ArrSubCategory.Length)
    '        End While
    '        ReDim Preserve ArrHeaderID(ArrHeaderID.Length - 2)
    '        ReDim Preserve ArrSubCategoryID(ArrSubCategoryID.Length - 2)
    '        ReDim Preserve ArrSubCategory(ArrSubCategory.Length - 2)
    '        Dim TSC As New CreateToursSubCategory.Generate(ArrHeaderID, ArrSubCategory, ArrSubCategoryID, Server.MapPath(Request.ApplicationPath), False)
    '        Me.SubCategory.Controls.Add(TSC)
    '    Catch ex As Exception
    '        Dim ERM As New ErrorLog
    '        'ERM.Log()
    '    Finally
    '        SqlCon.SqlCon.Close()
    '    End Try
    'End Sub


End Class
