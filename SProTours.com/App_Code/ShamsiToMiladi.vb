Public Class ShamsiToMiladi

    Function ConvertToMiladi(ByVal Year As String, ByVal Month As String, ByVal Day As String) As Object
        
        If Year < 1300 Then Year = Year + 1300
        Convertor(Year, Month, Day)

        Dim mToS As New MiladiToShamsi
        mToS.ConvertToShamsi(Year, Month, Day)

        Return (DateSerial(Year, Month, Day) + " " + Now.ToString("hh:mm:ss tt"))

    End Function

    Function ConvertToMiladi(ByVal Tarikh As String, Optional ByVal ShowNow As Boolean = True, Optional ByVal DoNotShoTime As Boolean = False) As Object
        Dim Value As Object = String.Empty
        Try
            If Tarikh <> "" Then
                Dim Dt() As String = Tarikh.Split("/")

                If Dt(0) < 1300 Then Dt(0) = Dt(0) + 1300
                Convertor(Dt(0), Dt(1), Dt(2))

                Dim mToS As New MiladiToShamsi
                mToS.ConvertToShamsi(Dt(0), Dt(1), Dt(2))

                If ShowNow = True And DoNotShoTime = False Then
                    Return (DateSerial(Dt(0), Dt(1), Dt(2)) + " " + Now.ToString("hh:mm:ss tt"))
                ElseIf ShowNow = False And DoNotShoTime = False Then
                    Return (DateSerial(Dt(0), Dt(1), Dt(2)) + " " + "00:00:00 AM")
                ElseIf ShowNow = False And DoNotShoTime = True Then
                    Dim DD, MM As String
                    If Dt(2).Length < 2 Then
                        DD = 0 & Dt(2).ToString
                    Else
                        DD = Dt(2)
                    End If
                    If Dt(1).Length < 2 Then
                        MM = 0 & Dt(1).ToString
                    Else
                        MM = Dt(1)
                    End If
                    Value = (MM + "/" + DD + "/" + Dt(0))
                End If
            Else
                Return ""
            End If
        Catch ex As Exception

        End Try

        Return (Value)

    End Function

    Private Sub Convertor(ByRef Y As Integer, ByRef M As Integer, ByRef D As Integer)
        If Y = 1378 Then
            If M = 12 And D = 10 Then
                Y = 2000
                M = 2
                D = 29 : Exit Sub
            End If
            If M = 12 And D > 10 Then
                D = D - 1
            End If
        ElseIf Y = 1379 Then
            D = D - 1
            If D = 0 Then
                M = M - 1
                If M > 0 And M < 7 Then D = 31
                If M > 6 Then D = 30
                If M = 0 Then
                    D = 29
                    M = 12
                    Y = Y - 1
                End If
            End If
        End If
        '*******************
        If M < 10 Or (M = 10 And D < 11) Then
            Y = Y + 621
        Else
            Y = Y + 622
        End If
        Select Case M
            Case 1
                If D < 12 Then
                    M = 3
                    D = D + 20
                Else
                    M = 4
                    D = D - 11
                End If
            Case 2
                If D < 11 Then
                    M = 4
                    D = D + 20
                Else
                    M = 5
                    D = D - 10
                End If
            Case 3
                If D < 11 Then
                    M = 5
                    D = D + 21
                Else
                    M = 6
                    D = D - 10
                End If
            Case 4
                If D < 10 Then
                    M = 6
                    D = D + 21
                Else
                    M = 7
                    D = D - 9
                End If
            Case 5, 6, 8
                If D < 10 Then
                    M = M + 2
                    D = D + 22
                Else
                    M = M + 3
                    D = D - 9
                End If
            Case 7
                If D < 9 Then
                    M = 9
                    D = D + 22
                Else
                    M = 10
                    D = D - 8
                End If
            Case 9
                If D < 10 Then
                    M = 11
                    D = D + 21
                Else
                    M = 12
                    D = D - 9
                End If
            Case 10
                If D < 11 Then
                    M = 12
                    D = D + 21
                Else
                    M = 1
                    D = D - 10
                End If
            Case 11
                If D < 12 Then
                    M = 1
                    D = D + 20
                Else
                    M = 2
                    D = D - 11
                End If
            Case 12
                If D < 10 Then
                    M = 2
                    D = D + 19
                Else
                    M = 3
                    D = D - 9
                End If

        End Select
    End Sub

End Class
