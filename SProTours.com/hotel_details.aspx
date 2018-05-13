<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="hotel_details.aspx.vb" Inherits="hotel_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">  
    <div class="booking-item-details">
        <div class="booking-item-header">
            <div class="row">
                <div class="col-md-12" >
                    <h2 class="lh1em">
                        <asp:Label ID="lblHotelName" runat="server" Text="Labelhotelname"></asp:Label><asp:Image ID="imgStars" runat="server" Width="90" Height="21" />
                    </h2> 
                    <p class="lh1em text-small"><i class="fa fa-map-marker"></i><asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5">
                <div class="booking-item-dates-change mb20">
                    <div class="row">
                        <div class="col-md-12">
                            <br /><br /><br />
                        </div>
                    </div>
                </div>

                <div class="booking-item-dates-change mb20">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-group-lg form-group-icon-left" style="text-align: left;"><i class="fa fa-map-marker input-icon input-icon-highlight"></i>
                                <label style="text-align: right">جستجوی جدید</label>
                                <asp:TextBox class="typeahead form-control" placeholder="نام هتل را وارد کنید" ID="txtHotelName" runat="server" style="text-align:left"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-daterange" data-date-format="dd/M/yyyy">
                            <div class="col-md-6">
                                <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                    <label style="text-align: right">تاریخ ورود</label>
                                    <input id="start" class="form-control" name="start" type="text" onblur="ChangeBookingDates(this);" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                    <label style="text-align: right">تاریخ خروج</label>
                                    <input id="end" class="form-control" name="end" type="text" onblur="ChangeBookingDates();" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-university input-icon input-icon-highlight"></i>
                                            <label style="text-align: right">اطلاق</label>
                                            <asp:DropDownList class="form-control" ID="ddlRooms" runat="server" 
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
                                    </td>
                                    <td style="width:10px;"></td>
                                    <td>
                                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-user input-icon input-icon-highlight"></i>
                                            <label style="text-align: right">بزرگسال</label>
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
                                    </td>
                                    <td style="width:10px;"></td>
                                    <td>
                                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-child input-icon input-icon-highlight"></i>
                                            <label style="text-align: right">خردسال</label>
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
                                    </td>
                                    <td style="width:10px;"></td>
                                    <td>
                                        <div class="form-group">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <div id="divChildAges" runat="server" visible="false" dir="rtl" style="text-align: right">
                                                        <label ID="lblChildAges" runat="server" style="text-align: right;">سن خردسال</label>
                                                        <table dir="rtl">
                                                            <tr style="text-align: right">
                                                                <td>
                                                                    <asp:DropDownList ID="ddlChild7" runat="server" 
                                                                        Width="100%" Height="33px">
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
                                                                <td style="width: 2px"></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlChild6" runat="server" 
                                                                        Width="100%" Height="33px">
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
                                                                <td style="width: 2px"></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlChild5" runat="server" 
                                                                        Width="100%" Height="33px">
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
                                                                <td style="width: 2px"></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlChild4" runat="server" 
                                                                        Width="100%" Height="33px">
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
                                                                <td style="width: 2px"></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlChild3" runat="server" 
                                                                        Width="100%" Height="33px">
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
                                                                <td style="width: 2px"></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlChild2" runat="server" 
                                                                        Width="100%" Height="33px">
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
                                                                <td style="width: 2px"></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlChild1" runat="server" 
                                                                        Width="100%" Height="33px">
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
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button class="btn btn-primary btn-lg" CausesValidation="false" 
                                ID="btnSearch" runat="server" Text="🔎 جستجو" Height="43px" Width="100%" 
                                Font-Bold="True" Font-Size="14pt" style="display:none;"/>

                                <span id="Span1" class="btn btn-default btn-primary" onclick="ChildValidation();" style="width: 100%;">🔎 جستجو</span>
                        </div>
                    </div>


                </div>
            </div>
            <div class="col-md-7">
            <div class="booking-item-dates-change mb20">
                <div class="tabbable booking-details-tabbable">
                    <ul class="nav nav-pills nav-justified" id="myTab">
                        <li class="active"><a href="#photos-tab" data-toggle="tab"><i class="fa fa-camera"></i>تصاویر</a>
                        </li>
                        <li><a href="#facilities-tab" data-toggle="tab"><i class="fa fa-university"></i>امکانات</a>
                        </li>
                        <li><a href="#policies-tab" data-toggle="tab"><i class="fa fa-book"></i>قوانین</a>
                        </li>
                        <!--<li style="width:24%;"><a href="#google-map-tab" data-toggle="tab"><i class="fa fa-map-marker"></i>نقشه</a>
                        </li>-->
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="photos-tab">
                            <div ID="DivImageLightBox"  runat="server" class="fotorama" data-allowfullscreen="true" data-autoplay="true" data-width="100%"  data-nav="thumbs" style="width:100%;">

                            </div>
                        </div>
                        <div class="tab-pane fade" id="facilities-tab">
                            <div id="Divfacilities"
                                style="width:100%; height:393px; display: block; overflow: auto;">
                                <table class="table table-bordered table-striped table-booking-history">
                                        <tbody id="TbodyFacilities" runat="server">
                                        </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="policies-tab">
                            <div id="Divpolicies" 
                                style="width:100%; height:393px; display: block; overflow: auto;">
                                <table class="table table-bordered table-striped table-booking-history">
                                        <tbody id="ContentPlaceHolder1_TblRoomTypes">
                                            <tr>
                                                <td>Check In</td>
                                                <td><asp:Label ID="lblCheckIn" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Check Out</td>
                                                <td><asp:Label ID="lblCheckOut" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Pet Policy</td>
                                                <td><asp:Label ID="lblPetPolicy" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Children and extra bed</td>
                                                <td><asp:Label ID="lblExtraBedAndChildren" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>The Fine Print</td>
                                                <td><asp:Label ID="lblTheFinePrint" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                        </tbody>
                                </table>    
                            </div>
                        </div>
                        <div class="tab-pane fade" id="google-map-tab">
                            <div id="map-canvas" style="width:100%; height:393px;"></div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
                    
        </div>
        <div class="row">                                         
            <div class="col-md-12">
            <div class="booking-item-dates-change mb20">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <!--<label style="text-align: right">اطاق ها</label>-->
                            <div style="display: block; overflow: auto; border: 1px groove orange;">
                                <label id="lblIds" runat="server" style="display:none;"></label>
                                <table id="tblRoomTypes" class="table table-bordered table-striped table-booking-history">
                                    <thead>
                                        <tr>
                                            <th>نوع اطاق</th>
                                            <th>ظرفیت</th>
                                            <th>بزرگسال</th>
                                            <th>کودک</th>
                                            <th>تخت اضافی</th>
                                            <th>سن کودکان</th>
                                            <th>قیمت</th>
                                            <th>تعداد اطاق</th>
                                            <th>قیمت کل</th>
                                        </tr>
                                    </thead>
                                    <tbody ID="TblRoomTypesBody" runat="server">
                                    </tbody>
                                </table>
                            </div>
                    </div>
                    <div style="width:100%; text-align:right;">
                        <asp:Label ID="lblTotalPrice" runat="server" Text="Label">0</asp:Label>
                    </div>
                            
                </div>
            </div>

                    
                    
            <div class="row">
            <div class="col-md-9">
            </div>
            <div class="col-md-3">
                <!--<span id="Span2" data-toggle="modal" href="#page1Modal" class="btn btn-default btn-primary" onclick="LoadFrom1(this)" style="width: 100%;">ادامه</span>-->
                <span id="Span2" class="btn btn-default btn-primary" onclick="RequestValidation()" style="width: 100%;">ادامه</span>
            </div>
            </div>
            </div>
            </div>
                    
        </div>
    </div>

    <div class="gap gap-small"></div>
    </div>
