<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="hotels_search_results.aspx.vb" Inherits="hotels_search_results" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link rel="stylesheet" href="css/AccordionMenu.css">
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="index.html">Home</a>
                </li>
                <li><a href="#">United States</a>
                </li>
                <li><a href="#">New York (NY)</a>
                </li>
                <li><a href="#">New York City</a>
                </li>
                <li class="active">New York City Hotels</li>
            </ul>
            <div class="booking-item-dates-change mb40">
                <div class="row">
                <div class="col-md-4" >
                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-map-marker input-icon"></i>
                        <label>Where are you going?</label>
                        <asp:TextBox class="typeahead form-control" placeholder="City, Airport, Hotel Name" ID="txtHotelName" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="input-daterange" data-date-format="yyyy/M/dd">
                    <div class="col-md-2">
                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                            <label>Check In</label>
                            <input id="start" class="form-control" name="start" type="text" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                            <label>Check Out</label>
                            <input id="end" class="form-control" name="end" type="text"/>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div class="form-group">
                            <label>Rooms</label>
                            <asp:DropDownList class="form-control" ID="ddlRoomCount" runat="server" 
                                Height="47" Width="80px">
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
                    <div class="col-md-1">
                        <div class="form-group">
                            <label>Guests</label>
                            <asp:DropDownList class="form-control" ID="ddlGuestCount" runat="server" 
                                Height="46" Width="80px">
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
                </div>
                    <div class="col-md-2">
                    <label style="color: #FFFFFF">.</label>
                        <asp:Button class="btn btn-primary btn-lg" ID="btnSearchForHotels" 
                            runat="server" Text="New Search" Width="160px" />
                    </div>
            </div>
            </div>
            <div class="row">
                <div class="col-md-3" >
                <aside class="booking-filters text-white">
                <h3>Filter By:</h3>
                    <div id="accordion">
                    <h5 class="booking-filters-title" style="background-color: #666666; height: auto;">Star Rating</h5>
                    <div style="padding: .7em .5em .5em .7em;margin: 10px 10px 10px 10px;">
                        <div class="checkbox">
                            <asp:CheckBox  style="width:30px; height:30px;" ID="CheckBox1" runat="server" Text="1 Star" AutoPostBack="True"></asp:CheckBox>
                        </div>
                        <div class="checkbox">
                            <input id="OneStar" class="i-check" type="checkbox" runat="server" />
                        </div>
                        <div class="checkbox">
                            <label><input id="TwoStar" class="i-check" type="checkbox" />2 star</label>
                        </div>
                        <div class="checkbox">
                            <label><input id="ThreeStar" class="i-check" type="checkbox" />3 star</label>
                        </div>
                        <div class="checkbox">
                            <label><input id="FourStar" class="i-check" type="checkbox" />4 star</label>
                        </div>
                        <div class="checkbox">
                            <label><input id="FiveStar" class="i-check" type="checkbox" />5 star</label>
                        </div>
                        <div class="checkbox">
                            <label><input id="Unrated" class="i-check" type="checkbox" />Unrated</label>
                        </div>
                    </div>



                    <h5 style="background-color: #666666">Facility</h5>
                    <div style="padding: .7em .5em .5em .7em;margin: 10px 10px 10px 10px;">
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                    </div>
                    <h5 style="background-color: #666666">Room Facility</h5>
                    <div style="padding: .7em .5em .5em .7em;margin: 10px 10px 10px 10px;">
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                        <div class="checkbox">
                            <label><input class="i-check" type="checkbox" />5 star (220)</label>
                        </div>
                    </div>
                    </div>
                </aside>
            </div>
                <div class="col-md-9">
                    <ul class="booking-list">
                        <li>
                            <a class="booking-item" href="#">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="booking-item-img-wrap">
                                            <img src="img/hotel_porto_bay_rio_internacional_rooftop_pool_800x600.jpg" alt="Image Alternative text" title="hotel PORTO BAY RIO INTERNACIONAL rooftop pool" />
                                            <div class="booking-item-img-num"><i class="fa fa-picture-o"></i>23</div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="booking-item-rating">
                                            <ul class="icon-group booking-item-rating-stars">
                                                <li><i class="fa fa-star"></i>
                                                </li>
                                                <li><i class="fa fa-star"></i>
                                                </li>
                                                <li><i class="fa fa-star"></i>
                                                </li>
                                                <li><i class="fa fa-star"></i>
                                                </li>
                                                <li><i class="fa fa-star-o"></i>
                                                </li>
                                            </ul>
                                        </div>
                                        <h5 class="booking-item-title">Warwick New York Hotel</h5>
                                        <p class="booking-item-address"><i class="fa fa-map-marker"></i> New York, NY (Midtown East)</p><small class="booking-item-last-booked">Latest booking: 48 minutes ago</small>
                                    </div>
                                    <div class="col-md-3">
                                    <span class="booking-item-price-from">from</span>
                                    <span class="booking-item-price">$452</span>
                                    <span>/night</span>
                                    <span id="1002" data-toggle="modal" href="#normalModal" class="btn btn-default btn-primary" onclick="myFunction(this)">Request</span>
                                    </div>
                                </div>
                            </a>
                        </li>
                    </ul>
            </div>
            <div class="gap"></div>
        </div>

