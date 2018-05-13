Imports Microsoft.VisualBasic
Imports System.Data

Public Class VisitLog
    Private SqlCon As SqlConnectionSite


    Public Sub SetLog(ByVal MemberID As String)

        SqlCon = New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.Parameters.Add("@VisitDate", SqlDbType.DateTime).Value = Now.ToString
            Cmd.CommandText = "Insert Into VisitLog (VisitDate,MemberID) Values (@VisitDate,@MemberID)"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

    End Sub

    Public Sub SetOnlineMembers(ByVal Count As Integer)

        SqlCon = New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@OnlineMembers", SqlDbType.Int).Value = Count
            Cmd.CommandText = "Update SiteSettings Set OnlineMembers=@OnlineMembers"

            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

    End Sub

    Public Sub OnlineMembers(ByVal Effect As String)

        SqlCon = New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Select Case Effect
                Case Is = "+"
                    Cmd.CommandText = "Update SiteSettings Set OnlineMembers=OnlineMembers + 1"
                Case Is = "-"
                    Cmd.CommandText = "Update SiteSettings Set OnlineMembers=OnlineMembers - 1"
                Case Is = "0"
                    Cmd.CommandText = "Update SiteSettings Set OnlineMembers='0'"
            End Select
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

    End Sub

End Class