<!---Modals------------>
<div id="LoginRequiredModal" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">ورود به حساب کاربری</h4>
            </div>
            <div class="modal-body">
                <div class="booking-item-dates-change">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-map-marker input-icon"></i>
                                <label>لطفاً جهت تکمیل فرآیند رزرواسیون به حساب کاربری خود وارید شود </label>
                                <br />
                                <label>و یا یک حساب جدیدایجاد کنید</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <span data-animated-link="fadeOut" data-toggle="modal" class="" href="#pageModalLogin"><i class="fa fa-user"></i>ورود اعضاء</span>
                        </div>
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-4">
                            <span data-animated-link="fadeOut" data-toggle="modal" class="" href="#pageModalRequestMember"><i class="fa fa-edit"></i>درخواست عضویت</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">انصراف</button>
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>



<div id="page1Modal" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">جزئیات درخواست</h4>
            </div>
            <div class="modal-body">
                        <div class="booking-item-dates-change">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-map-marker input-icon"></i>
                                        <label>نام هتل</label>
                                        <asp:TextBox class="form-control" ID="txtOwerviewHotelName" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row" dir="rtl">
                                <div class="col-md-6">
                                        <label>تاریخ خروج</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewCheckOut" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                        <label>تاریخ ورود</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewCheckIn" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                        <label>تعداد اطاق</label>
                                    <asp:TextBox style="text-align:center" class="form-control" name="txtOwerviewRooms" ID="txtOwerviewRooms" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                        <label>تعداد کودکان</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewChild" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                        <label>تعداد بزرگسالان</label>
                                    <asp:TextBox style="text-align:center" class="form-control" ID="txtOwerviewAdult" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12" dir="rtl" style="text-align: right;">
                                        <label id="lblPage2ChildAges" runat="server" dir="rtl" style="display:none;">سن کودکان</label>
                                        
                                        <table dir="ltr">
                                        <tr>
                                        <td><asp:TextBox style="text-align:center; display:none;" class="form-control" ID="txtOwerviewChild7" runat="server" 
                                                ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 2px"></td>
                                        <td><asp:TextBox style="text-align:center; display:none;" class="form-control" ID="txtOwerviewChild6" runat="server" 
                                                ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 2px"></td>
                                        <td><asp:TextBox style="text-align:center; display:none;" class="form-control" ID="txtOwerviewChild5" runat="server" 
                                                ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 2px"></td>
                                        <td><asp:TextBox style="text-align:center; display:none;" class="form-control" ID="txtOwerviewChild4" runat="server" 
                                                ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 2px"></td>
                                        <td><asp:TextBox style="text-align:center; display:none;" class="form-control" ID="txtOwerviewChild3" runat="server" 
                                                ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 2px"></td>
                                        <td><asp:TextBox style="text-align:center; display:none;" class="form-control" ID="txtOwerviewChild2" runat="server" 
                                                ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 2px"></td>
                                        <td><asp:TextBox style="text-align:center; display:none;" class="form-control" ID="txtOwerviewChild1" runat="server" 
                                                ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                        </table>

                                </div>
                            </div>
                            <div class="row">
                                
                                <div class="col-md-12">
                                        <label>نوع اطاق ها</label>
                                        <div style="border: 1px groove #CCCCCC; text-align:left; direction:ltr; ">
                                            <asp:Label ID="lblOverViewRooms" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtOverViewRooms" runat="server" style="display:none;"></asp:TextBox>
                                        </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                        <label>توضیحات بیشتر</label>
                                    <asp:TextBox style="text-align:right" class="form-control" ID="txtLastOverviewDescription" runat="server" Height="70" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">اصلاح</button>
                <span id="SpanbtnRequestMembershipContinue" data-toggle="modal" href="#page2Modal" class="btn btn-default btn-primary"  style="width: 60px;display:inline;">ادامه</span>
                <span  id="SpanbtnRequestMembershipSendRequest" class="btn btn-default btn-primary" onclick="doSendRequestPostback()" style="display:none;">ارسال درخواست</span>
            </div>

        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

