Imports Microsoft.VisualBasic

Public Class PackageGenerator

    Public Function Generate(ByVal ImageAddress As String, ByVal CurrencyType As String, ByVal HotelName As String, ByVal HotelStars As String, ByVal HotelAddress As String, ByVal RoomType As String, ByVal SingleRoom As String, ByVal DoubleRoom As String, ByVal ExtraBed As String, ByVal Child As String, ByVal Infant As String, ByVal Availability As String) As String

        If IsNumeric(SingleRoom) = True Then
            SingleRoom = CurrencyType & " " & SingleRoom
        End If
        If IsNumeric(DoubleRoom) = True Then
            DoubleRoom = CurrencyType & " " & DoubleRoom
        End If
        If IsNumeric(ExtraBed) = True Then
            ExtraBed = CurrencyType & " " & ExtraBed
        End If
        If IsNumeric(Child) = True Then
            Child = CurrencyType & " " & Child
        End If
        If IsNumeric(Infant) = True Then
            Infant = CurrencyType & " " & Infant
        End If

        Dim Value As String =
        "<tr><td>" & _
        "<table cellpadding=""0"" cellspacing=""0"" class=""style1"">" & _
        "<tr>" & _
            "<td bgcolor=""#ED7D31"" style=""border-bottom-style: groove; border-bottom-width: 3px; "" class=""style35"">&nbsp;</td>" & _
            "<td bgcolor=""#ED7D31"" style=""border-bottom-style: groove; border-bottom-width: 3px; "" class=""style37"">&nbsp;</td>" & _
            "<td bgcolor=""#ED7D31"" class=""style35"" style=""border-bottom-style: groove; border-bottom-width: 3px"">&nbsp;</td>" & _
            "<td bgcolor=""#ED7D31"" style=""color: #FFFFFF; border-bottom-style: groove; border-bottom-width: 3px"" class=""style38"">" & HotelStars & "</td>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style5"" width=""15.5%"">&nbsp;</td>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td bgcolor=""#ED7D31"" colspan=""5"" style=""border-bottom-style: groove; border-bottom-width: 3px; border-right-style: solid; border-right-width: thin; border-right-color: #000000; Text-align: center; Color: #FFFFFF;"">" & Availability & "</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td class=""style37"" style=""border-bottom-style: solid; border-bottom-width: thin; border-right-style: solid; border-right-width: thin; border-bottom-color: #000000; border-right-color: #000000;"" colspan=""3"" rowspan=""5""><img alt="""" src=""" & ImageAddress & """ width=""100%"" /></td>" & _
            "<td rowspan=""2"" class=""style38"">" & "&nbsp;" & HotelName & "</td>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style5"" width=""15.5%"">&nbsp;</td>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
            "<td style=""border-right-style: solid; border-right-width: thin; border-right-color: #000000"" class=""style41"">&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style5"" width=""15.5%""></td>" & _
            "<td class=""style35""></td>" & _
            "<td bgcolor=""#ED7D31"" class=""style40"" style=""color: #FFFFFF; border-right-style: groove; border-right-width: thin; border-right-color: #FFFFFF;"">SNG</td>" & _
            "<td bgcolor=""#ED7D31"" class=""style40"" style=""color: #FFFFFF; border-right-style: groove; border-right-width: thin; border-right-color: #FFFFFF;"">DBL</td>" & _
            "<td bgcolor=""#ED7D31"" class=""style40"" style=""color: #FFFFFF; border-right-style: groove; border-right-width: thin; border-right-color: #FFFFFF;"">Ex Bed</td>" & _
            "<td bgcolor=""#BC5610"" class=""style40"" style=""color: #FFFFFF; border-right-style: groove; border-right-width: thin; border-right-color: #FFFFFF;"">6-12</td>" & _
            "<td bgcolor=""#BC5610"" class=""style40"" style=""border-right-style: solid; border-right-width: thin; border-right-color: #000000; color: #FFFFFF;"">0-5</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td rowspan=""3"" style=""border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000; background-color: #f2f2f2;"" class=""style38"">" & "&nbsp;" & HotelAddress & "</td>" & _
            "<td class=""style36""></td>" & _
            "<td class=""style25"" style=""background-color: #d9d9d9"" width=""15.5%""></td>" & _
            "<td class=""style36""></td>" & _
            "<td class=""style42""></td>" & _
            "<td class=""style42""></td>" & _
            "<td class=""style42""></td>" & _
            "<td class=""style42""></td>" & _
            "<td class=""style42"" style=""border-right-style: solid; border-right-width: thin; border-right-color: #000000""></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style5"" style=""border-top-style: groove; border-bottom-style: groove; border-top-width: 5px; border-bottom-width: 5px; border-top-color: #FFFFFF; border-bottom-color: #FFFFFF"" width=""15.5%"">" & RoomType & "</td>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style40"" style=""border-top-style: groove; border-bottom-style: groove; border-top-width: 2px; border-bottom-width: 2px"">" & SingleRoom & "</td>" & _
            "<td class=""style40"" style=""border-top-style: groove; border-bottom-style: groove; border-top-width: 2px; border-bottom-width: 2px"">" & DoubleRoom & "</td>" & _
            "<td class=""style40"" style=""border-top-style: groove; border-bottom-style: groove; border-top-width: 2px; border-bottom-width: 2px"">" & ExtraBed & "</td>" & _
            "<td class=""style40"" style=""border-top-style: groove; border-bottom-style: groove; border-top-width: 2px; border-bottom-width: 2px"">" & Child & "</td>" & _
            "<td class=""style40"" style=""border-top-style: groove; border-bottom-style: groove; border-top-width: 2px; border-bottom-width: 2px; border-right-style: ridge; border-right-width: thin; border-right-color: #000000;"">" & Infant & "</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td class=""style35"" style=""border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000"">&nbsp;</td>" & _
            "<td class=""style5"" style=""border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000; background-color: #d9d9d9;"" width=""15.5%"">&nbsp;</td>" & _
            "<td class=""style35"" style=""border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000"">&nbsp;</td>" & _
            "<td style=""border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000"" class=""style41"">&nbsp;</td>" & _
            "<td style=""border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000"" class=""style41"">&nbsp;</td>" & _
            "<td style=""border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000"" class=""style41"">&nbsp;</td>" & _
            "<td style=""border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000"" class=""style41"">&nbsp;</td>" & _
            "<td style=""border-bottom-style: solid; border-bottom-width: thin; border-right-style: solid; border-right-width: thin; border-bottom-color: #000000; border-right-color: #000000;"" class=""style41"">&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style37"">&nbsp;</td>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style38"">&nbsp;</td>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style5"" width=""15.5%"">&nbsp;</td>" & _
            "<td class=""style35"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
            "<td class=""style41"">&nbsp;</td>" & _
        "</tr>" & _
        "</table>" & _
        "</tr></td>"

        Return Value

    End Function

End Class
