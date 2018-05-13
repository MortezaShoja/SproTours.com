Imports System.Globalization

Partial Class _Hotels
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        '    Dim taghi As String = Request.QueryString("Action")
        '    If Request.QueryString("Action") = "done" And Session("submit") = "true" Then
        '        Session("submit") = "false"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "peygham();", True)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub ddlChild_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlChild.SelectedIndexChanged

        Select Case Me.ddlChild.Text
            Case Is = 0
                Me.ddlChild1.Text = ""
                Me.ddlChild2.Text = ""
                Me.ddlChild3.Text = ""
                Me.ddlChild4.Text = ""
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 1
                Me.ddlChild2.Text = ""
                Me.ddlChild3.Text = ""
                Me.ddlChild4.Text = ""
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 2
                Me.ddlChild3.Text = ""
                Me.ddlChild4.Text = ""
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 3
                Me.ddlChild4.Text = ""
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 4
                Me.ddlChild5.Text = ""
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 5
                Me.ddlChild6.Text = ""
                Me.ddlChild7.Text = ""
            Case Is = 6
                Me.ddlChild7.Text = ""
        End Select

        Me.ddlChild1.Visible = False
        Me.ddlChild2.Visible = False
        Me.ddlChild3.Visible = False
        Me.ddlChild4.Visible = False
        Me.ddlChild5.Visible = False
        Me.ddlChild6.Visible = False
        Me.ddlChild7.Visible = False
        Me.divChildAges.Visible = False

        If Me.ddlChild.Text > 0 Then
            Me.divChildAges.Visible = True
        End If

        Select Case Me.ddlChild.Text
            Case Is = "1"
                Me.ddlChild1.Visible = True
            Case Is = "2"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
            Case Is = "3"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
            Case Is = "4"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
                Me.ddlChild4.Visible = True
            Case Is = "5"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
                Me.ddlChild4.Visible = True
                Me.ddlChild5.Visible = True
            Case Is = "6"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
                Me.ddlChild4.Visible = True
                Me.ddlChild5.Visible = True
                Me.ddlChild6.Visible = True
            Case Is = "7"
                Me.ddlChild1.Visible = True
                Me.ddlChild2.Visible = True
                Me.ddlChild3.Visible = True
                Me.ddlChild4.Visible = True
                Me.ddlChild5.Visible = True
                Me.ddlChild6.Visible = True
                Me.ddlChild7.Visible = True
        End Select
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim tmp() As String = Me.txtHotelName.Text.Split(",")
        Dim childAges As String = String.Empty

        If Me.ddlChild.Text >= "1" Then
            childAges = "&c1=" & Me.ddlChild1.Text
        End If
        If Me.ddlChild.Text >= "2" Then
            childAges += "&c2=" & Me.ddlChild2.Text
        End If
        If Me.ddlChild.Text >= "3" Then
            childAges += "&c3=" & Me.ddlChild3.Text
        End If
        If Me.ddlChild.Text >= "4" Then
            childAges += "&c4=" & Me.ddlChild4.Text
        End If
        If Me.ddlChild.Text >= "5" Then
            childAges += "&c5=" & Me.ddlChild5.Text
        End If
        If Me.ddlChild.Text >= "6" Then
            childAges += "&c6=" & Me.ddlChild6.Text
        End If
        If Me.ddlChild.Text = "7" Then
            childAges += "&c7=" & Me.ddlChild7.Text
        End If

        Response.Redirect("hotel_details.aspx?Rid=" & Guid.NewGuid.ToString & "&hc=" & tmp(tmp.Length - 1).Trim & "&ci=" & Request.Form("start") & "&co=" & Request.Form("end") & "&r=" & Me.ddlRooms.Text & "&ac=" & Me.ddlAdult.Text & "&c=" & Me.ddlChild.Text & childAges)
    End Sub

End Class
