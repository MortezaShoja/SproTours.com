<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Flight.aspx.vb" Inherits="Flight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- FACEBOOK WIDGET -->
    <div id="fb-root"></div>
    <script>
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s);
            js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.0";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));
    </script>

    <!-- /FACEBOOK WIDGET -->
    <div class="global-wrap">
        <!-- TOP AREA -->
        <div class="top-area show-onload">
            <div class="bg-holder full">
                <div class="bg-mask"></div>
                <div class="bg-parallax" style="background-image:url('images/Flight.jpg');"></div>
                <div class="bg-content">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="search-tabs search-tabs-bg mt50">
                                    <div class="tabbable">
                                        <div class="tab-content">
                                            <div class="tab-pane fade in active" id="tab-1">
                                                <!--<h3 style="color: #ffffff">
                                                    Just Sit back</h3>-->
                                                <div class="row">
                                                    <div class="col-md-9">
                                                        <h3 style="color: #ffffff">پایین ترین قیمت پروازهای سراسر دنیا</h3>
                                                    </div>
                                                    <div class="col-md-3" style="text-align:right;">
                                                    <fieldset>
                                                    <table style=" top: 10px; position: relative;">
                                                    <tr>
                                                    <td><label for="radioReturn" style="color: #FFFFFF">دو طرفه</label></td>
                                                    <td style="width:3px;"></td>
                                                    <td><input type="radio" onclick="RadioSelection(this)" name="action" id="radioReturn" value="Return" checked="checked" /></td>
                                                    <td style="width:10px;"></td>
                                                    <td><label for="radioOneWay" style="color: #FFFFFF">یک طرفه</label></td>
                                                    <td style="width:3px;"></td>
                                                    <td><input type="radio" onclick="RadioSelection(this)" name="action" id="radioOneWay" value="OneWay" /></td>
                                                    </tr>
                                                    </table>
                                                    </fieldset>
                                                    </div>
                                                </div>
                                                <div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-plane input-icon"></i>
                                                                <label style="text-align: right; color: #FFFFFF;">بعدا</label>
                                                                <asp:TextBox class="flighttypeahead form-control" placeholder="Airport, City" ID="txtFlyFrom" runat="server" BackColor="White" style="border-color:White"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-plane input-icon"></i>
                                                                <label style="text-align: right; color: #FFFFFF;">مقصد</label>
                                                                <asp:TextBox class="flighttypeahead form-control" placeholder="Airport, City" ID="txtFlyTo" runat="server" BackColor="White" style="border-color:White"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">

                                                        <div class="input-daterange" data-date-format="yyyy/M/dd">
                                                            <div class="col-md-3">
                                                                <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                                                    <label style="text-align: right; color: #FFFFFF;">تاریخ رفت</label>
                                                                    <input id="start" class="form-control" name="start" type="text" style="background-color: #FFFFFF" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div id="divReturn" style="display:block" class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                                                    <label style="text-align: right; color: #FFFFFF;">تاریخ برگشت</label>
                                                                    <input id="end" class="form-control" name="end" type="text" style="background-color: #FFFFFF" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                            <div class="form-group form-group-lg form-group-icon-right"><i onclick="slideDownAspDDl(this)" class="fa fa-chevron-down input-icon input-icon-highlight"></i>
                                                                <label style="text-align: right; color: #FFFFFF;">کلاس پرواز</label>
                                                                <asp:DropDownList ID="ddlFlightClass" runat="server" Height="48px">
                                                                    <asp:ListItem Value="Economy"></asp:ListItem>
                                                                    <asp:ListItem Value="Bussiness Class"></asp:ListItem>
                                                                    <asp:ListItem Value="First Class"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                            <div class="form-group form-group-lg form-group-icon-right"><i onclick="ModalfromPassengers(this)" class="fa fa-chevron-down input-icon input-icon-highlight"></i>
                                                                <label style="text-align: right; color: #FFFFFF;">مسافران</label>
                                                                <input id="txtPassengers" type="text" style="height:48px; background-color: #FFFFFF; border-color:White;" onclick="ModalfromPassengers(this)" readonly value="1 مسافر" />
                                                            </div>
                                                                <div id="DivModalfromPassengers"class="booking-item-dates-change" 
                                                                    style="z-index: 999; position: absolute; top: 75px; background-color: #FFFFFF; display: none;">
                                                                    <i onclick="ModalfromPassengers(this)" class="fa fa-times  input-icon input-icon-highlight" style="z-index: 999; position: absolute; top: 10px; right:10px;"></i>
                                                                        <table>

                                                                        <tr>
                                                                        <td colspan="4">
                                                                        <label>بزرگسال</label>
                                                                        </td>

                                                                        </tr>
                                                                        <tr>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="Button1" type="button" value="-" style="width: 35px; height: 35px" onclick="document.getElementById('txtAdult').value = parseInt(document.getElementById('txtAdult').value) - 1; if (parseInt(document.getElementById('txtAdult').value) < 0) { document.getElementById('txtAdult').value = 0 }; sumPassengers();" /></td>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="txtAdult" type="text" style="width: 35px; height: 35px; text-align: center;" value="1" /></td>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="Button2" type="button" value="+" style="width: 35px; height: 35px" onclick="document.getElementById('txtAdult').value = parseInt(document.getElementById('txtAdult').value) + 1; sumPassengers();"/></td>
                                                                        </tr>

                                                                        <tr>
                                                                        <td colspan="4">
                                                                        <label dir="rtl">نوجوان (زیر 12 سال)</label>
                                                                        </td>

                                                                        </tr>
                                                                        <tr>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="Button3" type="button" value="-" style="width: 35px; height: 35px" onclick="document.getElementById('txtYouth').value = parseInt(document.getElementById('txtYouth').value) - 1; if (parseInt(document.getElementById('txtYouth').value) < 0) { document.getElementById('txtYouth').value = 0 }; sumPassengers();" /></td>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="txtYouth" type="text" style="width: 35px; height: 35px; text-align: center;" value="0" /></td>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="Button4" type="button" value="+" style="width: 35px; height: 35px" onclick="document.getElementById('txtYouth').value = parseInt(document.getElementById('txtYouth').value) + 1; sumPassengers();"/></td>
                                                                        </tr>

                                                                        <tr>
                                                                        <td colspan="4">
                                                                        <label dir="rtl">خردسال (زیر 2 سال)</label>
                                                                        </td>

                                                                        </tr>
                                                                        <tr>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="Button5" type="button" value="-" style="width: 35px; height: 35px" onclick="document.getElementById('txtChild').value = parseInt(document.getElementById('txtChild').value) - 1; if (parseInt(document.getElementById('txtChild').value) < 0) { document.getElementById('txtChild').value = 0 }; sumPassengers();" /></td>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="txtChild" type="text" style="width: 35px; height: 35px; text-align: center;" value="0" /></td>
                                                                        <td style="width: 35px; height: 35px">
                                                                            <input id="Button6" type="button" value="+" style="width: 35px; height: 35px" onclick="document.getElementById('txtChild').value = parseInt(document.getElementById('txtChild').value) + 1; sumPassengers();"/></td>
                                                                        </tr>


                                                                        </table>
                                                                    
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="row">
                                                        <div class="col-md-9">
                                                        </div>
                                                            <div class="col-md-3">
                                                                <span id="Span3" class="btn btn-default btn-primary" onclick="LoadFrom1(this)" 
                                                                    style="width: 100%; vertical-align: middle;">ادامه</span>
                                                            </div>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <!--<div class="loc-info text-right hidden-xs hidden-sm">
                                    <h3 class="loc-info-title"><img src="img/flags/32/fr.png" alt="Image Alternative text" title="Image Title" />Paris</h3>
                                    <p class="loc-info-weather"><span class="loc-info-weather-num">+31</span><i class="im im-rain loc-info-weather-icon"></i>
                                    </p>
                                    <ul class="loc-info-list">
                                        <li><a href="#"><i class="fa fa-building-o"></i> 277 Hotels from $36/night</a>
                                        </li>
                                        <li><a href="#"><i class="fa fa-home"></i> 130 Rentals from $44/night</a>
                                        </li>
                                        <li><a href="#"><i class="fa fa-car"></i> 294 Car Offers from $45/day</a>
                                        </li>
                                        <li><a href="#"><i class="fa fa-bolt"></i> 200 Activities this Week</a>
                                        </li>
                                    </ul><a class="btn btn-white btn-ghost mt10" href="#"><i class="fa fa-angle-right"></i> Explore</a>
                                </div>-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END TOP AREA  -->

        <!--
        <div class="gap"></div>
        <div class="container">
            <div class="row row-wrap" data-gutter="60">
                <div class="col-md-4">
                    <div class="thumb">
                        <header class="thumb-header"><i class="fa fa-dollar box-icon-md round box-icon-black animate-icon-top-to-bottom"></i>
                        </header>
                        <div class="thumb-caption">
                            <h5 class="thumb-title"><a class="text-darken" href="#">Best Price Guarantee</a></h5>
                            <p class="thumb-desc">Eu lectus non vivamus ornare lacinia elementum faucibus natoque parturient ullamcorper placerat</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="thumb">
                        <header class="thumb-header"><i class="fa fa-lock box-icon-md round box-icon-black animate-icon-top-to-bottom"></i>
                        </header>
                        <div class="thumb-caption">
                            <h5 class="thumb-title"><a class="text-darken" href="#">Trust & Safety</a></h5>
                            <p class="thumb-desc">Imperdiet nisi potenti fermentum vehicula eleifend elementum varius netus adipiscing neque quisque</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="thumb">
                        <header class="thumb-header"><i class="fa fa-thumbs-o-up box-icon-md round box-icon-black animate-icon-top-to-bottom"></i>
                        </header>
                        <div class="thumb-caption">
                            <h5 class="thumb-title"><a class="text-darken" href="#">Best Travel Agent</a></h5>
                            <p class="thumb-desc">Curae urna fusce massa a lacus nisl id velit magnis venenatis consequat</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="gap gap-small"></div>
        </div>
        <div class="bg-holder">
            <div class="bg-mask"></div>
            <div class="bg-parallax" style="background-image:url(img/hotel_the_cliff_bay_spa_suite_2048x1310.jpg);"></div>
            <div class="bg-content">
                <div class="container">
                    <div class="gap gap-big text-center text-white">
                        <h2 class="text-uc mb20">Last Minute Deal</h2>
                        <ul class="icon-list list-inline-block mb0 last-minute-rating">
                            <li><i class="fa fa-star"></i>
                            </li>
                            <li><i class="fa fa-star"></i>
                            </li>
                            <li><i class="fa fa-star"></i>
                            </li>
                            <li><i class="fa fa-star"></i>
                            </li>
                            <li><i class="fa fa-star"></i>
                            </li>
                        </ul>
                        <h5 class="last-minute-title">The Peninsula - New York</h5>
                        <p class="last-minute-date">Fri 14 Mar - Sun 16 Mar</p>
                        <p class="mb20"><b>$120</b> / person</p><a class="btn btn-lg btn-white btn-ghost" href="#">Book Now <i class="fa fa-angle-right"></i></a>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="gap"></div>
            <h2 class="text-center">Top Destinations</h2>
            <div class="gap">
                <div class="row row-wrap">
                    <div class="col-md-3">
                        <div class="thumb">
                            <header class="thumb-header">
                                <a class="hover-img curved" href="#">
                                    <img src="img/the_journey_home_400x300.jpg" alt="Image Alternative text" title="the journey home" /><i class="fa fa-plus box-icon-white box-icon-border hover-icon-top-right round"></i>
                                </a>
                            </header>
                            <div class="thumb-caption">
                                <h4 class="thumb-title">Africa</h4>
                                <p class="thumb-desc">Ut blandit pharetra suspendisse montes libero eleifend bibendum</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="thumb">
                            <header class="thumb-header">
                                <a class="hover-img curved" href="#">
                                    <img src="img/upper_lake_in_new_york_central_park_800x600.jpg" alt="Image Alternative text" title="Upper Lake in New York Central Park" /><i class="fa fa-plus box-icon-white box-icon-border hover-icon-top-right round"></i>
                                </a>
                            </header>
                            <div class="thumb-caption">
                                <h4 class="thumb-title">USA</h4>
                                <p class="thumb-desc">Cursus faucibus egestas rutrum mauris vulputate consequat ante</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="thumb">
                            <header class="thumb-header">
                                <a class="hover-img curved" href="#">
                                    <img src="img/people_on_the_beach_800x600.jpg" alt="Image Alternative text" title="people on the beach" /><i class="fa fa-plus box-icon-white box-icon-border hover-icon-top-right round"></i>
                                </a>
                            </header>
                            <div class="thumb-caption">
                                <h4 class="thumb-title">Australia</h4>
                                <p class="thumb-desc">Senectus hendrerit torquent lorem scelerisque quam a curae</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="thumb">
                            <header class="thumb-header">
                                <a class="hover-img curved" href="#">
                                    <img src="img/lack_of_blue_depresses_me_800x600.jpg" alt="Image Alternative text" title="lack of blue depresses me" /><i class="fa fa-plus box-icon-white box-icon-border hover-icon-top-right round"></i>
                                </a>
                            </header>
                            <div class="thumb-caption">
                                <h4 class="thumb-title">Greece</h4>
                                <p class="thumb-desc">Penatibus ac lacinia platea cras lobortis nullam dapibus</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        -->
    </div>

    <!--- Page Modals--->

    <div id="page1Modal" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content" >
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">جزئیات درخواست</h4>
            </div>
            <div class="modal-body">
                        <div class="booking-item-dates-change">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-map-marker input-icon"></i>
                                        <label>مبدا پرواز</label>
                                        <asp:TextBox class="form-control" ID="txtOwerviewFlyFrom" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-map-marker input-icon"></i>
                                        <label>مقصد پرواز</label>
                                        <asp:TextBox class="form-control" ID="txtOwerviewFlyTo" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row" dir="rtl">
                                <div class="col-md-4">
                                        <label>کلاس پرواز</label>
                                    <asp:TextBox style="text-align:center" class="form-control" name="txtOwerviewFlightClass" ID="txtOwerviewFlightClass" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                        <label>تاریخ برگشت</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewCheckOut" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                        <label>تاریخ رفت</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewCheckIn" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                        <label>خردسال (زیر2سال)</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewChild" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                        <label>نوجوان (زیر12سال)</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewYouth" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                        <label>تعداد بزرگسال</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewAdult" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">اصلاح</button>
                <span id="Span1" data-toggle="modal" href="#page2Modal" class="btn btn-default btn-primary"  style="width: 60px;">ادامه</span>
            </div>

        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>
