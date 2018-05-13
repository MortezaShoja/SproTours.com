
Partial Class Flight
    Inherits System.Web.UI.Page
    Private LTDB As LogToDatabase
    Private RequestID As String
    Private GFI As GetFlightInfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Session("submit") = "true" Then
                Session("submit") = "false"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "peygham();", True)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnSendRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendRequest.Click
        Me.btnSendRequest.Enabled = False

        Dim SE As New SendEmail
        Dim CH As New CreateHTMLEmail

        Dim RaftDate As String = Request.Form("start")
        Dim BargashtDate As String = Request.Form("end")

        Dim FlightClass As String = Request.Form.Get(Me.txtOwerviewFlightClass.UniqueID)

        Dim Adult As Integer = Integer.Parse(Request.Form.Get(Me.txtOwerviewAdult.UniqueID))
        Dim Youth As Integer = Integer.Parse(Request.Form.Get(Me.txtOwerviewYouth.UniqueID))
        Dim Child As Integer = Integer.Parse(Request.Form.Get(Me.txtOwerviewChild.UniqueID))



        RequestID = Guid.NewGuid.ToString
        Dim HotelID As String = String.Empty
        LTDB = New LogToDatabase
        LTDB.LogFlightRequests(RequestID, Now.ToString, Me.txtFlyFrom.Text, Me.txtFlyTo.Text, RaftDate, BargashtDate, FlightClass, Adult, Youth, Child, Me.txtLastOverviewName.Text, Me.txtLastOverviewFamily.Text, Me.txtLastOverviewPhone.Text, Me.txtLastOverviewEmail.Text, Me.txtLastOverviewDescription.Text)

        Dim RequestCode As Integer = 0
        GFI = New GetFlightInfo
        RequestCode = GFI.GetRequestCode(RequestID)
        SE.Sender("noreply@SproTours.com", "Sprotours.com", "NoReplyMaster2016", Me.txtLastOverviewEmail.Text, CH.CreateFlightReservationRequestEmail(RequestCode, Me.txtFlyFrom.Text, Me.txtFlyTo.Text, RaftDate, BargashtDate, FlightClass, Adult, Youth, Child, Me.txtLastOverviewName.Text, Me.txtLastOverviewFamily.Text, Me.txtLastOverviewPhone.Text, Me.txtLastOverviewEmail.Text, Me.txtLastOverviewDescription.Text, Server.MapPath("Email/Flight_CustomerReservationRequest.htm")), "درخواست رزرو پرواز", "")
        SE.Sender("noreply@SproTours.com", "Sprotours.com", "NoReplyMaster2016", "reservation@SproTours.com", CH.CreateFlightReservationRequestEmail(RequestCode, Me.txtFlyFrom.Text, Me.txtFlyTo.Text, RaftDate, BargashtDate, FlightClass, Adult, Youth, Child, Me.txtLastOverviewName.Text, Me.txtLastOverviewFamily.Text, Me.txtLastOverviewPhone.Text, Me.txtLastOverviewEmail.Text, Me.txtLastOverviewDescription.Text, Server.MapPath("Email/Flight_ReservationRequest.htm")), "Flight Reservation Request", "")

        Session("submit") = "true"
        Response.Redirect("Flight.aspx?Action=done")
    End Sub

End Class
