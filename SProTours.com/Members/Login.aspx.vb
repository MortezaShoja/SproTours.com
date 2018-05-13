Imports System.Data

Partial Class _Login
    Inherits System.Web.UI.Page
    Private SE As SendEmail
    Private CHE As CreateHTMLEmail

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Response.Redirect("~/Members/NewOrders.aspx")

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Me.txtLoginUserName.Text = "" Then
            Me.lblLoginMessages.Text = "Please fill all parts."
        End If
        Dim v As New Validation
        If v.Email(Me.txtLoginUserName.Text) Then
            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Try

                Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtLoginUserName.Text
                Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Me.txtLoginPassword.Text
                'Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = FileSecurity.Code(Me.txtLoginPassword.Text, 10)

                Cmd.CommandText = "Select ID,FullName,Password,Suspend from Members where Email=@Email And Password=@Password And Active='1'"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                If sdr.Read Then
                    If CType(sdr(3), Boolean) = False Then
                        Response.Cookies("UserSettings")("ID") = sdr(0).ToString
                        Response.Cookies("UserSettings")("Name") = sdr(1).ToString
                        Response.Cookies("UserSettings")("Secret") = sdr(2).ToString.Replace(" ", "_")
                        Response.Cookies("UserSettings").Expires = DateTime.Now.AddYears(1)
                    Else
                        Me.lblLoginMessages.Text = "حساب کاربری شما مسدود می باشد" & "<br />" & "لطفاً جهت کسب اطلاعات بیشتر با واحد پشتیبانی از طریق ایمیل Support@Sprotours.com تماس حاصل فرمایید." + "<br />" + "<br />" + "با تشکر" + "<br />" + "TurkOrder"
                    End If
                Else
                    Me.txtLoginUserName.Text = String.Empty
                    Me.txtLoginPassword.Text = String.Empty
                    Me.lblLoginMessages.Text = "* نام کاربری یا کلمه عبور صحیح نمی باشد."
                End If
            Catch ex As Exception
                Dim ERM As New ErrorLog
                'ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "btnLogin_Click")
            Finally
                SqlCon.SqlCon.Close()
            End Try
        Else
            Me.txtLoginUserName.Text = String.Empty
            Me.lblLoginMessages.Text = "لطفاً ایمیل خود را بصورت صحیح وارد نمایید."
        End If

        If Request.Cookies("UserSettings")("ID").ToString <> String.Empty Then
            Response.Redirect("~/Members/profile.aspx")
        End If
    End Sub

    Protected Sub btnRecoverPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecoverPassword.Click

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtRequestPassword.Text
            Cmd.CommandText = "Select FullName,Password,ID from Members Where Email=@Email"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                SE = New SendEmail
                CHE = New CreateHTMLEmail
                Dim ServerPath As String = Server.MapPath(Request.ApplicationPath)
                Dim R As String = SE.Sender("Noreply@SproTours.com", "SproTours.com", "EmailMaster2017", Me.txtRequestPassword.Text, CHE.CreateRegistration(sdr(0), Me.txtRequestPassword.Text, sdr(1), sdr(2).ToString, ServerPath & "\Email\PasswordRecovery.htm"), "بازیابی کلمه عبور", "")

                Me.txtRequestPassword.Text = String.Empty
                Me.lblRecoverPassword.Text = "مشخصات حساب کاربری به آدرس ایمیل شما ارسال گردید"
                Me.lblRecoverPassword.ForeColor = Drawing.Color.Green
            Else
                Me.lblRecoverPassword.Text = "هیچ حساب کاربری با آدرس ایمیل وارد شده در سیستم جود ندارد"
                Me.lblRecoverPassword.ForeColor = Drawing.Color.Red
            End If

        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "CheckPassword")
        Finally
            SqlCon.SqlCon.Close()
        End Try


    End Sub

End Class
