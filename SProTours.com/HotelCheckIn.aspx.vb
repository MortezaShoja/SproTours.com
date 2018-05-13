Imports System.Data

Partial Class HotelCheckIn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadHotelInfo()
        GenerateGuests()
    End Sub

    Private Sub GenerateGuests()
        Me.txtRoomID.Text = String.Empty
        Dim RequestID As String = Request.QueryString("Rid")
        Dim TotalPrice As Decimal = 0
        Dim CurrencyType As String = String.Empty

        Dim CHGRI As CreateHotelGuestsInfo.Generate
        Dim Dvw As New Data.DataView
        Dim Tbl As New Data.DataTable
        Dim SqlCon As New SqlConnectionSite
        Tbl.Clear()
        Tbl.Columns.Add("نوع اطاق")
        Tbl.Columns.Add("تعداد")
        Tbl.Columns.Add("قیمت")

        Try
            Dim Cmd As New SqlClient.SqlCommand
            '                            0          1          2      3                           4                         5             6
            Cmd.CommandText = "select H.RoomID,R.RoomType,H.Adults,H.Child,COUNT(RoomID) as 'RoomCount',Sum(H.Price) as 'TotalPrice',H.CurrencyType from HotelRequestsRoomTypes H inner Join Hotel.dbo.Rooms R on R.ID=H.RoomID Where H.RequestID='" & RequestID & "' And MemberID='" & Request.Cookies("UserSettings")("ID").ToString & "' Group by H.RoomID,R.RoomType,H.Adults,H.Child,H.Price,H.CurrencyType Order by TotalPrice Desc"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Dim row As DataRow = Tbl.NewRow
                row(0) = sdr(1).ToString
                row(1) = sdr(4).ToString
                row(2) = CType(sdr(5), Decimal).ToString("N2")
                TotalPrice += sdr(5)
                Tbl.Rows.Add(row)
                CurrencyType = sdr(6).ToString
                Me.txtRoomID.Text += sdr(0).ToString & "," & sdr(2).ToString & "," & sdr(3).ToString & "," & sdr(4).ToString & "#"
                For I As Integer = 1 To Integer.Parse(sdr(4))
                    Me.txtTotalAdult.Text = Integer.Parse(Me.txtTotalAdult.Text) + Integer.Parse(sdr(2))
                    Me.txtTotalChild.Text = Integer.Parse(Me.txtTotalChild.Text) + Integer.Parse(sdr(3))
                    CHGRI = New CreateHotelGuestsInfo.Generate(sdr(0).ToString & "|" & I, sdr(1).ToString, sdr(2).ToString, sdr(3).ToString)
                    Me.divRooms.Controls.Add(CHGRI)
                Next
            End While
            Me.lblTotalPrice.Text = TotalPrice.ToString("N2") & " " & CurrencyType
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try
        Me.txtTotalGuests.Text = Integer.Parse(Me.txtTotalAdult.Text) + Integer.Parse(Me.txtTotalChild.Text)
        Dvw = New Data.DataView(Tbl)
        Me.dgvRoomTypes.DataSource = Dvw
        Me.dgvRoomTypes.DataBind()

    End Sub

    Private Sub LoadHotelInfo()
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
                Me.lblHotelName.Text = sdr(0).ToString
                Me.lblAddress.Text = " " & sdr(1).ToString
                Select Case sdr(2).ToString
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
    End Sub

    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Dim SqlCon As New SqlConnectionSite

        Dim tmpRoomCount() As String = Me.txtRoomID.Text.Split("#")

        For I As Integer = 0 To tmpRoomCount.Length - 2
            Dim tmpRoomDeails() As String = tmpRoomCount(I).Split(",")
            ' 0 = RoomID
            ' 1 = Adult
            ' 2 = Child
            ' 3 = RoomCount
            Dim TmpCurrentRoomID As String = tmpRoomDeails(0).Replace("-", "_")
            For K As Integer = 1 To tmpRoomDeails(3)
                For J As Integer = 1 To tmpRoomDeails(1)
                    'Update Smoking
                    Dim Smoking As Integer = 1
                    Select Case Request.Form("lstSmoking_" & TmpCurrentRoomID & "|" & K)
                        Case Is = "خیر"
                            Smoking = 0
                    End Select
                    Try
                        Dim Cmd As New SqlClient.SqlCommand
                        Cmd.CommandText = "Update HotelRequestsRoomTypes Set Smoking='" & Smoking & "' Where RequestID='" & Request.QueryString("Rid") & "' And RoomID='" & tmpRoomDeails(0) & "' And RoomIDRow='" & K & "'"
                        Cmd.Connection = SqlCon.SqlCon
                        SqlCon.SqlCon.Open()
                        Cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        Dim ERM As New ErrorLog
                        'ERM.Log()
                    Finally
                        SqlCon.SqlCon.Close()
                    End Try
                    '---------------------------------------------------
                    'Adult Count
                    '---------------------------------------
                    Try
                        Dim Cmd As New SqlClient.SqlCommand
                        Cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = Request.Form("txtAdultFullName" & J & "_" & TmpCurrentRoomID & "|" & K)
                        Cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = Request.Form("txtAdultBirthDate" & J & "_" & TmpCurrentRoomID & "|" & K)
                        Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Request.Form("txtAdultEmail" & J & "_" & TmpCurrentRoomID & "|" & K)
                        Cmd.CommandText = "Insert Into HotelGuestsInfo (RequestID,RoomID,GuestsType,PersonRow,RoomRow,FullName,BirthDate,Email) Values ('" & Request.QueryString("Rid") & "','" & tmpRoomDeails(0) & "',N'Adult','" & J & "','" & K & "',@FullName,@BirthDate,@Email)"
                        Cmd.Connection = SqlCon.SqlCon
                        SqlCon.SqlCon.Open()
                        Cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        Dim ERM As New ErrorLog
                        'ERM.Log()
                    Finally
                        SqlCon.SqlCon.Close()
                    End Try
                Next

                For L As Integer = 1 To tmpRoomDeails(1)
                    'Child Count
                    '---------------------------------------
                    Try
                        Dim Cmd As New SqlClient.SqlCommand
                        Cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = Request.Form("txtChildFullName" & L & "_" & TmpCurrentRoomID & "|" & K)
                        Cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = Request.Form("txtChildBirthDate" & L & "_" & TmpCurrentRoomID & "|" & K)
                        Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Request.Form("txtChildEmail" & L & "_" & TmpCurrentRoomID & "|" & K)
                        Cmd.CommandText = "Insert Into HotelGuestsInfo (RequestID,RoomID,GuestsType,PersonRow,RoomRow,FullName,BirthDate,Email) Values ('" & Request.QueryString("Rid") & "','" & tmpRoomDeails(0) & "',N'Child','" & L & "','" & K & "',@FullName,@BirthDate,@Email)"
                        Cmd.Connection = SqlCon.SqlCon
                        SqlCon.SqlCon.Open()
                        Cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        Dim ERM As New ErrorLog
                        'ERM.Log()
                    Finally
                        SqlCon.SqlCon.Close()
                    End Try
                Next

            Next

        Next
    End Sub
End Class
