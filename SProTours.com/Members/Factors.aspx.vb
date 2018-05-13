Imports System.Globalization
Imports System.Data

Partial Class Members_Factors
    Inherits System.Web.UI.Page
    Private SE As SendEmail
    Private CHE As CreateHTMLEmail
    Private MC As MoneyCodec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If HttpContext.Current.Request.Cookies.Get("UserSettings") Is Nothing Then
            Response.Redirect("../Default.aspx")
        Else
            If IsPostBack = False Then
                FillgvFactors()
            End If
        End If

    End Sub

    Private Sub FillgvFactors()
        Dim TmpSumTotal As Decimal = 0
        MC = New MoneyCodec
        Try
            Dim Dvw As New Data.DataView
            Dim Tbl As New Data.DataTable
            Tbl.Clear()
            Tbl.Columns.Add("شماره فاکتور")
            Tbl.Columns.Add("تاریخ صدور")
            Tbl.Columns.Add("مبلغ فاکتور")
            'populating rows

            Dim SqlCon As New SqlConnectionSite
            Dim Cmd As New SqlClient.SqlCommand
            Try
                Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(Request.Cookies("UserSettings")("ID").ToString)
                'Cmd.CommandText = "select Code,CreateDate,TotalFactorAmount from Factors Where MemberID=@MemberID order by CreateDate"
                Cmd.CommandText = "select Code,CreateDate,TotalFactorAmount from Factors Where MemberID=@MemberID order by Code desc"
                Cmd.Connection = SqlCon.SqlCon
                SqlCon.SqlCon.Open()
                Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                While sdr.Read
                    Dim row As DataRow = Tbl.NewRow
                    row(0) = sdr(0)
                    row(1) = sdr(1)
                    row(2) = MC.Code(sdr(2))
                    TmpSumTotal += sdr(2)
                    Tbl.Rows.Add(row)
                End While
            Catch ex As Exception
                Dim ERM As New ErrorLog
                ERM.Log(Request, "Error", Request.Cookies("AdminSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "FillgvFactors#1")
            Finally
                SqlCon.SqlCon.Close()
            End Try

            Dvw = New Data.DataView(Tbl)
            Me.gvFactors.DataSource = Dvw
            Me.gvFactors.DataBind()

        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", Request.Cookies("AdminSettings")("ID").ToString, ex.StackTrace, ex.Message, "", Request.Url.Segments.Last(), "FillgvFactors#2")
        Finally

        End Try
        Me.lblSumPrice.Text = " جمع کل : " & MC.Code(TmpSumTotal) & " تومان "
    End Sub

    Protected Sub gvFactors_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvFactors.RowCommand
        Dim currentRowIndex As Integer = Int32.Parse(e.CommandArgument.ToString())
        Dim FactorNo As String = Me.gvFactors.Rows(currentRowIndex.ToString).Cells(1).Text
        Dim FactorID As String = GetFactorID(Me.gvFactors.Rows(currentRowIndex.ToString).Cells(1).Text)
        Dim ServerPath As String = Server.MapPath(Request.ApplicationPath)

        System.IO.File.Copy(ServerPath & "\admin\Factors\" & FactorNo & ".html", ServerPath & "\Factors\" & FactorID & ".html", True)

        If (e.CommandName = "btnView") Then
            Dim url As String = "../Factors/" & FactorID & ".html"
            Response.Redirect(url, False)
            'Dim s As String = "window.open('" & url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');"

            'Me.lblFactorNo.Text = FactorNo
            'Dim Sr As New System.IO.StreamReader(ServerPath & "\Factors\" & FactorID & ".html")
            'Me.lblFactorDetails.Text = Sr.ReadToEnd

            'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "script", "$('#pageModalFactor').modal('show');", True)
            'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "script", s, True)
        End If

    End Sub

    Private Function GetFactorID(ByVal FactorCode As Integer) As String
        Dim value As String = String.Empty

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand
        Try
            Cmd.Parameters.Add("@Code", SqlDbType.Int).Value = FactorCode
            Cmd.CommandText = "Select ID from Factors Where Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Request, "Error", Request.Cookies("AdminSettings")("ID").ToString, ex.StackTrace, ex.Message, Cmd.CommandText, Request.Url.Segments.Last(), "GetFactorID")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function

End Class
