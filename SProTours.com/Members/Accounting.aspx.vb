Imports System.Data
Imports System.Globalization

Partial Class Members_Accounting
    Inherits System.Web.UI.Page
    Private MC As MoneyCodec
    Private GAS As AccountStatus

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If HttpContext.Current.Request.Cookies.Get("UserSettings") Is Nothing Then
            Response.Redirect("../Default.aspx")
        Else
            FillgvAccounting()
        End If

    End Sub

    Private Sub FillgvAccounting()
        'select (ISNULL(CONVERT(varchar(50),F.TotalFactorAmount),'0')) as 'Bedehkar',(ISNULL(CONVERT(varchar(50),P.Amount),'')) as 'Bestankar',(ISNULL(CONVERT(varchar(50),F.CreateDate),'') + ISNULL(CONVERT(varchar(50),P.RegDate),'')) as PaymentDate ,(ISNULL(CONVERT(varchar(50),F.Code),'') + ISNULL(CONVERT(varchar(50),P.TrackingNo),'')) as 'TrackingNo',(ISNULL(CONVERT(varchar(50),F.RequestCodes),'') + ISNULL(CONVERT(varchar(50),P.RequestCode),'') + '  ' + ISNULL(CONVERT(varchar(50),P.PayDate),'') + '  ' + ISNULL(CONVERT(varchar(50),P.PayTime),'') + '  ' + ISNULL(CONVERT(varchar(50),P.AccountNo),'')) as 'RequestCode' From Factors F full outer join Payments P on P.MemberID=F.MemberID order by PaymentDate

        MC = New MoneyCodec

        Dim Reports(0) As String
        Dim SumBedehkar As Decimal = 0
        Dim SumBestankar As Decimal = 0

        Dim DC As DateConvertor
        '----------------------------Factors---------------------------------------------------------
        Try
            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Try
                Cmd.CommandText = "select TotalFactorAmount,CreateDate,Code,RequestCodes From Factors Where MemberID='" & Request.Cookies("UserSettings")("ID").ToString & "'"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                While sdr.Read
                    DC = New DateConvertor
                    DC.Convertor(CType(sdr(1), Date).ToString(New CultureInfo("en-US")))
                    SumBedehkar += sdr(0)
                    Reports(Reports.Length - 1) = "0#" & sdr(0).ToString & "#" & DC.Hyear & "/" & DC.Hmonth & "/" & DC.Hday & "#" & " فاکتور شماره " & sdr(2).ToString
                    ReDim Preserve Reports(Reports.Length)
                End While
            Catch ex As Exception
                Dim ERM As New ErrorLog
                ERM.Log(Request, "Error", Request.Cookies("UserSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "GetFactorsInfo")
            Finally
                SqlCon.SqlCon.Close()
            End Try
            '-------------------------OtherExpensess--------------------------------------------------
            Try
                Cmd.CommandText = "select Amount,RegDate,RequestCode,Babate From OtherExpenses Where MemberID='" & Request.Cookies("UserSettings")("ID").ToString & "'"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                While sdr.Read
                    DC = New DateConvertor
                    DC.Convertor(CType(sdr(1), Date).ToString(New CultureInfo("en-US")))
                    SumBedehkar += sdr(0)
                    If sdr(3).ToString = "کنسلی" Then
                        Reports(Reports.Length - 1) = "0#" & sdr(0).ToString & "#" & DC.Hyear & "/" & DC.Hmonth & "/" & DC.Hday & "#" & " کنسلی کد سفارش " & sdr(2).ToString
                    Else
                        Reports(Reports.Length - 1) = "0#" & sdr(0).ToString & "#" & DC.Hyear & "/" & DC.Hmonth & "/" & DC.Hday & "#" & sdr(3).ToString
                    End If

                    ReDim Preserve Reports(Reports.Length)
                End While
                ReDim Preserve Reports(Reports.Length - 1)
            Catch ex As Exception
                Dim ERM As New ErrorLog
                ERM.Log(Request, "Error", Request.Cookies("UserSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "GetFactorsInfo")
            Finally
                SqlCon.SqlCon.Close()
            End Try
            '------------------------Payments----------------------------------------------------
            Try
                Cmd.CommandText = "select Amount,RegDate,RequestCode,AccountOwner,AccountNo,PayDate,PayTime,TrackingNo From Payments Where Accepted='1' AND MemberID='" & Request.Cookies("UserSettings")("ID").ToString & "'"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                While sdr.Read
                    DC = New DateConvertor
                    DC.Convertor(CType(sdr(1), Date).ToString(New CultureInfo("en-US")))

                    If sdr(0) > 0 Then
                        SumBestankar += sdr(0)
                        Reports(Reports.Length - 1) = sdr(0).ToString & "#0#" & DC.Hyear & "/" & DC.Hmonth & "/" & DC.Hday & "#" & " پرداختی به تاریخ " & sdr(5).ToString & " زمان " & sdr(6).ToString & " شماره پیگیری تراکنش " & sdr(7).ToString
                        ReDim Preserve Reports(Reports.Length)
                    Else
                        SumBedehkar += sdr(0) * -1
                        Reports(Reports.Length - 1) = "0#" & (sdr(0) * -1).ToString & "#" & DC.Hyear & "/" & DC.Hmonth & "/" & DC.Hday & "#" & " عودت وجه به تاریخ " & sdr(5).ToString & " زمان " & sdr(6).ToString & " شماره پیگیری تراکنش " & sdr(7).ToString
                        ReDim Preserve Reports(Reports.Length)
                    End If

                End While
                ReDim Preserve Reports(Reports.Length - 2)
            Catch ex As Exception
                Dim ERM As New ErrorLog
                ERM.Log(Request, "Error", Request.Cookies("UserSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "GetFactorsInfo")
            Finally
                SqlCon.SqlCon.Close()
            End Try

            '----------------------------------------------------------------------------
            Dim Dvw As New Data.DataView
            Dim Tbl As New Data.DataTable
            Tbl.Clear()

            Tbl.Columns.Add("شرح")
            Tbl.Columns.Add("تاریخ")
            Tbl.Columns.Add("بدهکار")
            Tbl.Columns.Add("بستانکار")

            For I As Integer = 0 To Reports.Length - 1
                Dim tmp() As String = Reports(I).Split("#")
                Dim row As DataRow = Tbl.NewRow
                row(0) = tmp(3)
                row(1) = tmp(2)
                row(2) = MC.Code(tmp(1))
                row(3) = MC.Code(tmp(0))
                Tbl.Rows.Add(row)
            Next

            '' Sample Code (Sorting DataTable)
            ''Dim filterExp As String = "Patient<> ''"
            ''Dim sortExp As String = "Date "
            ''dt_item.Select(filterExp, sortExp, DataViewRowState.CurrentRows)

            Tbl = Tbl.Select("", "تاریخ").CopyToDataTable()


            Dim TblSorted As New Data.DataTable
            TblSorted.Clear()

            TblSorted.Columns.Add("ردیف", GetType(Integer))
            TblSorted.Columns.Add("شرح")
            TblSorted.Columns.Add("تاریخ")
            TblSorted.Columns.Add("بدهکار")
            TblSorted.Columns.Add("بستانکار")
            TblSorted.Columns.Add("مانده")

            Dim rows() As DataRow = Tbl.Select()
            Dim Mande As Decimal = 0
            For I As Integer = 0 To Tbl.Rows.Count - 1
                Try
                    Dim rowSorted As DataRow = TblSorted.NewRow
                    rowSorted(0) = Tbl.Rows.Count - I
                    rowSorted(1) = rows(I).Item("شرح")
                    rowSorted(2) = rows(I).Item("تاریخ")
                    rowSorted(3) = rows(I).Item("بدهکار")
                    rowSorted(4) = rows(I).Item("بستانکار")
                    Dim Bestankar As Integer = MC.DeCode(rows(I).Item("بستانکار"))
                    Dim Bedehkar As Integer = MC.DeCode(rows(I).Item("بدهکار"))
                    Mande = Bestankar - Bedehkar + Mande
                    rowSorted(5) = MC.Code(Mande)
                    TblSorted.Rows.Add(rowSorted)
                Catch ex As Exception

                End Try
            Next

            TblSorted = TblSorted.Select("", "ردیف").CopyToDataTable()

            Dvw = New Data.DataView(TblSorted)

            'Dvw.Sort = "تاریخ DESC"

            Me.gvAccounting.DataSource = Dvw
            Me.gvAccounting.DataBind()
            If SumBestankar - SumBedehkar < 0 Then
                Me.lblJameKol.ForeColor = Drawing.Color.Red
            Else
                Me.lblJameKol.ForeColor = Drawing.Color.Green
            End If
            Me.lblBedehkar.Text = MC.Code(SumBedehkar)
            Me.lblBestankar.Text = MC.Code(SumBestankar)
            Me.lblJameKol.Text = MC.Code(SumBestankar - SumBedehkar)

            Dim Mi As New MemberInfo
            Dim MemberType As String = Mi.GetMemberType(Request.Cookies("UserSettings")("ID").ToString)

            GAS = New AccountStatus
            Dim tmpJameKoleJari As Decimal = GAS.GetTotalPriceNewProducts(Request.Cookies("UserSettings")("ID").ToString, MemberType)
            'If MemberType <> "کاربر عادی" Then
            '    Me.lblJameKoleJari.Text = MC.Code(tmpJameKoleJari, False)
            '    Me.lbltotalJariTitle.Text = "جمع سفارشات جاری (تومان) : "
            'Else
            '    'Me.lblJameKoleJari.Text = MC.Code(tmpJameKoleJari / 2, False)
            '    'Me.lbltotalJariTitle.Text = "50% جمع سفارشات جاری (تومان) : "
            '    Me.lblJameKoleJari.Text = MC.Code(tmpJameKoleJari, False)
            '    Me.lbltotalJariTitle.Text = "جمع سفارشات جاری (تومان) : "
            'End If

            'Me.lblJameKoleJari.Text = MC.Code(tmpJameKoleJari / 2, False)
            'Me.lbltotalJariTitle.Text = "50% جمع سفارشات جاری (تومان) : "

            Me.lblJameKoleJari.Text = MC.Code(tmpJameKoleJari, False)
            Me.lbltotalJariTitle.Text = "جمع سفارشات جاری (تومان) : "

            Dim tmpGhabelepardakht As Decimal = MC.DeCode(Me.lblJameKoleJari.Text) - MC.DeCode(Me.lblJameKol.Text)
            If tmpGhabelepardakht < 0 Then tmpGhabelepardakht = 0
            Me.lblGhabelePardakht.Text = MC.Code(tmpGhabelepardakht, False)

        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", Request.Cookies("UserSettings")("ID").ToString, ex.StackTrace, ex.Message, "", Request.Url.Segments.Last(), "FillgvAccounting")
        Finally

        End Try

    End Sub

End Class
