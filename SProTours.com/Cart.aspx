<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Cart.aspx.vb" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<%--    <section class="title_container start-style">
        <div class="page-section-content">
            <div class="container page-section">
                <h2 class="uppercase undertitle text-start">Cart</h2>
            </div>
        </div>
    </section>--%>

    <div class="booking-item-details">
        <div class="booking-item-header">
            <div class="container">
                <div class="ok-row">
                    <div class="ok-md-8 ok-xsd-12">

                        <div class="dima-data-table-wrap cart-table">
                            <table>
                                <thead>
                                    <tr>
                                        <th>نام تور</th>
                                        <th>بزرگسال</th>
                                        <th>کودک</th>
                                        <th>مبلغ کل</th>
                                        <th>کمیسیون</th>
                                        <th>سایر خدمات</th>
                                        <th>تخفیف</th>
                                        <th>قابل پرداخت</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody id="TblCartItems" runat="server">
                                    <%--<tr>
                                        <td class="product-name">
                                            <div class="product-thumbnail">
                                                <a data-animated-link="fadeOut" href="#">
                                                    <img style="width:150px;" src="Packages/Tours/no-photo.png" class="attachment-shop_thumbnail" alt="">
                                                </a>
                                            </div>
                                            <div class="cart-item-details">
                                                <h6><a data-animated-link="fadeOut" href="#">Product Name</a></h6>
                                            </div>
                                        </td>
                                        <td>1</td>
                                        <td>2</td>
                                        <td>$45.45</td>
                                        <td>$45.45</td>
                                        <td>$45.45</td>
                                        <td class="product-remove">
                                            <h6><a data-animated-link="fadeOut" href="#"><i class="fa fa-trash-o"></i></a></h6>
                                        </td>
                                    </tr>--%>
                                    
                                </tbody>
                            </table>
                        </div>

                        <div class="double-clear"></div>

                    </div>

                    <div class="ok-md-4 ok-xsd-6">
                        <div class="dima-box coupon-box">
                            <h4 class="box-titel" style="text-align:right;">سبد خرید</h4>
                            <div class="form-small form">
<%--                                <div class="field">
                                    <label for="Coupon">Have a coupon?</label>
                                    <input id="Coupon" name="Coupon" type="text" placeholder="Coupon Code" required="" aria-required="true">
                                    <a data-animated-link="fadeOut" href="#" class="di_header no-bottom-margin button button-block small fill uppercase">Apply Coupon</a>
                                </div>--%>
                                <ul class="dima-nav-end"
                                    <li class="shopping-btn sub-icon menu-item-has-children cart_wrapper">
                                        <ul class="sub-menu with-border product_list_widget">
                                            <li>
                                                <p><span id="SumTotal" runat="server">1</span><span class="float-end"> : مبلغ کل</span></p>
                                                <p><span id="discount" runat="server">1</span><span class="float-end"> : تخفیف</span></p>
                                                <p style="font-weight:bold;"><span id="TotalPrice" runat="server">1</span><span class="float-end"> : قابل پرداخت</span></p>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                                <hr />
                                <img src="http://www.turkordershop.ir/img/Bank_logo.jpg" />
                                <span style="text-align:center;"> پرداخت با کلیه کارهای بانکی عضو شبکه شتاب </span>
                                <hr />
                                <a data-animated-link="fadeOut" onclick="CheckoutBasket();" class="no-bottom-margin button button-block small fill uppercase">پرداخت</a>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>



</asp:Content>

