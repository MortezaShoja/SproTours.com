Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim MemberID As String = Request.QueryString("Validation")
            If MemberID <> String.Empty Then
                ValidateEmail(MemberID)
            End If
        End If

    End Sub

    Private Sub ValidateEmail(ByVal MemberID As String)
        If MemberID <> Nothing Then

            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Dim EmailValidation As Boolean = False
            Try
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()

                Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
                Cmd.CommandText = "Select EmailValidation from Members where ID=@ID"

                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                If sdr.Read Then
                    EmailValidation = sdr(0)
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "$(window).load(function(){ MessageBox('خطا','لینک ارسالی صحیح نمی باشد' + ' <br /> ' + 'لطفاً با واحد پشتیبانی از طریق ایمیل Support@Sprotours.com' + ' <br /> ' + 'تماس حاصل نمایید'); }) ;", True)
                End If

            Catch ex As Exception
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "$(window).load(function(){ MessageBox('خطا','لینک ارسالی صحیح نمی باشد' + ' <br /> ' + 'لطفاً با واحد پشتیبانی از طریق ایمیل Support@Sprotours.com' + ' <br /> ' + 'تماس حاصل نمایید'); }) ;", True)
            Finally
                SqlCon.SqlCon.Close()
            End Try

            Try
                SqlCon.SqlCon.Open()
                If EmailValidation = False Then
                    Cmd.CommandText = "Update Members Set EmailValidation='1' where ID=@ID"
                    Cmd.ExecuteNonQuery()
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "$(window).load(function(){ MessageBox('فعال سازی حساب کاربری','حساب کاربری شما با موفقیت فعال شد' + ' <br /> ' + 'به SproTours خوش آمدید'); }) ;", True)
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "$(window).load(function(){ MessageBox('خطا','این حساب از قبل فعال می باشد'); }) ;", True)
                End If
            Catch ex As Exception
            Finally
                SqlCon.SqlCon.Close()
            End Try
        End If
    End Sub
End Class
