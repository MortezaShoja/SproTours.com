Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Text
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime

Public Class SendEmail
    Inherits System.Web.UI.Page
    Private mail As New MailMessage()
    Private FND() As String

    'Successful
    'Error Message
    Public Function Sender(ByVal From As String, ByVal DisplayName As String, ByVal Password As String, ByVal SendTo As String, ByVal Message As String, ByVal Subject As String, ByVal Attach As String) As String
        Dim value As String = "Successful"
        Using mailMessage As New MailMessage(New MailAddress(SendTo), New MailAddress(SendTo))
            mailMessage.Body = Message
            mailMessage.Subject = Subject
            mail = New MailMessage()
            Try
                Dim SmtpServer As New SmtpClient()
                SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                SmtpServer.Port = 587
                'SmtpServer.Port = 25

                Dim MS() As String = From.ToString.Split("@")
                Dim MailServer() As String = MS(1).ToString.Split(".")
                Select Case UCase(MailServer(0))
                    Case Is = "GMAIL"
                        SmtpServer.Host = "smtp.gmail.com"
                        SmtpServer.EnableSsl = True
                    Case Is = "YAHOO"
                        SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                        SmtpServer.Host = "smtp.mail.yahoo.com"
                        SmtpServer.EnableSsl = False
                    Case Is = "YMAIL"
                        SmtpServer.Host = "smtp.ymail.com"
                        SmtpServer.EnableSsl = False
                    Case Is = "AOL"
                        SmtpServer.Host = "smtp.aol.com"
                        SmtpServer.EnableSsl = False
                    Case Is = "LIVE"
                        SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                        SmtpServer.Host = "smtp.live.com"
                        SmtpServer.EnableSsl = True
                    Case Is = "SERVICEPRO"
                        SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                        SmtpServer.Host = "mail.servicepro.comtr"
                        SmtpServer.EnableSsl = False
                    Case Is = "SPROTOURS"
                        SmtpServer.Credentials = New System.Net.NetworkCredential(From, Password)
                        SmtpServer.Host = "mail.sprotours.com"
                        SmtpServer.EnableSsl = False
                End Select


                Dim addr() As String = SendTo.Split(",")
                mail.From = New MailAddress(From, DisplayName, System.Text.Encoding.UTF8)
                Dim i As Byte
                For i = 0 To addr.Length - 1
                    mail.To.Add(addr(i))
                Next i
                mail.Subject = Subject
                mail.Body = Message
                mail.BodyEncoding = System.Text.Encoding.UTF8
                If Attach.Length <> 0 Then
                    mail.Attachments.Add(New Attachment(Attach))
                End If
                mail.IsBodyHtml = True
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                mail.ReplyTo = New MailAddress(SendTo)
                SmtpServer.Send(mail)
            Catch ex As Exception
                value = ex.Message.ToString
            End Try
        End Using
        Return value
    End Function
End Class


