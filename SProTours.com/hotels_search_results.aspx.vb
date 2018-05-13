Imports System.Data

Partial Class hotels_search_results
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

        Try
            Me.ddlRoomCount.Text = Application("RoomCount").ToString
        Catch ex As Exception
            Me.ddlRoomCount.Text = 1
        End Try

        Try
            Me.ddlGuestCount.Text = Application("GuestCount").ToString
        Catch ex As Exception
            Me.ddlGuestCount.Text = 2
        End Try

        Try
            Me.txtHotelName.Text = Application("HotelName").ToString
        Catch ex As Exception
            Me.txtHotelName.Text = String.Empty
        End Try


        Page.ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", "document.getElementById('js_querystring_shadow').value='salam'", True)
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", "document.getElementById('end').value='" + EndDate + "';", True)

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
