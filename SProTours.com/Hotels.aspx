<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Hotels.aspx.vb" Inherits="_Hotels" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- FACEBOOK WIDGET -->
    <div id="fb-root"></div>
    <!-- /FACEBOOK WIDGET -->
    <div class="global-wrap">
        <!-- TOP AREA -->
        <div class="top-area show-onload">
            <div class="bg-holder full">
                <div class="bg-mask"></div>
                <div class="bg-parallax" style="background-image:url('images/Istanbul_2048x1365.jpg');"></div>
                <div class="bg-content" style="height:600px;">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="search-tabs search-tabs-bg mt50">
                                <div class="tabbable">
                                        <div class="tab-content">
                                            <div class="tab-pane fade in active" id="tab-1">
                                                <!--<h3 style="color: #ffffff">Just Sit back</h3>-->
                                                <div>
                                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-map-marker input-icon"></i>
                                                        <label style="color:White;">رزرواسیون آنلاین هتلهای ترکیه</label>
                                                        <asp:TextBox class="typeahead form-control" placeholder="نام هتل را وارد کنید" ID="txtHotelName" runat="server" BackColor="White"></asp:TextBox>
                                                    </div>
                                                    
                                                    <div class="row">

                                                        <div class="col-md-2">
                                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-university input-icon input-icon-highlight"></i>
                                                                <label style="color:White;">اطاق</label>
                                                                    <asp:DropDownList class="form-control" ID="ddlRooms" runat="server" 
                                                                        Width="100%" Height="45px">
                                                                        <asp:ListItem Selected="True">1</asp:ListItem>
                                                                        <asp:ListItem>2</asp:ListItem>
                                                                        <asp:ListItem>3</asp:ListItem>
                                                                        <asp:ListItem>4</asp:ListItem>
                                                                        <asp:ListItem>5</asp:ListItem>
                                                                        <asp:ListItem>6</asp:ListItem>
                                                                        <asp:ListItem>7</asp:ListItem>
                                                                        <asp:ListItem>8</asp:ListItem>
                                                                        <asp:ListItem>9</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>11</asp:ListItem>
                                                                        <asp:ListItem>12</asp:ListItem>
                                                                        <asp:ListItem>13</asp:ListItem>
                                                                        <asp:ListItem>14</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>16</asp:ListItem>
                                                                        <asp:ListItem>17</asp:ListItem>
                                                                        <asp:ListItem>18</asp:ListItem>
                                                                        <asp:ListItem>19</asp:ListItem>
                                                                        <asp:ListItem>20</asp:ListItem>
                                                                        <asp:ListItem>21</asp:ListItem>
                                                                        <asp:ListItem>22</asp:ListItem>
                                                                        <asp:ListItem>23</asp:ListItem>
                                                                        <asp:ListItem>24</asp:ListItem>
                                                                        <asp:ListItem>25</asp:ListItem>
                                                                        <asp:ListItem>26</asp:ListItem>
                                                                        <asp:ListItem>27</asp:ListItem>
                                                                        <asp:ListItem>28</asp:ListItem>
                                                                        <asp:ListItem>29</asp:ListItem>
                                                                        <asp:ListItem>30</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-user input-icon input-icon-highlight"></i>
                                                                <label style="color:White;">بزرگسال</label>
                                                                    <asp:DropDownList class="form-control" ID="ddlAdult" runat="server" 
                                                                        Width="100%">
                                                                        <asp:ListItem>1</asp:ListItem>
                                                                        <asp:ListItem Selected="True">2</asp:ListItem>
                                                                        <asp:ListItem>3</asp:ListItem>
                                                                        <asp:ListItem>4</asp:ListItem>
                                                                        <asp:ListItem>5</asp:ListItem>
                                                                        <asp:ListItem>6</asp:ListItem>
                                                                        <asp:ListItem>7</asp:ListItem>
                                                                        <asp:ListItem>8</asp:ListItem>
                                                                        <asp:ListItem>9</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>11</asp:ListItem>
                                                                        <asp:ListItem>12</asp:ListItem>
                                                                        <asp:ListItem>13</asp:ListItem>
                                                                        <asp:ListItem>14</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>16</asp:ListItem>
                                                                        <asp:ListItem>17</asp:ListItem>
                                                                        <asp:ListItem>18</asp:ListItem>
                                                                        <asp:ListItem>19</asp:ListItem>
                                                                        <asp:ListItem>20</asp:ListItem>
                                                                        <asp:ListItem>21</asp:ListItem>
                                                                        <asp:ListItem>22</asp:ListItem>
                                                                        <asp:ListItem>23</asp:ListItem>
                                                                        <asp:ListItem>24</asp:ListItem>
                                                                        <asp:ListItem>25</asp:ListItem>
                                                                        <asp:ListItem>26</asp:ListItem>
                                                                        <asp:ListItem>27</asp:ListItem>
                                                                        <asp:ListItem>28</asp:ListItem>
                                                                        <asp:ListItem>29</asp:ListItem>
                                                                        <asp:ListItem>30</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-child input-icon input-icon-highlight"></i>
                                                                <label style="color:White;">خردسال</label>
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                        <asp:DropDownList class="form-control" ID="ddlChild" runat="server" 
                                                                        Width="100%" AutoPostBack="True">
                                                                        <asp:ListItem Selected="True">0</asp:ListItem>
                                                                        <asp:ListItem>1</asp:ListItem>
                                                                        <asp:ListItem>2</asp:ListItem>
                                                                        <asp:ListItem>3</asp:ListItem>
                                                                        <asp:ListItem>4</asp:ListItem>
                                                                        <asp:ListItem>5</asp:ListItem>
                                                                        <asp:ListItem>6</asp:ListItem>
                                                                        <asp:ListItem>7</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>

                                                        <div class="input-daterange" data-date-format="dd/M/yyyy">
                                                            <div class="col-md-3">
                                                                <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                                                    <label style="color:White;">تاریخ ورود</label>
                                                                    <input id="start" class="form-control" name="start" type="text" style="background-color:White;"  />
                                                                </div>
                                                            </div>

                                                            <div class="col-md-3">
                                                                <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                                                    <label style="color:White;">تاریخ خروج</label>
                                                                    <input id="end" class="form-control" name="end" type="text" style="background-color:White;" />
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    
                                                    <div class="row">
                                                        <div class="col-md-9">
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <div id="divChildAges" runat="server" visible="false">
                                                                        <table dir="ltr">
                                                                            <tr>
                                                                                <td>
                                                                                    <label style="color:White;" ID="lblChildAges" runat="server">سن خردسالان : </label> 
                                                                                </td>
                                                                                <td style="width:10px;"></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlChild7" runat="server" 
                                                                                        Width="34px" Height="34px">
                                                                                        <asp:ListItem Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem>0</asp:ListItem>
                                                                                        <asp:ListItem>1</asp:ListItem>
                                                                                        <asp:ListItem>2</asp:ListItem>
                                                                                        <asp:ListItem>3</asp:ListItem>
                                                                                        <asp:ListItem>4</asp:ListItem>
                                                                                        <asp:ListItem>5</asp:ListItem>
                                                                                        <asp:ListItem>6</asp:ListItem>
                                                                                        <asp:ListItem>7</asp:ListItem>
                                                                                        <asp:ListItem>8</asp:ListItem>
                                                                                        <asp:ListItem>9</asp:ListItem>
                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                        <asp:ListItem>11</asp:ListItem>
                                                                                        <asp:ListItem>12</asp:ListItem>
                                                                                        <asp:ListItem>13</asp:ListItem>
                                                                                        <asp:ListItem>14</asp:ListItem>
                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                        <asp:ListItem>16</asp:ListItem>
                                                                                        <asp:ListItem>17</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="ddlChild6" runat="server" 
                                                                                        Width="34px" Height="34px">
                                                                                        <asp:ListItem Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem>0</asp:ListItem>
                                                                                        <asp:ListItem>1</asp:ListItem>
                                                                                        <asp:ListItem>2</asp:ListItem>
                                                                                        <asp:ListItem>3</asp:ListItem>
                                                                                        <asp:ListItem>4</asp:ListItem>
                                                                                        <asp:ListItem>5</asp:ListItem>
                                                                                        <asp:ListItem>6</asp:ListItem>
                                                                                        <asp:ListItem>7</asp:ListItem>
                                                                                        <asp:ListItem>8</asp:ListItem>
                                                                                        <asp:ListItem>9</asp:ListItem>
                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                        <asp:ListItem>11</asp:ListItem>
                                                                                        <asp:ListItem>12</asp:ListItem>
                                                                                        <asp:ListItem>13</asp:ListItem>
                                                                                        <asp:ListItem>14</asp:ListItem>
                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                        <asp:ListItem>16</asp:ListItem>
                                                                                        <asp:ListItem>17</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="ddlChild5" runat="server" 
                                                                                        Width="34px" Height="34px">
                                                                                        <asp:ListItem Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem>0</asp:ListItem>
                                                                                        <asp:ListItem>1</asp:ListItem>
                                                                                        <asp:ListItem>2</asp:ListItem>
                                                                                        <asp:ListItem>3</asp:ListItem>
                                                                                        <asp:ListItem>4</asp:ListItem>
                                                                                        <asp:ListItem>5</asp:ListItem>
                                                                                        <asp:ListItem>6</asp:ListItem>
                                                                                        <asp:ListItem>7</asp:ListItem>
                                                                                        <asp:ListItem>8</asp:ListItem>
                                                                                        <asp:ListItem>9</asp:ListItem>
                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                        <asp:ListItem>11</asp:ListItem>
                                                                                        <asp:ListItem>12</asp:ListItem>
                                                                                        <asp:ListItem>13</asp:ListItem>
                                                                                        <asp:ListItem>14</asp:ListItem>
                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                        <asp:ListItem>16</asp:ListItem>
                                                                                        <asp:ListItem>17</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="ddlChild4" runat="server" 
                                                                                        Width="34px" Height="34px">
                                                                                        <asp:ListItem Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem>0</asp:ListItem>
                                                                                        <asp:ListItem>1</asp:ListItem>
                                                                                        <asp:ListItem>2</asp:ListItem>
                                                                                        <asp:ListItem>3</asp:ListItem>
                                                                                        <asp:ListItem>4</asp:ListItem>
                                                                                        <asp:ListItem>5</asp:ListItem>
                                                                                        <asp:ListItem>6</asp:ListItem>
                                                                                        <asp:ListItem>7</asp:ListItem>
                                                                                        <asp:ListItem>8</asp:ListItem>
                                                                                        <asp:ListItem>9</asp:ListItem>
                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                        <asp:ListItem>11</asp:ListItem>
                                                                                        <asp:ListItem>12</asp:ListItem>
                                                                                        <asp:ListItem>13</asp:ListItem>
                                                                                        <asp:ListItem>14</asp:ListItem>
                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                        <asp:ListItem>16</asp:ListItem>
                                                                                        <asp:ListItem>17</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="ddlChild3" runat="server" 
                                                                                        Width="34px" Height="34px">
                                                                                        <asp:ListItem Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem>0</asp:ListItem>
                                                                                        <asp:ListItem>1</asp:ListItem>
                                                                                        <asp:ListItem>2</asp:ListItem>
                                                                                        <asp:ListItem>3</asp:ListItem>
                                                                                        <asp:ListItem>4</asp:ListItem>
                                                                                        <asp:ListItem>5</asp:ListItem>
                                                                                        <asp:ListItem>6</asp:ListItem>
                                                                                        <asp:ListItem>7</asp:ListItem>
                                                                                        <asp:ListItem>8</asp:ListItem>
                                                                                        <asp:ListItem>9</asp:ListItem>
                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                        <asp:ListItem>11</asp:ListItem>
                                                                                        <asp:ListItem>12</asp:ListItem>
                                                                                        <asp:ListItem>13</asp:ListItem>
                                                                                        <asp:ListItem>14</asp:ListItem>
                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                        <asp:ListItem>16</asp:ListItem>
                                                                                        <asp:ListItem>17</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="ddlChild2" runat="server" 
                                                                                        Width="34px" Height="34px">
                                                                                        <asp:ListItem Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem>0</asp:ListItem>
                                                                                        <asp:ListItem>1</asp:ListItem>
                                                                                        <asp:ListItem>2</asp:ListItem>
                                                                                        <asp:ListItem>3</asp:ListItem>
                                                                                        <asp:ListItem>4</asp:ListItem>
                                                                                        <asp:ListItem>5</asp:ListItem>
                                                                                        <asp:ListItem>6</asp:ListItem>
                                                                                        <asp:ListItem>7</asp:ListItem>
                                                                                        <asp:ListItem>8</asp:ListItem>
                                                                                        <asp:ListItem>9</asp:ListItem>
                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                        <asp:ListItem>11</asp:ListItem>
                                                                                        <asp:ListItem>12</asp:ListItem>
                                                                                        <asp:ListItem>13</asp:ListItem>
                                                                                        <asp:ListItem>14</asp:ListItem>
                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                        <asp:ListItem>16</asp:ListItem>
                                                                                        <asp:ListItem>17</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="ddlChild1" runat="server" 
                                                                                        Width="34px" Height="34px">
                                                                                        <asp:ListItem Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem>0</asp:ListItem>
                                                                                        <asp:ListItem>1</asp:ListItem>
                                                                                        <asp:ListItem>2</asp:ListItem>
                                                                                        <asp:ListItem>3</asp:ListItem>
                                                                                        <asp:ListItem>4</asp:ListItem>
                                                                                        <asp:ListItem>5</asp:ListItem>
                                                                                        <asp:ListItem>6</asp:ListItem>
                                                                                        <asp:ListItem>7</asp:ListItem>
                                                                                        <asp:ListItem>8</asp:ListItem>
                                                                                        <asp:ListItem>9</asp:ListItem>
                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                        <asp:ListItem>11</asp:ListItem>
                                                                                        <asp:ListItem>12</asp:ListItem>
                                                                                        <asp:ListItem>13</asp:ListItem>
                                                                                        <asp:ListItem>14</asp:ListItem>
                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                        <asp:ListItem>16</asp:ListItem>
                                                                                        <asp:ListItem>17</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <span id="Span1" class="btn btn-default btn-primary" onclick="ChildValidation();" style="width: 100%;">🔎 جستجو</span>
                                                            <asp:Button class="btn btn-primary btn-lg" ID="btnSearch" 
                                                            runat="server" Text="جستجو" Width="100%" style="display:none;"/>
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
<script type="text/javascript">
    function Meee(message) {
        alert(message);
    };

    function MessageBox(Title, Message) {
        document.getElementById("pageModalMessageBoxTitle").innerHTML = Title;
        document.getElementById("pageModalMessageBoxMessage").innerHTML = Message;
        $("#pageModalMessageBox").modal('show');
    }

    // Start Validation --------------------------------------------------
    function ChildValidation() {
        var tmpchildflag = 'false'
        var ErMsg = ''
        var currentdate = new Date().format('dd/MMM/yyyy');

        if (document.getElementById("<%= txtHotelName.ClientID %>").value == '') {
            ErMsg = '* نام هتل را وارد کنید'
        }

        if (document.getElementById("start").value < currentdate) {
            document.getElementById("start").style.borderColor = "red";
            if (ErMsg !== '') {
                ErMsg += '<br />' + '* تاریخ ورورد نمی تواند روزهای گذشته باشد'
            } else {
                ErMsg = '* تاریخ ورورد نمی تواند روزهای گذشته باشد'
            }
        } else {
            document.getElementById("start").style.borderColor = "";
        }
        var tmpStartDate = document.getElementById("start").value.split("/");
        var LastMonth = new Date(tmpStartDate);
        LastMonth.setMonth(LastMonth.getMonth() + 1);

        var tmpEndDate = document.getElementById("end").value.split("/");

        if (Date.parse(tmpEndDate) > Date.parse(LastMonth)) {
            document.getElementById("end").style.borderColor = "red";
            if (ErMsg !== '') {
                ErMsg += '<br />' + '* تاریخ خروج نمی تواند بیشتر از یک ماه باشد'
            } else {
                ErMsg = '* تاریخ خروج نمی تواند بیشتر از یک ماه باشد'
            }
        } else {
            document.getElementById("end").style.borderColor = "";
        }


        //Start Child Validation ----------------------------------------------------
        var tmpchildno = document.getElementById("<%= ddlChild.ClientID %>").value

        try {
            if (document.getElementById("<%= ddlChild1.ClientID %>").value == "" && tmpchildno >= 1) {
                document.getElementById("<%= ddlChild1.ClientID %>").style.borderColor = "red";
                tmpchildflag = "true";
            } else {
                document.getElementById("<%= ddlChild1.ClientID %>").style.borderColor = "";
            }
        }
        catch (e) {
        }
        //---------------------
        try {
            if (document.getElementById("<%= ddlChild2.ClientID %>").value == "" && tmpchildno >= 2) {
                document.getElementById("<%= ddlChild2.ClientID %>").style.borderColor = "red";
                tmpchildflag = "true";
            } else {
                document.getElementById("<%= ddlChild2.ClientID %>").style.borderColor = "";
            }
        }
        catch (e) {
        }
        //---------------------
        try {
            if (document.getElementById("<%= ddlChild3.ClientID %>").value == "" && tmpchildno >= 3) {
                document.getElementById("<%= ddlChild3.ClientID %>").style.borderColor = "red";
                tmpchildflag = "true";
            } else {
                document.getElementById("<%= ddlChild3.ClientID %>").style.borderColor = "";
            }
        }
        catch (e) {
        }
        //---------------------
        try {
            if (document.getElementById("<%= ddlChild4.ClientID %>").value == "" && tmpchildno >= 4) {
                document.getElementById("<%= ddlChild4.ClientID %>").style.borderColor = "red";
                tmpchildflag = "true";
            } else {
                document.getElementById("<%= ddlChild4.ClientID %>").style.borderColor = "";
            }
        }
        catch (e) {
        }
        //---------------------
        try {
            if (document.getElementById("<%= ddlChild5.ClientID %>").value == "" && tmpchildno >= 5) {
                document.getElementById("<%= ddlChild5.ClientID %>").style.borderColor = "red";
                tmpchildflag = "true";
            } else {
                document.getElementById("<%= ddlChild5.ClientID %>").style.borderColor = "";
            }
        }
        catch (e) {
        }
        //---------------------
        try {
            if (document.getElementById("<%= ddlChild6.ClientID %>").value == "" && tmpchildno >= 6) {
                document.getElementById("<%= ddlChild6.ClientID %>").style.borderColor = "red";
                tmpchildflag = "true";
            } else {
                document.getElementById("<%= ddlChild6.ClientID %>").style.borderColor = "";
            }
        }
        catch (e) {
        }
        //---------------------
        try {
            if (document.getElementById("<%= ddlChild7.ClientID %>").value == "" && tmpchildno == 7) {
                document.getElementById("<%= ddlChild7.ClientID %>").style.borderColor = "red";
                tmpchildflag = "true";
            } else {
                document.getElementById("<%= ddlChild7.ClientID %>").style.borderColor = "";
            }
        }
        catch (e) {
        }

        //End Child Validation----------------------------

        if (tmpchildflag == "true" | ErMsg !== '') {
            if (ErMsg !== '') {
                if (tmpchildflag == "true") {
                    ErMsg += '<br />' + '* سن تمامی کودکان را وارد کنید'
                }
            } else {
                ErMsg = '* سن تمامی کودکان را وارد کنید'
            };

            MessageBox('خطا', 'لطفاً موارد ذکر شده را تکمیل کنید' + '<br />' + ErMsg);
        } else {
            document.getElementById("<%= btnSearch.ClientID %>").click();
        }
    }
    //End Validation ----------------------------------------------------
</script>

        <script src="js/core/jquery-2.1.1.min.js"></script>
        <script src="js/bootstrap.js"></script> <!-- UI -->
        <script src="js/slimmenu.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>
        <script src="js/bootstrap-timepicker.js"></script>
        <script src="js/nicescroll.js"></script>
        <script src="js/typeahead.js"></script>
        <script src="js/customtypeahead.js"></script>

</asp:Content>

