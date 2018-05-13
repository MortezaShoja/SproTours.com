Imports System.Data

Partial Class FlightTypeAhead
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Act As String = Request.QueryString("Action")
        If Act.Length >= 3 Then
            Response.Write(GetResult(Act))
        End If

    End Sub

    Private Function GetResult(ByVal SearchChar As String) As String
        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Dim Value As String = String.Empty
        Try

            'Cmd.Parameters.Add("@HotelName", SqlDbType.NVarChar).Value = SearchChar

            Cmd.CommandText = "select AirportName,AirportCode,City,Country From Airports Where City like N'%" & SearchChar.Replace(" ", "%") & "%' Or Country like N'%" & SearchChar.Replace(" ", "%") & "%' Or Airportname like N'%" & SearchChar.Replace(" ", "%") & "%' or AirportCode like N'%" & SearchChar.Replace(" ", "%") & "%'"
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

End Class