<div id="page2Modal" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">مشخصات درخواست دهنده</h4>
            </div>
            <div class="modal-body">
                        <div id="divMemberLoginMethode" class="booking-item-dates-change" style="text-align:center;">
                           <span class="btn btn-default btn-primary" data-animated-link="fadeOut" data-toggle="modal" class="" href="#pageModalLogin">حساب کاربری از قبل دارم</span>
                           <hr />
                           <span class="btn btn-default btn-primary" data-animated-link="fadeOut" data-toggle="modal" class="" href="#pageModalRequestMember">کاربر جدید هستم و میخواهم ثبت نام کنم</span>          
                        </div>
            </div>
            <div class="modal-footer">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <button type="button" class="btn btn-default" data-dismiss="modal"  onclick="LoadFrom1(this)">اصلاح</button>
                        <span  id="SpanbtnSendRequest" class="btn btn-default btn-primary" onclick="doSendRequestPostback()" style="display:none;">ارسال درخواست</span>
                        <asp:Button style="display:none;" class="btn btn-primary" ID="btnSendRequest" runat="server" Text="ارسال درخواست" CausesValidation="False" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>

<div id="pageModalRequestReceived" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">ثبت درخواست</h4>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="booking-item-dates-change">
                            <div class="row">
                                <div class="col-md-10">
                                    <label id="lblFinishingMessage">درخواست رزرو شما در حال ثبت می باشد<br />لطفاً جهت پیگیری به ایمیل و یا پنل مدیریتی خود مراجعه فرمایید</label>
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

