Imports Microsoft.VisualBasic
Imports System.Data

Public Class GetHotelsInfo

    Private SqlConHotels As SqlConnectionHotels
    Private SqlConRequests As SqlConnectionSite
    Private Cmd As SqlClient.SqlCommand


    Public Function GetHotelID(ByVal HotelCode As Integer) As String
        Dim value As String = String.Empty

        Try
            Cmd = New SqlClient.SqlCommand
            SqlConHotels = New SqlConnectionHotels

            Cmd.CommandText = "Select ID from Hotels where HotelCode='" & HotelCode & "'"
            Cmd.Connection = SqlConHotels.SqlCon
            SqlConHotels.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                value = sdr(0).ToString
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlConHotels.SqlCon.Close()
        End Try

        Return value
    End Function

    Public Function GetHotelID(ByVal RoomID As String, ByVal MemberID As String) As String
        Dim value As String = String.Empty

        Try
            Cmd = New SqlClient.SqlCommand
            SqlConRequests = New SqlConnectionSite

            Cmd.CommandText = "Select top 1 R.HotelID from hotel.dbo.Rooms R inner join HotelRequestsRoomTypes H on H.RoomID=R.ID Where H.RequestID='" & RoomID & "' And H.MemberID='" & MemberID & "'"
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

    Public Function GetRequestCode(ByVal RequestID As String) As Integer
        Dim value As String = String.Empty

        Try
            Cmd = New SqlClient.SqlCommand
            SqlConRequests = New SqlConnectionSite

            Cmd.CommandText = "Select RequestCode from HotelRequests where ID='" & RequestID & "'"
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
