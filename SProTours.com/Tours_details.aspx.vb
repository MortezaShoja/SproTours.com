Imports System.Data
Imports System.Globalization

Partial Class Tours_details
    Inherits System.Web.UI.Page
    Private LTDB As LogToDatabase
    Private RequestID As String
    Private TourID As String
    Private MC As MoneyCodec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MemberID As String = String.Empty
        Try
            MemberID = Request.Cookies("UserSettings")("ID").ToString.ToString
        Catch ex As Exception
        End Try


        If MemberID <> String.Empty Then
            Try

                TourID = Request.QueryString("cid")
                Dim Action As String = String.Empty
                Action = Request.QueryString("Action")

                If Action = "done" Then
                    If Action = "done" And Session("submit") = "true" Then
                        'If Action = "done" Then
                        Session("submit") = "false"
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "peygham();", True)
                        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "openmessagebox(this);", True)
                    End If
                Else

                    If TourID = "" Then
                        Response.Redirect("Tours.aspx")
                    End If
                End If
            Catch ex As Exception
                Response.Redirect("Tours.aspx")
            End Try
            If IsPostBack = False Then
                CreateToursSubcategory()
            End If
        Else
            Response.Redirect("default.aspx?L=2")
        End If
    End Sub

    Private Sub FillDLLAges(ByVal MaxChildAge As Integer)
        Me.ddlChild1.Items.Clear()
        Me.ddlChild2.Items.Clear()
        Me.ddlChild3.Items.Clear()
        Me.ddlChild4.Items.Clear()
        Me.ddlChild5.Items.Clear()
        Me.ddlChild6.Items.Clear()
        Me.ddlChild7.Items.Clear()

        Me.ddlChild1.Items.Add("")
        For I As Integer = 0 To MaxChildAge
            Me.ddlChild1.Items.Add(I)
        Next

        Me.ddlChild2.Items.Add("")
        For I As Integer = 0 To MaxChildAge
            Me.ddlChild2.Items.Add(I)
        Next

        Me.ddlChild3.Items.Add("")
        For I As Integer = 0 To MaxChildAge
            Me.ddlChild3.Items.Add(I)
        Next

        Me.ddlChild4.Items.Add("")
        For I As Integer = 0 To MaxChildAge
            Me.ddlChild4.Items.Add(I)
        Next

        Me.ddlChild5.Items.Add("")
        For I As Integer = 0 To MaxChildAge
            Me.ddlChild5.Items.Add(I)
        Next

        Me.ddlChild6.Items.Add("")
        For I As Integer = 0 To MaxChildAge
            Me.ddlChild6.Items.Add(I)
        Next

        Me.ddlChild7.Items.Add("")
        For I As Integer = 0 To MaxChildAge
            Me.ddlChild7.Items.Add(I)
        Next


    End Sub

    Private Function GetCurrencyRate(ByVal CurrencySign As String) As Decimal
        Dim value As String = 0

        Dim SqlCon As New SqlConnectionTurkorder

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@CurrencySign", SqlDbType.NVarChar).Value = CurrencySign
            Cmd.CommandText = "Select IstanbulRate From Exchange Where CurrencySign=@CurrencySign"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function

    Private Sub LoadImages(ByVal TourID As String)
        Try
            'Dim Images() As String = System.IO.Directory.GetFiles(Server.MapPath(Request.ApplicationPath) & "\Packages\TourDetails\" & TourID)
            Dim OurServerPath As String = "C:\Inetpub\vhosts\sprotours.com\admin.sprotours.com"
            Dim Images() As String = System.IO.Directory.GetFiles(OurServerPath & "\Packages\TourDetails\" & TourID)
            Me.DivImageLightBox.InnerHtml = String.Empty

            For I As Integer = 0 To Images.Length - 1
                Dim tmpImageArr() As String = Images(I).Split("\")
                Dim CurrImage As String = "http://admin.sprotours.com/Packages/TourDetails/" & TourID & "/" & tmpImageArr(tmpImageArr.Length - 1)
                Me.DivImageLightBox.InnerHtml += "<a href=""" & CurrImage & """><img src=""" & CurrImage & """></a>"
            Next
        Catch ex As Exception
            Dim CurrImage As String = "http://admin.SproTours.com/Packages/Tours/no-photo.png"
            Me.DivImageLightBox.InnerHtml += "<a href=""" & CurrImage & """><img src=""" & CurrImage & """></a>"
        End Try
    End Sub

    Private Sub CreateToursSubcategory()
        MC = New MoneyCodec

        Dim SqlCon As New SqlConnectionSite

        Try
            Dim Cmd As New SqlClient.SqlCommand
            'Cmd.CommandText = "select D.ID,ISNULL(S.SubCategory, H.HeadCategory ) as TourName,D.CurrencyType,D.Price,D.Discount,D.AgencyCommission,D.ChildDiscount,D.ChildAge,D.TourPlan,D.TourRules,D.TourTime,D.StartDate,D.Shanbe,D.YekShanbe,D.DoShanbe,D.SeShanbe,D.ChaharShanbe,D.PanjShanbe,D.Jome from TourDetails D inner join TourHeadCategory H on D.HeadCategoryID=H.HeadCategoryID left join TourSubCategory S on D.SubCategoryID=S.ID where D.ID='" & TourID & "'"
            '                          0    1           2        3          4           5            6              7           8          9        10       11     12      13       14      15        16       17         18          19      20     21        22      23       24
            Cmd.CommandText = "select ID,TourName,CurrencyType,Price,DiscountFromQTY,Discount,AgencyCommission,ChildDiscount,ChildAge,TourPlan,TourRules,TourTime,Extras,StartDate,Shanbe,YekShanbe,DoShanbe,SeShanbe,ChaharShanbe,PanjShanbe,Jome,AdultMin,AdultMax,ChildMin,ChildMax from TourDetails Where ID='" & TourID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then

                LoadImages(sdr(0).ToString)
                FillExtraServices(sdr(0).ToString)
                Me.lblTourName.Text = sdr(1).ToString
                'CurrencyType(0),AdultPrice(1),DiscountFromQTY(2),Discount(3),AgencyCommission(4),ChildDiscount(5),ChildAge(6)
                Session("TourData") = sdr(2).ToString & "|" & sdr(3).ToString & "|" & sdr(4).ToString & "|" & sdr(5).ToString & "|" & sdr(6).ToString & "|" & sdr(7).ToString & "|" & sdr(8).ToString
                FillDLLAges(sdr(8))
                Me.lblTourPlan.Text = sdr(9).ToString.Replace(vbCrLf, "<br/>")
                Me.lblTourRules.Text = sdr(10).ToString.Replace(vbCrLf, "<br/>")
                Me.lblTourTime.Text = sdr(11).ToString.Replace(vbCrLf, "<br/>")
                Me.lblTourExtras.Text = sdr(12).ToString.Replace(vbCrLf, "<br/>")
                'sdr(13)
                Dim InactiveWeekdays As String = String.Empty
                If Boolean.Parse(sdr(14)) = False Then
                    InactiveWeekdays += "day == 6 || " ' Shanbe
                End If
                If Boolean.Parse(sdr(15)) = False Then
                    InactiveWeekdays += "day == 0 || " ' Yek Shanbe
                End If
                If Boolean.Parse(sdr(16)) = False Then
                    InactiveWeekdays += "day == 1 || " ' Do Shanbe
                End If
                If Boolean.Parse(sdr(17)) = False Then
                    InactiveWeekdays += "day == 2 || " ' Se Shanbe
                End If
                If Boolean.Parse(sdr(18)) = False Then
                    InactiveWeekdays += "day == 3 || " ' Chahar Shanbe
                End If
                If Boolean.Parse(sdr(19)) = False Then
                    InactiveWeekdays += "day == 4 || " ' Panj Shanbe
                End If
                If Boolean.Parse(sdr(20)) = False Then
                    InactiveWeekdays += "day == 5 || " ' Jome
                End If
                Try
                    InactiveWeekdays = Mid(InactiveWeekdays, 1, InactiveWeekdays.Length - 4)
                Catch ex As Exception

                End Try
                LoadDatePickerJS(InactiveWeekdays)

                Me.ddlAdult.Items.Clear()
                For I As Integer = sdr(21) To sdr(22)
                    Me.ddlAdult.Items.Add(I)
                Next

                Me.ddlChild.Items.Clear()
                For I As Integer = sdr(23) To sdr(24)
                    Me.ddlChild.Items.Add(I)
                Next
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        PriceCalc()
    End Sub

    Private Sub LoadDatePickerJS(ByVal InactiveWeekdays As String)
        Dim JS As String = String.Empty
        Try

            'Dim Today As DateTime = Now.ToString(New CultureInfo("en-us"))

            Me.txtSelectedDate.Text = ConvertEUDateToUSDate()

            If InactiveWeekdays <> String.Empty Then
                JS = "function DisableMonday(date) {" & _
                                        " var day = date.getDay();" & _
                                        " if (" & InactiveWeekdays & ") {" & _
                                                "return [false];" & _
                                            "} else {" & _
                                                " return [true];" & _
                                        "}" & _
                                    "}" & _
                                    " $(function () {" & _
                                        " $(""#datepicker"").datepicker({" & _
                                            " changeMonth: true," & _
                                            " changeYear: true," & _
                                            " beforeShowDay: DisableMonday" & _
                                        "});" & _
                                        " $( ""#datepicker"" ).datepicker( ""option"", ""dateFormat"", ""dd/M/yy"" );" & _
                                    " }); " & _
                                    " $('document').ready(function () { " & _
                                        " document.getElementById(""datepicker"").value = '" & ConvertEUDateToUSDate() & "'; " & _
                                    " }); "
            Else
                JS = "$(function () { $(""#datepicker"").datepicker(); }); " & _
                    " $('document').ready(function () { " & _
                        " document.getElementById(""datepicker"").value = '" & ConvertEUDateToUSDate() & "'; " & _
                    " }); "
            End If

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error to load datetimpicker <br/> " & ex.Message.Replace("'", "") & Now.Date.ToString("dd/MM/yyyy") & "');", True)
        End Try
        '" showButtonPanel: true, " & _ ' Show Today

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "dtpicker", JS, True)

    End Sub

    Private Function ConvertEUDateToUSDate() As String
        Dim value As String = String.Empty

        Dim today As String = Now.Date.ToString("dd/MM/yyyy")
        Dim tmpvalue() = (today.Replace(".", "/")).Split("/")

        Dim tmpMonth As String = String.Empty
        Select Case Integer.Parse(tmpvalue(1))
            Case Is = 1
                tmpMonth = "Jan"
            Case Is = 2
                tmpMonth = "Feb"
            Case Is = 3
                tmpMonth = "Mar"
            Case Is = 4
                tmpMonth = "Apr"
            Case Is = 5
                tmpMonth = "May"
            Case Is = 6
                tmpMonth = "Jun"
            Case Is = 7
                tmpMonth = "Jul"
            Case Is = 8
                tmpMonth = "Aug"
            Case Is = 9
                tmpMonth = "Sep"
            Case Is = 10
                tmpMonth = "Oct"
            Case Is = 11
                tmpMonth = "Nov"
            Case Is = 12
                tmpMonth = "Dec"
        End Select

        value = tmpvalue(0) & "/" & tmpMonth & "/" & tmpvalue(2)

        Return value
    End Function

    Protected Sub btnSendRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendRequest.Click


        'Dim SE As New SendEmail
        'Dim CH As New CreateHTMLEmail

        ''SE.Sender("noreply@SproTours.com", "ContactUs Message", "NoReplyMaster2016", "g.guler@SproTours.com", "Name : " & Me.txtName.Text & "<br/>" & "Email : " & Me.txtEmail.Text & "<br/>" & "Phone : " & Me.txtTelephone.Text & "<br/>" & "<hr/>" & Me.txtMessage.Text.Replace(Chr(13), "<br/>"), Me.txtEmail.Text, "")
        ''SE.Sender("noreply@SproTours.com", "ContactUs Message", "NoReplyMaster2016", "info@SproTours.com", "Name : " & Me.txtName.Text & "<br/>" & "Email : " & Me.txtEmail.Text & "<br/>" & "Phone : " & Me.txtTelephone.Text & "<br/>" & "<hr/>" & Me.txtMessage.Text.Replace(Chr(13), "<br/>"), Me.txtEmail.Text, "")
        ''SE.Sender("noreply@SproTours.com", "Spro Tours", "NoReplyMaster2016", "r_shoja_h@yahoo.com", CH.CreateEmailNoChange(Server.MapPath("Email/ReservationResult.htm")), "درخواست رزرو هتل", "")
        ''SE.Sender("noreply@SproTours.com", "Spro Tours", "NoReplyMaster2016", "mory.shoja@gmail.com", CH.CreateEmailNoChange(Server.MapPath("Email/ReservationResult.htm")), "درخواست رزرو هتل", "")

        LTDB = New LogToDatabase


        'CurrencyType(0),AdultPrice(1),DiscountFromQTY(2),Discount(3),AgencyCommission(4),ChildDiscount(5),ChildAge(6)
        Dim TourData() As String = Session("TourData").ToString.Split("|")

        Dim CurrencyType As String = TourData(0)
        Dim CurrencyRate As Decimal = GetCurrencyRate(TourData(0))
        Dim AdultSinglePrice As Decimal = TourData(1)
        Dim DiscountFromQTY As Integer = TourData(2)
        Dim Discount As Decimal = TourData(3)
        Dim AgencyCommission As Decimal = TourData(4)
        Dim ChildDiscount As Decimal = TourData(5)
        Dim ChildAge As Integer = TourData(6)

        Dim TotalPrices() As String = PriceCalc()

        RequestID = Guid.NewGuid.ToString

        Dim MemberID As String = String.Empty
        Try
            MemberID = Request.Cookies("UserSettings")("ID").ToString.ToString
        Catch ex As Exception
        End Try

        Dim ExtraServices() As String = Me.ExtraServicestxtSumTotal.Value.Split(" ")

        LTDB.LogTourRequests(RequestID, Now.ToString, MemberID, TourID, Me.txtSelectedDate.Text, Me.ddlAdult.Text, Me.ddlChild.Text, ChildAge, Me.ddlChild1.Text, Me.ddlChild2.Text, Me.ddlChild3.Text, Me.ddlChild4.Text, Me.ddlChild5.Text, Me.ddlChild6.Text, Me.ddlChild7.Text, Me.txtName.Text, Me.txtFamily.Text, Me.txtPhone.Text, Me.txtEmail.Text, Me.txtDescription.Text, CurrencyType, CurrencyRate, AdultSinglePrice, DiscountFromQTY, Discount, AgencyCommission, ChildDiscount, Me.txtServicesDB.Value, ExtraServices(0), TotalPrices(0), TotalPrices(1))

        Dim RequestCode As Integer = LTDB.GetTourRequestCode(RequestID)

        'Dim CHE As New CreateHTMLEmail
        'CHE.CreateToursVoucher(RequestCode, Server.MapPath("Email/Tour_Voucher.htm"))

        '---------------------------- Dargahe Pardakht
        ' ''Dim MerchantID As String = "4352504"
        ' ''Dim Password As String = "g42WUKbQq"
        ' ''Dim ws As New com.arianpal.merchant.WebService
        ' ''Try
        ' ''    Dim Result As PaymentRequestResult = ws.RequestPayment(MerchantID, Password, TotalPrice, " شماره پیگیری تراکنش : " & RequestCode, Me.txtName.Text & " " & Me.txtFamily.Text, Me.txtEmail.Text, Me.txtPhone.Text, RequestCode, "http://www.SproTours.com/Tours.aspx?RC=" & RequestCode)
        ' ''    If Result.ResultStatus = ResultValues.Succeed Then
        ' ''        Response.Redirect(Result.PaymentPath.ToString)
        ' ''    Else
        ' ''        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "message", "MessageBox('خطا','خطا در برقراری ارتباط با درگاه پرداخت');", True)
        ' ''    End If

        ' ''Catch ex As Exception
        ' ''    'Session("MSG") = "113" & "<br />" & ex.Message.ToString
        ' ''    'Response.Redirect("Message.aspx")
        ' ''End Try

        'Dim RequestCode As Integer = 0
        'Dim GTI As New GetTourInfo
        'RequestCode = GTI.GetRequestCode(RequestID)

        'SE.Sender("noreply@SproTours.com", "Sprotours.com", "NoReplyMaster2016", Me.txtEmail.Text, CH.CreateToursReservationRequestEmail(RequestCode, Me.lblTourName.Text, CheckIn, Me.ddlAdult.Text, Me.ddlChild.Text, ChildAges, Me.txtName.Text, Me.txtFamily.Text, Me.txtPhone.Text, Me.txtEmail.Text, Me.txtDescription.Text, Server.MapPath("Email/Tour_CustomerReservationRequest.htm")), "درخواست رزرو پکیج تور", "")
        'SE.Sender("noreply@SproTours.com", "Sprotours.com", "NoReplyMaster2016", "reservation@SproTours.com", CH.CreateToursReservationRequestEmail(RequestCode, Me.lblTourName.Text, CheckIn, Me.ddlAdult.Text, Me.ddlChild.Text, ChildAges, Me.txtName.Text, Me.txtFamily.Text, Me.txtPhone.Text, Me.txtEmail.Text, Me.txtDescription.Text, Server.MapPath("Email/Tour_TourReservationRequest.htm")), "Tour Reservation Request", "")
        'SE.Sender("noreply@SproTours.com", "Sprotours.com", "NoReplyMaster2016", "reservation@SproTours.com", CH.CreateToursReservationRequestEmail(RequestCode, Me.lblTourName.Text, CheckIn, Me.ddlAdult.Text, Me.ddlChild.Text, ChildAges, Me.txtName.Text, Me.txtFamily.Text, Me.txtPhone.Text, Me.txtEmail.Text, Me.txtDescription.Text, Server.MapPath("Email/Tour_ReservationRequest.htm")), "Tour Reservation Request", "")

        'Session("submit") = "true"
        'Response.Redirect("Tours.aspx?Action=done")

        Session("TourData") = String.Empty


        Response.Redirect("Tours.aspx")
    End Sub

    Protected Sub ddlAdult_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAdult.TextChanged
        PriceCalc()
    End Sub

    Protected Sub ddlChild_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlChild.TextChanged
        PriceCalc()
    End Sub

    Protected Sub btnPriceCalc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPriceCalc.Click
        PriceCalc()
    End Sub

    Private Function PriceCalc() As Array

        Dim Value(1) As String

        MC = New MoneyCodec

        Dim AdultCount As Integer = Me.ddlAdult.Text
        Dim ChildCount As Integer = Me.ddlChild.Text

        'CurrencyType(0),AdultPrice(1),DiscountFromQTY(2),Discount(3),AgencyCommission(4),ChildDiscount(5),ChildAge(6)
        Dim TourData() As String = Session("TourData").ToString.Split("|")

        Dim CurrencyType As String = TourData(0)
        Dim CurrencyRate As Decimal = GetCurrencyRate(TourData(0))
        Dim AdultSinglePrice As Decimal = TourData(1)
        Dim DiscountFromQTY As Integer = TourData(2)
        Dim Discount As Decimal = TourData(3)
        Dim AgencyCommission As Decimal = TourData(4)
        Dim ChildDiscount As Decimal = TourData(5)
        'Dim ChildAge As Integer = TourData(6)

        Dim TotalPrice As Decimal = 0

        Dim Rate As Decimal = GetCurrencyRate(CurrencyType)



        Dim ExtraPersonDiscount As Decimal = 0
        'If Discount = 0 Then
        '    ExtraPersonDiscount = (AdultCount + ChildCount - 1) * Discount
        'Else
        '    ExtraPersonDiscount = (AdultCount - 1) * Discount
        'End If
        If AdultCount > DiscountFromQTY Then
            ExtraPersonDiscount = (DiscountFromQTY - AdultCount) * Discount
        End If

        ExtraPersonDiscount -= (AdultCount + ChildCount) * 5

        Dim ExtraServices() As String = Me.ExtraServicestxtSumTotal.Value.Split(" ")

        Dim Commission As Integer = ((AgencyCommission * (AdultSinglePrice * (AdultCount + ChildCount) + ExtraServices(0))) / 100) * -1

        TotalPrice = (AdultSinglePrice * (AdultCount + ChildCount)) - (ChildCount * ChildDiscount) + Commission + ExtraPersonDiscount + ExtraServices(0)

        Me.lblSumTotalPrice.Text = (AdultSinglePrice * (AdultCount + ChildCount)) & " " & CurrencyType
        Me.lblDiscount.Text = ((ChildCount * ChildDiscount) * -1) + ExtraPersonDiscount & " " & CurrencyType
        Me.lblAgencyCommission.Text = Decimal.Parse(Commission).ToString("N0") & " " & CurrencyType
        Me.lblExtraServices.Text = Me.ExtraServicestxtSumTotal.Value
        Me.lblTotalPriceDefaultCurrency.Text = TotalPrice & " " & CurrencyType
        Me.lblTotalPriceTooman.Text = MC.Code(Rate * TotalPrice) & " تومان "




        Value(0) = TotalPrice
        Value(1) = Rate * TotalPrice

        Return Value

    End Function

    Private Sub FillExtraServices(ByVal TourID As String)
        Dim Sql As New SqlConnectionSite
        Dim QTY As Integer = 0
        Dim Value As String = String.Empty

        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Sql.SqlCon

            cmd.Parameters.Add("@TourID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(TourID)
            cmd.CommandText = "Select Name,Price from TourExtraServices Where TourID=@TourID"
            Sql.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = cmd.ExecuteReader
            While sdr.Read
                Value += "<tr>" & _
                                "<td style=""width:40%; text-align:center;"">" & sdr(0).ToString & "</td>" & _
                                "<td style=""width:25%; text-align:center;"" id=""tdSingle" & QTY & """>" & sdr(1).ToString & "</td>" & _
                                "<td style=""width:10%; text-align:center;"">" & _
                                    "<select id=""txtQty" & QTY & """ onchange=""ExtraServiceCalc('" & QTY & "'); CreateServicesDB('" & sdr(0).ToString & "',this);"">" & _
                                        "<option>0</option>" & _
                                        "<option>1</option>" & _
                                        "<option>2</option>" & _
                                        "<option>3</option>" & _
                                        "<option>4</option>" & _
                                        "<option>5</option>" & _
                                        "<option>6</option>" & _
                                        "<option>7</option>" & _
                                        "<option>8</option>" & _
                                        "<option>9</option>" & _
                                        "<option>10</option>" & _
                                    "</select>" & _
                                "</td>" & _
                                "<td style=""width:25%; text-align:center;"" id=""tdSum" & QTY & """>0</td>" & _
                            "</tr>"
                QTY += 1
            End While

            Me.txtExtraQTY.Text = QTY
        Catch ex As Exception
        Finally
            Sql.SqlCon.Close()
        End Try

        If Value <> String.Empty Then
            Me.DivExtraServices.Visible = True
            Me.TbodyExtraServices.InnerHtml = Value
        Else
            Me.DivExtraServices.Visible = False
        End If
    End Sub

End Class

