
Partial Class Members_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If HttpContext.Current.Request.Cookies.Get("UserSettings") Is Nothing Then
        '    Response.Redirect("../Default.aspx")
        'Else
        '    Response.Redirect("NewOrders.aspx")
        'End If

    End Sub

End Class
