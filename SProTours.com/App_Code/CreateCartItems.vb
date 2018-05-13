Imports Microsoft.VisualBasic
Imports System.Data

Public Class CreateCartItems
    Private SqlCon As SqlConnectionSite

    Public Function Create(ByVal MemberID As String) As Array
        Dim value(2) As String

        Dim QTY As Integer = 0
        Dim Total As Decimal = 0

        Dim SQLCon As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            '                           0       1           2           3               4           5           6           7             8         9               10                11             12             13                14            15          16              17
            Cmd.CommandText = "select T.ID,T.TourName,R.NoOfAdults,R.NoOfChild,T.CurrencyType,R.Discount,R.TotalPrice,R.TotalTomanPrice,R.ID,R.CurrentRate,R.AdultSinglePrice,R.DiscountFromQTY,R.Discount,R.AgencyCommission,R.ChildDiscount,R.NoOfAdults,R.NoOfChild,R.ExtraServicesTotal from TourDetails T inner join TourRequests R on R.TourID=T.ID Where R.MemberID=@MemberID and Status=N'در سبد خرید'"
            Cmd.Connection = SQLCon.SqlCon
            SQLCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Dim TourImage As String = String.Empty
                Try
                    Dim OurServerPath As String = "C:\Inetpub\vhosts\sprotours.com\admin.sprotours.com"
                    Dim Images() As String = System.IO.Directory.GetFiles(OurServerPath & "\Packages\TourDetails\" & sdr(0).ToString)
                    Dim tmpSelectedIMG() As String = Images(0).Split("\")
                    TourImage = "http://admin.SproTours.com/" & "Packages/TourDetails/" & sdr(0).ToString & "/" & tmpSelectedIMG(tmpSelectedIMG.Length - 1)
                Catch ex As Exception
                    TourImage = "http://admin.SproTours.com/Packages/Tours/no-photo.png"
                End Try

                Dim CurrencyType As String = sdr(4).ToString
                Dim CurrencyRate As Decimal = sdr(9)
                Dim AdultSinglePrice As Decimal = sdr(10)
                Dim DiscountFromQTY As Integer = sdr(11)
                Dim Discount As Decimal = sdr(12)
                Dim AgencyCommission As Decimal = sdr(13)
                Dim ChildDiscount As Decimal = sdr(14)
                Dim AdultCount As Integer = sdr(15)
                Dim ChildCount As Integer = sdr(16)

                Dim ExtraServices As Decimal = sdr(17)

                'Dim ChildAge As Integer = TourData(5)

                Dim TotalPrice As Decimal = 0

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

                Dim Commission As Integer = ((AgencyCommission * (AdultSinglePrice * (AdultCount + ChildCount) + ExtraServices)) / 100) * -1

                TotalPrice = (AdultSinglePrice * (AdultCount + ChildCount)) - (ChildCount * ChildDiscount) + Commission + ExtraPersonDiscount + ExtraServices

                Dim MC As New MoneyCodec
                Dim lblSumTotalPrice As String = Decimal.Parse(AdultSinglePrice * (AdultCount + ChildCount)).ToString("N2") & " " & CurrencyType
                Dim lblDiscount As String = Decimal.Parse(((ChildCount * ChildDiscount) * -1) + ExtraPersonDiscount).ToString("N2") & " " & CurrencyType
                Dim lblAgencyCommission As String = Decimal.Parse(Commission).ToString("N0") & " " & CurrencyType
                Dim lblTotalPriceDefaultCurrency As String = Decimal.Parse(TotalPrice).ToString("N2") & " " & CurrencyType
                Dim lblTotalPriceTooman As String = Decimal.Parse(CurrencyRate * TotalPrice).ToString("N0") & " تومان "



                value(0) += "<tr>" & _
                                "<td class=""product-name"">" & _
                                    "<div class=""product-thumbnail"">" & _
                                        "<a data-animated-link=""fadeOut"" href=""Tours_details.aspx?cid=" & sdr(0).ToString & """>" & _
                                            "<img style=""width:150px;"" src=""" & TourImage & """ class=""attachment-shop_thumbnail"" alt=""" & sdr(1).ToString & """>" & _
                                        "</a>" & _
                                    "</div>" & _
                                    "<div class=""cart-item-details"">" & _
                                        "<h6><a data-animated-link=""fadeOut"" href=""Tours_details.aspx?cid=" & sdr(0).ToString & """>" & sdr(1).ToString & "</a></h6>" & _
                                    "</div>" & _
                                "</td>" & _
                                "<td>" & sdr(2).ToString & "</td>" & _
                                "<td>" & sdr(3).ToString & "</td>" & _
                                "<td>" & lblSumTotalPrice & "</td>" & _
                                "<td>" & lblAgencyCommission & "</td>" & _
                                "<td>" & ExtraServices.ToString("N0") & " " & CurrencyType & "</td>" & _
                                "<td>" & lblDiscount & "</td>" & _
                                "<td>" & lblTotalPriceDefaultCurrency & "<br/><b>" & lblTotalPriceTooman & "</b></td>" & _
                                "<td class=""product-remove"">" & _
                                    "<h6><a data-animated-link=""fadeOut"" href=""#""><i class=""fa fa-trash-o"" onclick=""DeleteBasket('" & sdr(8).ToString & "');"" ></i></a></h6>" & _
                                "</td>" & _
                            "</tr>"

                Total += sdr(7)
                QTY += 1
            End While

        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SQLCon.SqlCon.Close()
        End Try

        value(1) = QTY
        value(2) = Total
        Return value
    End Function
End Class