<div id="normalModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Request Form</h4>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel ID="UpdatePanel99" runat="server">
                    <ContentTemplate>
                        <div class="booking-item-dates-change">
                            <div class="row">
                                <div class="col-md-12" >
                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-map-marker input-icon"></i>
                                        <label>Hotel Name</label>
                                        <asp:TextBox class="form-control" ID="txtRequestFormHotelName" runat="server" ReadOnly="True"></asp:TextBox>
                                        <div ID="DivtxtRequestFormHotelCode" runat="server" style="position: absolute; z-index: 999; width: 0px; height: 0px">
                                            <asp:TextBox ID="txtRequestFormHotelCode" runat="server" AutoPostBack="True" Width="0" Wrap="False" BorderStyle="None" BorderWidth="0"></asp:TextBox>                        
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-daterange" data-date-format="yyyy/M/dd">
                                    <div class="col-md-6">
                                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                            <label>Check In</label>
                                            <asp:TextBox class="form-control" ID="txtRequestFormCheckIn" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                            <label>Check Out</label>
                                            <asp:TextBox class="form-control" ID="txtRequestFormCheckOut" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Rooms</label>
                            <asp:TextBox class="form-control" ID="txtRequestFormRooms" runat="server" ReadOnly="True" Height="47" Width="105px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Guests</label>
                            <asp:TextBox class="form-control" ID="txtRequestFormGuests" runat="server" ReadOnly="True" Height="47" Width="105px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Adults</label>
                            <asp:DropDownList class="form-control" ID="ddlRequestFormAdults" runat="server" 
                                Height="46" Width="105px">
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
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Children</label>
                            <asp:DropDownList class="form-control" ID="ddlRequestFormChildren" runat="server" 
                                Height="46" Width="105px" AutoPostBack="True">
                                <asp:ListItem Selected="True">0</asp:ListItem>
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
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                        <div id="DivRequestFormChildren" class="booking-item-dates-change" runat="server" visible="false">
                            <div class="row">
                                                              <div class="col-md-12">
                                                                <div>
                                                                    <label ID="lblAgeOfChildren" runat="server" style="color: #e27513">Age of children at check-out</label>
                                                                    <asp:DropDownList ID="ddlAgeOfChild1" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild2" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild3" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild4" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild5" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild6" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild7" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild8" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild9" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                    <asp:DropDownList ID="ddlAgeOfChild10" runat="server" ForeColor="#4D4D4D" 
                                                                        Visible="False">
                                                                        <asp:ListItem></asp:ListItem>
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
                                                                </div>
                                                            </div>

                            </div>
                        </div>
                        </div>
                        <div class="booking-item-dates-change">
                            <div class="row">
                            <div class="form-group">
                                <div class="col-md-3">
                                <label>Single Room</label>
                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" 
                                    Height="47" Width="105px">
                                    <asp:ListItem Selected="True">0</asp:ListItem>
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

                                <div class="col-md-3">
                                <label>Double Room</label>
                                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" 
                                    Height="47" Width="105px">
                                    <asp:ListItem Selected="True">0</asp:ListItem>
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

                                <div class="col-md-3">
                                <label>Triple Room</label>
                                <asp:DropDownList class="form-control" ID="DropDownList3" runat="server" 
                                    Height="47" Width="105px">
                                    <asp:ListItem Selected="True">0</asp:ListItem>
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

                                <div class="col-md-3">
                                <label>Suite</label>
                                <asp:DropDownList class="form-control" ID="DropDownList4" runat="server" 
                                    Height="47" Width="105px">
                                    <asp:ListItem Selected="True">0</asp:ListItem>
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
                                <row>
                                <div class="col-md-12" >
                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-file-text input-icon"></i>
                                        <label style="color: #e27513">Remarks</label>
                                        <asp:TextBox class="typeahead form-control" placeholder="Write a Remark ..." ID="TextBox1" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                </row>
                            </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Send Request</button>
            </div>

        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div><!-- /.modal -->


<script>
    $("#accordion").accordion({
        heightStyle: "content"
    });
</script>
<script>

    $(".modal-wide").on("show.bs.modal", function () {
        var height = $(window).height() - 200;
        //**$("#<%=txtRequestFormHotelCode.ClientID%>").val("Hello world");
    });

    function myFunction(object) {
        $("#<%= txtRequestFormHotelCode.ClientID%>").val(object.id);
        __doPostBack('<%= txtRequestFormHotelCode.UniqueID %>', '');
    }

</script>
        </div>
</asp:Content>

