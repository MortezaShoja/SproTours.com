Imports System.Data
Imports System.Net
Imports System.Globalization

Partial Class hotel_details
    Inherits System.Web.UI.Page

    Private GHI As New GetHotelsInfo
    Private LTDB As LogToDatabase
    'Private RequestID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GHI = New GetHotelsInfo

        'Try
        '    Dim MID As String = Request.Cookies("UserSettings")("ID").ToString
        '    If MID.Length > 1 Then
        '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "BtnSendRequestDisplayMode('Show');", True)
        '    Else
        '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "BtnSendRequestDisplayMode('Hide');", True)
        '        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Login", "BtnSendRequestDisplayMode();", True)
        '    End If
        'Catch ex As Exception

        'End Try
        'Try
        '    If Session("submit") = "true" Then
        '        Session("submit") = "false"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "peygham();", True)
        '    End If
        'Catch ex As Exception

        'End Try
        Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim pathth As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim host As String = HttpContext.Current.Request.Url.Host

        Dim HotelID As String = String.Empty
        If IsPostBack = False Then

            Try
                HotelID = GHI.GetHotelID(Request.QueryString("hc"))
                Me.txtHotelName.Text = GetHotelNameString(Request.QueryString("hc"))
                If HotelID = "" Then
                    Response.Redirect("hotels.aspx")
                End If

                GetRoomTypes(Request.QueryString("ci"), Request.QueryString("co"))
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", "document.getElementById('start').value='" & Request.QueryString("ci") & "'; " & "document.getElementById('end').value='" & Request.QueryString("co") & "';", True)
                Me.ddlRooms.Text = Request.QueryString("r")
                Me.ddlAdult.Text = Request.QueryString("ac")
                Me.ddlChild.Text = Request.QueryString("c")
                Me.ddlChild1.Visible = False
                Me.ddlChild2.Visible = False
                Me.ddlChild3.Visible = False
                Me.ddlChild4.Visible = False
                Me.ddlChild5.Visible = False
                Me.ddlChild6.Visible = False
                Me.ddlChild7.Visible = False

                If Request.QueryString("c") > 0 Then
                    Me.divChildAges.Visible = True
                End If
                Select Case Request.QueryString("c")
                    Case Is = "1"
                        Me.ddlChild1.Text = Request.QueryString("c1")
                        Me.ddlChild1.Visible = True
                    Case Is = "2"
                        Me.ddlChild1.Text = Request.QueryString("c1")
                        Me.ddlChild2.Text = Request.QueryString("c2")
                        Me.ddlChild1.Visible = True
                        Me.ddlChild2.Visible = True
                    Case Is = "3"
                        Me.ddlChild1.Text = Request.QueryString("c1")
                        Me.ddlChild2.Text = Request.QueryString("c2")
                        Me.ddlChild3.Text = Request.QueryString("c3")
                        Me.ddlChild1.Visible = True
                        Me.ddlChild2.Visible = True
                        Me.ddlChild3.Visible = True
                    Case Is = "4"
                        Me.ddlChild1.Text = Request.QueryString("c1")
                        Me.ddlChild2.Text = Request.QueryString("c2")
                        Me.ddlChild3.Text = Request.QueryString("c3")
                        Me.ddlChild4.Text = Request.QueryString("c4")
                        Me.ddlChild1.Visible = True
                        Me.ddlChild2.Visible = True
                        Me.ddlChild3.Visible = True
                        Me.ddlChild4.Visible = True
                    Case Is = "5"
                        Me.ddlChild1.Text = Request.QueryString("c1")
                        Me.ddlChild2.Text = Request.QueryString("c2")
                        Me.ddlChild3.Text = Request.QueryString("c3")
                        Me.ddlChild4.Text = Request.QueryString("c4")
                        Me.ddlChild5.Text = Request.QueryString("c5")
                        Me.ddlChild1.Visible = True
                        Me.ddlChild2.Visible = True
                        Me.ddlChild3.Visible = True
                        Me.ddlChild4.Visible = True
                        Me.ddlChild5.Visible = True
                    Case Is = "6"
                        Me.ddlChild1.Text = Request.QueryString("c1")
                        Me.ddlChild2.Text = Request.QueryString("c2")
                        Me.ddlChild3.Text = Request.QueryString("c3")
                        Me.ddlChild4.Text = Request.QueryString("c4")
                        Me.ddlChild5.Text = Request.QueryString("c5")
                        Me.ddlChild6.Text = Request.QueryString("c6")
                        Me.ddlChild1.Visible = True
                        Me.ddlChild2.Visible = True
                        Me.ddlChild3.Visible = True
                        Me.ddlChild4.Visible = True
                        Me.ddlChild5.Visible = True
                        Me.ddlChild6.Visible = True
                    Case Is = "7"
                        Me.ddlChild1.Text = Request.QueryString("c1")
                        Me.ddlChild2.Text = Request.QueryString("c2")
                        Me.ddlChild3.Text = Request.QueryString("c3")
                        Me.ddlChild4.Text = Request.QueryString("c4")
                        Me.ddlChild5.Text = Request.QueryString("c5")
                        Me.ddlChild6.Text = Request.QueryString("c6")
                        Me.ddlChild7.Text = Request.QueryString("c7")
                        Me.ddlChild1.Visible = True
                        Me.ddlChild2.Visible = True
                        Me.ddlChild3.Visible = True
                        Me.ddlChild4.Visible = True
                        Me.ddlChild5.Visible = True
                        Me.ddlChild6.Visible = True
                        Me.ddlChild7.Visible = True
                End Select


                '----------------------- Facilities ---------------------
                Dim SqlCon As New SqlConnectionHotels
                Dim tmpFacilityType As String = String.Empty
                Dim tmpFacilities As String = String.Empty
                Try
                    Dim Cmd As New SqlClient.SqlCommand
                    Cmd.CommandText = "select FacilityType,Facility from Facilities where HotelID='" & HotelID & "' order by FacilityType,Facility"
                    Cmd.Connection = SqlCon.SqlCon
                    SqlCon.SqlCon.Open()
                    Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                    While sdr.Read
                        If tmpFacilityType = String.Empty Then
                            tmpFacilityType = sdr(0).ToString
                        End If

                        If tmpFacilityType <> sdr(0).ToString Then
                            Dim CFR As CreateFacilityRows.Generate
                            CFR = New CreateFacilityRows.Generate(tmpFacilityType, tmpFacilities)
                            Me.TbodyFacilities.Controls.Add(CFR)

                            tmpFacilityType = sdr(0).ToString
                            tmpFacilities = String.Empty
                        End If
                        tmpFacilities += sdr(1).ToString & "<br />"
                    End While

                    Dim CFR2 As CreateFacilityRows.Generate
                    CFR2 = New CreateFacilityRows.Generate(tmpFacilityType, tmpFacilities)
                    Me.TbodyFacilities.Controls.Add(CFR2)
                    tmpFacilityType = String.Empty
                    tmpFacilities = String.Empty

                Catch ex As Exception
                    Dim ERM As New ErrorLog
                    'ERM.Log()
                Finally
                    SqlCon.SqlCon.Close()
                End Try

                'Load Hotel Info------------------------------------------------------
                Dim Country As String = String.Empty
                Dim City As String = String.Empty

                Try
                    Dim Cmd As New SqlClient.SqlCommand
                    Cmd.CommandText = "select Country,City,HotelName,FullAddress,CheckIn,CheckOut,PetPolicy,Extras,FinePrint,Stars,Map from Hotels Where ID='" & HotelID & "'"
                    Cmd.Connection = SqlCon.SqlCon
                    SqlCon.SqlCon.Open()
                    Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                    If sdr.Read Then
                        Country = sdr(0).ToString
                        City = sdr(1).ToString
                        Me.lblHotelName.Text = sdr(2).ToString
                        Me.lblAddress.Text = " " & sdr(3).ToString
                        Me.lblCheckIn.Text = sdr(4).ToString.Replace(vbCrLf, "").Replace("Check-in", "").Trim
                        Me.lblCheckOut.Text = sdr(5).ToString.Replace(vbCrLf, "").Replace("Check-out", "").Trim
                        Me.lblPetPolicy.Text = sdr(6).ToString
                        Me.lblExtraBedAndChildren.Text += sdr(7).ToString.Replace(".", "<br/>").Replace("Children and Extra Beds", "")
                        Me.lblTheFinePrint.Text += sdr(8).ToString.Replace("The Fine Print ", "")
                        Select Case sdr(9).ToString
                            Case Is = "1"
                                Me.imgStars.ImageUrl = "Images/stars/1star.png"
                            Case Is = "2"
                                Me.imgStars.ImageUrl = "Images/stars/2stars.png"
                            Case Is = "3"
                                Me.imgStars.ImageUrl = "Images/stars/3stars.png"
                            Case Is = "4"
                                Me.imgStars.ImageUrl = "Images/stars/4stars.png"
                            Case Is = "5"
                                Me.imgStars.ImageUrl = "Images/stars/5stars.png"
                        End Select
                        'Response.Write(sdr(10).ToString)
                    End If
                Catch ex As Exception
                    Dim ERM As New ErrorLog
                    'ERM.Log()
                Finally
                    SqlCon.SqlCon.Close()
                End Try
                Try
                    Dim URLADDress As String = Server.MapPath(Request.ApplicationPath) & "/Hotels/Countries/" & Country & "/" & City & "/Hotels/" & HotelID & "/Images"
                    Dim Images() As String = System.IO.Directory.GetFiles(Server.MapPath(Request.ApplicationPath) & "/Hotels/Countries/" & Country & "/" & City & "/Hotels/" & HotelID & "/Images")
                    Dim Ilb As ImageLightBox.Generate
                    For I As Integer = 0 To Images.Length - 1
                        Dim tmp() As String = Images(I).Split("\")
                        Dim path As String = "Hotels/Countries/" & Country & "/" & City & "/Hotels/" & HotelID & "/Images/" & tmp(tmp.Length - 1)
                        Ilb = New ImageLightBox.Generate(path)
                        Me.DivImageLightBox.Controls.Add(Ilb)
                    Next
                Catch ex As Exception

                End Try

            Catch ex As Exception
                Response.Redirect("hotels.aspx")
            End Try
        End If


        'Dim Action As String = String.Empty
        'Action = Request.QueryString("Action")

        'If Action = "done" Then
        '    If Action = "done" And Session("submit") = "true" Then
        '        'If Action = "done" Then
        '        Session("submit") = "false"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "peygham();", True)
        '        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "openmessagebox(this);", True)
        '    End If
        'Else

    End Sub

    Private Function GetHotelNameString(ByVal HotelCode As String) As String

        Dim SqlCon As New SqlConnectionHotels
        Dim Cmd As New SqlClient.SqlCommand
        Dim Value As String = String.Empty
        Try

            Cmd.CommandText = "select HotelName,City,Country,HotelCode From Hotels Where HotelCode='" & HotelCode & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value += sdr(0).ToString & ", " & sdr(1).ToString & ", " & sdr(2).ToString & ", " & sdr(3).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    Private Sub GetRoomTypes(ByVal CheckIn As String, ByVal CheckOut As String)

        Dim HotelID As String = String.Empty
        HotelID = GHI.GetHotelID(Request.QueryString("hc"))

        Dim SqlCon As New SqlConnectionHotels
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Dim Cs As CreateRoomTypeRows.Generate
            Cmd.CommandText = "select ID,RoomType,Occupancy from Rooms Where HotelID='" & HotelID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Me.lblIds.InnerText = ""
            While sdr.Read
                Me.lblIds.InnerText += sdr(0).ToString & ","
                Dim SSQ As New SqlConnectionSite
                Cs = New CreateRoomTypeRows.Generate(sdr(0).ToString, sdr(1).ToString, sdr(2).ToString, CheckIn, CheckOut, SSQ.SqlCon.ConnectionString)
                Me.TblRoomTypesbody.Controls.Add(Cs)
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub

    Private Function GetHotelID(ByVal HotelCode As String) As String
        Dim Value As String = String.Empty

        Dim SqlCon As New SqlConnectionHotels
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "select ID from Hotels Where HotelCode='" & HotelCode & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value = sdr(0).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    'Protected Sub btnNewSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewSearch.Click
    '    Dim tmp() As String = Me.txtHotelName.Text.Split(",")
    '    Response.Redirect("hotel_details.aspx?HotelID=" & tmp(tmp.Length - 1).Trim & "&ci=" & Now.ToString("dd/MMM/yyyy", New CultureInfo("en-us")) & "&co=" & Now.AddDays(7).ToString("dd/MMM/yyyy", New CultureInfo("en-us")))
    'End Sub


    Protected Sub btnSendRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendRequest.Click
        Dim NoOfRooms As Integer = 0
        Dim NoOfChild As Integer = 0
        Dim NoOfAdults As Integer = 0

        Dim tmpRoomIDs() As String = Me.lblIds.InnerText.Split(",")
        Dim SqlCon As New SqlConnectionSite
        For i As Integer = 0 To tmpRoomIDs.Length - 2
            Dim tmpRoomID As String = tmpRoomIDs(i).Replace("-", "_")
            Dim tmpPrice() As String = Request.Form("txtPrice_" & tmpRoomID).Split(" ")
            Dim tmpTotalPrice() As String = Request.Form("txtTotalPrice_" & tmpRoomID).Split(" ")
            Dim tmpChkExtraBex As String = Request.Form("chkExtraBed_" & tmpRoomID)
            If tmpChkExtraBex = "on" Then
                tmpChkExtraBex = 1
            Else
                tmpChkExtraBex = 0
            End If
            If tmpTotalPrice(0) > 0 Then
                Dim tmpRoomCount As Integer = Integer.Parse(Request.Form("lstRoomCount_" & tmpRoomID))
                NoOfRooms += tmpRoomCount
                For k As Integer = 1 To tmpRoomCount
                    Try
                        Dim Cmd As New SqlClient.SqlCommand
                        Cmd.CommandText = "Insert Into HotelRequestsRoomTypes (RoomIDRow,RequestID,MemberID,RequestDate,RoomID,CheckIn,CheckOut,Adults,Child,Bed,Child1,Child2,Child3,Child4,Child5,Child6,Child7,Price,CurrencyType) values ('" & k & "','" & Request.QueryString("Rid") & "','" & Request.Cookies("UserSettings")("ID").ToString & "','" & Now.ToString & "','" & tmpRoomIDs(i) & "','" & Request.Form("start") & "','" & Request.Form("end") & "','" & Request.Form("lstAdult_" & tmpRoomID) & "','" & Request.Form("lstChilds_" & tmpRoomID) & "','" & tmpChkExtraBex & "','" & Request.Form("lstChild1_" & tmpRoomID) & "','" & Request.Form("lstChild2_" & tmpRoomID) & "','" & Request.Form("lstChild3_" & tmpRoomID) & "','" & Request.Form("lstChild4_" & tmpRoomID) & "','" & Request.Form("lstChild5_" & tmpRoomID) & "','" & Request.Form("lstChild6_" & tmpRoomID) & "','" & Request.Form("lstChild7_" & tmpRoomID) & "','" & tmpPrice(0) & "','" & tmpPrice(1) & "')"
                        Cmd.Connection = SqlCon.SqlCon
                        SqlCon.SqlCon.Open()
                        Cmd.ExecuteNonQuery()
                        NoOfChild += Request.Form("lstChilds_" & tmpRoomID)
                        NoOfAdults += Request.Form("lstAdult_" & tmpRoomID)

                    Catch ex As Exception
                        Dim ERM As New ErrorLog
                        'ERM.Log()
                    Finally
                        SqlCon.SqlCon.Close()
                    End Try
                Next
            End If
        Next

        'Generate Request Code--------------------------------------------------------
        GHI = New GetHotelsInfo
        Dim HotelID As String = GHI.GetHotelID(tmpRoomIDs(0), Request.Cookies("UserSettings")("ID").ToString)
        LTDB = New LogToDatabase
        LTDB.LogHotelRequests(Request.QueryString("Rid"), Request.Cookies("UserSettings")("ID").ToString, HotelID, Request.Form("start"), Request.Form("end"), NoOfRooms, NoOfChild, NoOfAdults, "")

        '-------------------------------------------------------

        Response.Redirect("HotelCheckIn.aspx?Rid=" & Request.QueryString("Rid"))
        'Dim SE As New SendEmail
        'Dim CH As New CreateHTMLEmail

        'SE.Sender("noreply@SproTours.com", "ContactUs Message", "NoReplyMaster2016", "g.guler@SproTours.com", "Name : " & Me.txtName.Text & "<br/>" & "Email : " & Me.txtEmail.Text & "<br/>" & "Phone : " & Me.txtTelephone.Text & "<br/>" & "<hr/>" & Me.txtMessage.Text.Replace(Chr(13), "<br/>"), Me.txtEmail.Text, "")
        'SE.Sender("noreply@SproTours.com", "ContactUs Message", "NoReplyMaster2016", "info@SproTours.com", "Name : " & Me.txtName.Text & "<br/>" & "Email : " & Me.txtEmail.Text & "<br/>" & "Phone : " & Me.txtTelephone.Text & "<br/>" & "<hr/>" & Me.txtMessage.Text.Replace(Chr(13), "<br/>"), Me.txtEmail.Text, "")
        'SE.Sender("noreply@SproTours.com", "Spro Tours", "NoReplyMaster2016", "r_shoja_h@yahoo.com", CH.CreateEmailNoChange(Server.MapPath("Email/ReservationResult.htm")), "درخواست رزرو هتل", "")
        'SE.Sender("noreply@SproTours.com", "Spro Tours", "NoReplyMaster2016", "mory.shoja@gmail.com", CH.CreateEmailNoChange(Server.MapPath("Email/ReservationResult.htm")), "درخواست رزرو هتل", "")
        'Dim CheckIn As String = String.Empty
        'Dim CheckOut As String = String.Empty

        'Try
        '    CheckIn = Request.Form("start")
        '    CheckOut = Request.Form("end")
        'Catch ex As Exception
        '    Response.Write("date <br /> " & ex.Message.ToString)
        'End Try
        'Dim ChildAges As String = "<table>"

        'If Me.ddlChild.Text >= 1 Then
        '    If Me.ddlChild1.Text > 0 Then
        '        ChildAges += "<tr><td style=""text-align: left"">کودک اول :</td><td style=""text-align: right"">" & Me.ddlChild1.Text & " سال " & "</td></tr>"
        '    Else
        '        ChildAges += "<tr><td style=""text-align: left"">کودک اول :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 2 Then
        '    If Me.ddlChild2.Text > 0 Then
        '        ChildAges += "<tr><td style=""text-align: left"">کودک دوم :</td><td style=""text-align: right"">" & Me.ddlChild2.Text & " سال " & "</td></tr>"
        '    Else
        '        ChildAges += "<tr><td style=""text-align: left"">کودک دوم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 3 Then
        '    If Me.ddlChild3.Text > 0 Then
        '        ChildAges += "<tr><td style=""text-align: left"">کودک سوم :</td><td style=""text-align: right"">" & Me.ddlChild3.Text & " سال " & "</td></tr>"
        '    Else
        '        ChildAges += "<tr><td style=""text-align: left"">کودک سوم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 4 Then
        '    If Me.ddlChild4.Text > 0 Then
        '        ChildAges += "<tr><td style=""text-align: left"">کودک چهارم :</td><td style=""text-align: right"">" & Me.ddlChild4.Text & " سال " & "</td></tr>"
        '    Else
        '        ChildAges += "<tr><td style=""text-align: left"">کودک چهارم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 5 Then
        '    If Me.ddlChild5.Text > 0 Then
        '        ChildAges += "<tr><td style=""text-align: left"">کودک پنجم :</td><td style=""text-align: right"">" & Me.ddlChild5.Text & " سال " & "</td></tr>"
        '    Else
        '        ChildAges += "<tr><td style=""text-align: left"">کودک پنجم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 6 Then
        '    If Me.ddlChild6.Text > 0 Then
        '        ChildAges += "<tr><td style=""text-align: left"">کودک ششم :</td><td style=""text-align: right"">" & Me.ddlChild6.Text & " سال " & "</td></tr>"
        '    Else
        '        ChildAges += "<tr><td style=""text-align: left"">کودک ششم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 7 Then
        '    If Me.ddlChild7.Text > 0 Then
        '        ChildAges += "<tr><td style=""text-align: left"">کودک هفتم :</td><td style=""text-align: right"">" & Me.ddlChild7.Text & " سال " & "</td></tr>"
        '    Else
        '        ChildAges += "<tr><td style=""text-align: left"">کودک هفتم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
        '    End If
        'End If

        'ChildAges += "</table>"
        ''---------------------------------------- Child Ages English

        'Dim EnChildAges As String = "<table>"

        'If Me.ddlChild.Text >= 1 Then
        '    If Me.ddlChild1.Text > 0 Then
        '        If Me.ddlChild1.Text = 1 Then
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 1 :</td><td style=""text-align: left"">" & Me.ddlChild1.Text & " year " & "</td></tr>"
        '        Else
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 1 :</td><td style=""text-align: left"">" & Me.ddlChild1.Text & " years " & "</td></tr>"
        '        End If
        '    Else
        '        EnChildAges += "<tr><td style=""text-align: right"">Child 1 :</td><td style=""text-align: left""> Under 1 year</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 2 Then
        '    If Me.ddlChild2.Text > 0 Then
        '        If Me.ddlChild2.Text = 1 Then
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 2 :</td><td style=""text-align: left"">" & Me.ddlChild2.Text & " year " & "</td></tr>"
        '        Else
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 2 :</td><td style=""text-align: left"">" & Me.ddlChild2.Text & " years " & "</td></tr>"
        '        End If
        '    Else
        '        EnChildAges += "<tr><td style=""text-align: right"">Child 2 :</td><td style=""text-align: left""> Under 1 year</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 3 Then
        '    If Me.ddlChild3.Text > 0 Then
        '        If Me.ddlChild3.Text = 1 Then
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 3 :</td><td style=""text-align: left"">" & Me.ddlChild3.Text & " year " & "</td></tr>"
        '        Else
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 3 :</td><td style=""text-align: left"">" & Me.ddlChild3.Text & " years " & "</td></tr>"
        '        End If
        '    Else
        '        EnChildAges += "<tr><td style=""text-align: right"">Child 3 :</td><td style=""text-align: left""> Under 1 year</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 4 Then
        '    If Me.ddlChild4.Text > 0 Then
        '        If Me.ddlChild4.Text = 1 Then
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 4 :</td><td style=""text-align: left"">" & Me.ddlChild4.Text & " year " & "</td></tr>"
        '        Else
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 4 :</td><td style=""text-align: left"">" & Me.ddlChild4.Text & " years " & "</td></tr>"
        '        End If
        '    Else
        '        EnChildAges += "<tr><td style=""text-align: right"">Child 4 :</td><td style=""text-align: left""> Under 1 year</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 5 Then
        '    If Me.ddlChild5.Text > 0 Then
        '        If Me.ddlChild5.Text = 1 Then
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 5 :</td><td style=""text-align: left"">" & Me.ddlChild5.Text & " year " & "</td></tr>"
        '        Else
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 5 :</td><td style=""text-align: left"">" & Me.ddlChild5.Text & " years " & "</td></tr>"
        '        End If
        '    Else
        '        EnChildAges += "<tr><td style=""text-align: right"">Child 5 :</td><td style=""text-align: left""> Under 1 year</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 6 Then
        '    If Me.ddlChild6.Text > 0 Then
        '        If Me.ddlChild6.Text = 1 Then
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 6 :</td><td style=""text-align: left"">" & Me.ddlChild6.Text & " year " & "</td></tr>"
        '        Else
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 6 :</td><td style=""text-align: left"">" & Me.ddlChild6.Text & " years " & "</td></tr>"
        '        End If
        '    Else
        '        EnChildAges += "<tr><td style=""text-align: right"">Child 6 :</td><td style=""text-align: left""> Under 1 year</td></tr>"
        '    End If
        'End If

        'If Me.ddlChild.Text >= 7 Then
        '    If Me.ddlChild7.Text > 0 Then
        '        If Me.ddlChild7.Text = 1 Then
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 7 :</td><td style=""text-align: left"">" & Me.ddlChild7.Text & " year " & "</td></tr>"
        '        Else
        '            EnChildAges += "<tr><td style=""text-align: right"">Child 7 :</td><td style=""text-align: left"">" & Me.ddlChild7.Text & " years " & "</td></tr>"
        '        End If
        '    Else
        '        EnChildAges += "<tr><td style=""text-align: right"">Child 7 :</td><td style=""text-align: left""> Under 1 year</td></tr>"
        '    End If
        'End If
        'EnChildAges += "</table>"
        ''Response.Write("End of Tables <br /> ")
        ''-----------------------------------------------
        'Dim RoomCount As String = "0"

        'RoomCount = Request.Form.Get(Me.txtOwerviewRooms.UniqueID)
        ''Request.Form.Get(Me.txtOwerviewRooms.UniqueID)


        'Dim RoomTypes As String = String.Empty

        'RoomTypes = Request.Form.Get(Me.txtOverViewRooms.UniqueID)

        'RequestID = Guid.NewGuid.ToString
        'Dim HotelID As String = String.Empty
        'HotelID = GHI.GetHotelID(Request.QueryString("HotelID"))
        'LTDB = New LogToDatabase
        'Dim ermsg As String = LTDB.LogHotelRequests(RequestID, Request.Cookies("UserSettings")("ID").ToString, HotelID, CheckIn, CheckOut, RoomCount, Me.ddlAdult.Text, Me.ddlChild.Text, Me.ddlChild1.Text, Me.ddlChild2.Text, Me.ddlChild3.Text, Me.ddlChild4.Text, Me.ddlChild5.Text, Me.ddlChild6.Text, Me.ddlChild7.Text, RoomTypes, Me.txtLastOverviewDescription.Text)
        ''Response.Write(" <br /> Save too database <br /> ")


        'Dim RequestCode As String = "0"
        'Try
        '    RequestCode = GHI.GetRequestCode(RequestID)
        'Catch ex As Exception
        '    'Response.Write("<br /> Error RequestCode <br /> " & ex.Message.ToString)
        'End Try

        'Dim GMI As New GetMemberInfo
        'Dim MemberInfo() As String = GMI.GetMemberInfo(Request.Cookies("UserSettings")("ID").ToString)
        'Try
        '    SE.Sender("noreply@SproTours.com", "Sprotours.com", "NoReplyMaster2016", MemberInfo(2), CH.CreateHotelReservationRequestEmail(RequestCode, Me.lblHotelName.Text, Me.lblAddress.Text, CheckIn, CheckOut, RoomCount, Me.ddlAdult.Text, Me.ddlChild.Text, ChildAges, RoomTypes, MemberInfo(0), MemberInfo(3), MemberInfo(4), MemberInfo(5), MemberInfo(2), Me.txtLastOverviewDescription.Text, Server.MapPath("Email/Hotel_CustomerReservationRequest.htm")), "درخواست رزرو هتل", "")
        '    'SE.Sender("noreply@SproTours.com", "Sprotours.com", "NoReplyMaster2016", "reservation@SproTours.com", CH.CreateHotelReservationRequestEmail(RequestCode, Me.lblHotelName.Text, Me.lblAddress.Text, CheckIn, CheckOut, RoomCount, Me.ddlAdult.Text, Me.ddlChild.Text, EnChildAges, RoomTypes, Me.txtLastOverviewAgancy.Text, Me.txtLastOverviewName.Text, Me.txtLastOverviewFamily.Text, Me.txtLastOverviewPhone.Text, Me.txtLastOverviewEmail.Text, Me.txtLastOverviewDescription.Text, Server.MapPath("Email/Hotel_HotelReservationRequest.htm")), "Hotel Reservation Request", "")

        '    If MemberInfo(0) <> "" Then
        '        SE.Sender("noreply@SproTours.com", MemberInfo(0) & " | " & MemberInfo(3) & " " & MemberInfo(4), "NoReplyMaster2016", "reservation@SproTours.com", CH.CreateHotelReservationRequestEmail(RequestCode, Me.lblHotelName.Text, Me.lblAddress.Text, CheckIn, CheckOut, RoomCount, Me.ddlAdult.Text, Me.ddlChild.Text, EnChildAges, RoomTypes, MemberInfo(0), MemberInfo(3), MemberInfo(4), MemberInfo(5), MemberInfo(2), Me.txtLastOverviewDescription.Text, Server.MapPath("Email/Hotel_ReservationRequest.htm")), "Hotel Reservation Request", "")
        '    Else
        '        SE.Sender("noreply@SproTours.com", MemberInfo(3) & " " & MemberInfo(4), "NoReplyMaster2016", "reservation@SproTours.com", CH.CreateHotelReservationRequestEmail(RequestCode, Me.lblHotelName.Text, Me.lblAddress.Text, CheckIn, CheckOut, RoomCount, Me.ddlAdult.Text, Me.ddlChild.Text, EnChildAges, RoomTypes, MemberInfo(0), MemberInfo(3), MemberInfo(4), MemberInfo(5), MemberInfo(2), Me.txtLastOverviewDescription.Text, Server.MapPath("Email/Hotel_ReservationRequest.htm")), "Hotel Reservation Request", "")
        '    End If
        'Catch ex As Exception
        '    'Response.Write("Send EMail <br /> " & ex.Message.ToString & " <br />")
        'End Try
        'Session("submit") = "true"
        ''Response.Write("End <br /> ")
        'Response.Redirect("~/Default.aspx")

    End Sub

    Protected Sub ddlChild_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlChild.SelectedIndexChanged

        Select Case Me.ddlChild.Text
            Case Is = 0
                Me.ddlChild1.Text = ""
                Me.ddlChild2.Text = ""
                Me.ddlChild3.Text = ""
                Me.ddlChild4.Text = ""
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 1
                Me.ddlChild2.Text = ""
                Me.ddlChild3.Text = ""
                Me.ddlChild4.Text = ""
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 2
                Me.ddlChild3.Text = ""
                Me.ddlChild4.Text = ""
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 3
                Me.ddlChild4.Text = ""
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 4
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 5
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 6
                Me.ddlChild7.Text = ""
        End Select

        Me.ddlChild1.Visible = False
        Me.ddlChild2.Visible = False
        Me.ddlChild3.Visible = False
        Me.ddlChild4.Visible = False
        Me.ddlChild5.Visible = False
        Me.ddlChild6.Visible = False
        Me.ddlChild7.Visible = False
        Me.divChildAges.Visible = False

        If Me.ddlChild.Text > 0 Then
            Me.divChildAges.Visible = True
        End If

        Select Case Me.ddlChild.Text
            Case Is = "1"
                Me.ddlChild1.Visible = True
            Case Is = "2"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
            Case Is = "3"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
            Case Is = "4"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
                Me.ddlChild4.Visible = True
            Case Is = "5"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
                Me.ddlChild4.Visible = True
                Me.ddlChild5.Visible = True
            Case Is = "6"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
                Me.ddlChild4.Visible = True
                Me.ddlChild5.Visible = True
                Me.ddlChild6.Visible = True
            Case Is = "7"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
                Me.ddlChild4.Visible = True
                Me.ddlChild5.Visible = True
                Me.ddlChild6.Visible = True
                Me.ddlChild7.Visible = True
        End Select
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim tmp() As String = Me.txtHotelName.Text.Split(",")
        Dim childAges As String = String.Empty

        If Me.ddlChild.Text >= "1" Then
            childAges = "&c1=" & Me.ddlChild1.Text
        End If
        If Me.ddlChild.Text >= "2" Then
            childAges += "&c2=" & Me.ddlChild2.Text
        End If
        If Me.ddlChild.Text >= "3" Then
            childAges += "&c3=" & Me.ddlChild3.Text
        End If
        If Me.ddlChild.Text >= "4" Then
            childAges += "&c4=" & Me.ddlChild4.Text
        End If
        If Me.ddlChild.Text >= "5" Then
            childAges += "&c5=" & Me.ddlChild5.Text
        End If
        If Me.ddlChild.Text >= "6" Then
            childAges += "&c6=" & Me.ddlChild6.Text
        End If
        If Me.ddlChild.Text = "7" Then
            childAges += "&c7=" & Me.ddlChild7.Text
        End If

        Response.Redirect("hotel_details.aspx?Rid=" & Guid.NewGuid.ToString & "&hc=" & tmp(tmp.Length - 1).Trim & "&ci=" & Request.Form("start") & "&co=" & Request.Form("end") & "&r=" & Me.ddlRooms.Text & "&ac=" & Me.ddlAdult.Text & "&c=" & Me.ddlChild.Text & childAges)

    End Sub

End Class

