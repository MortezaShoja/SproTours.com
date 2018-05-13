Imports Microsoft.VisualBasic
Imports System.Data

Public Class GetTourInfo

    Private SqlConHotels As SqlConnectionHotels
    Private SqlConRequests As SqlConnectionSite
    Private Cmd As SqlClient.SqlCommand


    Public Function GetRequestCode(ByVal RequestID As String) As Integer
        Dim value As Integer = 0

        Try
            Cmd = New SqlClient.SqlCommand
            SqlConRequests = New SqlConnectionSite

            Cmd.CommandText = "Select RequestCode from TourRequests where ID='" & RequestID & "'"
            Cmd.Connection = SqlConRequests.SqlCon
            SqlConRequests.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                value = sdr(0).ToString
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlConRequests.SqlCon.Close()
        End Try

        Return value
    End Function


    Public Function GetDescount(ByVal TourQTY As Integer) As Decimal
        Dim value As Decimal = 0

        Dim Rate As Decimal = GetCurrencyRate("$")

        If TourQTY > 1 Then
            TourQTY -= 1
            If TourQTY = 1 Then
                value = 10
            ElseIf TourQTY > 1 Then
                value = TourQTY * 15
            End If
        End If

        Return value * Rate
    End Function

    Private Function GetCurrencyRate(ByVal CurrencySign As String) As Decimal
        Dim value As String = 0

        Dim SqlCon As New SqlConnectionTurkorder

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@CurrencySign", SqlDbType.NVarChar).Value = CurrencySign
            Cmd.CommandText = "Select IstanbulRate From Exchange Where CurrencySign=@CurrencySign"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function

End Class
