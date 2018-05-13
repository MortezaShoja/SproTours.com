<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HotelCheckIn.aspx.vb" Inherits="HotelCheckIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="booking-item-details">
            <div class="booking-item-header">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4" >
                                <div class="booking-item-dates-change mb20">
                                    <label>Your booking includes:</label>
                                    <br />
                                    <br />
                                    <br />
                                </div>
                                <div class="booking-item-dates-change mb20">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-users input-icon input-icon-highlight"></i>
                                                        <label>کل میهمانان</label>
                                                        <asp:TextBox class="form-control" ID="txtTotalGuests" runat="server" Enabled="false" Text="0" Height="43px" style="padding-left: 40px;"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-user input-icon input-icon-highlight"></i>
                                                        <label>بزرگسال</label>
                                                        <asp:TextBox class="form-control" ID="txtTotalAdult" runat="server" Enabled="false" Text="0" Height="43px" style="padding-left: 40px;"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-child input-icon input-icon-highlight"></i>
                                                        <label>خردسال</label>
                                                        <asp:TextBox class="form-control" ID="txtTotalChild" runat="server" Enabled="false" Text="0" Height="43px" style="padding-left: 40px;"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <asp:GridView ID="dgvRoomTypes" runat="server" Width="100%" BorderWidth="2px">
                                        <RowStyle BackColor="#d3d3d3" Height="40px" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#9d9d9d" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#555c66" Font-Bold="True" ForeColor="#333333" BorderStyle="Groove" BorderColor="#FF9900" />
                                        <HeaderStyle BackColor="#555c66" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <EditRowStyle BackColor="#9d9d9d" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <asp:TextBox ID="txtRoomID" runat="server" Visible="false"></asp:TextBox>
                                    <div class="form-group" style="text-align:right">
                                       <asp:Label ID="lblTotalPrice" runat="server" Text="0" Font-Size="Large" ForeColor="#FF9900" Font-Bold="True"></asp:Label>
                                       <br />
                                       <br />
                                    </div>
                                    <asp:Button class="btn btn-primary" ID="btnRegister" runat="server" Text="ثبت رزرواسیون" />
                                </div>
                            </div>
                            <div class="col-md-8" >
                                <div class="booking-item-dates-change mb20">
                                    <h2 class="lh1em">
                                        <asp:Label ID="lblHotelName" runat="server" Text="Labelhotelname"></asp:Label><asp:Image ID="imgStars" runat="server" Width="90" Height="21" />
                                    </h2> 
                                    <p class="lh1em"><i class="fa fa-map-marker"></i><asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></p>
                                </div>
                                <div id="divRooms" runat="server">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--<div class="booking-item-dates-change mb10">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-home input-icon input-icon-highlight"></i>
                                                <label>نوع اطاق</label>
                                                    <input class="form-control" type="text" value="double" disabled="true"/>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-user input-icon input-icon-highlight"></i>
                                                <label>بزرگسال</label>
                                                    <input class="form-control" type="text" value="2" disabled="true"/>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-child input-icon input-icon-highlight"></i>
                                                <label>خردسال</label>
                                                    <input class="form-control" type="text" value="1" disabled="true"/>
                                                </div>
                                            </div>

                                        <div class="col-md-2">
                                            <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-fire input-icon input-icon-highlight"></i>
                                                <label>سیگار</label>
                                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" 
                                                        Width="100%" Height="45px">
                                                        <asp:ListItem Selected="True">خیر</asp:ListItem>
                                                        <asp:ListItem>بلی</asp:ListItem>
                                                    </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label>نام و نام خانوادگی</label>
                                        </div>
                                        <div class="col-md-3">
                                            <label>تاریخ تولد</label>
                                        </div>
                                        <div class="col-md-5">
                                            <label>ایمیل (اختیاری)</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-lg form-group-icon-left">
                                                <input class="form-control" type="text" value="" /><i class="fa fa-user input-icon-inline"></i>
                                            </div>
                                        </div>
                                        <div class="input-daterange" data-date-format="dd/M/yyyy">
                                            <div class="col-md-3">
                                                <div class="form-group form-group-lg form-group-icon-left">
                                                    <input id="start" class="form-control" name="start" type="text" style="background-color:White;"  /><i class="fa fa-calendar input-icon-inline"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="form-group form-group-lg form-group-icon-left">
                                                <input class="form-control" type="text" value="" /><i class="fa fa-envelope-o input-icon-inline"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-lg form-group-icon-left">
                                                <input class="form-control" type="text" value="" /><i class="fa fa-user input-icon-inline"></i>
                                            </div>
                                        </div>
                                        <div class="input-daterange" data-date-format="dd/M/yyyy">
                                            <div class="col-md-3">
                                                <div class="form-group form-group-lg form-group-icon-left">
                                                    <input id="Text1" class="form-control" name="start" type="text" style="background-color:White;"  /><i class="fa fa-calendar input-icon-inline"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="form-group form-group-lg form-group-icon-left">
                                                <input class="form-control" type="text" value="" /><i class="fa fa-envelope-o input-icon-inline"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-lg form-group-icon-left">
                                                <input class="form-control" type="text" value="" /><i class="fa fa-child input-icon-inline"></i>
                                            </div>
                                        </div>
                                        <div class="input-daterange" data-date-format="dd/M/yyyy">
                                            <div class="col-md-3">
                                                <div class="form-group form-group-lg form-group-icon-left">
                                                    <input id="Text2" class="form-control" name="start" type="text" style="background-color:White;"  /><i class="fa fa-calendar input-icon-inline"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="form-group form-group-lg form-group-icon-left">
                                                <input class="form-control" type="text" value="" /><i class="fa fa-envelope-o input-icon-inline"></i>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
</asp:Content>

