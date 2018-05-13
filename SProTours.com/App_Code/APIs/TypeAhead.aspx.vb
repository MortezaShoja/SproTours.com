Imports System.Data

Partial Class TypeAhead
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Act As String = Request.QueryString("Action")
        If Act.Length >= 3 Then
            Response.Write(GetResult(Act))
        End If

    End Sub

    Private Function GetResult(ByVal SearchChar As String) As String
        Dim SLV As New StringLanguageValidation


        Dim tmp As String = ConvertToEnglish(SearchChar)
        SearchChar = tmp
        Dim SqlCon As New SqlConnectionHotels
        Dim Cmd As New SqlClient.SqlCommand
        Dim Value As String = String.Empty
        Try

            'Cmd.Parameters.Add("@HotelName", SqlDbType.NVarChar).Value = SearchChar

            'Cmd.CommandText = "select top 7 HotelName,City,Country,HotelCode From Hotels Where HotelName Like N'%" & SearchChar.Replace(" ", "%") & "%' or City Like N'%" & SearchChar.Replace(" ", "%") & "%' Or Country Like N'%" & SearchChar.Replace(" ", "%") & "%'"
            Cmd.CommandText = "select top 7 HotelName,City,Country,HotelCode From Hotels Where HotelName Like N'%" & SearchChar.Replace(" ", "%") & "%'"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Value += sdr(0).ToString & ", " & sdr(1).ToString & ", " & sdr(2).ToString & ", " & sdr(3).ToString & "~"
                'Value += sdr(1).ToString & ", " & sdr(2).ToString & ", " & sdr(3).ToString & "~"
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Try
            Value = Mid(Value, 1, Value.Length - 1)
        Catch ex As Exception
            Value = String.Empty
        End Try

        Return Value
    End Function

    Private Function ConvertToEnglish(ByVal SearchText As String) As String
        Dim Value As String = String.Empty

        Dim tmpArr() As Char = SearchText.ToCharArray
        For I As Integer = 0 To tmpArr.Length - 1
            Dim tmpvalue As String = String.Empty
            Select Case tmpArr(I)
                Case Is = "ا"
                    tmpvalue = "a"
                Case Is = "آ"
                    tmpvalue = "a"
                Case Is = "ب"
                    tmpvalue = "b"
                Case Is = "پ"
                    tmpvalue = "p"
                Case Is = "ت"
                    tmpvalue = "t"
                Case Is = "ث"
                    tmpvalue = "s"
                Case Is = "ج"
                    tmpvalue = "j"
                Case Is = "چ"
                    tmpvalue = "ch"
                Case Is = "ح"
                    tmpvalue = "h"
                Case Is = "خ"
                    tmpvalue = "kh"
                Case Is = "د"
                    tmpvalue = "d"
                Case Is = "ذ"
                    tmpvalue = "z"
                Case Is = "ر"
                    tmpvalue = "r"
                Case Is = "ز"
                    tmpvalue = "z"
                Case Is = "ژ"
                    tmpvalue = "zh"
                Case Is = "س"
                    tmpvalue = "s"
                Case Is = "ص"
                    tmpvalue = "s"
                Case Is = "ض"
                    tmpvalue = "z"
                Case Is = "ط"
                    tmpvalue = "t"
                Case Is = "ظ"
                    tmpvalue = "z"
                Case Is = "ع"
                    tmpvalue = "e"
                Case Is = "ف"
                    tmpvalue = "f"
                Case Is = "ق"
                    tmpvalue = "gh"
                Case Is = "غ"
                    tmpvalue = "gh"
                Case Is = "ک"
                    tmpvalue = "k"
                Case Is = "گ"
                    tmpvalue = "g"
                Case Is = "ل"
                    tmpvalue = "l"
                Case Is = "م"
                    tmpvalue = "m"
                Case Is = "ن"
                    tmpvalue = "n"
                Case Is = "و"
                    tmpvalue = "v"
                Case Is = "ه"
                    tmpvalue = "h"
                Case Is = "ی"
                    tmpvalue = "i"
            End Select
            If tmpvalue = String.Empty Then
                Value += tmpArr(I)
            Else
                Value += tmpvalue
            End If
        Next
        Return Value
    End Function
End Class
