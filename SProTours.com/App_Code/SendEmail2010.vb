Imports Microsoft.VisualBasic
Imports System.Net.Mail

Public NotInheritable Class SendEmail2010


    Public Property subject As String
    Public Property body As String
    Public Property receiver As String

    Public Function send(ByVal From As String, ByVal DisplayName As String, ByVal Password As String, ByVal SendTo As String, ByVal Message As String, ByVal Subject As String, ByVal Attach As String) As String
        Dim value As String = "Successful"
        'Try
        '    Dim smtpServer As New SmtpClient()
        '    Dim mail As New MailMessage()
        '    smtpServer.UseDefaultCredentials = False
        '    smtpServer.Credentials = New Net.NetworkCredential(From, Password)
        '    smtpServer.Port = 587
        '    smtpServer.EnableSsl = True
        '    smtpServer.Host = "smtp.gmail.com"

        '    mail = New MailMessage()
        '    mail.From = New MailAddress(From)
        '    mail.To.Add(receiver)
        '    mail.Subject = subject
        '    mail.Body = body
        '    smtpServer.Send(mail)
        'Catch ex As Exception
        '    'MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        '    value = ex.Message & vbNewLine & ex.StackTrace
        'End Try

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New System.Net.NetworkCredential(From, Password)
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "mail.SproTours.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(From, DisplayName, System.Text.Encoding.UTF8)
            e_mail.To.Add(SendTo)
            e_mail.Subject = Subject
            e_mail.IsBodyHtml = True
            e_mail.Body = Message
            Smtp_Server.Send(e_mail)

        Catch error_t As Exception
            'MsgBox(error_t.ToString)
            value = error_t.Message & vbNewLine & error_t.StackTrace
        End Try

        Return value
    End Function


End Class
