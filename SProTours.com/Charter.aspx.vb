
Partial Class Charter
    Inherits System.Web.UI.Page
    Private LTDB As LogToDatabase
    Private RequestID As String
    Private GFI As GetFlightInfo

    Private SQl As SqlConnectionSite
    Private cmd As Data.SqlClient.SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillDDlDepartureAirPorts()
        FillDDlDestinationAirPorts()

        Try
            If Session("submit") = "true" Then
                Session("submit") = "false"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "peygham();", True)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillDDlDepartureAirPorts()
        Try
            Me.txtFlyFrom.Items.Clear()
            Me.txtFlyFrom.Items.Add("")
            SQl = New SqlConnectionSite
            cmd = New Data.SqlClient.SqlCommand
            cmd.Connection = SQl.SqlCon
            cmd.CommandText = "select A.AirportName,A.AirportCode,A.City,A.Country from Airports A inner join Charters C on A.Row=C.DepartureAirportID"
            Dim Sdr As Data.SqlClient.SqlDataReader

            SQl.SqlCon.Open()
            Sdr = cmd.ExecuteReader
            While Sdr.Read
                Me.txtFlyFrom.Items.Add(Sdr(0).ToString & ", " & Sdr(1).ToString & ", " & Sdr(2).ToString & ", " & Sdr(3).ToString)
            End While
            SQl.SqlCon.Close()
        Catch ex As Exception
            SQl.SqlCon.Close()
        Finally
            SQl.SqlCon.Close()
        End Try
    End Sub

    Private Sub FillDDlDestinationAirPorts()
        Try
            Me.txtFlyTo.Items.Clear()
            Me.txtFlyTo.Items.Add("")
            SQl = New SqlConnectionSite
            cmd = New Data.SqlClient.SqlCommand
            cmd.Connection = SQl.SqlCon
            cmd.CommandText = "select A.AirportName,A.AirportCode,A.City,A.Country from Airports A inner join Charters C on A.Row=C.DestinationAirportID"
            Dim Sdr As Data.SqlClient.SqlDataReader

            SQl.SqlCon.Open()
            Sdr = cmd.ExecuteReader
            While Sdr.Read
                Me.txtFlyTo.Items.Add(Sdr(0).ToString & ", " & Sdr(1).ToString & ", " & Sdr(2).ToString & ", " & Sdr(3).ToString)
            End While
            SQl.SqlCon.Close()
        Catch ex As Exception
            SQl.SqlCon.Close()
        Finally
            SQl.SqlCon.Close()
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

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        Response.Redirect("Charter_search_results.aspx")
    End Sub
End Class