<!---- End Page Modal 1---->


<div id="page2Modal" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content" >
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">مشخصات درخواست دهنده</h4>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="booking-item-dates-change">
                            <div class="row">
                                <div class="col-md-6">
                                        <label>نام خانوادگی</label>
                                        <asp:TextBox style="text-align:right" class="form-control" ID="txtLastOverviewFamily" runat="server" CausesValidation="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="لطفا نام خانوادگی خود را وارد کنید" ControlToValidate="txtLastOverviewFamily"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                        <label>نام</label>
                                        <asp:TextBox style="text-align:right" class="form-control" ID="txtLastOverviewName" runat="server" CausesValidation="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="لطفا نام خود را وارد کنید" ControlToValidate="txtLastOverviewName"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                        <label>ایمیل</label>
                                    <asp:TextBox style="text-align:right" class="form-control" ID="txtLastOverviewEmail" runat="server" CausesValidation="True"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtLastOverviewEmail" ErrorMessage="ایمیل صحیح نمی باشد"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-6">
                                        <label>شماره تماس</label>
                                    <asp:TextBox style="text-align:right" class="form-control" ID="txtLastOverviewPhone" runat="server" CausesValidation="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفا شماره تماس خود را وارد کنید" ControlToValidate="txtLastOverviewPhone"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtLastOverviewPhone" Type="Integer"
                                                 Operator="DataTypeCheck" ErrorMessage="شماره تلفن صحیح نمی باشد" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                        <label>توضیحات بیشتر</label>
                                    <asp:TextBox style="text-align:right" class="form-control" ID="txtLastOverviewDescription" runat="server" Height="100" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="modal-footer">
                
                <asp:UpdatePanel ID="UpdatePanelSendRequest" runat="server">
                    <ContentTemplate>
                        <button type="button" class="btn btn-default" data-dismiss="modal"  onclick="LoadFrom1(this)">اصلاح</button>
                        <span id="Span2" class="btn btn-default btn-primary" onclick="doSendRequestPostback(this)">ارسال درخواست</span>
                        <asp:Button style="display:none;" class="btn btn-primary" ID="btnSendRequest" runat="server" Text="ارسال درخواست" CausesValidation="True" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>
