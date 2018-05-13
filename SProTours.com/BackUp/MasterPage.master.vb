
Partial Class OKAB_MasterPage
    Inherits System.Web.UI.MasterPage

    Dim SE As SendEmail

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        SE = New SendEmail
        SE.Sender("noreply@SproTours.com", "Contact Me Message", "NoReplyMaster2016", "g.guler@SproTours.com", "Name : " & Me.txtName.Text & "<br/>" & "Email : " & Me.txtEmail.Text & "<br/>" & "Phone : " & Me.txtTelephone.Text, Me.txtEmail.Text, "")
        SE.Sender("noreply@SproTours.com", "Contact Me Message", "NoReplyMaster2016", "info@SproTours.com", "Name : " & Me.txtName.Text & "<br/>" & "Email : " & Me.txtEmail.Text & "<br/>" & "Phone : " & Me.txtTelephone.Text, Me.txtEmail.Text, "")

        Me.txtEmail.Text = String.Empty
        Me.txtName.Text = String.Empty
        Me.txtTelephone.Text = String.Empty
    End Sub

End Class

