<%@ Application Language="VB" %>

<script runat="server">
    Private VL As VisitLog
    Private MemberID As String = "00000000-0000-0000-0000-000000000000"
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Application("ViewLog") = 0
        'VL = New VisitLog
        'VL.OnlineMembers("0")
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Application("ViewLog") += 1
        
        Try
            MemberID = Request.Cookies("UserSettings")("ID").ToString.ToString
        Catch ex As Exception
        End Try
        VL = New VisitLog
        VL.SetLog(MemberID)
        VL.SetOnlineMembers(Integer.Parse(Application("ViewLog")))
        'VL.OnlineMembers("+")
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        Application("ViewLog") -= 1
        If Integer.Parse(Application("ViewLog")) < 0 Then
            Application("ViewLog") = 0
        End If
        'VL = New VisitLog
        'VL.OnlineMembers("-")
    End Sub
       
</script>