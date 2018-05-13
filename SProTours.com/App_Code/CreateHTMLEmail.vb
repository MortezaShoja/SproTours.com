Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Web
Imports System.Data

Public Class CreateHTMLEmail

    Private GTI As GetTourInfo


    Public Function CreateEmailNoChange(ByVal Path As String)

        Dim reader As StreamReader
        Dim strFileName As String = Path
        Dim strFileText
        reader = File.OpenText(strFileName)
        While reader.Peek <> -1
            strFileText += reader.ReadLine()
        End While
        reader.Close()
        Return strFileText
    End Function

    Public Function CreateHotelInvoice(ByVal RequestCode As String, ByVal RequestDate As String, ByVal Hotelname As String, ByVal HotelAddress As String, ByVal HotelStar As Integer, ByVal RoomTypes As String, ByVal CheckIn As String, ByVal CheckOut As String, ByVal Path As String) As String

        Dim reader As StreamReader
        Dim strFileName As String = Path
        Dim strFileText
        reader = File.OpenText(strFileName)
        While reader.Peek <> -1
            strFileText += reader.ReadLine()
        End While
        reader.Close()
        strFileText = Replace(strFileText, "#RequestCode#", RequestCode)
        strFileText = Replace(strFileText, "#RequestDate#", RequestDate)
        strFileText = Replace(strFileText, "#HotelName#", Hotelname)
        strFileText = Replace(strFileText, "#HotelAddress#", HotelAddress)
        Dim tmpHotelStars As String = String.Empty
        For I As Integer = 1 To HotelStar
            tmpHotelStars += " <i class=""fa fa-star"" style=""color:#ed8323""></i>"
        Next
        strFileText = Replace(strFileText, "#HotelStars#", tmpHotelStars)
        strFileText = Replace(strFileText, "#RoomTypes#", RoomTypes)

        strFileText = Replace(strFileText, "#CheckIn#", CheckIn)
        strFileText = Replace(strFileText, "#CheckOut#", CheckOut)

        Return strFileText
    End Function

    Public Function CreateHotelReservationRequestEmail(ByVal RequestCode As Integer, ByVal Hotelname As String, ByVal HotelAddress As String, ByVal Checkin As String, ByVal Checkout As String, ByVal Rooms As String, ByVal Adult As String, ByVal Child As String, ByVal Ages As String, ByVal RoomTypes As String, ByVal AganceName As String, ByVal Name As String, ByVal Family As String, ByVal Phone As String, ByVal Email As String, ByVal Descriptions As String, ByVal Path As String) As String

        Dim reader As StreamReader
        Dim strFileName As String = Path
        Dim strFileText
        reader = File.OpenText(strFileName)
        While reader.Peek <> -1
            strFileText += reader.ReadLine()
        End While
        reader.Close()
        strFileText = Replace(strFileText, "#RequestCode#", RequestCode)
        strFileText = Replace(strFileText, "#Hotelname#", Hotelname)
        strFileText = Replace(strFileText, "#HotelAddress#", HotelAddress)
        strFileText = Replace(strFileText, "#Checkin#", Checkin)
        strFileText = Replace(strFileText, "#Checkout#", Checkout)

        strFileText = Replace(strFileText, "#Rooms#", Rooms)
        strFileText = Replace(strFileText, "#Guests#", Integer.Parse(Adult) + Integer.Parse(Child))
        strFileText = Replace(strFileText, "#Adult#", Adult)
        strFileText = Replace(strFileText, "#Child#", Child)

        strFileText = Replace(strFileText, "#Ages#", Ages)
        strFileText = Replace(strFileText, "#RoomTypes#", RoomTypes.Replace(",", "<br />"))
        strFileText = Replace(strFileText, "#Name#", Name)

        strFileText = Replace(strFileText, "#AGANCY#", AganceName)
        strFileText = Replace(strFileText, "#Family#", Family)
        strFileText = Replace(strFileText, "#Phone#", Phone) '<a href="mailto:no-one@snai1mai1.com?subject=free chocolate">example</a>
        strFileText = Replace(strFileText, "#Email#", "<a href=""mailto:" & Email & "?subject=قیمت هتل"" > " & Email & "</a>")
        strFileText = Replace(strFileText, "#Descriptions#", Descriptions.Replace(vbLf, "<br />"))

        Return strFileText
    End Function


    'Public Function CreateToursVoucher(ByVal RequestCode As Integer, ByVal TourName As String, ByVal TourImage As String, ByVal Checkin As String, ByVal Adult As String, ByVal Child As String, ByVal Ages As String, ByVal Name As String, ByVal Family As String, ByVal Phone As String, ByVal Email As String, ByVal Descriptions As String, ByVal TourPlan As String, ByVal StartDate As String, ByVal Rules As String, ByVal SumTotal As String, ByVal ChildDiscount As String, ByVal AgancyCommission As String, ByVal TotalPriceDefaultCurrency As String, ByVal TotalPriceToman As String, ByVal PaymentDate As String, ByVal RefNum As String, ByVal ThisYear As String, ByVal Path As String) As String
    Public Function CreateToursVoucher(ByVal PaymentCode As String, ByVal Path As String) As Object

        Dim reader As StreamReader
        Dim strFileName As String = Path & "\Email\Tour_Voucher.htm"
        Dim tmpstrFileText As Object
        Dim strFileText As Object = Nothing
        reader = File.OpenText(strFileName)
        While reader.Peek <> -1
            tmpstrFileText += reader.ReadLine()
        End While
        reader.Close()

        Dim SqlCon As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@Code", SqlDbType.Int).Value = PaymentCode
            '                                               0                          1        2           3             4           5        6          7            8        9         10       11       12      13        14       15     16       17       18     19         20                21              22          23
            Cmd.CommandText = "SELECT ROW_NUMBER() over(order by R.RequestDate desc),R.ID,T.TourName,R.RequestCode,R.RequestDate,R.TourID,R.CheckIn,R.NoOfAdults,R.NoOfChild,R.Child1,R.Child2,R.Child3,R.Child4,R.Child5,R.Child6,R.Child7,R.Name,R.Family,R.Phone,R.Email,R.Description,R.ExtraServicesDetails,T.TourTime,T.TourPlan FROM TourRequests R Inner Join TourDetails T on R.TourID=T.ID inner join Payments P on R.paymentID=P.ID where P.Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                strFileText += tmpstrFileText

                strFileText = Replace(strFileText, "#Row#", sdr(0).ToString)
                strFileText = Replace(strFileText, "#RequestCode#", sdr(3).ToString)
                strFileText = Replace(strFileText, "#QRCodeAddress#", "http://Sprotours.com/QRCode/" & sdr(1).ToString & ".jpg")
                strFileText = Replace(strFileText, "#TourName#", sdr(2).ToString)
                strFileText = Replace(strFileText, "#Checkin#", Date.Parse(sdr(6).ToString).ToString("yyyy/MMM/dd"))

                strFileText = Replace(strFileText, "#AdultQTY#", sdr(7).ToString)
                strFileText = Replace(strFileText, "#ChildQTY#", sdr(8).ToString)

                Dim ChildAges As String = String.Empty
                Try

                    If sdr(8) >= 1 Then
                        If sdr(9).ToString <> String.Empty Then
                            If sdr(9) > 0 Then
                                ChildAges += "کودک اول : <b>" & sdr(9) & "</b> سال | "
                            Else
                                ChildAges += "کودک اول :  <b>زیر یک سال</b> | "
                            End If
                        End If
                    End If

                    If sdr(8) >= 2 Then
                        If sdr(10).ToString <> String.Empty Then
                            If sdr(10) > 0 Then
                                ChildAges += "کودک دوم : <b>" & sdr(10) & "</b> سال | "
                            Else
                                ChildAges += "کودک دوم :  <b>زیر یک سال</b> | "
                            End If
                        End If
                    End If

                    If sdr(8) >= 3 Then
                        If sdr(11).ToString <> String.Empty Then
                            If sdr(11) > 0 Then
                                ChildAges += "کودک سوم : <b>" & sdr(11) & "</b> سال | "
                            Else
                                ChildAges += "کودک سوم :  <b>زیر یک سال</b> | "
                            End If
                        End If
                    End If

                    If sdr(8) >= 4 Then
                        If sdr(12).ToString <> String.Empty Then
                            If sdr(12) > 0 Then
                                ChildAges += "کودک چهارم : <b>" & sdr(12) & "</b> سال | "
                            Else
                                ChildAges += "کودک چهارم :  <b>زیر یک سال</b> | "
                            End If
                        End If
                    End If

                    If sdr(8) >= 5 Then
                        If sdr(13).ToString <> String.Empty Then
                            If sdr(13) > 0 Then
                                ChildAges += "کودک پنجم : <b>" & sdr(13) & "</b> سال | "
                            Else
                                ChildAges += "کودک پنجم :  <b>زیر یک سال</b> | "
                            End If
                        End If
                    End If

                    If sdr(8) >= 6 Then
                        If sdr(14).ToString <> String.Empty Then
                            If sdr(14) > 0 Then
                                ChildAges += "کودک ششم : <b>" & sdr(14) & "</b> سال | "
                            Else
                                ChildAges += "کودک ششم :  <b>زیر یک سال</b> | "
                            End If
                        End If
                    End If

                    If sdr(8) >= 7 Then
                        If sdr(15).ToString <> String.Empty Then
                            If sdr(15) > 0 Then
                                ChildAges += "کودک هفتم : <b>" & sdr(15) & "</b> سال | "
                            Else
                                ChildAges += "کودک هفتم :  <b>زیر یک سال</b> | "
                            End If
                        End If
                    End If

                    'ChildAges = "<table>"

                    'If sdr(8) >= 1 Then
                    '    If sdr(9).ToString <> String.Empty Then
                    '        If sdr(9) > 0 Then
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک اول :</td><td style=""text-align: right"">" & sdr(9) & " سال " & "</td></tr>"
                    '        Else
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک اول :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
                    '        End If
                    '    End If
                    'End If

                    'If sdr(8) >= 2 Then
                    '    If sdr(10).ToString <> String.Empty Then
                    '        If sdr(10) > 0 Then
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک دوم :</td><td style=""text-align: right"">" & sdr(10) & " سال " & "</td></tr>"
                    '        Else
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک دوم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
                    '        End If
                    '    End If
                    'End If

                    'If sdr(8) >= 3 Then
                    '    If sdr(11).ToString <> String.Empty Then
                    '        If sdr(11) > 0 Then
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک سوم :</td><td style=""text-align: right"">" & sdr(11) & " سال " & "</td></tr>"
                    '        Else
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک سوم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
                    '        End If
                    '    End If
                    'End If

                    'If sdr(8) >= 4 Then
                    '    If sdr(12).ToString <> String.Empty Then
                    '        If sdr(12) > 0 Then
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک چهارم :</td><td style=""text-align: right"">" & sdr(12) & " سال " & "</td></tr>"
                    '        Else
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک چهارم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
                    '        End If
                    '    End If
                    'End If

                    'If sdr(8) >= 5 Then
                    '    If sdr(13).ToString <> String.Empty Then
                    '        If sdr(13) > 0 Then
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک پنجم :</td><td style=""text-align: right"">" & sdr(13) & " سال " & "</td></tr>"
                    '        Else
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک پنجم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
                    '        End If
                    '    End If
                    'End If

                    'If sdr(8) >= 6 Then
                    '    If sdr(14).ToString <> String.Empty Then
                    '        If sdr(14) > 0 Then
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک ششم :</td><td style=""text-align: right"">" & sdr(14) & " سال " & "</td></tr>"
                    '        Else
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک ششم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
                    '        End If
                    '    End If
                    'End If

                    'If sdr(8) >= 7 Then
                    '    If sdr(15).ToString <> String.Empty Then
                    '        If sdr(15) > 0 Then
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک هفتم :</td><td style=""text-align: right"">" & sdr(15) & " سال " & "</td></tr>"
                    '        Else
                    '            ChildAges += "<tr><td style=""text-align: left"">کودک هفتم :</td><td style=""text-align: right""> زیر یک سال</td></tr>"
                    '        End If
                    '    End If
                    'End If
                    'ChildAges += "</table>"

                Catch ex As Exception

                End Try

                strFileText = Replace(strFileText, "#ChildAges#", ChildAges)

                strFileText = Replace(strFileText, "#Name#", sdr(16).ToString)
                strFileText = Replace(strFileText, "#Family#", sdr(17).ToString)
                strFileText = Replace(strFileText, "#Mobile#", sdr(18).ToString) '<a href="mailto:no-one@snai1mai1.com?subject=free chocolate">example</a>
                strFileText = Replace(strFileText, "#Email#", "<a href=""mailto:" & sdr(16).ToString & "?subject=قیمت تور"" > " & sdr(19).ToString & "</a>")
                strFileText = Replace(strFileText, "#Descriptions#", sdr(20).ToString.Replace(vbLf, "<br />"))
                strFileText = Replace(strFileText, "#ExtraServices#", sdr(21).ToString)

                strFileText = Replace(strFileText, "#TourTime#", sdr(22).ToString).Replace(vbCrLf, "<br />")
                strFileText = Replace(strFileText, "#TourPlan#", sdr(23).ToString).Replace(vbCrLf, "<br />")

            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        'RequestResult = strFileText

        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim VoucherStrFileName As String = Path & "/Email/Voucher.htm"
        Dim VoucherstrFileText(1) As Object
        reader = File.OpenText(VoucherStrFileName)
        While reader.Peek <> -1
            VoucherstrFileText(0) += reader.ReadLine()
        End While
        reader.Close()

        '-----------------------------------------------------------------------------

        Dim PaymentDetails() As Object = CreateCustomerReceipt(PaymentCode)
        VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#RowItems#", PaymentDetails(0))
        VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#SumTotalPrice#", Decimal.Parse(PaymentDetails(1)).ToString("N0"))
        GTI = New GetTourInfo
        Dim TourDiscount As Decimal = GTI.GetDescount(PaymentDetails(2))
        VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#Discount#", TourDiscount.ToString("N0"))
        VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#TotalPrice#", Decimal.Parse(PaymentDetails(1) - TourDiscount).ToString("N0"))
        VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#PaymentRefno#", PaymentDetails(4))
        VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#PaymentStatus#", PaymentDetails(5))


        '-------------------------------------------------------------------------------

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@Code", SqlDbType.Int).Value = PaymentCode
            Cmd.CommandText = "select P.RegDate,M.MemberType,M.CoAgencyName,M.FullName,M.Email From Members M inner join Payments P on P.MemberID=M.ID where P.Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#ThisYear#", Now.Year.ToString)
                VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#VoucherItems#", strFileText)
                VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#PaymentCode#", PaymentCode)
                VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#PaymentDate#", sdr(0).ToString)
                Try
                    If sdr(2).ToString <> String.Empty Then
                        VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#Agency#", sdr(1).ToString & " " & sdr(2).ToString)
                    Else
                        VoucherstrFileText(0) = Replace(VoucherstrFileText(0), "#Agency#", sdr(3).ToString)
                    End If
                Catch ex As Exception
                End Try
                VoucherstrFileText(1) = sdr(4).ToString
            End If
        Catch ex As Exception

        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return VoucherstrFileText
    End Function

    Public Function CreateReceipt(ByVal PaymentCode As String, ByVal Path As String) As Object

        Dim reader As StreamReader
        Dim strFileName As String = Path & "\Email\Receipt.htm"
        Dim strFileText As Object = Nothing
        reader = File.OpenText(strFileName)
        While reader.Peek <> -1
            strFileText += reader.ReadLine()
        End While
        reader.Close()

        Dim Value As Object = Nothing
        Dim PaymentDate As String = String.Empty
        Dim PaymentRefNum As String = String.Empty
        Dim PaymentStatus As String = String.Empty
        Dim SumTotalPrice As Decimal = 0
        Dim TourQTY As Integer = 0

        Dim SqlCon As New SqlConnectionSite

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@Code", SqlDbType.Int).Value = PaymentCode
            '                                                       0                  1        2           3              4         5       6       7           8             9               10                  11          12              13              14              15            16         17          18            19            20
            Cmd.CommandText = "SELECT ROW_NUMBER() over(order by R.RequestDate desc),R.ID,T.TourName,R.RequestCode,R.RequestDate,R.CheckIn,R.Name,R.Family,R.CurrencyType,R.CurrentRate,R.AdultSinglePrice,R.DiscountFromQTY,R.Discount,R.AgencyCommission,R.ChildDiscount,R.NoOfAdults,R.NoOfChild,P.RegDate,P.PaymentRefnum,P.Status,R.ExtraServicesTotal FROM TourRequests R Inner Join TourDetails T on R.TourID=T.ID inner join Payments P on R.paymentID=P.ID where P.Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                TourQTY += 1

                Dim CurrencyType As String = sdr(8).ToString
                Dim CurrencyRate As Decimal = sdr(9)
                Dim AdultSinglePrice As Decimal = sdr(10)
                Dim DiscountFromQTY As Integer = sdr(11)
                Dim Discount As Decimal = sdr(12)
                Dim AgencyCommission As Decimal = sdr(13)
                Dim ChildDiscount As Decimal = sdr(14)
                Dim AdultCount As Integer = sdr(15)
                Dim ChildCount As Integer = sdr(16)

                Dim ExtraServices As Decimal = sdr(20)

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
                SumTotalPrice += Decimal.Parse(CurrencyRate * TotalPrice)

                Value += "<tr>" & _
                            "<td class=""style2"" style=""border: thin solid #000000; text-align: center; vertical-align: middle; background-color: #FF9933;"">" & sdr(0).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style4"">" & sdr(3).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"">" & sdr(2).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style5"">" & sdr(15).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style6"">" & sdr(16).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style10"">" & lblSumTotalPrice & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style9"">" & lblDiscount & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style8"">" & lblAgencyCommission & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style8"">" & ExtraServices & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style7"">" & lblTotalPriceDefaultCurrency & "<br/>" & lblTotalPriceTooman & "</td>" & _
                        "</tr>"

                PaymentDate = Date.Parse(sdr(17)).ToString("yyyy/MMM/dd")
                PaymentRefNum = sdr(18).ToString
                PaymentStatus = sdr(19).ToString

            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try


        strFileText = Replace(strFileText, "#RowItems#", Value)

        strFileText = Replace(strFileText, "#PaymentCode#", PaymentCode)
        strFileText = Replace(strFileText, "#PaymentDate#", PaymentDate)
        strFileText = Replace(strFileText, "#RefNum#", PaymentRefNum)
        strFileText = Replace(strFileText, "#PaymentStatus#", PaymentStatus)


        strFileText = Replace(strFileText, "#SumTotalPrice#", SumTotalPrice.ToString("N0"))
        GTI = New GetTourInfo
        Dim TourDiscount As Decimal = GTI.GetDescount(TourQTY)
        strFileText = Replace(strFileText, "#Discount#", TourDiscount.ToString("N0"))
        strFileText = Replace(strFileText, "#TotalPrice#", (SumTotalPrice - TourDiscount).ToString("N0"))

        strFileText = Replace(strFileText, "#ThisYear#", Now.Year.ToString)

        Return strFileText
    End Function


    Public Function CreateCustomerReceipt(ByVal PaymentCode As String) As Object


        Dim Value(7) As Object
        Dim PaymentDate As String = String.Empty
        Dim PaymentRefNum As String = String.Empty
        Dim PaymentStatus As String = String.Empty
        Dim SumTotalPrice As Decimal = 0
        Dim TourQTY As Integer = 0

        Dim SqlCon As New SqlConnectionSite

        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@Code", SqlDbType.Int).Value = PaymentCode
            '                                                       0                  1        2           3              4         5       6       7           8             9               10                  11          12              13              14              15            16         17          18            19            20
            Cmd.CommandText = "SELECT ROW_NUMBER() over(order by R.RequestDate desc),R.ID,T.TourName,R.RequestCode,R.RequestDate,R.CheckIn,R.Name,R.Family,R.CurrencyType,R.CurrentRate,R.AdultSinglePrice,R.DiscountFromQTY,R.Discount,R.AgencyCommission,R.ChildDiscount,R.NoOfAdults,R.NoOfChild,P.RegDate,P.PaymentRefnum,P.Status,R.ExtraServicesTotal FROM TourRequests R Inner Join TourDetails T on R.TourID=T.ID inner join Payments P on R.paymentID=P.ID where P.Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader

            While sdr.Read

                Dim CurrencyType As String = sdr(8).ToString
                Dim CurrencyRate As Decimal = sdr(9)
                Dim AdultSinglePrice As Decimal = sdr(10)
                Dim DiscountFromQTY As Integer = sdr(11)
                Dim Discount As Decimal = sdr(12)
                'Dim AgencyCommission As Decimal = sdr(13)
                Dim ChildDiscount As Decimal = sdr(14)
                Dim AdultCount As Integer = sdr(15)
                Dim ChildCount As Integer = sdr(16)

                Dim ExtraService As Decimal = sdr(20)

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

                'Dim Commission As Integer = ((AgencyCommission * (AdultSinglePrice * (AdultCount + ChildCount) + ExtraServices)) / 100) * -1

                'TotalPrice = (AdultSinglePrice * (AdultCount + ChildCount)) - (ChildCount * ChildDiscount) - (AgencyCommission * (AdultCount + ChildCount)) + ExtraPersonDiscount
                TotalPrice = (AdultSinglePrice * (AdultCount + ChildCount)) - (ChildCount * ChildDiscount) + ExtraPersonDiscount + ExtraService

                Dim MC As New MoneyCodec
                Dim lblSumTotalPrice As String = Decimal.Parse(AdultSinglePrice * (AdultCount + ChildCount)).ToString("N2") & " " & CurrencyType
                Dim lblDiscount As String = Decimal.Parse(((ChildCount * ChildDiscount) * -1) + ExtraPersonDiscount).ToString("N2") & " " & CurrencyType
                'Dim lblAgencyCommission As String = (-1 * Decimal.Parse(AgencyCommission * (AdultCount + ChildCount))).ToString("N2") & " " & CurrencyType
                Dim lblTotalPriceDefaultCurrency As String = Decimal.Parse(TotalPrice).ToString("N2") & " " & CurrencyType
                Dim lblTotalPriceTooman As String = Decimal.Parse(CurrencyRate * TotalPrice).ToString("N0") & " تومان "

                Value(0) += "<tr>" & _
                            "<td class=""style2"" style=""border: thin solid #000000; text-align: center; vertical-align: middle; background-color: #FF9933;"">" & sdr(0).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style4"">" & sdr(3).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"">" & sdr(2).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style5"">" & sdr(15).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style6"">" & sdr(16).ToString & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style10"">" & ExtraService & " " & CurrencyType & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style10"">" & lblSumTotalPrice & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style9"">" & lblDiscount & "</td>" & _
                            "<td style=""border: thin solid #000000; text-align: center; vertical-align: middle;"" class=""style7"">" & lblTotalPriceDefaultCurrency & "<br/>" & lblTotalPriceTooman & "</td>" & _
                        "</tr>"


                SumTotalPrice += Decimal.Parse(CurrencyRate * TotalPrice)
                Value(1) = SumTotalPrice

                TourQTY += 1
                Value(2) = TourQTY

                PaymentDate = Date.Parse(sdr(17)).ToString("yyyy/MMM/dd")
                Value(3) = PaymentDate
                PaymentRefNum = sdr(18).ToString
                Value(4) = PaymentRefNum
                PaymentStatus = sdr(19).ToString
                Value(5) = PaymentStatus

            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    Public Function CreateFlightReservationRequestEmail(ByVal RequestCode As Integer, ByVal FlyFrom As String, ByVal FlyTo As String, ByVal RaftDate As String, ByVal BargashtDate As String, ByVal FlightClass As String, ByVal Adult As String, ByVal Youth As String, ByVal Child As String, ByVal Name As String, ByVal Family As String, ByVal Phone As String, ByVal Email As String, ByVal Descriptions As String, ByVal Path As String) As String

        Dim reader As StreamReader
        Dim strFileName As String = Path
        Dim strFileText
        reader = File.OpenText(strFileName)
        While reader.Peek <> -1
            strFileText += reader.ReadLine()
        End While
        reader.Close()
        strFileText = Replace(strFileText, "#RequestCode#", RequestCode)
        strFileText = Replace(strFileText, "#FlyFrom#", FlyFrom)
        strFileText = Replace(strFileText, "#FlyTo#", FlyTo)
        strFileText = Replace(strFileText, "#RaftDate#", RaftDate)
        strFileText = Replace(strFileText, "#BargashtDate#", BargashtDate)

        strFileText = Replace(strFileText, "#Passengers#", Integer.Parse(Adult) + Integer.Parse(Child) + Integer.Parse(Youth))
        strFileText = Replace(strFileText, "#FlightClass#", FlightClass)
        strFileText = Replace(strFileText, "#Adult#", Adult)
        strFileText = Replace(strFileText, "#Youth#", Youth)
        strFileText = Replace(strFileText, "#Child#", Child)


        strFileText = Replace(strFileText, "#Name#", Name)
        strFileText = Replace(strFileText, "#Family#", Family)
        strFileText = Replace(strFileText, "#Phone#", Phone) '<a href="mailto:no-one@snai1mai1.com?subject=free chocolate">example</a>
        strFileText = Replace(strFileText, "#Email#", "<a href=""mailto:" & Email & "?subject=قیمت پرواز"" > " & Email & "</a>")
        strFileText = Replace(strFileText, "#Descriptions#", Descriptions.Replace(vbLf, "<br />"))

        Return strFileText
    End Function

    Public Function CreateRegistration(ByVal FullName As String, ByVal Email As String, ByVal Password As String, ByVal MemberID As String, ByVal Path As String) As String
        Dim strFileText As String = String.Empty

        Try
            Dim reader As StreamReader
            Dim strFileName As String = Path
            reader = File.OpenText(strFileName)
            While reader.Peek <> -1
                strFileText += reader.ReadLine()
            End While
            reader.Close()
            strFileText = Replace(strFileText, "#FullName#", FullName)
            strFileText = Replace(strFileText, "#Email#", Email)
            strFileText = Replace(strFileText, "#Password#", Password)
            strFileText = Replace(strFileText, "#MemberID#", MemberID)

        Catch ex As Exception
        End Try

        Return strFileText
    End Function
End Class
