Public Class FileSecurity
    Public Shared Function Code(ByVal InputString As String, ByVal Differ As Integer) As String
        Dim CharArray() As Char = InputString.ToCharArray
        Dim TempString As String = String.Empty
        If Differ > -1 And Differ < 134 Then
            Dim c As Integer
            For c = 0 To CharArray.Length - 1
                CharArray(c) = Chr(Asc(CharArray(c)) - Differ)
                TempString &= CharArray(c)
            Next
        End If
        Return (TempString)
    End Function

    Public Shared Function DeCode(ByVal InputString As String, ByVal Differ As Integer) As String
        Dim CharArray() As Char = InputString.ToCharArray
        Dim TempString As String = String.Empty
        If Differ > -1 And Differ < 134 Then
            Dim c As Integer
            For c = 0 To CharArray.Length - 1
                CharArray(c) = Chr(Asc(CharArray(c)) + Differ)
                TempString &= CharArray(c)
            Next
        End If
        Return (TempString)
    End Function
End Class
