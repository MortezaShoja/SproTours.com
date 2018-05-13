Imports System.Data
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Partial Class Packages
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MemberID As String = String.Empty

        Try
            MemberID = Request.Cookies("UserSettings")("ID").ToString.ToString
        Catch ex As Exception
        End Try

        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "script", "CoAgencySelector();", True)

        If MemberID <> String.Empty Then
            If IsPostBack = False Then
                FillddlCountry()
                FillddlCity()
                LoadHotels()
            End If
        Else
            Response.Redirect("default.aspx?L=2")
        End If

    End Sub

    Private Function LoadHF() As Array
        Dim Value(1) As String

        Dim PublishType As String = String.Empty

        Select Case Me.ddlSearch_PackageType.SelectedIndex
            Case Is = 0
                PublishType = "عادی"
            Case Is = 1
                PublishType = "آفر ویژه"
        End Select

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = Me.ddlSearch_Country.Text
            Cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = Me.ddlSearch_City.Text
            Cmd.Parameters.Add("@PackageType", SqlDbType.NVarChar).Value = PublishType

            Cmd.CommandText = "Select HeaderTitle,FooterTitle From HotelPackageHF Where Country=@Country and City=@City and PackageType=@PackageType"
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

    Private Sub LoadHotels()

        Dim HF() As String = LoadHF()

        Dim PublishType As String = String.Empty

        Select Case Me.ddlSearch_PackageType.SelectedIndex
            Case Is = 0
                PublishType = "عادی"
            Case Is = 1
                PublishType = "آفر ویژه"
        End Select

        FillHottelsQTY(PublishType)

        Dim PG As New PackageGenerator
        Me.tblPackages.InnerHtml = "<table cellpadding=""0"" cellspacing=""0"" class=""style1"">"
        '----------------------------- HEader
        Me.tblPackages.InnerHtml += "<THEAD>"
        Me.tblPackages.InnerHtml += "<tr><td colspan=""12""><img src=""http://www.SproTours.com/Images/Package/Header.jpg"" style=""width:100%"" /></td></tr>"
        Me.tblPackages.InnerHtml += "<tr style=""Background-color:white;""><td colspan=""12"">" & HF(0) & "</td></tr>"
        Me.tblPackages.InnerHtml += "</THEAD>"
        '------------------------------- Header

        Me.tblPackages.InnerHtml += "<TBODY>"
        'Me.tblPackages.InnerHtml += PG.Generate("https://media-cdn.tripadvisor.com/media/photo-o/0e/d5/8e/98/hotel-carlos-i.jpg", "$", "Hilton", "★★★★★", "Sisli,Istanbul", "Standard Room", "30", "30", "30", "30", "30","az tarikhe ta tarikhe")

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try

            Cmd.Parameters.Add("@NowDate", SqlDbType.Date).Value = Now.Date
            Cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = PublishType

            Dim Shart As String = String.Empty

            Dim SearchText As String = Me.txtSearch.Text
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

            Select Case Me.ddlSearch_PackageType.SelectedIndex
                Case Is = 0
                    tmpFilter = " order by Rank Desc, SNGSell Desc, Address Asc"
                Case Is = 1
                    tmpFilter = " order by Address Asc,  Rank Desc, SNGSell Desc"
                Case Is = 2
                    tmpFilter = " order by SNGSell Desc, Address Asc, Rank Desc"
            End Select
            Cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = Me.ddlSearch_City.Text

            '                          0     1      2      3        4        5       6       7        8         9        10         11       12
            Cmd.CommandText = "Select ID,HotelName,Rank,RoomType,Address,Currency,SNGSell,DBLSell,ExBedSell,ChildSell,InfantSell,StartDate,EndDate from Packages Where " & Shart & " Type=@Type and ((CONVERT(VARCHAR(10),EndDate,111)) >= (CONVERT(VARCHAR(10),@NowDate,111))) and City=@City " & tmpFilter
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Dim Stars As String = String.Empty
                For i As Integer = 1 To sdr(2)
                    Stars += "★"
                Next
                Stars = sdr(2).ToString & " " & Stars

                Me.tblPackages.InnerHtml += PG.Generate("http://admin.Sprotours.com/Packages/Hotels/" & sdr(0).ToString & ".jpg", sdr(5).ToString, UCase(sdr(1).ToString), Stars, UCase(sdr(4).ToString), UCase(sdr(3).ToString), sdr(6).ToString, sdr(7).ToString, sdr(8).ToString, sdr(9).ToString, sdr(10).ToString, Date.Parse(sdr(11)).ToString("yyyy/MM/dd") & " :: " & Date.Parse(sdr(12)).ToString("yyyy/MM/dd"))
            End While
        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Me.tblPackages.InnerHtml += "</TBODY>"
        Me.tblPackages.InnerHtml += "</table>"

        Me.tblPackages.InnerHtml += "<img src=""http://www.SproTours.com/Images/Package/Footer.jpg"" style=""width:100%"" />"
        Me.tblPackages.InnerHtml += "<div style=""Background-color:white;"">" & HF(1) & "</div>"
        Me.tblPackages.InnerHtml += "<img src=""http://www.SproTours.com/Images/Package/address.jpg"" style=""width:100%"" />"

    End Sub

    Private Sub FillHottelsQTY(ByVal PublishType As String)

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand


        Dim Shart As String = String.Empty

        Dim SearchText As String = Me.txtSearch.Text
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

        '--------------------------------------------------------------------------------------

        Try

            Cmd.Parameters.Add("@NowDate", SqlDbType.Date).Value = Now.Date
            Cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = PublishType
            Cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = Me.ddlSearch_City.Text

            Cmd.CommandText = "Select Rank,count(*) from Packages Where " & Shart & " ((CONVERT(VARCHAR(10),EndDate,111)) >= (CONVERT(VARCHAR(10),@NowDate,111))) And Type=@Type and City=@City Group by rank  order by Rank Desc"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Me.lblHotelsQTY.Text = String.Empty
            Dim TotalQTY As Integer = 0
            While sdr.Read
                TotalQTY += sdr(1)
                Me.lblHotelsQTY.Text += SratCount(sdr(0)) & " <b style=""color:gray;"">" & sdr(1).ToString & vbTab & "</b> | " & vbTab
            End While
            Me.lblHotelsQTY.Text += " <b style=""color:gray;"">" & "تعداد هتل ها " & TotalQTY & "</b>"
        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try

    End Sub

    Private Function SratCount(ByVal QTY As Integer) As String
        Dim value As String = String.Empty
        For I As Integer = 1 To QTY
            value += "★"
        Next
        Return value
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadHotels()
    End Sub

    Protected Sub ddlSearch_PackageType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSearch_PackageType.SelectedIndexChanged, ddlSearch_City.SelectedIndexChanged, ddlSearch_Country.SelectedIndexChanged
        LoadHotels()
    End Sub

    Protected Sub btnPrintToPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintToPDF.Click
        Dim SearchText As String = Me.txtSearch.Text
        Try
            SearchText = SearchText.Replace("-", "_")
            SearchText = SearchText.Replace("_", "_")
            SearchText = SearchText.Replace("/", "_")
            SearchText = SearchText.Replace("\", "_")
            SearchText = SearchText.Replace(",", "_")
            SearchText = SearchText.Replace(".", "_")
        Catch ex As Exception

        End Try

        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "print", "window.open('" & "PackagePrintPreview.aspx?H=" & SearchText & "&S=" & Me.ddlFilter.SelectedIndex & "','_blank');", True)

        Dim PC As Integer = GetPackageCode()

        Response.Redirect("PackagePrintPreview.aspx?H=" & SearchText & "&S=" & Me.ddlSearch_PackageType.SelectedIndex & "&C=" & Me.ddlSearch_City.Text & "&PC=" & PC)

        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf")
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Dim sw As New StringWriter()
        'Dim hw As New HtmlTextWriter(sw)
        'Me.pnlPackages.RenderControl(hw)
        'Dim sr As New StringReader(sw.ToString())
        'Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
        'Dim htmlparser As New HTMLWorker(pdfDoc)
        'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        'pdfDoc.Open()
        'htmlparser.Parse(sr)
        'pdfDoc.Close()
        'Response.Write(pdfDoc)
        'Response.[End]()
    End Sub

    Private Function GetPackageCode() As Integer
        Dim value As Integer = 0
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Dim PublishType As String = String.Empty

            Select Case Me.ddlSearch_PackageType.SelectedIndex
                Case Is = 0
                    PublishType = "عادی"
                Case Is = 1
                    PublishType = "آفر ویژه"
            End Select

            Cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = Me.ddlSearch_City.Text
            Cmd.Parameters.Add("@PackageType", SqlDbType.NVarChar).Value = PublishType

            Cmd.CommandText = "Select Row From HotelPackageHF Where City=@City and PackageType=@PackageType"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0)
            End If
        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try
        Return value
    End Function
    Private Sub FillddlCountry()
        Me.ddlSearch_Country.Items.Clear()

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            '-----Coutry---------------------------------------------------------------
            Cmd.CommandText = "Select Code,Country From Packages_Country order by Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Dim li As New System.Web.UI.WebControls.ListItem
                li.Value = sdr(0).ToString
                li.Text = sdr(1).ToString
                Me.ddlSearch_Country.Items.Add(li)
            End While

        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub

    Private Sub FillddlCity()

        Me.ddlSearch_City.Items.Clear()

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            '-----Coutry---------------------------------------------------------------
            Cmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar).Value = Me.ddlSearch_Country.SelectedValue
            Cmd.CommandText = "Select City From Packages_City where CountryCode=@CountryCode order by Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Me.ddlSearch_City.Items.Add(sdr(0).ToString)
            End While

        Catch ex As Exception
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub


End Class