<!---- End Page Modal 2---->

<div id="page3Modal" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content" >
            <div class="modal-header">
                <h4 class="modal-title">ثبت درخواست</h4>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="booking-item-dates-change">
                            <div class="row">
                                <div class="col-md-10">

                                        <label id="lblFinishingMessage"></label>
                                </div>
                                <div class="col-md-2">
                                    <asp:Image ID="imgloaderFinalStep" runat="server" ImageUrl="~/images/Loader/loading2.gif" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="modal-footer">
            </div>

        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>

<!---- End Page Modals---->




<script type="text/javascript">


    function sumPassengers() {
        document.getElementById('txtPassengers').value = (parseInt(document.getElementById('txtAdult').value) + parseInt(document.getElementById('txtYouth').value) + parseInt(document.getElementById('txtChild').value)) + " مسافر "
    };

    function slideDownAspDDl() {
        $("ddlFlightClass").slideDown();
        document.getElementById("<%= ddlFlightClass.ClientID %>").slideDown();
    };

    function ModalfromPassengers() {

        if (document.getElementById("DivModalfromPassengers").style.display == "none") {
            document.getElementById("DivModalfromPassengers").style.display = ""
        } else {
            document.getElementById("DivModalfromPassengers").style.display = "none"
        }
    };

    $("#DivModalfromPassengers").clickOutsideThisElement(function () {
        document.getElementById("DivModalfromPassengers").style.display = ""
    });


    function LoadFrom1() {

        var tmpfinalFlag = "false"

        if ((parseInt(document.getElementById('txtAdult').value) + parseInt(document.getElementById('txtYouth').value) + parseInt(document.getElementById('txtChild').value)) == 0 ) {
            document.getElementById("txtPassengers").style.borderColor = "red";
            tmpfinalFlag = "true";
        } else {
            document.getElementById("txtPassengers").style.borderColor = "";
        } 


        if (document.getElementById("<%= txtFlyFrom.ClientID %>").value == "") {
            document.getElementById("<%= txtFlyFrom.ClientID %>").style.borderColor = "red";
            tmpfinalFlag = "true";
        } else {
            document.getElementById("<%= txtFlyFrom.ClientID %>").style.borderColor = "";
        }

        if (document.getElementById("<%= txtFlyTo.ClientID %>").value == "") {
            document.getElementById("<%= txtFlyTo.ClientID %>").style.borderColor = "red";
            tmpfinalFlag = "true";
        } else {
            document.getElementById("<%= txtFlyTo.ClientID %>").style.borderColor = "";
        }

        if (tmpfinalFlag == "false") {

            document.getElementById("<%= txtOwerviewCheckIn.ClientID %>").value = document.getElementById("start").value;
            document.getElementById("<%= txtOwerviewCheckOut.ClientID %>").value = document.getElementById("end").value;
            document.getElementById("<%= txtOwerviewFlyFrom.ClientID %>").value = document.getElementById("<%= txtFlyFrom.ClientID %>").value;
            document.getElementById("<%= txtOwerviewFlyTo.ClientID %>").value = document.getElementById("<%= txtFlyTo.ClientID %>").value;
            document.getElementById("<%= txtOwerviewFlightClass.ClientID %>").value = document.getElementById("<%= ddlFlightClass.ClientID %>").value;
            document.getElementById("<%= txtOwerviewAdult.ClientID %>").value = document.getElementById('txtAdult').value;
            document.getElementById("<%= txtOwerviewYouth.ClientID %>").value = document.getElementById('txtYouth').value;
            document.getElementById("<%= txtOwerviewChild.ClientID %>").value = document.getElementById('txtChild').value;
            $("#page1Modal").modal('show');
        } else {
            alert("لطفا کلیه اطلاعات را بصورت صحیح وارد کنید");
        }

        }


        function validateEmail(email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }


        function doSendRequestPostback(object) {
            
        document.getElementById("lblFinishingMessage").innerHTML = document.getElementById("<%= txtLastOverviewName.ClientID %>").value + " " + document.getElementById("<%= txtLastOverviewFamily.ClientID %>").value  + " عزیز " + "<br />" + "با تشکر از حسن انتخاب شما" + "<br />" + "درخواست شما در حال ثبت می باشد" + "<br />" + "لطفا چند لحظه منتظر بمانید" + "<br />" + "با تشکر";
        
        var tmpfinalFlagLast = "false"

        if (document.getElementById("<%= txtLastOverviewName.ClientID %>").value == "") {
            document.getElementById("<%= txtLastOverviewName.ClientID %>").style.borderColor = "red";
            tmpfinalFlagLast = "true";
        } else {
            document.getElementById("<%= txtLastOverviewName.ClientID %>").style.borderColor = "";
        }

        if (document.getElementById("<%= txtLastOverviewFamily.ClientID %>").value == "") {
            document.getElementById("<%= txtLastOverviewFamily.ClientID %>").style.borderColor = "red";
            tmpfinalFlagLast = "true";
        } else {
            document.getElementById("<%= txtLastOverviewFamily.ClientID %>").style.borderColor = "";
        }

        if (document.getElementById("<%= txtLastOverviewPhone.ClientID %>").value == "") {
            document.getElementById("<%= txtLastOverviewPhone.ClientID %>").style.borderColor = "red";
            tmpfinalFlagLast = "true";
        } else {
            document.getElementById("<%= txtLastOverviewPhone.ClientID %>").style.borderColor = "";
        }

        if (document.getElementById("<%= txtLastOverviewEmail.ClientID %>").value == "") {
            document.getElementById("<%= txtLastOverviewEmail.ClientID %>").style.borderColor = "red";
            tmpfinalFlagLast = "true";
        } else {
            document.getElementById("<%= txtLastOverviewEmail.ClientID %>").style.borderColor = "";
        }
        
        //if (document.getElementById("<%= txtLastOverviewDescription.ClientID %>").value == "") {
            //document.getElementById("<%= txtLastOverviewDescription.ClientID %>").style.borderColor = "red";
            //tmpfinalFlag = "true";
        //} else {
            //document.getElementById("<%= txtLastOverviewDescription.ClientID %>").style.borderColor = "";
        //}
        //------------- Email Validation ----------------------------------------------
        var Emailvalidator = validateEmail(document.getElementById("<%= txtLastOverviewEmail.ClientID %>").value);
        if (Emailvalidator == false) {
            document.getElementById("<%= txtLastOverviewEmail.ClientID %>").style.borderColor = "red";
            tmpfinalFlagLast = "true";
        }


        //--------------------------------------------------------------------------
        if (tmpfinalFlagLast == "false") {
            $("#page1Modal").modal('hide');
            $("#page2Modal").modal('hide');
            $("#page3Modal").modal('show');

            document.getElementById("<%= btnSendRequest.ClientID %>").click();
        } else {
            alert("لطفا کلیه مشخصات را بصورت صحیح وارد کنید");
        }
        
    }

    function openmessagebox(object) {
        $("#page3Modal").modal('show');
    }

    function peygham() {

        //$("#page1Modal").modal('show');
        //document.getElementById('page2Modal').showModal();
        alert("قیمت پرواز مورد انتخاب شما در اسرع وقت به ایمیل شماارسال خواهد شد");
 
    }

    function teram() {
        $("#page3Modal").modal('show');
    }

    function RadioSelection() {
        if (document.getElementById("radioOneWay").checked == true) {
            document.getElementById("divReturn").style.display = "none";
        }

        if (document.getElementById("radioReturn").checked == true) {
            document.getElementById("divReturn").style.display = "block";
        }
    }

</script>

    <script src="js/core/jquery-2.1.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <!-- UI -->
    <script src="js/slimmenu.js"></script>
    <script src="js/bootstrap-datepicker.js"></script>
    <script src="js/bootstrap-timepicker.js"></script>
    <script src="js/nicescroll.js"></script>
    <script src="js/typeahead.js"></script>
    <script src="js/customtypeahead.js"></script>
</asp:Content>

