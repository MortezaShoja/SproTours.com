Imports Microsoft.VisualBasic
Imports System.Data

Public Class AccountStatus

    Public Function GetStatus(ByVal MemberID As String, Optional ByVal ExceptFactor As String = "") As String
        Dim SumPardakhti As Decimal = 0
        Dim SumFactors As Decimal = 0
        Dim SumOtherExpensess As Decimal = 0

        '----------------------Payments------------------------------------
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.CommandText = "select SUM(amount) from Payments where MemberID='" & MemberID & "' AND Accepted='1'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If IsNumeric(sdr(0).ToString) Then
                    SumPardakhti = sdr(0)
                End If
            End If
        Catch ex As Exception


            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "select SUM(amount)")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        '---------------Factors----------------------------------
        If ExceptFactor <> String.Empty Then
            ExceptFactor = " And Not ID='" & ExceptFactor & "'"
        End If
        Try
            'Cmd.CommandText = "select SUM(TotalFactorAmount),Sum(Discount) from Factors where MemberID='" & MemberID & "'" & ExceptFactor
            Cmd.CommandText = "select SUM(TotalFactorAmount) from Factors where MemberID='" & MemberID & "'" & ExceptFactor
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If IsNumeric(sdr(0).ToString) Then
                    SumFactors = sdr(0)
                End If
            End If
        Catch ex As Exception


            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "select SUM(TotalFactorAmount)")
        Finally
            SqlCon.SqlCon.Close()
        End Try
        '---------------OtherExpensess----------------------------------
        Try
            Cmd.CommandText = "select SUM(Amount) from OtherExpenses where MemberID='" & MemberID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If IsNumeric(sdr(0).ToString) Then
                    SumOtherExpensess = sdr(0)
                End If
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "select SUM(TotalFactorAmount)")
        Finally
            SqlCon.SqlCon.Close()
        End Try
        '-------------------------------------------------
        Return (SumPardakhti - (SumFactors + SumOtherExpensess))
    End Function

    Public Function GetTotalStatus(ByVal MemberID As String) As String
        Dim SumPardakhti As Decimal = 0
        Dim SumFactors As Decimal = 0
        Dim SumCurrentRequests As Decimal = 0
        Dim SumOtherExpensess As Decimal = 0

        '----------------------Payments------------------------------------
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.CommandText = "select SUM(amount) from Payments where MemberID='" & MemberID & "' AND (Accepted='1' or Accepted is null)"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If IsNumeric(sdr(0).ToString) Then
                    SumPardakhti = sdr(0)
                End If
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "select SUM(amount)")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        '---------------Factors----------------------------------
        Try
            'Cmd.CommandText = "select SUM(TotalFactorAmount),Sum(Discount) from Factors where MemberID='" & MemberID & "'" & ExceptFactor
            Cmd.CommandText = "select SUM(TotalFactorAmount) from Factors where MemberID='" & MemberID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If IsNumeric(sdr(0).ToString) Then
                    SumFactors = sdr(0)
                End If
            End If
        Catch ex As Exception


            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "select SUM(TotalFactorAmount)")
        Finally
            SqlCon.SqlCon.Close()
        End Try
        '---------------OtherExpensess----------------------------------
        Try
            Cmd.CommandText = "select SUM(Amount) from OtherExpenses where MemberID='" & MemberID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If IsNumeric(sdr(0).ToString) Then
                    SumOtherExpensess = sdr(0)
                End If
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "select SUM(TotalFactorAmount)")
        Finally
            SqlCon.SqlCon.Close()
        End Try
        '---------------Sefareshate Jari----------------------------------
        Try
            If MemberID = "E1D69CE5-315A-4ED7-980D-D925EE304F18" Then
                MemberID = MemberID
            End If

            Cmd.CommandText = "Select sum(TotalTomanPrice) from Requests Where MemberID='" & MemberID & "' and Status !=N'به ایران ارسال شد'  and Status !=N'عدم موجودی' and Status !=N'نقص اطلاعات' and Status !=N'به ایران ارسال شد' and Status !=N'بازگشت به استانبول' and Status !=N'عودت به فروشنده' and Status !=N'انبار ایران' and Status !=N'فروش مجدد در ایران' and Status !=N'کنسل'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If IsNumeric(sdr(0).ToString) Then
                    SumCurrentRequests = sdr(0)
                    If SumCurrentRequests = 4524000 Then
                        SumCurrentRequests = SumCurrentRequests
                    End If
                    SumCurrentRequests = SumCurrentRequests / 2
                End If
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "select SUM(TotalFactorAmount)")
        Finally
            SqlCon.SqlCon.Close()
        End Try
        '-------------------------------------------------
        Return (SumPardakhti - (SumFactors + SumOtherExpensess + SumCurrentRequests))
    End Function

    Public Function GetTotalBuyingPriceNewProducts(ByVal MemberID As String, ByVal MemberType As String) As Decimal
        Dim Value As Decimal = 0
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)

        Try
            Cmd.CommandText = "Select TotalSitePriceTomanWithOurRates,TotalTomanPrice from Requests Where MemberID=@ID and Status !=N'به ایران ارسال شد'  and Status !=N'عدم موجودی' and Status !=N'نقص اطلاعات' and Status !=N'به ایران ارسال شد' and Status !=N'بازگشت به استانبول' and Status !=N'انبار ایران' and Status !=N'فروش مجدد در ایران' and Status !=N'کنسل' and Status !=N'عودت به فروشنده' order by RequestCode desc"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                If MemberType <> "کاربر عادی" Then
                    Value += sdr(0)
                Else
                    Value += sdr(1)
                End If
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "GetTotalBuyingPriceNewProducts")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    Public Function GetTotalPriceNewProducts(ByVal MemberID As String, ByVal MemberType As String) As Decimal
        Dim Value As Decimal = 0
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)

        Try
            Cmd.CommandText = "Select TotalTomanPrice from Requests Where MemberID=@ID and Status !=N'به ایران ارسال شد'  and Status !=N'عدم موجودی' and Status !=N'نقص اطلاعات' and Status !=N'به ایران ارسال شد' and Status !=N'بازگشت به استانبول' and Status !=N'انبار ایران' and Status !=N'فروش مجدد در ایران' and Status !=N'کنسل' and Status !=N'عودت به فروشنده' and Status !=N'در انتظار تایید' and Status !=N'در انتظار موجودی' order by RequestCode desc"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Value += sdr(0)
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "GetTotalBuyingPriceNewProducts")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    Public Function GetTotalPurchased(ByVal MemberID As String) As Decimal
        Dim Value As Decimal = 0
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)

        Try
            Cmd.CommandText = "select count(*) from Requests where MemberID=@MemberID and Status=N'خریداری شد'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Value += sdr(0)
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "GetTotalPurchased")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    Public Function GetCurrencyRate(ByVal CurrencyAbbreviation As String) As Decimal
        Dim Value As Decimal = 0
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        Cmd.Parameters.Add("@CurrencyAbbreviation", SqlDbType.NVarChar).Value = CurrencyAbbreviation

        Try
            Cmd.CommandText = "Select IstanbulRate From Exchange where CurrencyAbbreviation=@CurrencyAbbreviation"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Value += sdr(0)
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, "AccountStatus", "GetCurrencyRate")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

End Class