<script type="text/javascript">

//    function BtnSendRequestDisplayMode(DisplayMode) {
//        if (DisplayMode == 'Show') {
//            $("#page2Modal").modal('hide');
//            document.getElementById("SpanbtnSendRequest").style.display = "";
//            document.getElementById("SpanbtnRequestMembershipContinue").style.display = "none";
//            document.getElementById("SpanbtnRequestMembershipSendRequest").style.display = "";
//        } else {
//            document.getElementById("SpanbtnSendRequest").style.display = "none";
//            document.getElementById("SpanbtnRequestMembershipContinue").style.display = "";
//            document.getElementById("SpanbtnRequestMembershipSendRequest").style.display = "None";
//        }
//    }

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
    function RequestValidation() {
        var tmpelements = document.querySelectorAll('select[id^="lstRoomCount_"]');
        var tmpRoomCount = 0
        for (i = 0; i < (tmpelements.length); i++) {
            tmpRoomCount = parseInt(tmpRoomCount) + parseInt(tmpelements[i].value);
        };

        if (parseInt(tmpRoomCount) == 0) {
            MessageBox('خطا', '* لطفاً نوع و تعداد اطاق مورد نظر خود را انتخاب کنید');
        } else {
            document.getElementById("<%= btnSendRequest.ClientID %>").click();
        };
    };
//    function RequestValidation() {
//        var tmpchilderrormsg = ""
//        var tmpfalg = "false"

//        //Start Table ----------------------------------------------------
//        document.getElementById("<%= lblOverViewRooms.ClientID %>").innerHTML = "";
//        var refTab = document.getElementById("tblRoomTypes");

//        var ttl;
//        // Loop through all rows and columns of the table and popup alert with the value
//        // /content of each cell.
//        var roomcount = 0;
//        for (var i = 1; row = refTab.rows[i]; i++) {
//            row = refTab.rows[i];
//            var rowtext = "";
//            var ddlval = 0;

//            for (var j = 0; col = row.cells[j]; j++) {
//                // Cel RoomType Name
//                if (j == 0) {
//                    rowtext = rowtext + col.firstChild.nodeValue + " : "
//                }
//                // Cel DDL RoomCount
//                if (j == 3) {
//                    //alert(col.firstChild.value);
//                    ddlval = col.firstChild.value
//                    if (ddlval == 1) {
//                        rowtext = rowtext + col.firstChild.value + " Room"
//                    } else {
//                        rowtext = rowtext + col.firstChild.value + " Rooms"
//                    };
//                }
//                // Cel TotalPrice
//                if (j == 4) {
//                    rowtext = rowtext + " = " + col.firstChild.nodeValue
//                }

//            }


//            if (ddlval > 0) {
//                roomcount = parseInt(roomcount) + parseInt(ddlval)
//                document.getElementById("<%= lblOverViewRooms.ClientID %>").innerHTML = document.getElementById("<%= lblOverViewRooms.ClientID %>").innerHTML + rowtext + "<br />"
//                document.getElementById("<%= txtOverViewRooms.ClientID %>").value = document.getElementById("<%= txtOverViewRooms.ClientID %>").value + rowtext + "#"
//                rowtext = ""
//            }
//        }

//        if (document.getElementById("<%= lblOverViewRooms.ClientID %>").innerHTML !== "") {
//            document.getElementById("<%= lblOverViewRooms.ClientID %>").innerHTML = document.getElementById("<%= lblOverViewRooms.ClientID %>").innerHTML + "<span style='color:red;'>  Total Price : " + document.getElementById("<%= lblTotalPrice.ClientID %>").innerHTML + "</Span>"
//            document.getElementById("<%= txtOverViewRooms.ClientID %>").value = document.getElementById("<%= txtOverViewRooms.ClientID %>").value + "#" + document.getElementById("<%= lblTotalPrice.ClientID %>").innerHTML
//        }
//        document.getElementById("<%= txtOwerviewRooms.ClientID %>").value = roomcount;
//        //End Table ----------------------------------------------------
//   
//      
//        var errormsg = '';
//        if (roomcount == 0) {
//            //document.getElementById("<%= ddlChild7.ClientID %>").style.borderColor = "red";
//            errormsg = '* لطفاً نوع و تعداد اطاق مورد نظر خود را انتخاب کنید';
//        } else {
//            //document.getElementById("<%= ddlChild7.ClientID %>").style.borderColor = "";
//        }

