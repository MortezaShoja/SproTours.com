Imports System.Data

Partial Class PackagePrintPreview
    Inherits System.Web.UI.Page

    Protected Sub mainform_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainform.Load
        Try
            Dim HotelName As String = Request.QueryString("H").ToString
            Dim Sorting As Integer = Request.QueryString("S").ToString
            Dim PackageCode As Integer = Request.QueryString("PC").ToString
            Dim City As String = Request.QueryString("C").ToString
            LoadHotels(HotelName, Sorting, City, PackageCode)
        Catch ex As Exception

        End Try
    End Sub

    Private Function LoadHF(ByVal PackageCode As String) As Array
        Dim Value(1) As String

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.Parameters.Add("@Row", SqlDbType.Int).Value = PackageCode
            Cmd.CommandText = "Select HeaderTitle,FooterTitle From HotelPackageHF Where Row=@Row"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value(0) = sdr(0).ToString
                Value(1) = sdr(1).ToString
            End If
        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try
        Return Value
    End Function

    Private Sub LoadHotels(ByVal HotelName As String, ByVal Sorting As Integer, ByVal city As String, ByVal PackageCode As Integer)

        Dim HF() As String = LoadHF(PackageCode)
        Dim PublishType As String = "عادی"
        Try
            If Request.QueryString("T").ToString = "1" Then
                PublishType = "آفر ویژه"
            End If
        Catch ex As Exception
        End Try

        'FillHottelsQTY(PublishType)

        Dim PG As New PackageGenerator
        Me.mainform.InnerHtml = "<table id=""tblPackages"" cellpadding=""0"" cellspacing=""0"" class=""style1"">"

        Me.mainform.InnerHtml += "<THEAD>"
        Me.mainform.InnerHtml += "<tr><td colspan=""12""><img src=""http://www.SproTours.com/Images/Package/Header.jpg"" style=""width:100%"" /></td></tr>"
        Me.mainform.InnerHtml += "<tr style=""Background-color:white;""><td colspan=""12"">" & HF(0) & "</td></tr>"
        Me.mainform.InnerHtml += "</THEAD>"


        Me.mainform.InnerHtml += "<TBODY>"

        'Me.mainform.InnerHtml += PG.Generate("https://media-cdn.tripadvisor.com/media/photo-o/0e/d5/8e/98/hotel-carlos-i.jpg", "$", "Hilton", "★★★★★", "Sisli,Istanbul", "Standard Room", "30", "30", "30", "30", "30","az tarikhe ta tarikhe")

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try

            Cmd.Parameters.Add("@NowDate", SqlDbType.Date).Value = Now.Date
            Cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = PublishType
            Cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = city

            Dim Shart As String = String.Empty

            Dim SearchText As String = HotelName
            Try
                SearchText = SearchText.Replace("-", " ")
                SearchText = SearchText.Replace("_", " ")
                SearchText = SearchText.Replace("/", " ")
                SearchText = SearchText.Replace("\", " ")
                SearchText = SearchText.Replace(",", " ")
                SearchText = SearchText.Replace(".", " ")
            Catch ex As Exception

            End Try
            If SearchText <> String.Empty Then
                Dim tmpHotelNameSearchKeys() As String = SearchText.Split(" ")
                For I As Integer = 0 To tmpHotelNameSearchKeys.Length - 1
                    Cmd.Parameters.Add("@SearchKey" & I.ToString, SqlDbType.NVarChar).Value = tmpHotelNameSearchKeys(I)
                    Shart += " (Hotelname Like '%' + @SearchKey" & I.ToString & " + '%' or Address Like '%' + @SearchKey" & I.ToString & " + '%') and "
                Next
            End If

            Dim tmpFilter As String = " order by Rank Desc, SNGSell Desc, Address Asc"

            Select Case Sorting
                Case Is = 0
                    tmpFilter = " order by Rank Desc, SNGSell Desc, Address Asc"
                Case Is = 1
                    tmpFilter = " order by Address Asc,  Rank Desc, SNGSell Desc"
                Case Is = 2
                    tmpFilter = " order by SNGSell Desc, Address Asc, Rank Desc"
            End Select

            '                          0     1      2      3        4        5       6       7        8         9        10         11       12
            Cmd.CommandText = "Select ID,HotelName,Rank,RoomType,Address,Currency,SNGSell,DBLSell,ExBedSell,ChildSell,InfantSell,StartDate,EndDate from Packages Where " & Shart & " (CONVERT(VARCHAR(10),@NowDate,110)) <= (CONVERT(VARCHAR(10),DATEADD(DAY, 15, Regdate),110)) And Type=@Type And City=@City " & tmpFilter
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Dim Stars As String = String.Empty
                For i As Integer = 1 To sdr(2)
                    Stars += "★"
                Next
                Stars = sdr(2).ToString & " " & Stars

                Me.mainform.InnerHtml += PG.Generate("http://admin.Sprotours.com/Packages/Hotels/" & sdr(0).ToString & ".jpg", sdr(5).ToString, UCase(sdr(1).ToString), Stars, UCase(sdr(4).ToString), UCase(sdr(3).ToString), sdr(6).ToString, sdr(7).ToString, sdr(8).ToString, sdr(9).ToString, sdr(10).ToString, Date.Parse(sdr(11)).ToString("yyyy/MM/dd") & " :: " & Date.Parse(sdr(12)).ToString("yyyy/MM/dd"))
            End While
        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Me.mainform.InnerHtml += "</TBODY>"

        'Me.mainform.InnerHtml += "<tfoot>"
        'Me.mainform.InnerHtml += "<tr><td colspan=""12""><img src=""http://www.SproTours.com/Images/Package/Footer.jpg"" style=""width:100%"" /></td></tr>"
        'Me.mainform.InnerHtml += "</tfoot>"

        Me.mainform.InnerHtml += "</table>"

        'Me.mainform.InnerHtml += "<br/>"
        Me.mainform.InnerHtml += "<img src=""http://www.SproTours.com/Images/Package/Footer.jpg"" style=""width:100%"" />"
        Me.mainform.InnerHtml += "<div style=""Background-color:white;"">" & HF(1) & "</div>"
        Me.mainform.InnerHtml += "<img src=""http://www.SproTours.com/Images/Package/address.jpg"" style=""width:100%"" />"

    End Sub

    'Private Sub FillHottelsQTY(ByVal PublishType As String)

    '    Dim SqlCon As New SqlConnectionSite
    '    Dim Cmd As New SqlClient.SqlCommand


    '    Dim Shart As String = String.Empty

    '    Dim SearchText As String = Me.txtSearch.Text
    '    Try
    '        SearchText = SearchText.Replace("-", " ")
    '        SearchText = SearchText.Replace("_", " ")
    '        SearchText = SearchText.Replace("/", " ")
    '        SearchText = SearchText.Replace("\", " ")
    '        SearchText = SearchText.Replace(",", " ")
    '        SearchText = SearchText.Replace(".", " ")
    '    Catch ex As Exception

    '    End Try
    '    If SearchText <> String.Empty Then
    '        Dim tmpHotelNameSearchKeys() As String = SearchText.Split(" ")
    '        For I As Integer = 0 To tmpHotelNameSearchKeys.Length - 1
    '            Cmd.Parameters.Add("@SearchKey" & I.ToString, SqlDbType.NVarChar).Value = tmpHotelNameSearchKeys(I)
    '            Shart += " (Hotelname Like '%' + @SearchKey" & I.ToString & " + '%' or Address Like '%' + @SearchKey" & I.ToString & " + '%') and "
    '        Next
    '    End If

    '    '--------------------------------------------------------------------------------------

    '    Try

    '        Cmd.Parameters.Add("@NowDate", SqlDbType.Date).Value = Now.Date
    '        Cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = PublishType
    '        Cmd.CommandText = "Select Rank,count(*) from Packages Where " & Shart & " (CONVERT(VARCHAR(10),@NowDate,110)) <= (CONVERT(VARCHAR(10),DATEADD(DAY, 15, Regdate),110)) And Type=@Type Group by rank  order by Rank Desc"
    '        Cmd.Connection = SqlCon.SqlCon
    '        SqlCon.SqlCon.Open()
    '        Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
    '        Me.lblHotelsQTY.Text = String.Empty
    '        Dim TotalQTY As Integer = 0
    '        While sdr.Read
    '            TotalQTY += sdr(1)
    '            Me.lblHotelsQTY.Text += SratCount(sdr(0)) & " <b style=""color:gray;"">" & sdr(1).ToString & vbTab & "</b> | " & vbTab
    '        End While
    '        Me.lblHotelsQTY.Text += " <b style=""color:gray;"">" & "تعداد هتل ها " & TotalQTY & "</b>"
    '    Catch ex As Exception
    '    Finally
    '        SqlCon.SqlCon.Close()
    '    End Try

    'End Sub

    Private Function SratCount(ByVal QTY As Integer) As String
        Dim value As String = String.Empty
        For I As Integer = 1 To QTY
            value += "★"
        Next
        Return value
    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "script", "alert('ssss');", True)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "print", "window.print();", True)
    End Sub
End Class
