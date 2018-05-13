
Partial Class QRValidator
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RequestID As String = String.Empty

        Try
            RequestID = Request.QueryString("ID")
            Response.Redirect("Tours_details.aspx?cid=" & ID)
        Catch ex As Exception

        End Try
    End Sub
End Class
