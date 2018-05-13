Imports Microsoft.VisualBasic

Public Class StringLanguageValidation

    'Validates a string of alpha characters
    Public Function CheckForAlphaCharacters(ByVal StringToCheck As String) As String
        For i = 0 To StringToCheck.Length - 1
            If Not Char.IsLetter(StringToCheck.Chars(i)) Then
                If Not Char.IsWhiteSpace(StringToCheck.Chars(i)) Then
                    Return False
                End If
            End If
        Next

        Return True 'Return true if all elements are characters
    End Function

End Class
