Imports System.Data

Partial Class HotelInvoice
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadHotelInfo()
        Dim CHE As New CreateHTMLEmail
        Dim tmpHotelInfo() As String = GetHotelInfo()
        Me.lblRequestInvoice.Text = CHE.CreateHotelInvoice("H100", Now.Date.ToString("dd/MMM/yyyy"), tmpHotelInfo(0), tmpHotelInfo(1), tmpHotelInfo(2), CreateRoomTypeHTML, "", "", Server.MapPath("Email/HotelInvoice.htm"))
    End Sub

    Private Function CreateRoomTypeHTML() As String
        Dim Value As String = String.Empty
        Dim SumPrice As Integer = 0
        Dim SumQty As Integer = 0
        Dim CurrencyType As String = String.Empty

        Dim SqlCon As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            '                                           0                                       1          2      3      4                        5                           6             7
            Cmd.CommandText = "select ROW_NUMBER() OVER(ORDER BY Sum(H.Price) desc) AS Row,R.RoomType,H.Adults,H.Child,H.Bed,COUNT(RoomID) as 'RoomCount',Sum(H.Price) as 'TotalPrice',H.CurrencyType from HotelRequestsRoomTypes H inner Join Hotel.dbo.Rooms R on R.ID=H.RoomID Where H.RequestID='" & Request.QueryString("Rid") & "' And MemberID='" & Request.Cookies("UserSettings")("ID").ToString & "' Group by H.RoomID,R.RoomType,H.Adults,H.Child,H.Bed,H.Price,H.CurrencyType Order by TotalPrice Desc"
            'Cmd.CommandText = "select H.RoomID,R.RoomType,H.Adults,H.Child,COUNT(RoomID) as 'RoomCount',Sum(H.Price) as 'TotalPrice',H.CurrencyType from HotelRequestsRoomTypes H inner Join Hotel.dbo.Rooms R on R.ID=H.RoomID Where H.RequestID='" & RequestID & "' And MemberID='" & Request.Cookies("UserSettings")("ID").ToString & "' Group by H.RoomID,R.RoomType,H.Adults,H.Child,H.Price,H.CurrencyType Order by TotalPrice Desc"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Value += "<tr>" & _
                     "<td style=""border: thin solid #808080; text-align:center; color:#ed8323;"">" & sdr(0).ToString & "</td>" & _
                     "<td style=""border: thin solid #808080;"">" & sdr(1).ToString & "</td>" & _
                     "<td style=""border: thin solid #808080; text-align:center;"">" & sdr(2).ToString & "</td>" & _
                     "<td style=""border: thin solid #808080; text-align:center;"">" & sdr(3).ToString & "</td>" & _
                     "<td style=""border: thin solid #808080; text-align:center;"">" & sdr(4).ToString & "</td>" & _
                     "<td style=""border: thin solid #808080; text-align:center;"">" & CType((sdr(6) / sdr(5)), Decimal).ToString("N2") & " " & sdr(7).ToString & "</td>" & _
                     "<td style=""border: thin solid #808080; text-align:center;"">" & sdr(5).ToString & "</td>" & _
                     "<td style=""border: thin solid #808080; text-align:center;"">" & CType(sdr(6), Decimal).ToString("N2") & " " & sdr(7).ToString & "</td>" & _
                "</tr>"
                SumQty += sdr(5)
                SumPrice += sdr(6)
                CurrencyType = sdr(7).ToString
            End While

        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Value += "<tr>" & _
                    "<td></td>" & _
                    "<td></td>" & _
                    "<td></td>" & _
                    "<td></td>" & _
                    "<td></td>" & _
                    "<td style=""text-align:right"">Total : </td>" & _
                    "<td style=""border: thin solid #808080; text-align:center; color:#ed8323;"">" & SumQty & "</td>" & _
                    "<td style=""border: thin solid #808080; text-align:center; color:#ed8323;"">" & CType(SumPrice, Decimal).ToString("N2") & " " & CurrencyType & "</td>" & _
                "</tr>"

        Return Value
    End Function

    Private Function GetHotelInfo() As Array
        Dim Value(2) As String

        Dim GHI As New GetHotelsInfo
        Dim HotelID As String = GHI.GetHotelID(Request.QueryString("Rid"), Request.Cookies("UserSettings")("ID").ToString)

        Dim SqlCon As New SqlConnectionHotels
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "select HotelName,FullAddress,Stars from Hotels Where ID='" & HotelID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value(0) = sdr(0).ToString
                Value(1) = sdr(1).ToString
                Value(2) = sdr(2)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    Private Function GetRequestInfo() As Array
        Dim Value(2) As String

        Dim GHI As New GetHotelsInfo
        Dim HotelID As String = GHI.GetHotelID(Request.QueryString("Rid"), Request.Cookies("UserSettings")("ID").ToString)

        Dim SqlCon As New SqlConnectionHotels
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "select HotelName,FullAddress,Stars from Hotels Where ID='" & HotelID & "'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value(0) = sdr(0).ToString
                Value(1) = sdr(1).ToString
                Value(2) = sdr(2)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function
End Class
