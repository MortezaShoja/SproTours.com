Imports Microsoft.VisualBasic
Imports System.Data

Public Class GetMemberInfo

    Private SqlCon As SqlConnectionSite
    Private Cmd As SqlClient.SqlCommand


    Public Function GetMemberInfo(ByVal MemberID As String) As Array
        Dim value(6) As String

        Try
            Cmd = New SqlClient.SqlCommand
            SqlCon = New SqlConnectionSite

            Cmd.CommandText = "Select CoAgencyName,MemberType,Email,Name,LastName,Phone,Mobile from Members where ID='" & MemberID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                value(0) = sdr(0).ToString
                value(1) = sdr(1).ToString
                value(2) = sdr(2).ToString
                value(3) = sdr(3).ToString
                value(4) = sdr(4).ToString
                value(5) = sdr(5).ToString
                value(6) = sdr(6).ToString
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function


End Class
