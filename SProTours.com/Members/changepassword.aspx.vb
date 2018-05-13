Imports System.Data

Partial Class changepassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If HttpContext.Current.Request.Cookies.Get("UserSettings") Is Nothing Then
            Response.Redirect("../Default.aspx")
        Else

        End If

    End Sub

    Protected Sub btnChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try

            Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = Request.Cookies("UserSettings")("ID").ToString

            Cmd.CommandText = "Select Password from Members where ID=@ID"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If sdr(0).ToString = Me.txtCurrentPassword.Text Then
                    If Me.txtNewPassword.Text = Me.txtNewPaswordAgain.Text Then
                        sdr.Close()
                        Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Me.txtNewPassword.Text
                        Cmd.CommandText = "Update Members set password=@Password where ID='" & Request.Cookies("UserSettings")("ID").ToString & "'"
                        Cmd.ExecuteNonQuery()
                        Me.lblMessages.Text = "رمز عبور شما با موفقیت تغییر یافت"
                        Me.lblMessages.ForeColor = Drawing.Color.Orange
                    Else
                        Me.lblMessages.ForeColor = Drawing.Color.Red
                        Me.lblMessages.Text = "رمز عبور جدید صحیح نمی باشد. " & "<br />" & "لطفاً هر دو رمز جدید را به صورت یکسان وارد نمایید"
                    End If
                Else
                    Me.lblMessages.ForeColor = Drawing.Color.Red
                    Me.lblMessages.Text = "رمز عبور فعلی شما صحیح نمی باشد!"
                End If
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "btnChangePassword_Click")
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub


End Class
