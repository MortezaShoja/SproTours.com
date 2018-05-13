Imports System.Data

Partial Class Cart
    Inherits System.Web.UI.Page

    Private GTI As GetTourInfo


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MemberID As String = String.Empty
        Try
            MemberID = Request.Cookies("UserSettings")("ID").ToString.ToString
        Catch ex As Exception
        End Try


        If MemberID <> String.Empty Then
            Dim CTCI As New CreateCartItems

            Dim tmpCTCI() As String = CTCI.Create(MemberID)
            Me.TblCartItems.InnerHtml = tmpCTCI(0)

            GTI = New GetTourInfo
            Dim TourDiscount As Decimal = GTI.GetDescount(tmpCTCI(1))

            Me.SumTotal.InnerHtml = Decimal.Parse(tmpCTCI(2)).ToString("N0")
            Me.discount.InnerHtml = Decimal.Parse(TourDiscount).ToString("N0")
            Me.TotalPrice.InnerHtml = Decimal.Parse(tmpCTCI(2) - TourDiscount).ToString("N0")
        Else
            Response.Redirect("default.aspx?L=2")
        End If
    End Sub
End Class
