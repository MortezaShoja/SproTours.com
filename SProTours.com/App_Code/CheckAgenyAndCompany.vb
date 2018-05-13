Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Net
Imports System.IO

Public Class CheckAgenyAndCompany
    Public Function CheckEmail(ByVal Email As String, ByVal MemberID As String) As Boolean
        Dim value As Boolean = False

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try

            Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email
            If MemberID <> String.Empty Then
                Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
                Cmd.CommandText = "Select Code from Members where Email=@Email and ID != @ID And Active='1' Union Select U.Row from Users U inner Join Members M on U.MemberID=M.ID where U.Email=@Email and U.MemberID!=@ID and M.Active='1'"
            Else
                Cmd.CommandText = "Select Code from Members where Email=@Email union Select Row from Users where Email=@Email"
                'Cmd.CommandText = "Select Code from Members where Email=@Email and Active='1' Union Select U.Row from Users U inner Join Members M on U.MemberID=M.ID where U.Email=@Email and M.Active='1'"
            End If
            
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = False
            Else
                value = True
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
            value = False
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function


    Public Function CheckCompanyAndMemberName(ByVal MemberName As String) As Boolean
        Dim value As Boolean = False
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try

            Cmd.Parameters.Add("@CoMemberName", SqlDbType.NVarChar).Value = MemberName

            Cmd.CommandText = "Select ID from Members where CoMemberName=@CoMemberName"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = True
            Else
                value = False
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
            value = False
        Finally
            SqlCon.SqlCon.Close()
        End Try
        Return value
    End Function
End Class