//        if (errormsg !== '') {
//            errormsg = 'لطفاً موارد ذیل را تکمیل کنید' + '<br />' + errormsg;
//            MessageBox('خطا', errormsg);
//        } else {

//            $("#page1Modal").modal('show');

//            ddlchildclicked();

//            document.getElementById("<%= txtOwerviewHotelName.ClientID %>").value = document.getElementById("<%= lblHotelName.ClientID %>").innerText;
//            document.getElementById("<%= txtOwerviewCheckIn.ClientID %>").value = document.getElementById("start").value;
//            document.getElementById("<%= txtOwerviewCheckOut.ClientID %>").value = document.getElementById("end").value;
//            document.getElementById("<%= txtOwerviewAdult.ClientID %>").value = document.getElementById("<%= ddlAdult.ClientID %>").value;
//            document.getElementById("<%= txtOwerviewChild.ClientID %>").value = document.getElementById("<%= ddlChild.ClientID %>").value;

//            //---------------------------------
//            document.getElementById("<%= txtOwerviewChild1.ClientID %>").value = document.getElementById("<%= ddlChild1.ClientID %>").value;
//            document.getElementById("<%= txtOwerviewChild2.ClientID %>").value = document.getElementById("<%= ddlChild2.ClientID %>").value;
//            document.getElementById("<%= txtOwerviewChild3.ClientID %>").value = document.getElementById("<%= ddlChild3.ClientID %>").value;
//            document.getElementById("<%= txtOwerviewChild4.ClientID %>").value = document.getElementById("<%= ddlChild4.ClientID %>").value;
//            document.getElementById("<%= txtOwerviewChild5.ClientID %>").value = document.getElementById("<%= ddlChild5.ClientID %>").value;
//            document.getElementById("<%= txtOwerviewChild6.ClientID %>").value = document.getElementById("<%= ddlChild6.ClientID %>").value;
//            document.getElementById("<%= txtOwerviewChild7.ClientID %>").value = document.getElementById("<%= ddlChild7.ClientID %>").value;

//        }
//    }

    // End Validation -------------------------------------------------- 

   $(".modal-wide").on("show.bs.modal", function () {
        var height = $(window).height() - 200;
    });
    // --------------------------------------------------

    function validateEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }

//    // ------------------------------------------------------------
//    function ddlchildclicked() {

//        document.getElementById("<%= txtOwerviewChild1.ClientID %>").style.display = "none";
//        document.getElementById("<%= txtOwerviewChild2.ClientID %>").style.display = "none";
//        document.getElementById("<%= txtOwerviewChild3.ClientID %>").style.display = "none";
//        document.getElementById("<%= txtOwerviewChild4.ClientID %>").style.display = "none";
//        document.getElementById("<%= txtOwerviewChild5.ClientID %>").style.display = "none";
//        document.getElementById("<%= txtOwerviewChild6.ClientID %>").style.display = "none";
//        document.getElementById("<%= txtOwerviewChild7.ClientID %>").style.display = "none";
//        document.getElementById("<%= lblPage2ChildAges.ClientID %>").style.display = "none";

//        var tmpchild = document.getElementById("<%= ddlchild.ClientID %>").value;
//        
//        if (tmpchild >= 7) {
//            document.getElementById("<%= txtOwerviewChild7.ClientID %>").style.display = "inline"
//        } 
//        //-----------------------------------------
//        if (tmpchild >= 6) {
//            document.getElementById("<%= txtOwerviewChild6.ClientID %>").style.display = "inline"
//        }
//        //-----------------------------------------
//        if (tmpchild >= 5) {
//            document.getElementById("<%= txtOwerviewChild5.ClientID %>").style.display = "inline"
//        }
//        //-----------------------------------------
//        if (tmpchild >= 4) {
//            document.getElementById("<%= txtOwerviewChild4.ClientID %>").style.display = "inline"
//        }
//        //----------------------------------------
//        if (tmpchild >= 3) {
//            document.getElementById("<%= txtOwerviewChild3.ClientID %>").style.display = "inline"
//        }
//        //-----------------------------------------
//        if (tmpchild >= 2) {
//            document.getElementById("<%= txtOwerviewChild2.ClientID %>").style.display = "inline"
//        }
//        //-----------------------------------------
//        if (tmpchild >= 1) {
//            document.getElementById("<%= txtOwerviewChild1.ClientID %>").style.display = "inline"
//            document.getElementById("<%= lblPage2ChildAges.ClientID %>").style.display = "inline"
//        };
//        //-----------------------------------------
//    };


  //-------------------------------------------------


