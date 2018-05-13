Imports System.Data
Imports System.IO
Imports System.Net


Partial Class CreateAccount
    Inherits System.Web.UI.Page

    Private SE As SendEmail
    Private CHE As CreateHTMLEmail
    Private ImageFlag As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "loadCaptcha", "grecaptcha.render('recaptcha', {'sitekey': '6Le0mQ8UAAAAAK8Z3y1WP-3ClohnnQ9FZ5eCkWqb' });", True)

        If IsPostBack = False Then
            Me.MemberInfo_ID.Text = Guid.NewGuid.ToString
        Else
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "script", "CoAgencySelector();", True)
        End If

    End Sub

    Private Function GetMemberIDByCode(ByVal MemberCode As Integer) As String

        Dim Value As String = String.Empty

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = MemberCode
            '-----Login---------------------------------------------------------------
            Cmd.CommandText = "Select ID From Members Where Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value = sdr(0).ToString
            End If

        Catch ex As Exception
            'Dim ERM As New ErrorLog
            'ERM.Log(Request, "Error", "", ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "GetMemberIDByCode")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value

    End Function

    Private Function MembershipValidation() As Boolean
        Dim value As Boolean = True
        Dim CAaC As New CheckAgenyAndCompany
        Me.lblRegisterMessage.Text = String.Empty

        If Me.MemberInfo_ddlUserType.Text = String.Empty Then
            Me.MemberInfo_ddlUserType.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً نوع حساب کاربری را انتخاب کنید"
        Else
            Me.MemberInfo_ddlUserType.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_ddlAgencyType.Text = String.Empty Then
            Me.MemberInfo_ddlAgencyType.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً نوع مجوز فعالیت آژانس را انتخاب کنید"
        Else
            Me.MemberInfo_ddlAgencyType.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_CoAgancyName.Text = String.Empty Or Me.MemberInfo_CoAgancyName.Text.Length < 3 Then
            Me.MemberInfo_CoAgancyName.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً نام انگلیسی آژانس را وارد کنید"
        Else
            Me.MemberInfo_CoAgancyName.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_CoAgancyNamePersian.Text = String.Empty Or Me.MemberInfo_CoAgancyNamePersian.Text.Length < 3 Then
            Me.MemberInfo_CoAgancyNamePersian.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً نام فارسی آژانس را وارد کنید"
        Else
            Me.MemberInfo_CoAgancyNamePersian.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_FullName.Text = String.Empty Or Me.MemberInfo_FullName.Text.Length < 7 Then
            Me.MemberInfo_FullName.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً نام و نام خانوادگی خود را وارد کنید"
        Else
            Me.MemberInfo_FullName.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_LandPhone_Code.Text = String.Empty Or Me.MemberInfo_LandPhone_Code.Text.Length < 3 Then
            Me.MemberInfo_LandPhone_Code.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً کد شهر خود را وارد کنید"
        Else
            Me.MemberInfo_LandPhone_Code.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_LandPhone.Text = String.Empty Or Me.MemberInfo_LandPhone.Text.Length < 7 Then
            Me.MemberInfo_LandPhone.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً شماره تلفن خود را وارد کنید"
        Else
            Me.MemberInfo_LandPhone.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_Mobile.Text = String.Empty Or Me.MemberInfo_Mobile.Text.Length < 10 Then
            Me.MemberInfo_Mobile.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً شماره موبایل خود را وارد کنید"
        Else
            Me.MemberInfo_Mobile.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_TelegramID.Text = String.Empty Or Me.MemberInfo_TelegramID.Text.Length < 4 Then
            Me.MemberInfo_TelegramID.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً شماره / آی دی تلگرام خود را وارد کنید"
        Else
            Me.MemberInfo_TelegramID.BorderColor = Drawing.Color.Empty
        End If

        'If Me.MemberInfo_WebSite.Text = String.Empty Or Me.MemberInfo_WebSite.Text.Length < 4 Then
        '    Me.MemberInfo_WebSite.BorderColor = Drawing.Color.Red
        '    Me.lblRegisterMessage.Text += "<br />" & "* لطفاً آدرس وب سایت خود را وارد کنید"
        'Else
        '    Me.MemberInfo_WebSite.BorderColor = Drawing.Color.Empty
        'End If

        If Me.MemberInfo_Region.Text = String.Empty Or Me.MemberInfo_Region.Text.Length < 2 Then
            Me.MemberInfo_Region.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً استان خود را وارد کنید"
        Else
            Me.MemberInfo_Region.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_City.Text = String.Empty Or Me.MemberInfo_City.Text.Length < 2 Then
            Me.MemberInfo_City.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً شهر خود را وارد کنید"
        Else
            Me.MemberInfo_City.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_PostalCode.Text = String.Empty Or Me.MemberInfo_PostalCode.Text.Length < 10 Then
            Me.MemberInfo_PostalCode.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً کد پستی خود را وارد کنید"
        Else
            Me.MemberInfo_PostalCode.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_FullAddress.Text = String.Empty Or Me.MemberInfo_FullAddress.Text.Length < 10 Then
            Me.MemberInfo_FullAddress.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً آدرس خود را وارد کنید"
        Else
            Me.MemberInfo_FullAddress.BorderColor = Drawing.Color.Empty
        End If


        Dim v As New Validation

        If Me.MemberInfo_Email.Text = "" Or Me.MemberInfo_Email.Text.Length < 8 Then
            Me.MemberInfo_Email.BorderColor = Drawing.Color.Red
        ElseIf v.Email(Me.MemberInfo_Email.Text) = False Then
            Me.MemberInfo_Email.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* لطفاً آدرس ایمیل خود را بصورت صحیح وارد کنید"
        ElseIf CAaC.CheckEmail(Me.MemberInfo_Email.Text, "") = False Then
            Me.MemberInfo_Email.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* این ایمیل از قبل در سیستم ثبت می باشد"
        ElseIf v.CheckEmailAvailability(Me.MemberInfo_Email.Text) = False Then
            Me.MemberInfo_Email.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* آدرس ایمیل وارد شده وجود ندارد"
        Else
            Me.MemberInfo_Email.BorderColor = Drawing.Color.Empty
        End If

        If Me.MemberInfo_Password.Text = "" Or Me.MemberInfo_Password.Text.Length < 5 Then
            Me.MemberInfo_Password.BorderColor = Drawing.Color.Red
            Me.lblRegisterMessage.Text += "<br />" & "* رمز عبور باید حداقل 6 کاراکتر باشد"
        Else
            Me.MemberInfo_Password.BorderColor = System.Drawing.Color.Empty
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

    Protected Sub MemberInfo_BtnRegNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberInfo_BtnRegNew.Click

        If MembershipValidation() = True Then
            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Try

                Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(Me.MemberInfo_ID.Text)
                Cmd.Parameters.Add("@RegDate", SqlDbType.DateTime).Value = Now.ToString
                Cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = Me.MemberInfo_ddlUserType.Text
                Cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = Me.MemberInfo_FullName.Text

                Cmd.Parameters.Add("@CoAgencyName", SqlDbType.NVarChar).Value = Me.MemberInfo_CoAgancyName.Text
                Cmd.Parameters.Add("@CoAgencyNamePersian", SqlDbType.NVarChar).Value = Me.MemberInfo_CoAgancyNamePersian.Text
                Cmd.Parameters.Add("@AgencyType", SqlDbType.NVarChar).Value = Me.MemberInfo_ddlAgencyType.Text
                'Cmd.Parameters.Add("@AgencyRegNumber", SqlDbType.NVarChar).Value = Me.MemberInfo_AgancyRegNo.Text
                'Cmd.Parameters.Add("@AgencyRegDate", SqlDbType.NVarChar).Value = Me.MemberInfo_AgancyRegDate.Text

                Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.MemberInfo_Email.Text
                Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Me.MemberInfo_Password.Text
                Cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = ToEnglishNumber(Me.MemberInfo_LandPhone_Code.Text & "-" & Me.MemberInfo_LandPhone.Text)
                Cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = ToEnglishNumber(Me.MemberInfo_Mobile.Text)
                Cmd.Parameters.Add("@TelegramID", SqlDbType.NVarChar).Value = Me.MemberInfo_TelegramID.Text
                Cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = Me.MemberInfo_WebSite.Text

                Cmd.Parameters.Add("@Region", SqlDbType.NVarChar).Value = Me.MemberInfo_Region.Text
                Cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = Me.MemberInfo_City.Text
                Cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Me.MemberInfo_FullAddress.Text
                Cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = ToEnglishNumber(Me.MemberInfo_PostalCode.Text)

                Cmd.CommandText = "Insert Into Members (ID,RegDate,MemberType,FullName,CoAgencyName,CoAgencyNamePersian,AgencyType,Email,Password,Phone,Mobile,TelegramID,Website,Region,City,Address,PostalCode) Values (@ID,@RegDate,@MemberType,@FullName,@CoAgencyName,@CoAgencyNamePersian,@AgencyType,@Email,@Password,@Phone,@Mobile,@TelegramID,@Website,@Region,@City,@Address,@PostalCode)"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Cmd.ExecuteNonQuery()

                SE = New SendEmail
                Dim CHE As New CreateHTMLEmail
                SE.Sender("Noreply@SproTours.com", "SproTours.com", "EmailMaster2017", Me.MemberInfo_Email.Text, CHE.CreateRegistration(Me.MemberInfo_FullName.Text, Me.MemberInfo_Email.Text, Me.MemberInfo_Password.Text, Me.MemberInfo_ID.Text, Server.MapPath("Email/Registration.htm")), "تایید ایمیل", "")


            Catch ex As Exception
                'Dim ERM As New ErrorLog
                'ERM.Log(Request, "Error", Request.Cookies("AdminSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "MemberInfo_BtnUpdate_Click")
            Finally
                SqlCon.SqlCon.Close()
            End Try

            '----------------------------------------------------------------------------------------------

            RefreshText()
        End If
    End Sub

    Private Function ToEnglishNumber(ByVal Numbers As String) As String

        Numbers = Numbers.Replace("۰", "0")
        Numbers = Numbers.Replace("۱", "1")
        Numbers = Numbers.Replace("۲", "2")
        Numbers = Numbers.Replace("۳", "3")
        Numbers = Numbers.Replace("۴", "4")
        Numbers = Numbers.Replace("۵", "5")
        Numbers = Numbers.Replace("۶", "6")
        Numbers = Numbers.Replace("۷", "7")
        Numbers = Numbers.Replace("۸", "8")
        Numbers = Numbers.Replace("۹", "9")

        Return Numbers
    End Function

    Private Sub RefreshText()
        Me.MemberInfo_ID.Text = Guid.NewGuid.ToString

        Me.MemberInfo_ddlUserType.Text = "آژانس"
        Me.MemberInfo_FullName.Text = String.Empty

        Me.MemberInfo_CoAgancyName.Text = String.Empty
        Me.MemberInfo_CoAgancyNamePersian.Text = String.Empty
        Me.MemberInfo_ddlAgencyType.Text = String.Empty
        'Me.MemberInfo_AgancyRegNo.Text = String.Empty
        'Me.MemberInfo_AgancyRegDate.Text = String.Empty

        Me.MemberInfo_Email.Text = String.Empty
        Me.MemberInfo_Password.Text = String.Empty
        Me.MemberInfo_LandPhone.Text = String.Empty
        Me.MemberInfo_Mobile.Text = String.Empty
        Me.MemberInfo_TelegramID.Text = String.Empty
        'Me.MemberInfo_Fax.Text = String.Empty

        Me.MemberInfo_Region.Text = String.Empty
        Me.MemberInfo_City.Text = String.Empty
        Me.MemberInfo_FullAddress.Text = String.Empty
        Me.MemberInfo_PostalCode.Text = String.Empty
    End Sub

    Protected Sub MemberInfo_btnUsers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberInfo_btnUsers.Click
        FillGvUsers()
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "loadusers", "$('#pageModalUsers').modal('show');", True)
    End Sub

    Private Sub FillGvUsers()
        Dim counter As Integer = 0
        Try
            Dim Dvw As New Data.DataView
            Dim Tbl As New Data.DataTable
            Tbl.Clear()

            Tbl.Columns.Add("کد")
            Tbl.Columns.Add("واحد اداری")
            Tbl.Columns.Add("نام و نام خانوادگی")
            Tbl.Columns.Add("ایمیل")

            'populating rows

            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Try
                Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(Me.MemberInfo_ID.Text)
                Cmd.Parameters.Add("@status", SqlDbType.Bit).Value = True

                Dim ExtraParam As String = String.Empty
                If Me.Users_MSG_ddlDepartment.Text <> "همه" Then
                    Cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = Me.Users_MSG_ddlDepartment.Text
                    ExtraParam = " And Department=@Department"
                End If


                Cmd.CommandText = "Select Row,Department,FullName,Email from Users where MemberID=@MemberID " & ExtraParam & " And status=@status order by FullName desc"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                While sdr.Read
                    Dim row As DataRow = Tbl.NewRow
                    counter += 1
                    row(0) = sdr(0)
                    row(1) = sdr(1)
                    row(2) = sdr(2)
                    row(3) = sdr(3)
                    Tbl.Rows.Add(row)
                End While
            Catch ex As Exception
                'Dim ERM As New ErrorLog
                'ERM.Log(Request, "Error", Request.Cookies("AdminSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "FillgvMembers")
            Finally
                SqlCon.SqlCon.Close()
            End Try

            Dvw = New Data.DataView(Tbl)
            Me.Users_gv.DataSource = Dvw
            Me.Users_gv.DataBind()
        Catch ex As Exception
            'Dim ERM As New ErrorLog
            'ERM.Log(Request, "Error", Request.Cookies("AdminSettings")("ID").ToString, ex.StackTrace, ex.Message, "", Request.Url.Segments.Last(), "FillgvNewOrders#2")
        End Try
        Me.Users_lblUserCount.Text = "(" & counter & ") کاربران "
    End Sub

    Protected Sub Users_btnAddEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Users_btnAddEdit.Click

        Dim V As New Validation
        Dim CAaC As New CheckAgenyAndCompany
        Dim MSGResult As Boolean = False

        Me.Users_MSG_Message.Text = String.Empty

        If Me.Users_MSG_FullName.Text = String.Empty Or Me.Users_MSG_FullName.Text.Length < 7 Then
            Me.Users_MSG_FullName.BorderColor = Drawing.Color.Red
            Me.Users_MSG_Message.Text += "<br />" & "* لطفاً نام و نام خانوادگی خود را وارد کنید"
            MSGResult = True
        Else
            Me.Users_MSG_FullName.BorderColor = Drawing.Color.Empty
        End If


        If Me.Users_MSG_Mobile.Text = "" Or Me.Users_MSG_Mobile.Text.Length < 11 Then
            Me.Users_MSG_Mobile.BorderColor = Drawing.Color.Red
            Me.Users_MSG_Message.Text += "<br />" & "* لطفاٌ شماره موبایل خود را بصورت صحیح وارد کنید"
            MSGResult = True
        Else
            Me.Users_MSG_Mobile.BorderColor = System.Drawing.Color.Empty
        End If

        If Me.Users_MSG_TelegramID.Text = "" Or Me.Users_MSG_TelegramID.Text.Length < 4 Then
            Me.Users_MSG_TelegramID.BorderColor = Drawing.Color.Red
            Me.Users_MSG_Message.Text += "<br />" & "* لطفاٌ آی دی تلگرام خود را وارد کنید"
            MSGResult = True
        Else
            Me.Users_MSG_TelegramID.BorderColor = System.Drawing.Color.Empty
        End If

        If Me.Users_MSG_ddlDepartment.Text = "" Then
            Me.Users_MSG_ddlDepartment.BorderColor = Drawing.Color.Red
            Me.Users_MSG_Message.Text += "<br />" & "* لطفاٌ بخش مربوطه را انتخاب کنید"
            MSGResult = True
        Else
            Me.Users_MSG_ddlDepartment.BorderColor = System.Drawing.Color.Empty
        End If

        If Me.Users_MSG_Password.Text = "" Or Me.Users_MSG_Password.Text.Length < 5 Then
            Me.Users_MSG_Password.BorderColor = Drawing.Color.Red
            Me.Users_MSG_Message.Text += "<br />" & "* رمز عبور باید حداقل 6 کاراکتر باشد"
            MSGResult = True
        Else
            Me.Users_MSG_Password.BorderColor = System.Drawing.Color.Empty
        End If

        Me.Users_MSG_Email.BorderColor = Drawing.Color.Empty
        If V.Email(Me.Users_MSG_Email.Text) Then
            If CAaC.CheckEmail(Me.Users_MSG_Email.Text, "") = True Then
                If V.CheckEmailAvailability(Me.Users_MSG_Email.Text) Then
                    If MSGResult = False Then
                        Dim SqlCon As New SqlConnectionSite
                        Dim Cmd As New SqlClient.SqlCommand
                        Try

                            Cmd.Parameters.Add("MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(Me.MemberInfo_ID.Text)
                            Cmd.Parameters.Add("FullName", SqlDbType.NVarChar).Value = Me.Users_MSG_FullName.Text
                            Cmd.Parameters.Add("Department", SqlDbType.NVarChar).Value = Me.Users_MSG_ddlDepartment.Text
                            Cmd.Parameters.Add("TelegramID", SqlDbType.NVarChar).Value = Me.Users_MSG_TelegramID.Text
                            Cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = ToEnglishNumber(Me.Users_MSG_Mobile.Text)
                            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Me.Users_MSG_Email.Text
                            Cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Me.Users_MSG_Password.Text
                            Cmd.Parameters.Add("Status", SqlDbType.Bit).Value = True

                            If Me.Users_btnAddEdit.Text = "ثبت" Then
                                Cmd.CommandText = "Insert Into Users (MemberID,FullName,Department,TelegramID,Mobile,Email,Password,Status) values (@MemberID,@FullName,@Department,@TelegramID,@Mobile,@Email,@Password,@Status)"
                            Else
                                Cmd.Parameters.Add("@Row", SqlDbType.Int).Value = Me.Users_txtRow.Text
                                Cmd.CommandText = "Update Users set FullName=@FullName,Department=@Department,TelegramID=@TelegramID,Mobile=@Mobile,Email=@Email,Password=@Password,Status=@Status Where Row=@Row"
                            End If

                            Cmd.Connection = SqlCon.SqlCon
                            SqlCon.SqlCon.Open()
                            Cmd.ExecuteNonQuery()

                            Me.Users_btnAddEdit.Text = "ثبت"
                            Me.Users_btnAddEdit.Visible = False
                            Me.Users_btnNew.Visible = True
                            Me.Users_MSG_Div.Visible = False
                            FillGvUsers()
                        Catch ex As Exception
                            Me.Users_MSG_Message.Text += "<br />" & ex.Message.ToString
                            'Dim ERM As New ErrorLog
                            'ERM.Log(Request, "Error", Request.Cookies("AdminSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "FillddlOP")
                        Finally
                            SqlCon.SqlCon.Close()
                        End Try

                        FrereshUsersText()
                    End If

                Else
                    Me.Users_MSG_Email.BorderColor = Drawing.Color.Red
                    Me.Users_MSG_Message.Text += "<br />" & "* ایمیل وارد شده وجود ندارد"
                End If
            Else
                Me.Users_MSG_Email.BorderColor = Drawing.Color.Red
                Me.Users_MSG_Message.Text += "<br />" & "* این ایمیل از قبل در سیستم ثبت می باشد"
            End If
        Else
            Me.Users_MSG_Email.BorderColor = Drawing.Color.Red
            Me.Users_MSG_Message.Text += "<br />" & "* لطفاٌ ایمیل خود را به صورت صحیح وارد کنید"
        End If

    End Sub

    Private Sub LoadUsers(ByVal UserCode As Integer)
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.Parameters.Add("@Row", SqlDbType.Int).Value = UserCode

            Cmd.CommandText = "Select FullName,Department,TelegramID,Mobile,Email,Password,Status from Users Where Row=@Row"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Me.Users_MSG_FullName.Text = sdr(0).ToString
                Me.Users_MSG_ddlDepartment.Text = sdr(1).ToString
                Me.Users_MSG_TelegramID.Text = sdr(2).ToString
                Me.Users_MSG_Mobile.Text = sdr(3).ToString
                Me.Users_MSG_Email.Text = sdr(4).ToString
                Me.Users_MSG_Password.Text = sdr(5).ToString
            End If

            Me.Users_btnAddEdit.Text = "اصلاح"
            Me.Users_MSG_Div.Visible = True
            Me.Users_btnAddEdit.Visible = True
            Me.Users_btnNew.Visible = False
        Catch ex As Exception
            'Dim ERM As New ErrorLog
            'ERM.Log(Request, "Error", Request.Cookies("AdminSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "FillddlOP")
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub

    Protected Sub Users_gv_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Users_gv.RowCommand
        Dim currentRowIndex As Integer = Int32.Parse(e.CommandArgument.ToString())
        Dim UserID As String = Me.Users_gv.Rows(currentRowIndex.ToString).Cells(1).Text

        Me.Users_txtRow.Text = UserID

        If (e.CommandName = "btnView") Then
            LoadUsers(UserID)
        End If

    End Sub

    Protected Sub Users_btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Users_btnNew.Click
        Me.Users_btnAddEdit.Text = "ثبت"
        Me.Users_btnAddEdit.Visible = True
        Me.Users_btnNew.Visible = False
        Me.Users_MSG_Div.Visible = True
        FrereshUsersText()
    End Sub

    Private Sub FrereshUsersText()
        Me.Users_MSG_FullName.Text = String.Empty
        Me.Users_MSG_ddlDepartment.Text = "رزرواسیون"
        Me.Users_MSG_TelegramID.Text = String.Empty
        Me.Users_MSG_Mobile.Text = String.Empty
        Me.Users_MSG_Email.Text = String.Empty
        Me.Users_MSG_Password.Text = String.Empty
    End Sub

End Class
