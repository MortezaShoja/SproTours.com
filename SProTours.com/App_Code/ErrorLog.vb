Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Globalization

Public Class ErrorLog

    Public Sub ProductViewLog(ByVal MemberID As String, ByVal ProductID As String)
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        If MemberID = String.Empty Then
            MemberID = "00000000-0000-0000-0000-000000000000"
        End If

        Try
            Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.Parameters.Add("@ProductID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(ProductID)
            Cmd.Parameters.Add("@ViewDateTime", SqlDbType.DateTime).Value = Now.ToString

            Cmd.CommandText = "Insert Into ProductViewLog (MemberID,ProductID,ViewDateTime) Values (@MemberID,@ProductID,@ViewDateTime)"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            'Dim ERM As New ErrorLog
            'ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "ProductViewLog")
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub

    Public Sub Log(ByVal SWHRequest As System.Web.HttpRequest, ByVal EventType As String, ByVal UserID As String, ByVal ErrorLine As String, ByVal EventMessage As String, ByVal CommandText As String, ByVal EventPage As String, ByVal EventPlace As String)
        If UserID = String.Empty Then
            UserID = "00000000-0000-0000-0000-000000000000"
        End If

        'Dim computer_name() As String
        'computer_name = Split(System.Net.Dns.Resolve(SWHRequest.ServerVariables("remote_addr")).HostName, ".")

        'Dim HostName As String = computer_name(0).ToUpper
        Dim HostName As String = String.Empty
        Try
            HostName = System.Net.Dns.GetHostEntry(SWHRequest.ServerVariables("remote_addr")).HostName
        Catch ex As Exception

        End Try
        Dim IPAddress As String = String.Empty

        Try
            IPAddress = SWHRequest.UserHostAddress
        Catch ex As Exception

        End Try

        'Dim HostName As String = System.Net.Dns.GetHostName()
        'Dim IPAddress As String = System.Net.Dns.GetHostByName(HostName).AddressList(0).ToString()
        Dim SqlCon As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@EventDate", SqlDbType.DateTime).Value = Now.ToString
            Cmd.Parameters.Add("@EventType", SqlDbType.NVarChar).Value = EventType
            Cmd.Parameters.Add("@ErrorLine", SqlDbType.NVarChar).Value = ErrorLine
            Cmd.Parameters.Add("@EventMessage", SqlDbType.NVarChar).Value = EventMessage
            Cmd.Parameters.Add("@CommandText", SqlDbType.NVarChar).Value = CommandText
            Cmd.Parameters.Add("@EventPage", SqlDbType.NVarChar).Value = EventPage
            Cmd.Parameters.Add("@EventPlace", SqlDbType.NVarChar).Value = EventPlace
            Cmd.Parameters.Add("@IpAddress", SqlDbType.NVarChar).Value = IPAddress
            Cmd.Parameters.Add("@HostName", SqlDbType.NVarChar).Value = HostName
            Cmd.CommandText = "Insert Into EventLog (UserID,EventDate,EventType,ErrorLine,EventMessage,CommandText,EventPage,EventPlace,IpAddress,HostName) values ('" & UserID & "',@EventDate,@EventType,@ErrorLine,@EventMessage,@CommandText,@EventPage,@EventPlace,@IpAddress,@HostName)"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub

    Public Sub LogFromSub(ByVal EventType As String, ByVal UserID As String, ByVal ErrorLine As String, ByVal EventMessage As String, ByVal CommandText As String, ByVal EventPage As String, ByVal EventPlace As String)
        If UserID = String.Empty Then
            UserID = "00000000-0000-0000-0000-000000000000"
        End If

        'Dim HostName As String = System.Net.Dns.GetHostName()
        'Dim IPAddress As String = System.Net.Dns.GetHostByName(HostName).AddressList(0).ToString()
        Dim SqlCon As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@EventDate", SqlDbType.DateTime).Value = Now.ToString
            Cmd.Parameters.Add("@EventType", SqlDbType.NVarChar).Value = EventType
            Cmd.Parameters.Add("@ErrorLine", SqlDbType.NVarChar).Value = ErrorLine
            Cmd.Parameters.Add("@EventMessage", SqlDbType.NVarChar).Value = EventMessage
            Cmd.Parameters.Add("@CommandText", SqlDbType.NVarChar).Value = CommandText
            Cmd.Parameters.Add("@EventPage", SqlDbType.NVarChar).Value = EventPage
            Cmd.Parameters.Add("@EventPlace", SqlDbType.NVarChar).Value = EventPlace
            Cmd.Parameters.Add("@IpAddress", SqlDbType.NVarChar).Value = "--"
            Cmd.Parameters.Add("@HostName", SqlDbType.NVarChar).Value = "--"
            Cmd.CommandText = "Insert Into EventLog (UserID,EventDate,EventType,ErrorLine,EventMessage,CommandText,EventPage,EventPlace,IpAddress,HostName) values ('" & UserID & "',@EventDate,@EventType,@ErrorLine,@EventMessage,@CommandText,@EventPage,@EventPlace,@IpAddress,@HostName)"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub
End Class
