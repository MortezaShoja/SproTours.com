
Imports Microsoft.VisualBasic
Imports System.Data

Public Class GetFlightInfo

    Private SqlConHotels As SqlConnectionHotels
    Private SqlConRequests As SqlConnectionSite
    Private Cmd As SqlClient.SqlCommand


    Public Function GetRequestCode(ByVal RequestID As String) As Integer
        Dim value As Integer = 0

        Try
            Cmd = New SqlClient.SqlCommand
            SqlConRequests = New SqlConnectionSite

            Cmd.CommandText = "Select RequestCode from FlightRequests where ID='" & RequestID & "'"
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

End Class
