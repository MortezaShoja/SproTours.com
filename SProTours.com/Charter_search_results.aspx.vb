Imports System.Data

Partial Class Charter_search_results
    Inherits System.Web.UI.Page
    Private SQl As SqlConnectionSite
    Private cmd As Data.SqlClient.SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadResults()

        Dim StartDate As String = String.Empty
        Dim EndDate As String = String.Empty

        Try
            StartDate = Application("StartDate").ToString
        Catch ex As Exception
            StartDate = Now.Date.Date.ToString("yyyy/M/dd")
        End Try

        Try
            EndDate = Application("EndDate").ToString
        Catch ex As Exception
            EndDate = Now.Date.Date.AddDays(7).ToString("yyyy/M/dd")
        End Try


        Page.ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", "document.getElementById('js_querystring_shadow').value='salam'", True)
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", "document.getElementById('end').value='" + EndDate + "';", True)

    End Sub

    Private Sub LoadResults()

        Try
            Sql = New SqlConnectionSite
            cmd = New Data.SqlClient.SqlCommand
            cmd.Connection = Sql.SqlCon
            cmd.CommandText = "select ID,AirLine,Departure,Arrival,DepartureAirportID,DestinationAirportID,FlightNumber,AdultPrice,YouthPrice,InfantPrice,Description from Charters order by Departure , Arrival"

            Sql.SqlCon.Open()

            Dim sdr As Data.SqlClient.SqlDataReader = cmd.ExecuteReader
            While (sdr.Read)
                Me.DivCharterSearchResult.Controls.Add(New CreateCharterSearchResult.Generate(sdr(0).ToString, sdr(1).ToString, sdr(2).ToString, sdr(3).ToString, sdr(4).ToString, sdr(5).ToString, sdr(6).ToString, sdr(7), sdr(8), sdr(9), sdr(10), sdr(2).ToString, sdr(3).ToString, sdr(4).ToString, sdr(5).ToString, sdr(6).ToString, 2, 0, 1))
            End While
        Catch ex As Exception
            SQl.SqlCon.Close()
        Finally
            SQl.SqlCon.Close()
        End Try




    End Sub


    Private Function GetHotelNameAndID(ByVal HotelCode As Integer) As Array
        Dim Values(2) As String
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try

            Cmd.Parameters.Add("@HotelCode", SqlDbType.Int).Value = Integer.Parse(HotelCode)
            Cmd.CommandText = "Select ID,HotelName From Hotels Where HotelCode=@HotelCode"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try
        Return Values
    End Function
End Class