//    function doSendRequestPostback() {
//        document.getElementById("<%= btnSendRequest.ClientID %>").click();
//        $("#page1Modal").modal('hide');
//        $("#page2Modal").modal('hide');
//        $("#pageModalRequestReceived").modal('show');
//    }

//    function openmessagebox(object) {
//        $("#pageModalRequestReceived").modal('show');
//    }

//    function peygham() {

//        //$("#page1Modal").modal('show');
//        //document.getElementById('page2Modal').showModal();
//        alert("درخواست شما دریافت شد. لطفا جهت پیگیری به ایمیل خود مراجعه نمایید");
//        window.location = "hotels.aspx";
//    }

//    function teram() {
//        $("#pageModalRequestReceived").modal('show');
//    }

    function SumTotalRoomPrices() {
        var elements = document.querySelectorAll('input[id^="txtTotalPrice_"]');
        var TotalPrice = '0';
        var currencyType = '';

        for (i = 0; i < (elements.length); i++) {
            var tmpprices = elements[i].value.split(' ');
            TotalPrice = parseFloat(TotalPrice) + parseFloat(tmpprices[0]);
            currencyType = tmpprices[1];
        };
        if (isNaN(TotalPrice) == false) {
            document.getElementById("<%= lblTotalPrice.ClientID %>").innerHTML = "Total Price = " + TotalPrice.toLocaleString() + ' ' + currencyType;
        } else {
            document.getElementById("<%= lblTotalPrice.ClientID %>").innerHTML = 'Some Prices Are Not Available';
        };
    };

//    function SumTotalPricesEachRoom(roomid) {
//        //alert(roomid);
//        var currencyType = ''
//        
//            var res = document.getElementById("Price" + roomid).innerHTML.split(" ");
//            var c = document.getElementById("Select" + roomid).value;
//            if (c == "0") {
//                document.getElementById("TotalPrice" + roomid).innerHTML = "0";
//            } else {
//            if (document.getElementById("Price" + roomid).innerHTML !== 'Not Available') {
//                document.getElementById("TotalPrice" + roomid).innerHTML = (res[0] * c).toString() + ' ' + res[1];
//                currencyType = res[1];
//                    } else {
//                document.getElementById("TotalPrice" + roomid).innerHTML = 'Not Available'
//            }
//            };
//        
//        //----------------------


//        var ids = document.getElementById("<%= lblIds.ClientID %>").innerHTML.split(",");
//        var TotalPrice = 0;
//        var PriceNotAvailable = '';
//        for (i = 0; i < ids.length - 1; i++) {
//                var tmpPrice = document.getElementById("TotalPrice" + ids[i]).innerHTML.split(" ");
//                //alert(tmpPrice[0]);
//                TotalPrice += parseInt(tmpPrice[0]);

//        }

//            if (isNaN(TotalPrice) == false) {
//                document.getElementById("<%= lblTotalPrice.ClientID %>").innerHTML = TotalPrice.toLocaleString() + ' ' + currencyType;
//            } else {
//                document.getElementById("<%= lblTotalPrice.ClientID %>").innerHTML = 'Some Prices Are Not Available';
//            }
//        }

//    //----------------------

</script>
 

        <script src="js/core/jquery-2.1.1.min.js"></script>
        <script src="vendor/prettyphoto/js/prettyphoto.js"></script> <!-- PrettyPhoto Plugin --> 
        <script src="vendor/flexslider/js/jquery.flexslider.js"></script> <!-- FlexSlider --> 
        <script src="js/helper-plugins.js"></script> <!-- Plugins --> 
        <script src="js/bootstrap.js"></script> <!-- UI -->
        <script src="js/slimmenu.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>
        <script src="js/bootstrap-timepicker.js"></script>
        <script src="js/nicescroll.js"></script>
        <script src="js/fotorama.js"></script>
        <script src="js/typeahead.js"></script>
        <script src="js/customtypeahead.js"></script>

              
</asp:Content>

