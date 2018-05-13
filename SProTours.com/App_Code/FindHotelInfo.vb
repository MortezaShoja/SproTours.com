Imports Microsoft.VisualBasic
Imports System.Data

Public Class FindHotelInfo

    Public Function GetHotelName(ByVal HotelID As String) As String
        Dim value As String = String.Empty
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.CommandText = "Select HotelName from Hotels Where ID='" & HotelID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try
        Return value
    End Function

    Public Function GetHotelAddress(ByVal HotelID As String) As String
        Dim value As String = String.Empty
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.CommandText = "Select Country,Region,City,District from Hotels Where ID='" & HotelID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0).ToString & "," & sdr(1).ToString & "," & sdr(2).ToString & "," & sdr(3).ToString
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
