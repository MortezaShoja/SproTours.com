Imports System.Data
Imports System.Globalization
Imports com.arianpal.merchant

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private SE As SendEmail
    Private CHE As CreateHTMLEmail
    Private GTI As GetTourInfo


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadExchangeRates()
        Dim MemberID As String = String.Empty
        Try
            MemberID = Request.Cookies("UserSettings")("ID").ToString
        Catch ex As Exception
        End Try

        If IsPostBack = False Then
            Merguee()

            Me.lbltoDate.Text = Now.Year.ToString
            Try
                If MemberID <> String.Empty Then
                    Dim SqlCon As New SqlConnectionSite
                    Dim Cmd As New SqlClient.SqlCommand
                    Try
                        Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = Request.Cookies("UserSettings")("ID").ToString
                        Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Request.Cookies("UserSettings")("Secret").ToString
                        'Cmd.CommandText = "Select ID,Password,FullName,CoAgencyName,MemberType from Members where ID=@ID And Password=@Password and Active='1'"
                        '                                 0       1           2           3             4         5     6       7           8
                        Cmd.CommandText = "Select top 1 M.ID,M.Password,M.FullName,M.CoAgencyName,M.MemberType,M.Email,U.ID,U.FullName,U.Password from Members M full outer join Users U On U.MemberID=M.ID where (M.ID=@ID And M.Password=@Password) or (U.ID=@ID And U.Password=@Password) And M.Active='1'"


                        Cmd.Connection = SqlCon.SqlCon
                        SqlCon.SqlCon.Open()
                        Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                        If sdr.Read Then

                            If LCase(Request.Cookies("UserSettings")("ID").ToString) = LCase(sdr(0).ToString) Then

                                Dim tmpName() As String = sdr(2).ToString.Split(" ")
                                '-----------------
                                Me.liMobileMemberLogin.Visible = False
                                Me.liMobileMemberInfo.Visible = True
                                If tmpName(0).ToString.Length >= 10 Then
                                    Me.lblMobileMemberInfo.InnerText = Mid(tmpName(0).ToString, 1, 10)
                                Else
                                    Me.lblMobileMemberInfo.InnerText = tmpName(0).ToString
                                End If

                                DoLoginAction(sdr(0).ToString, sdr(1).ToString, sdr(2).ToString, sdr(3).ToString, sdr(4).ToString)
                            Else
                                Dim tmpName() As String = sdr(7).ToString.Split(" ")
                                '-----------------
                                Me.liMobileMemberLogin.Visible = False
                                Me.liMobileMemberInfo.Visible = True
                                If tmpName(0).ToString.Length >= 10 Then
                                    Me.lblMobileMemberInfo.InnerText = Mid(tmpName(0).ToString, 1, 10)
                                Else
                                    Me.lblMobileMemberInfo.InnerText = tmpName(0).ToString
                                End If

                                DoLoginAction(sdr(6).ToString, sdr(8).ToString, sdr(7).ToString, sdr(3).ToString, sdr(4).ToString)
                            End If

                            
                            sdr.Close()

                        Else
                            DoLogOut()
                        End If
                    Catch ex As Exception
                        DoLogOut()
                        Dim ERM As New ErrorLog
                        'ERM.Log()
                    Finally
                        SqlCon.SqlCon.Close()
                    End Try

                Else
                    Me.LiLogin.Visible = True
                    Me.LiRegister.Visible = True
                    Me.LiSignOut.Visible = False
                    Me.LiUserName.Visible = False
                End If
            Catch ex As Exception
                Me.LiLogin.Visible = True
                Me.LiRegister.Visible = True
                Me.LiSignOut.Visible = False
                Me.LiUserName.Visible = False
            End Try
        Else
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "alert", "MemberRquestType();", True)
        End If


        Dim CTBI As New CreateTopBasketItems
        Dim tmpCTBI() As String = CTBI.Create(MemberID)
        Me.BasketTopMenu.InnerHtml = tmpCTBI(0)
        Me.BasketMobileQty.InnerHtml = tmpCTBI(1)

    End Sub

    Private Sub Merguee()
        Dim Value As String = String.Empty

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            'Cmd.Parameters.Add("@Today", SqlDbType.Date).Value = Now.ToString("yyyy/MM/dd")
            'Cmd.CommandText = "Select Message from Merquee Where StartDate >= @Today and EndDate <= @Today order by code desc"
            Cmd.CommandText = "Select Message from Merquee"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Value += sdr(0).ToString & " <img src=""images/FavIcon_W.png"" style=""width:auto; height:30px;""/> "
            End While
        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Me.Marquee.InnerHtml = Value

    End Sub


    Private Sub LoadExchangeRates()
        Dim MC As New MoneyCodec

        Me.divExchangeRates.Controls.Clear()
        Dim SqlCon As New SqlConnectionTurkorder
        Dim Cmd As New SqlClient.SqlCommand

        Dim HtmlDom As String = "<table class=""table table-striped"" style=""width:100%"">" & _
            "<thead style=""Background-Color:#e27513;"">" & _
            "<tr>" & _
            "<td style=""Color:white;"">نوع ارز</td>" & _
            "<td style=""Color:white;"">نرخ ارز</td>" & _
            "</tr>" & _
            "</thead>" & _
            "<tbody>"
        Try
            Cmd.CommandText = "select CurrencySign,IstanbulRate from Exchange where CurrencyAbbreviation !=N'TMN' order by istanbulrate"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                HtmlDom += "<tr>" & _
                    "<td> " & sdr(0).ToString & " </td>" & _
                    "<td> " & MC.Code(sdr(1).ToString) & " تومان </td>"
            End While
        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try

        HtmlDom += "</tr>" & _
             "</tbody>" & _
            "</table>"

        Me.divExchangeRates.InnerHtml = HtmlDom
    End Sub

    'Protected Sub btnSendSubscription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendSubscription.Click
    '    SE = New SendEmail
    '    SE.Sender("noreply@SproTours.com", "Contact Me Message", "N_O_R_E_P_L_Y2016", "info@SproTours.com", "Name : " & Me.txtName.Text & "<br/>" & "Email : " & Me.txtEmail.Text & "<br/>" & "Phone : " & Me.txtTelephone.Text, Me.txtEmail.Text, "")
    '    Me.txtEmail.Text = String.Empty
    '    Me.txtName.Text = String.Empty
    '    Me.txtTelephone.Text = String.Empty
    'End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "alert", "ProgressPage('open');", True)
        Me.lblLoginMessages.Text = String.Empty
        If Me.txtLoginUserName.Text = "" Then
            Me.lblLoginMessages.Text = "Please fill all parts."
        End If
        Dim v As New Validation
        If v.Email(Me.txtLoginUserName.Text) Then
            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Try

                Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtLoginUserName.Text
                'Dim n As String = FileSecurity.Code(Me.txtLoginPassword.Text, 10)
                Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Me.txtLoginPassword.Text

                'Cmd.CommandText = "Select ID,Password,FullName,CoAgencyName,MemberType from Members where Email=@Email And Password=@Password And Active='1'"
                '                                 0       1           2           3             4         5     6       7           8
                Cmd.CommandText = "Select top 1 M.ID,M.Password,M.FullName,M.CoAgencyName,M.MemberType,M.Email,U.ID,U.FullName,U.Password from Members M full outer join Users U On U.MemberID=M.ID where (M.Email=@Email And M.Password=@Password) or (U.Email=@Email And U.Password=@Password) And M.Active='1'"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                If sdr.Read Then

                    If LCase(Me.txtLoginUserName.Text) = LCase(sdr(5)) Then
                        'Cmd.CommandText = "Update Members set LastLogin='" & Now.ToString & "' where ID='" & Request.Cookies("UserSettings")("ID").ToString & "'"
                        'Cmd.ExecuteNonQuery()
                        '-----------------
                        Dim tmpName() As String = sdr(2).ToString.Split(" ")
                        Me.liMobileMemberLogin.Visible = False
                        Me.liMobileMemberInfo.Visible = True
                        If tmpName(0).ToString.Length >= 10 Then
                            Me.lblMobileMemberInfo.InnerText = Mid(tmpName(0).ToString, 1, 10)
                        Else
                            Me.lblMobileMemberInfo.InnerText = tmpName(0).ToString
                        End If

                        DoLoginAction(sdr(0).ToString, sdr(1).ToString, sdr(2).ToString, sdr(3).ToString, sdr(4).ToString)
                    Else

                        'Cmd.CommandText = "Update Members set LastLogin='" & Now.ToString & "' where ID='" & Request.Cookies("UserSettings")("ID").ToString & "'"
                        'Cmd.ExecuteNonQuery()
                        '-----------------
                        Dim tmpName() As String = sdr(7).ToString.Split(" ")
                        Me.liMobileMemberLogin.Visible = False
                        Me.liMobileMemberInfo.Visible = True
                        If tmpName(0).ToString.Length >= 10 Then
                            Me.lblMobileMemberInfo.InnerText = Mid(tmpName(0).ToString, 1, 10)
                        Else
                            Me.lblMobileMemberInfo.InnerText = tmpName(0).ToString
                        End If

                        DoLoginAction(sdr(6).ToString, sdr(8).ToString, sdr(7).ToString, sdr(3).ToString, sdr(4).ToString)
                    End If


                    sdr.Close()

                    'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "key", "ProgressPage('close');", True)
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "Closepopup(this);", True)
                    'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
                Else
                    Me.txtLoginUserName.Text = String.Empty
                    Me.txtLoginPassword.Text = String.Empty
                    Me.lblLoginMessages.Text = "نام کاربری با کلمه عبور صحیح نمی باشد"
                End If
            Catch ex As Exception
                Me.lblLoginMessages.Text = "خطا در برقراری ارتباط با مرکز" & "<br />" & "لطفاً چند دقیقه دیگر مجدد تلاش کنید"
                Dim ERM As New ErrorLog
                'ERM.Log()
            Finally
                SqlCon.SqlCon.Close()
            End Try
        Else
            Me.txtLoginUserName.Text = String.Empty
            Me.lblLoginMessages.Text = "لطفاً ایمیل خود را بصورت صحیح وارد کنید"
        End If

        Response.Redirect("Default.aspx")
        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    Private Sub DoLoginAction(ByVal MemberID As String, ByVal Password As String, ByVal FullName As String, ByVal CoAgencyName As String, ByVal MemberType As String)

        Response.Cookies("UserSettings")("ID") = MemberID
        Response.Cookies("UserSettings")("Name") = FullName
        Response.Cookies("UserSettings")("Secret") = Password.Replace(" ", "_")
        Response.Cookies("UserSettings").Expires = DateTime.Now.AddYears(1)

        Me.lblpageModalRequestMember.Text = FullName & " (" & CoAgencyName & ")"

        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Login", "BtnSendRequestDisplayMode('Show');", True)
        Me.LiLogin.Visible = False
        Me.LiRegister.Visible = False
        Me.LiSignOut.Visible = True
        Me.LiUserName.Visible = True
    End Sub

    Private Sub DoLogOut()
        If (Not Request.Cookies("UserSettings") Is Nothing) Then
            Dim myCookie As HttpCookie
            myCookie = New HttpCookie("UserSettings")
            myCookie.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(myCookie)
        End If
        Me.LiLogin.Visible = True
        Me.LiRegister.Visible = True
        Me.LiSignOut.Visible = False
        Me.LiUserName.Visible = False
    End Sub

    Protected Sub btnRegisterPrivate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegisterPrivate.Click
        If MembershipValidation("عادی") Then
            RegMembershipRequests("عادی")
        End If
        ' RegMembershipRequests("عادی")
    End Sub

    Protected Sub btnRegisterMember_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegisterMember.Click
        If MembershipValidation("آژانس") Then
            RegMembershipRequests("آژانس")
        End If
    End Sub

    Protected Sub btnRegisterCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegisterCompany.Click
        If MembershipValidation("شرکت") Then
            RegMembershipRequests("شرکت")
        End If
    End Sub

    Private Function MembershipValidation(ByVal RequestType As String) As Boolean
        Dim value As Boolean = True
        Dim CAaC As New CheckAgenyAndCompany
        Me.lblRegisterMessage.Text = String.Empty

        Select Case RequestType

            Case Is = "آژانس"
                Me.txtNewMemberCompanyName.Text = String.Empty
                Me.txtNewMemberCompanyJobTitle.Text = String.Empty
                Me.txtNewMemberCompanyName.BorderColor = Drawing.Color.Empty
                Me.txtNewMemberCompanyJobTitle.BorderColor = Drawing.Color.Empty

                If Me.txtNewMemberMemberName.Text = String.Empty Or Me.txtNewMemberMemberName.Text.Length < 3 Then
                    Me.txtNewMemberMemberName.BorderColor = Drawing.Color.Red
                ElseIf CAaC.CheckCompanyAndMemberName(Me.txtNewMemberMemberName.Text) = True Then
                    Me.txtNewMemberMemberName.BorderColor = Drawing.Color.Red
                    Me.lblRegisterMessage.Text = "* این آژانس مسافرتی از قبل در سیستم ثبت می باشد"
                Else
                    Me.txtNewMemberMemberName.BorderColor = Drawing.Color.Empty
                End If


            Case Is = "شرکت"
                Me.txtNewMemberMemberName.Text = String.Empty
                Me.txtNewMemberMemberName.BorderColor = Drawing.Color.Empty

                If Me.txtNewMemberCompanyName.Text = String.Empty Or Me.txtNewMemberCompanyName.Text.Length < 3 Then
                    Me.txtNewMemberCompanyName.BorderColor = Drawing.Color.Red
                ElseIf CAaC.CheckCompanyAndMemberName(Me.txtNewMemberCompanyName.Text) = True Then
                    Me.txtNewMemberCompanyName.BorderColor = Drawing.Color.Red
                    Me.lblRegisterMessage.Text = "* این شرکت از قبل در سیستم ثبت می باشد"
                Else
                    Me.txtNewMemberCompanyName.BorderColor = Drawing.Color.Empty
                End If

                If Me.txtNewMemberCompanyJobTitle.Text = String.Empty Or Me.txtNewMemberCompanyJobTitle.Text.Length < 3 Then
                    Me.txtNewMemberCompanyJobTitle.BorderColor = Drawing.Color.Red
                Else
                    Me.txtNewMemberCompanyJobTitle.BorderColor = Drawing.Color.Empty
                End If

            Case Is = "عادی"
                Me.txtNewMemberMemberName.Text = String.Empty
                Me.txtNewMemberCompanyName.Text = String.Empty
                Me.txtNewMemberCompanyJobTitle.Text = String.Empty
                Me.txtNewMemberMemberName.BorderColor = Drawing.Color.Empty
                Me.txtNewMemberCompanyName.BorderColor = Drawing.Color.Empty
                Me.txtNewMemberCompanyJobTitle.BorderColor = Drawing.Color.Empty
        End Select

        If Me.txtNewMemberFullName.Text = String.Empty Or Me.txtNewMemberFullName.Text.Length < 7 Then
            Me.txtNewMemberFullName.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً نام و نام خانوادگی خود را وارد کنید"
        Else
            Me.txtNewMemberFullName.BorderColor = Drawing.Color.Empty
        End If

        If Me.txtNewMemberMobile.Text = String.Empty Or Me.txtNewMemberMobile.Text.Length < 10 Then
            Me.txtNewMemberMobile.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً شماره موبایل خود را وارد کنید"
        Else
            Me.txtNewMemberMobile.BorderColor = Drawing.Color.Empty
        End If

        If Me.txtNewMemberTelegramID.Text = String.Empty Or Me.txtNewMemberTelegramID.Text.Length < 4 Then
            Me.txtNewMemberTelegramID.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً آیدی تلگرام خود را وارد کنید"
        Else
            Me.txtNewMemberTelegramID.BorderColor = Drawing.Color.Empty
        End If

        Dim v As New Validation

        If Me.txtNewMemberEmail.Text = "" Or Me.txtNewMemberEmail.Text.Length < 8 Then
            Me.txtNewMemberEmail.BorderColor = Drawing.Color.Red
        ElseIf v.Email(Me.txtNewMemberEmail.Text) = False Then
            Me.txtNewMemberEmail.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً آدرس ایمیل خود را بصورت صحیح وارد کنید"
        ElseIf CAaC.CheckEmail(Me.txtNewMemberEmail.Text, "") = True Then
            Me.txtNewMemberEmail.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* این ایمیل از قبل در سیستم ثبت می باشد"
        Else
            Me.txtNewMemberEmail.BorderColor = Drawing.Color.Empty
        End If

        If Me.txtNewMemberPassword.Text = "" Or Me.txtNewMemberPassword.Text.Length < 5 Then
            Me.txtNewMemberPassword.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* رمز عبور باید حداقل 6 کاراکتر باشد"
        Else
            Me.txtNewMemberPassword.BorderColor = System.Drawing.Color.Empty
        End If

        '---------------------------------------------------------
        If Me.lblRegisterMessage.Text <> String.Empty Then
            Me.lblRegisterMessage.Text = "لطفاً تمام قسمت هایی که با رنگ قرمز مشخص شده اند را تکمیل کنید" & "<br />" & Me.lblRegisterMessage.Text
            value = False
        Else
            value = True
        End If
        Return value
    End Function

    Private Sub RefreshText()
        Me.txtNewMemberCompanyJobTitle.Text = ""
        Me.txtNewMemberCompanyJobTitle.Text = ""
        Me.txtNewMemberEmail.Text = ""
        Me.txtNewMemberFullName.Text = ""
        Me.txtNewMemberMemberName.Text = ""
        Me.txtNewMemberMobile.Text = ""
        Me.txtNewMemberPassword.Text = ""
    End Sub

    Private Sub RegMembershipRequests(ByVal RequestType As String)

        Dim SqlCon As New SqlConnectionSite
        Dim MemberID As String = Guid.NewGuid.ToString
        'Dim CodedPassword As String = FileSecurity.Code(Me.txtNewMemberPassword.Text, 10)
        Try
            Dim Cmd As New SqlClient.SqlCommand
            'Select Case RequestType
            '    Case Is = "عادی"
            '        Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = MemberID
            '        Cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = "عادی"
            '        Cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = Me.txtNewMemberFullName.Text
            '        Cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = Me.txtNewMemberMobile.Text
            '        Cmd.Parameters.Add("@TelegramID", SqlDbType.NVarChar).Value = Me.txtNewMemberTelegramID.Text
            '        Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtNewMemberEmail.Text
            '        Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Me.txtNewMemberPassword.Text
            '        Cmd.Parameters.Add("@Regdate", SqlDbType.DateTime).Value = Now.ToString
            '        Cmd.CommandText = "Insert Into Members (ID,MemberType,FullName,Mobile,TelegramID,Email,Password,Regdate) values (@ID,@MemberType,@FullName,@Mobile,@TelegramID,@Email,@Password,@Regdate)"
            '    Case Is = "آژانس"
            '        Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = MemberID
            '        Cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = "آژانس"
            '        Cmd.Parameters.Add("@CoAgencyName", SqlDbType.NVarChar).Value = Me.txtNewMemberMemberName.Text
            '        Cmd.Parameters.Add("@AgencyType", SqlDbType.NVarChar).Value = Me.ddlNewMemberMemberType.Text
            '        Cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = Me.txtNewMemberFullName.Text
            '        Cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = Me.txtNewMemberMobile.Text
            '        Cmd.Parameters.Add("@TelegramID", SqlDbType.NVarChar).Value = Me.txtNewMemberTelegramID.Text
            '        Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtNewMemberEmail.Text
            '        Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Me.txtNewMemberPassword.Text
            '        Cmd.Parameters.Add("@Regdate", SqlDbType.DateTime).Value = Now.ToString
            '        Cmd.CommandText = "Insert Into Members (ID,MemberType,CoAgencyName,AgencyType,FullName,Mobile,TelegramID,Email,Password,Regdate) values (@ID,@MemberType,@CoAgencyName,@AgencyType,@FullName,@Mobile,@TelegramID,@Email,@Password,@Regdate)"
            '    Case Is = "شرکت"
            '        Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = MemberID
            '        Cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = "شرکت"
            '        Cmd.Parameters.Add("@CoAgencyName", SqlDbType.NVarChar).Value = Me.txtNewMemberCompanyName.Text
            '        Cmd.Parameters.Add("@AgencyType", SqlDbType.NVarChar).Value = Me.txtNewMemberCompanyJobTitle.Text
            '        Cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = Me.txtNewMemberFullName.Text
            '        Cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = Me.txtNewMemberMobile.Text
            '        Cmd.Parameters.Add("@TelegramID", SqlDbType.NVarChar).Value = Me.txtNewMemberTelegramID.Text
            '        Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtNewMemberEmail.Text
            '        Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Me.txtNewMemberPassword.Text
            '        Cmd.Parameters.Add("@Regdate", SqlDbType.DateTime).Value = Now.ToString
            '        Cmd.CommandText = "Insert Into Members (ID,MemberType,CoAgencyName,AgencyType,FullName,Mobile,TelegramID,Email,Password,Regdate) values (@ID,@MemberType,@CoAgencyName,@AgencyType,@FullName,@Mobile,@TelegramID,@Email,@Password,@Regdate)"
            'End Select

            Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = MemberID
            Cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = "آژانس"
            Cmd.Parameters.Add("@CoAgencyName", SqlDbType.NVarChar).Value = Me.txtNewMemberMemberName.Text
            Cmd.Parameters.Add("@CoAgencyNamePersian", SqlDbType.NVarChar).Value = Me.txtNewMemberMemberNamePersian.Text
            Cmd.Parameters.Add("@AgencyType", SqlDbType.NVarChar).Value = Me.ddlNewMemberMemberType.Text
            Cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = Me.txtNewMemberFullName.Text
            Cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = Me.txtNewMemberMobile.Text
            Cmd.Parameters.Add("@TelegramID", SqlDbType.NVarChar).Value = Me.txtNewMemberTelegramID.Text
            Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtNewMemberEmail.Text
            Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Me.txtNewMemberPassword.Text
            Cmd.Parameters.Add("@Regdate", SqlDbType.DateTime).Value = Now.ToString
            Cmd.CommandText = "Insert Into Members (ID,MemberType,CoAgencyName,CoAgencyNamePersian,AgencyType,FullName,Mobile,TelegramID,Email,Password,Regdate) values (@ID,@MemberType,@CoAgencyName,@CoAgencyNamePersian,@AgencyType,@FullName,@Mobile,@TelegramID,@Email,@Password,@Regdate)"

            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()

            'Select Case RequestType
            '    Case Is = "عادی"
            '        DoLoginAction(MemberID, CodedPassword, Me.txtNewMemberFullName.Text, "", RequestType)
            '    Case Is = "آژآنس"
            '        DoLoginAction(MemberID, CodedPassword, Me.txtNewMemberFullName.Text, Me.txtNewMemberMemberName.Text, RequestType)
            '    Case Is = "شرکت"
            '        DoLoginAction(MemberID, CodedPassword, Me.txtNewMemberFullName.Text, Me.txtNewMemberCompanyName.Text, RequestType)
            'End Select

            SE = New SendEmail
            CHE = New CreateHTMLEmail
            SE.Sender("Noreply@SproTours.com", "SproTours.com", "EmailMaster2017", Me.txtNewMemberEmail.Text, CHE.CreateRegistration(Me.txtNewMemberFullName.Text, Me.txtNewMemberEmail.Text, Me.txtNewMemberPassword.Text, MemberID, Server.MapPath("Email/Registration.htm")), "تایید ایمیل", "")

            RefreshText()

            'Me.DivpageModalRequestMember.Visible = False
            'Me.btnRegisterPrivate.Visible = False
            'Me.btnClosepageModalRequestMember.Visible = True

            'Me.lblRegisterMessage.ForeColor = Drawing.Color.Green
            'Me.lblRegisterMessage.Text = Me.txtNewMemberName.Text & " " & Me.txtNewMemberMobile.Text & " عزیز" & vbCrLf & "درخواست عضویت شما با موفقیت ثبت گردید" & vbCrLf & "جهت تکمیل فرایند عضویت به آدرس ایمیل خود مراجعه نمایید"
            'Me.txtNewMemberEmail.Text = String.Empty
            'Me.txtNewMemberPassword.Text = String.Empty
            'Me.txtNewMemberMemberName.Text = String.Empty

            'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "Script", "pageModalRegistrationMemberAlert('');", True)

            'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "pageModalRegistrationMemberAlert();", True)

            Response.Redirect("Default.aspx")

        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try


    End Sub

    Protected Sub btnLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogOut.Click, btnMobileLogOut.Click
        DoLogOut()
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Login", "BtnSendRequestDisplayMode('Hide');", True)
        Response.Redirect("Default.aspx")
    End Sub


    Private Sub FillGridUnderProcessRequests()
        Try
            Dim Dvw As New Data.DataView
            Dim Tbl As New Data.DataTable
            Tbl.Clear()

            Dim Hotels() As String = GetHotelRequests()

            Tbl.Columns.Add("ID")
            Tbl.Columns.Add("Reuest Details")
            Tbl.Columns.Add("Last Update")
            Tbl.Columns.Add("Status")

            'populating rows

            For fc = 0 To Hotels.Count - 1
                Dim row As DataRow = Tbl.NewRow
                Dim tmp() As String = Hotels(fc).Split("#")
                row(0) = tmp(0)
                row(1) = tmp(1)
                row(2) = tmp(2)
                row(3) = tmp(3)
                Tbl.Rows.Add(row)
            Next

            Dvw = New Data.DataView(Tbl)
            Me.dgvUnderProcessRequests.DataSource = Dvw
            Me.dgvUnderProcessRequests.DataBind()

        Catch ex As Exception
            Session("Error") = "Error Code: " & "1" & "<br/>" & ex.ToString & ""
            Session("ErrorPage") = Page.Title.ToString()
            Response.Redirect("ErrorPage.Aspx")
        Finally

        End Try

    End Sub

    Private Function GetHotelRequests() As Array
        Dim SQl As SqlConnectionSite
        Dim cmd As Data.SqlClient.SqlCommand
        Dim Value(0) As String
        Dim tmp(3) As String

        Try
            SQl = New SqlConnectionSite
            cmd = New Data.SqlClient.SqlCommand
            cmd.Connection = SQl.SqlCon
            '                          0     1         2         3         4        5      6
            cmd.CommandText = "select ID,RequestCode,HotelID,LastUpdate,CheckIn,CheckOut,Status From HotelRequests  Where MemberID = '" & Request.Cookies("UserSettings")("ID").ToString.ToString & "' And (Not Status = N'Confirmed' or Not PaymentStatus = N'Confirmed') order by LastUpdate desc"

            SQl.SqlCon.Open()
            Dim sdr As Data.SqlClient.SqlDataReader = cmd.ExecuteReader
            While (sdr.Read)
                tmp(0) = "H " & sdr(1).ToString
                tmp(1) = GetHotelName(sdr(2).ToString) & vbCrLf & " CheckIn:" & CType(sdr(4), Date).ToString("dd/MMM/yyyy", New CultureInfo("en-us")) & "  CheckOut:" & CType(sdr(5), Date).ToString("dd/MMM/yyyy", New CultureInfo("en-us")) & vbCrLf & " RoomCount:" & GetHotelRoomCount(sdr(0).ToString)
                tmp(2) = sdr(3).ToString
                tmp(3) = sdr(6).ToString

                Value(Value.Length - 1) = tmp(0) & "#" & tmp(1) & "#" & tmp(2) & "#" & tmp(3)
                ReDim Preserve Value(Value.Length)
            End While
            ReDim Preserve Value(Value.Length - 2)
        Catch ex As Exception
            SQl.SqlCon.Close()
            Session("Error") = "Error Code: " & "1" & "<br/>" & ex.ToString & ""
            Session("ErrorPage") = Page.Title.ToString()
            Response.Redirect("ErrorPage.Aspx")
        Finally
            SQl.SqlCon.Close()
        End Try

        Return Value
    End Function

    Private Function GetHotelRoomCount(ByVal HotelRequestID As String) As Integer
        Dim Value As Integer = 0
        Dim SQlGetHotelRoomCount As New SqlConnectionSite
        Try
            Dim cmdGetHotelRoomCount = New Data.SqlClient.SqlCommand
            cmdGetHotelRoomCount.Connection = SQlGetHotelRoomCount.SqlCon
            cmdGetHotelRoomCount.CommandText = "select [Count] From HotelRequestsRoomTypes where RequestID='" & HotelRequestID & "'"

            SQlGetHotelRoomCount.SqlCon.Open()
            Dim sdrGetHotelRoomCount As Data.SqlClient.SqlDataReader = cmdGetHotelRoomCount.ExecuteReader
            While (sdrGetHotelRoomCount.Read)
                Value += sdrGetHotelRoomCount(0)
            End While
        Catch ex As Exception
            SQlGetHotelRoomCount.SqlCon.Close()
            Session("Error") = "Error Code: " & "1" & "<br/>" & ex.ToString & ""
            Session("ErrorPage") = Page.Title.ToString()
            Response.Redirect("ErrorPage.Aspx")
        Finally
            SQlGetHotelRoomCount.SqlCon.Close()
        End Try

        Return Value
    End Function


    Private Function GetHotelName(ByVal HotelID As String) As String
        Dim Value As String = String.Empty
        Dim SQlGetHotelRoomCount As New SqlConnectionHotels
        Try
            Dim cmdGetHotelRoomCount = New Data.SqlClient.SqlCommand
            cmdGetHotelRoomCount.Connection = SQlGetHotelRoomCount.SqlCon
            cmdGetHotelRoomCount.CommandText = "select HotelName,Country,City From Hotels where ID='" & HotelID & "'"

            SQlGetHotelRoomCount.SqlCon.Open()
            Dim sdrGetHotelRoomCount As Data.SqlClient.SqlDataReader = cmdGetHotelRoomCount.ExecuteReader
            While (sdrGetHotelRoomCount.Read)
                Value = sdrGetHotelRoomCount(0) & ", " & sdrGetHotelRoomCount(1) & ", " & sdrGetHotelRoomCount(2)
            End While
        Catch ex As Exception
            SQlGetHotelRoomCount.SqlCon.Close()
            Session("Error") = "Error Code: " & "1" & "<br/>" & ex.ToString & ""
            Session("ErrorPage") = Page.Title.ToString()
            Response.Redirect("ErrorPage.Aspx")
        Finally
            SQlGetHotelRoomCount.SqlCon.Close()
        End Try

        Return Value
    End Function

    Protected Sub btnRefreshUnderProcessRequests_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefreshUnderProcessRequests.Click
        FillGridUnderProcessRequests()
    End Sub

    Protected Sub btnCheckout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckout.Click

        Dim MemberID As String = String.Empty
        Try
            MemberID = Request.Cookies("UserSettings")("ID").ToString.ToString
        Catch ex As Exception
        End Try

       

        Dim SQLCon As New SqlConnectionSite

        '---------------------------------------------------------------------
        Dim RequestIDs As String = String.Empty
        Dim TotalTomanPrice As Decimal = 0
        Dim QTY As Integer = 0
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.CommandText = "select ID,TotalTomanPrice From TourRequests Where MemberID=@MemberID And Status=N'در سبد خرید'"
            Cmd.Connection = SQLCon.SqlCon
            SQLCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                QTY += 1
                RequestIDs += sdr(0).ToString & ","
                TotalTomanPrice += sdr(1)
                Try
                    Dim Q As New ThoughtWorks.QRCode.Codec.QRCodeEncoder
                    Q.Encode("http://www.Sprotours.com/QrValidator.aspx?ID=" & sdr(0).ToString).Save(Server.MapPath(Request.ApplicationPath) & "\QRCode\" & sdr(0).ToString & ".jpg")
                Catch ex As Exception
                End Try
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SQLCon.SqlCon.Close()
        End Try
        '---------------------------------------------------------------------------
        'Create Payments
        Dim PaymentID As Guid = Guid.NewGuid
        Dim GHabelePardakht As Decimal = 0
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = PaymentID
            Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.Parameters.Add("@RequestIDs", SqlDbType.NVarChar).Value = RequestIDs
            Cmd.Parameters.Add("@RegDate", SqlDbType.DateTime).Value = Now.ToString
            Cmd.Parameters.Add("@OrderPrice", SqlDbType.Decimal).Value = TotalTomanPrice

            GTI = New GetTourInfo
            Dim TourDiscount As Decimal = GTI.GetDescount(QTY)

            Cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = TourDiscount
            GHabelePardakht = TotalTomanPrice - TourDiscount
            Cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = GHabelePardakht

            Cmd.CommandText = "Insert Into Payments (ID,MemberID,RequestIDs,RegDate,OrderPrice,Discount,TotalPrice) values (@ID,@MemberID,@RequestIDs,@RegDate,@OrderPrice,@Discount,@TotalPrice)"
            Cmd.Connection = SQLCon.SqlCon
            SQLCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SQLCon.SqlCon.Close()
        End Try
        '---------------------------------------------------------------------------
        'Get PaymentCode

        Dim PaymentCode As Integer = 0
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = PaymentID
            Cmd.CommandText = "Select Code from Payments Where ID=@ID"
            Cmd.Connection = SQLCon.SqlCon
            SQLCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                PaymentCode = sdr(0)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SQLCon.SqlCon.Close()
        End Try
        '------------------------------------------------------------------
        'Set PaymentID into TourRequests

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@PaymentID", SqlDbType.UniqueIdentifier).Value = PaymentID
            Dim tmpIds() As String = RequestIDs.Split(",")
            Dim Shart As String = String.Empty
            For I As Integer = 0 To tmpIds.Length - 2
                Shart += "ID='" & tmpIds(I) & "' Or "
            Next
            Try
                Shart = Mid(Shart, 1, Shart.ToString.Length - 3)
            Catch ex As Exception
            End Try

            Cmd.CommandText = "Update TourRequests Set PaymentID=@PaymentID Where " & Shart
            Cmd.Connection = SQLCon.SqlCon
            SQLCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SQLCon.SqlCon.Close()
        End Try
        '---------------------------------------------------------------------------
        Dim MemberName As String = String.Empty
        Dim MemberEmail As String = String.Empty
        Dim MemberPhone As String = String.Empty

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.CommandText = "select FullName,Email,Mobile From Members Where ID=@ID"
            Cmd.Connection = SQLCon.SqlCon
            SQLCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                MemberName = sdr(0).ToString
                MemberEmail = sdr(1).ToString
                MemberPhone = sdr(2).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SQLCon.SqlCon.Close()
        End Try
        '------------------------------------------------------------------------------------



        '---------------------------- Dargahe Pardakht
        Dim MerchantID As String = "4352504"
        Dim Password As String = "g42WUKbQq"
        Dim ws As New com.arianpal.merchant.WebService
        Try
            Dim Result As PaymentRequestResult = ws.RequestPayment(MerchantID, Password, GHabelePardakht, " شماره پیگیری تراکنش : " & PaymentCode, MemberName, MemberEmail, MemberPhone, PaymentCode, "http://www.SproTours.com/Tours.aspx?RC=" & PaymentCode)
            If Result.ResultStatus = ResultValues.Succeed Then
                Response.Redirect(Result.PaymentPath.ToString)
            Else
                'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "message", "window.onload = function () { MessageBox('خطا','خطا در برقراری ارتباط با درگاه پرداخت');};", True)
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "message", "window.onload = function () { MessageBox('خطا','خطا در برقراری ارتباط با درگاه پرداخت');};", True)
            End If
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "message", "window.onload = function () { MessageBox('خطا','خطا در برقراری ارتباط با درگاه پرداخت');};", True)
        End Try

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim SqlCon As New SqlConnectionSite
        Try
            Dim cmd = New Data.SqlClient.SqlCommand
            cmd.Connection = SqlCon.SqlCon

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(Me.txtSelectedItemBasket.Text)
            cmd.CommandText = "Delete TourRequests where ID=@ID"
            SqlCon.SqlCon.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            SqlCon.SqlCon.Close()
            Session("Error") = "Error Code: " & "1" & "<br/>" & ex.ToString & ""
            Session("ErrorPage") = Page.Title.ToString()
            Response.Redirect("ErrorPage.Aspx")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Me.txtSelectedItemBasket.Text = String.Empty

        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    Protected Sub btnOpenMemberAccount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpenMemberAccount.Click, btnOpenMemberAccountMobile.Click
        If HttpContext.Current.Request.Cookies.Get("UserSettings") Is Nothing Then
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "script", "$('#pageModalLogin').modal('show');", True)
        Else
            Response.Redirect("Members/profile.aspx")
        End If
    End Sub
End Class

