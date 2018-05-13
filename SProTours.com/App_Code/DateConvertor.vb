Public Class DateConvertor

    Private Myear, Mmonth, Mday, a, m, y, d, n, x, b, c, Fyear, Fmonth, Fday As Integer
    Public Hyear, Hmonth, Hday As String
    Private HweekDayINT As Integer
    Public HweekDay As String
    Public Time As String

    Public Sub Convertor(Optional ByVal DateTime As String = "")

        '------------------ Input Milady Date ------------------------
        If DateTime = "" Then
            Myear = Now.Year.ToString
            Mmonth = Now.Month.ToString
            Mday = Now.Day.ToString
        Else
            Dim DTC() = DateTime.Split("/")
            Time = Mid(DTC(2), 5, 13)
            Myear = Mid(DTC(2), 1, 4)
            Mmonth = DTC(0)
            Mday = DTC(1)
        End If


        '---------------------- Convert Date ------------------------
        a = Int((14 - Mmonth) / 12)
        m = Mmonth + 12 * a - 3
        y = Myear - a - 1600
        d = 365 * y + Int(y / 4) - Int(y / 100) + Int(y / 400) + Int((153 * m + 2) / 5) + Mday - 1
        n = d - 84756
        x = n Mod 12053
        b = (x Mod 1461) + (1461) * Int(x / 11688)
        c = (b Mod 365) + 365 * Int(b / (1460 + 365 * Int((x + 1) / 11688)))
        '------------------ Output Hijiri Date -----------------------
        Fyear = 1211 + 33 * (n - x) / 12053 + 4 * (x - b) / 1461 + (b - c) / 365
        Fmonth = Int((c - 186 * Int(c / 186)) / (31 - Int(c / 186))) + 6 * Int(c / 186) + 1
        Fday = ((c - 186 * Int(c / 186)) Mod (31 - Int(c / 186))) + 1
        '------------------------- Hijiri WeekDay -----------------------
        HweekDayINT = (n + 4) Mod 7
        '--------------------- two String -----------------
        Hyear = Fyear.ToString
        '---------------------------------------
        If Fmonth <= 9 Then
            Hmonth = "0" & Fmonth.ToString
        Else
            Hmonth = Fmonth.ToString
        End If
        '-----------------------------------
        If Fday <= 9 Then
            Hday = "0" & Fday.ToString
        Else
            Hday = Fday.ToString
        End If
        Select Case HweekDayINT

            Case 0
                HweekDay = "شنبه"
            Case 1
                HweekDay = "یک شنبه"
            Case 2
                HweekDay = "دو شنبه"
            Case 3
                HweekDay = "سه شنبه"
            Case 4
                HweekDay = "چهار شنبه"
            Case 5
                HweekDay = "پنج شنبه"
            Case 6
                HweekDay = "جمعه"


        End Select


    End Sub


End Class


