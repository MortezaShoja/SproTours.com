Imports System.Data
Imports System.Globalization

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If HttpContext.Current.Request.Cookies.Get("UserSettings") Is Nothing Then
            If Request.Cookies("UserSettings")("ID").ToString = String.Empty Then
                Response.Redirect("Login.aspx")
            Else
                LoadMemberInfo()
            End If
        Catch ex As Exception
            Response.Redirect("Login.aspx")
        End Try


    End Sub

    Private Function CheckPassword() As Boolean
        Dim Value As Boolean = False

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = Request.Cookies("UserSettings")("ID").ToString
            Cmd.CommandText = "Select Password,Suspend from Members Where ID=@ID"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                If CType(sdr(1), Boolean) = False Then
                    Dim secret As String = Request.Cookies("UserSettings")("Secret")
                    If sdr(0).Replace(" ", "_") = Request.Cookies("UserSettings")("Secret") Then
                        Value = True
                    End If
                End If
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "CheckPassword")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    Private Sub LoadMemberInfo()
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        If System.IO.File.Exists(Server.MapPath(Request.ApplicationPath) & "\Members\Profiles\Images\" & Request.Cookies("UserSettings")("ID").ToString & ".png") Then
            Me.ImgLogo.ImageUrl = "~/Members/Profiles/Images/" & Request.Cookies("UserSettings")("ID").ToString & ".png"
        Else
            Me.ImgLogo.ImageUrl = "../Images/logo.png"
        End If

        Try

            Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = Request.Cookies("UserSettings")("ID").ToString

            Cmd.CommandText = "select FullName,RegDate,MemberType from Members where ID=@ID"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Me.lblMemberName.Text = sdr(0).ToString
                Dim DC As New DateConvertor
                DC.Convertor(CType(sdr(1), Date).ToString(New CultureInfo("en-us")))
                Me.lblRegdate.Text = "از " & DC.Hyear & "/" & DC.Hmonth & "/" & DC.Hday
                Me.lblUserType.Text = "نوع کاربری : " & "<br/>" & sdr(2).ToString
                'If sdr(2).ToString <> "کاربر عادی" Then
                '    Me.LinkPishfaktor.HRef = "ProcessedOrdersSpecialUsers.aspx"
                'End If
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "LoadMemberInfo")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        GetThisMonthsBought()

    End Sub

    Private Sub GetThisMonthsBought()
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        Dim MC As New MoneyCodec

        Dim DC As New DateConvertor
        DC.Convertor(Now.ToString(New CultureInfo("en-us")))
        Dim ShamsiCurrentMonth As String = DC.Hyear & "/" & DC.Hmonth & "/"

        Dim StM As New ShamsiToMiladi
        Dim FromDate As String = StM.ConvertToMiladi(ShamsiCurrentMonth & "01", False, True)
        Dim ToDate As String = String.Empty

        Select Case Integer.Parse(DC.Hmonth)
            Case Is < 6
                ToDate = StM.ConvertToMiladi(ShamsiCurrentMonth & "31", False, True)
            Case Is >= 6
                ToDate = StM.ConvertToMiladi(ShamsiCurrentMonth & "30", False, True)
            Case Is = 12
                ToDate = StM.ConvertToMiladi(ShamsiCurrentMonth & "29", False, True)
        End Select


        Try

            Cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = Request.Cookies("UserSettings")("ID").ToString

            Cmd.CommandText = "select sum(TotalSitePriceTomanWithIstanbulRates) from requests where MemberID=@MemberID and (Status=N'خریداری شد' or Status=N'دریافت در استانبول' or Status=N'به ایران ارسال شد' or Status=N'ارسال به ایران') and RequestDate between '" & FromDate & "' and '" & ToDate & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Me.lblThisMonthBought.Text = "خرید ماه جاری : " & MC.CodeFixUp(sdr(0)) & " تومان"
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "LoadMemberInfo")
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub

    Protected Sub btnLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogOut.Click
        DoLogOut()
    End Sub

    Private Sub DoLogOut()
        Try
            If (Not Request.Cookies("UserSettings") Is Nothing) Then
                Dim myCookie As HttpCookie
                myCookie = New HttpCookie("UserSettings")
                myCookie.Expires = DateTime.Now.AddDays(-1D)
                Response.Cookies.Add(myCookie)
            End If
        Catch ex As Exception

        End Try
        Response.Redirect("../Default.aspx")
    End Sub
End Class

