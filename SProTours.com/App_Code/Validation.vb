Imports Microsoft.VisualBasic
Imports System.Net
Imports System.IO

Public Class Validation

    Public Function Email(ByVal EmailAddress As String) As Boolean
        Dim R As Boolean = Regex.IsMatch(EmailAddress, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        Return R
    End Function

    Public Function CheckEmailAvailability(ByVal EmailAddress As String) As Boolean
        Dim value As Boolean = False

        Try
            Dim apiKey As String = "1d73be1de78a4038ac033d06f48a004e"
            Dim emailToValidate As String = EmailAddress
            Dim responseString As String = ""
            Dim apiURL As String = "https://api.zerobounce.net/v1/validate?apikey=" & apiKey & "&email=" & HttpUtility.UrlEncode(emailToValidate)
            'Uncomment out to use the optional API with IP Lookup
            'Dim apiURL as string = "https://api.zerobounce.net/v1/validatewithip?apikey=" & apiKey & "&email=" &  HttpUtility.UrlEncode(emailToValidate) & "&ipaddress=" & HttpUtility.UrlEncode("99.123.12.122")


            'Dim apiURL As String = "https://api.zerobounce.net/services.asmx/validate?apikey=" & apiKey & "&email=" & HttpUtility.UrlEncode(emailToValidate)
            ''Uncomment out to use the optional API with IP Lookup
            ''Dim apiURL as string = "https://api.zerobounce.net/services.asmx/validatewithip?apikey=" & apiKey & "&email=" &  HttpUtility.UrlEncode(emailToValidate) & "&ipaddress=" & HttpUtility.UrlEncode("99.123.12.122")

            '----------------------------------------------------
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12


            Dim request As HttpWebRequest = DirectCast(WebRequest.Create(apiURL), HttpWebRequest)
            request.Timeout = 150000
            request.Method = "GET"



            Using response As WebResponse = request.GetResponse()
                response.GetResponseStream().ReadTimeout = 20000
                Using ostream As New StreamReader(response.GetResponseStream())
                    responseString = ostream.ReadToEnd()
                End Using
            End Using

            responseString = responseString.Replace(Chr(34), "").Replace("{", "").Replace("}", "")
            Dim Status() As String = responseString.Split(",")

            If LCase(Status(1)) = "status:valid" Then
                value = True
            End If
        Catch ex As Exception
            value = True
            'Catch Exception - All errors will be shown here - if there are issues with the API
        End Try


        Return value
    End Function

End Class
