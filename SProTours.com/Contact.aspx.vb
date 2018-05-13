
Partial Class Contact
    Inherits System.Web.UI.Page

    Dim SE As SendEmail

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        SE = New SendEmail
        SE.Sender("noreply@SproTours.com", "ContactUs Message", "EmailMaster2017", "Hotel@SproTours.com", "Name : " & Me.txtName.Text & "<br/>" & "Email : " & "<a  href=""mailto:" & Me.txtEmail.Text & """>" & Me.txtEmail.Text & "</a>" & "<br/>" & "Phone : " & Me.txtTelephone.Text & "<br/>" & "<hr/>" & Me.txtMessage.Text.Replace(Chr(13), "<br/>"), Me.txtEmail.Text, "")

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "$(window).load(function(){ MessageBox('ارسال پیام','پیام شما دریافت شد' + ' <br /> ' + 'با تشکر'); }) ;", True)

        Me.txtEmail.Text = String.Empty
        Me.txtMessage.Text = String.Empty
        Me.txtName.Text = String.Empty
        Me.txtTelephone.Text = String.Empty
    End Sub
End Class
