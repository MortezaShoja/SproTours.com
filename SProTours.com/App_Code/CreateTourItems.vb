Imports Microsoft.VisualBasic

Public Class CreateTourItems

    Public Function GenerateItem(ByVal MenuCode As Integer, ByVal TourID As String, ByVal TourName As String, ByVal ImageAddress As String) As String

        Dim value As String = String.Empty

        value += "<li class=""col-md-3 col-sm-3 grid-item format-standard portraits " & MenuCode & """>" ' First Of Row 1
        value += "<div class=""thumb"">"

        value += "<header class=""thumb-header"">"
        'Value += "<a class=""hover-img curved"" onclick=""LoadFrom1('" & CCategoryName(i).ToString & "')"">"
        value += "<a class=""hover-img curved"" href=""Tours_details.aspx?cid=" & TourID & """>"
        value += "<img src=""" & ImageAddress & """/>"
        value += "</a>"
        value += "</header>"

        value += "<div class=""thumb-caption"">"
        value += "<div class=""row"">"


        value += "<div class=""col-md-12"">"
        value += "<p style=""text-align:right"" dir=""rtl"">" & TourName & "</p>"
        value += "</div>"


        value += "</div>"
        value += "</div>"
        value += "</div>"
        value += "</li>"

        Return value

    End Function

End Class
