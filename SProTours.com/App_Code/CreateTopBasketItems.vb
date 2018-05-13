Imports Microsoft.VisualBasic
Imports System.Data

Public Class CreateTopBasketItems
    Private SqlCon As SqlConnectionSite
    Private GTI As GetTourInfo


    Public Function Create(ByVal MemberID As String) As Array
        Dim value(1) As String

        Dim QTY As Integer = 0
        Dim Total As Decimal = 0

        Dim SQLCon As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.CommandText = "select T.ID,T.TourName,T.CurrencyType,R.TotalTomanPrice,R.ID from TourDetails T inner join TourRequests R on R.TourID=T.ID Where R.MemberID=@MemberID and Status=N'در سبد خرید'"
            Cmd.Connection = SQLCon.SqlCon
            SQLCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read

                Dim TourImage As String = String.Empty
                Try
                    Dim OurServerPath As String = "C:\Inetpub\vhosts\sprotours.com\admin.sprotours.com"
                    'Dim OurServerPath As String = "C:\Users\Morteza\OneDrive\Programming\Reza\SproTours\Admin"
                    Dim Images() As String = System.IO.Directory.GetFiles(OurServerPath & "\Packages\TourDetails\" & sdr(0).ToString)
                    Dim tmpSelectedIMG() As String = Images(0).Split("\")
                    TourImage = "http://admin.SproTours.com/" & "Packages/TourDetails/" & sdr(0).ToString & "/" & tmpSelectedIMG(tmpSelectedIMG.Length - 1)
                Catch ex As Exception
                    TourImage = "http://admin.SproTours.com/Packages/Tours/no-photo.png"
                End Try

                value(0) += "<li>" & _
                                    "<i style=""cursor:pointer; z-index:999; position:absolute; right:20px; top:10px;"" class=""fa fa-trash-o"" aria-hidden=""true"" onclick=""DeleteBasket('" & sdr(4).ToString & "');"" ></i>" & _
                                    "<a href=""Tours_details.aspx?cid=" & sdr(0).ToString & """ title=""" & sdr(1).ToString & """>" & _
                                        "<img width=""65"" height=""70"" class=""attachment-shop_thumbnail"" src=""" & TourImage & """ alt=""" & sdr(1).ToString & """/>" & sdr(1).ToString & "</a>" & _
                                    "<p style=""width:100%; text-align:right;"">" & Decimal.Parse(sdr(3)).ToString("N0") & "</p>" & _
                                "</li>"

                Total += sdr(3)
                QTY += 1
            End While

        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SQLCon.SqlCon.Close()
        End Try

        If QTY > 0 Then

            GTI = New GetTourInfo
            Dim TourDiscount As Decimal = GTI.GetDescount(QTY)

            value(0) = "<li class=""shopping-btn sub-icon menu-item-has-children cart_wrapper"">" & _
                        "<a data-animated-link=""fadeOut"" class=""start-border"">" & _
                            "<i class=""fa fa-shopping-cart""></i>" & _
                            "<span class=""total""><span class=""amount"">" & (Total - TourDiscount).ToString("N0") & "</span></span>" & _
                            "<span class=""badge-number"">" & QTY & "</span>" & _
                        "</a>" & _
                        "<ul class=""sub-menu with-border product_list_widget"">" & _
                            "<div style=""max-height:250px; overflow: auto; padding-right:10px;"">" & _
                            value(0)
            '-------------------------------------------------------------------------------------------------

            value(0) += "</div>" & _
                        "<li>" & _
                            "<p>مبلغ کل : <span class=""float-end"">" & Total.ToString("N0") & "</span></p>" & _
                            "<p>تخفیف : <span class=""float-end"">" & TourDiscount.ToString("N0") & "</span></p>" & _
                            "<p>قابل پرداخت : <span class=""float-end"">" & (Total - TourDiscount).ToString("N0") & "</span></p>" & _
                        "</li>" & _
                        "<li>" & _
                            "<a href=""Cart.aspx""><span class=""di_header button-block button fill"">نمایش سبد </span></a>" & _
                            "<span class=""button-block button fill no-bottom-margin"" onclick=""CheckoutBasket();"" >پرداخت</span>" & _
                        "</li>" & _
                    "</ul>" & _
                "</li>"
        Else
            value(0) = "<li class=""shopping-btn sub-icon menu-item-has-children cart_wrapper"">" & _
                        "<a data-animated-link=""fadeOut"" class=""start-border"">" & _
                            "<i class=""fa fa-shopping-cart""></i>" & _
                            "<span class=""total""><span class=""amount""></span></span>" & _
                            "<span class=""badge-number"">" & QTY & "</span>" & _
                        "</a>" & _
                        "</li>"
        End If

        value(1) = QTY
        Return value
    End Function
End Class
