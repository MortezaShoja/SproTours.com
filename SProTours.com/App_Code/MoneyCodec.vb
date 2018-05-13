Imports Microsoft.VisualBasic

Public Class MoneyCodec

    Public Function DeCode(ByVal Number As String) As Decimal
        Try
            Number = Number.Replace(".", "")
            Return Decimal.Parse(Number)
        Catch ex As Exception
            Return (0)
        End Try
    End Function

    Public Function Code(ByVal Number As String, Optional ByVal AsDecimal As Boolean = True) As String
        Dim value As String = String.Empty
        Try
            Number = Decimal.Parse(Number.Replace(".", ""))


            Dim tmp1() As String = Number.Split(",")

            Dim NuArr() As Char = tmp1(0).ToCharArray

            Dim tmpChr As String = String.Empty
            Dim J As Integer = 1
            For I As Integer = NuArr.Length - 1 To 0 Step -1
                tmpChr += NuArr(I)
                If J = 3 And I <> 0 Then
                    tmpChr += "."
                    J = 0
                End If
                J += 1
            Next

            For I As Integer = tmpChr.Length - 1 To 0 Step -1
                value += tmpChr(I)
            Next

            Try
                If AsDecimal = True Then
                    If Integer.Parse(tmp1(1)) > 0 Then
                        value = value + "," + tmp1(1)
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception
            value = "Error"
        End Try
        Return value
    End Function

    Public Function CodeFixUp(ByVal Number As String) As String
        Number = Number.Replace(".", "")
        Dim value As String = String.Empty

        Dim tmp1() As String = Number.Split(",")

        Try
            If tmp1(0).Length > 3 Then
                Dim taghii As String = Mid(tmp1(0), tmp1(0).Length - 2, 3)
                If Integer.Parse(Mid(tmp1(0), tmp1(0).Length - 2, 3)) > 0 Then
                    tmp1(0) = (Integer.Parse(Mid(tmp1(0), 1, tmp1(0).Length - 3)) + 1).ToString + "000"
                End If
            End If
        Catch ex As Exception

        End Try

        Dim NuArr() As Char = tmp1(0).ToCharArray

        Dim tmpChr As String = String.Empty
        Dim J As Integer = 1
        For I As Integer = NuArr.Length - 1 To 0 Step -1
            tmpChr += NuArr(I)
            If J = 3 And I <> 0 Then
                tmpChr += "."
                J = 0
            End If
            J += 1
        Next

        For I As Integer = tmpChr.Length - 1 To 0 Step -1
            value += tmpChr(I)
        Next

        Return value
    End Function

    ''---------------------------------------------------------------------------------------
    ''International Codec ------------------------------------------------------------------

    'Public Function DeCode(ByVal Number As String) As Decimal
    '    Try
    '        Number = Number.Replace(",", "")
    '        Return Decimal.Parse(Number)
    '    Catch ex As Exception
    '        Return (0)
    '    End Try

    'End Function

    'Public Function Code(ByVal Number As String, Optional ByVal AsDecimal As Boolean = True) As String
    '    Dim value As String = String.Empty
    '    Try
    '        Number = Decimal.Parse(Number.Replace(",", ""))


    '        Dim tmp1() As String = Number.Split(".")

    '        Dim NuArr() As Char = tmp1(0).ToCharArray

    '        Dim tmpChr As String = String.Empty
    '        Dim J As Integer = 1
    '        For I As Integer = NuArr.Length - 1 To 0 Step -1
    '            tmpChr += NuArr(I)
    '            If J = 3 And I <> 0 Then
    '                tmpChr += ","
    '                J = 0
    '            End If
    '            J += 1
    '        Next

    '        For I As Integer = tmpChr.Length - 1 To 0 Step -1
    '            value += tmpChr(I)
    '        Next

    '        Try
    '            If AsDecimal = True Then
    '                If Integer.Parse(tmp1(1)) > 0 Then
    '                    value = value + "." + tmp1(1)
    '                End If
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    Catch ex As Exception
    '        value = "Error"
    '    End Try
    '    Return value
    'End Function

    'Public Function CodeFixUp(ByVal Number As String) As String
    '    Number = Number.Replace(",", "")
    '    Dim value As String = String.Empty

    '    Dim tmp1() As String = Number.Split(".")

    '    Try
    '        If tmp1(0).Length > 3 Then
    '            Dim taghii As String = Mid(tmp1(0), tmp1(0).Length - 2, 3)
    '            If Integer.Parse(Mid(tmp1(0), tmp1(0).Length - 2, 3)) > 0 Then
    '                tmp1(0) = (Integer.Parse(Mid(tmp1(0), 1, tmp1(0).Length - 3)) + 1).ToString + "000"
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try

    '    Dim NuArr() As Char = tmp1(0).ToCharArray

    '    Dim tmpChr As String = String.Empty
    '    Dim J As Integer = 1
    '    For I As Integer = NuArr.Length - 1 To 0 Step -1
    '        tmpChr += NuArr(I)
    '        If J = 3 And I <> 0 Then
    '            tmpChr += ","
    '            J = 0
    '        End If
    '        J += 1
    '    Next

    '    For I As Integer = tmpChr.Length - 1 To 0 Step -1
    '        value += tmpChr(I)
    '    Next

    '    Return value
    'End Function

End Class
