<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Tours_details.aspx.vb" Inherits="Tours_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<link rel="stylesheet" href="/resources/demos/style.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<%--  <script>
      $(function () {
          $("#datepicker").datepicker();
      });
  </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
<div class="container">
    
    <div class="booking-item-details">
        <div class="booking-item-header">
            <div class="row">
                <div class="col-md-12" style="direction:rtl; text-align:right;">
                    <h2 class="lh1em"><asp:Label ID="lblTourName" runat="server" Text="lblTourName"></asp:Label></h2>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="booking-item-dates-change mb40">
                    <div ID="DivImageLightBox" runat="server" class="fotorama" data-allowfullscreen="true" data-autoplay="true" data-width="100%" data-nav="thumbs" style="width:100%;">
                    </div>
                </div>

                <div class="booking-item-dates-change mb40">
                    <div class="tabbable booking-details-tabbable">
                        <ul class="nav nav-tabs" id="Ul1">
                            <li style="width:25%;" class="active"><a href="#tourplan-tab" data-toggle="tab">برنامه تور</a>
                            </li>
                            <li style="width:25%;"><a href="#tourtime-tab" data-toggle="tab">زمان اجرا</a>
                            </li>
                            <li style="width:25%;"><a href="#tourrules-tab" data-toggle="tab">قوانین</a>
                            </li>
                            <li style="width:24%;"><a href="#tourextras-tab" data-toggle="tab">سایر خدمات</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tourplan-tab" style="min-height:165px; overflow: auto; direction:rtl; text-align:right;">
                                <asp:Label ID="lblTourPlan" runat="server" Text="" style="direction:rtl; text-align:right;"></asp:Label>
                            </div>
                            <div class="tab-pane fade" id="tourtime-tab" style="min-height:165px; overflow: auto; direction:rtl; text-align:right;">
                                <asp:Label ID="lblTourTime" runat="server" Text="" style="direction:rtl; text-align:right;"></asp:Label>
                            </div>
                            <div class="tab-pane fade" id="tourrules-tab" style="min-height:165px; overflow: auto; direction:rtl; text-align:right;">
                                <asp:Label ID="lblTourRules" runat="server" Text="" style="direction:rtl; text-align:right;"></asp:Label>
                            </div>
                            <div class="tab-pane fade" id="tourextras-tab" style="min-height:165px; overflow: auto; direction:rtl; text-align:right;">
                                <asp:Label ID="lblTourExtras" runat="server" Text="" style="direction:rtl; text-align:right;"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                                                          
            <div class="col-md-6">
                    
            <!--<h4>Title</h4>-->
                <div class="booking-item-dates-change mb40">
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label style="text-align: right">خردسال</label>
                                        <asp:DropDownList class="form-control" ID="ddlChild" runat="server" Width="100%" Height="45px" onclick="ddlchildclicked()" AutoPostBack="True">
                                            <asp:ListItem Selected="True">0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label style="text-align: right">بزرگسال</label>
                                        <asp:DropDownList class="form-control" ID="ddlAdult" runat="server" Width="100%" Height="45px" AppendDataBoundItems="False" AutoPostBack="True">
                                            <asp:ListItem>0</asp:ListItem>
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
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-6">
                            <div class="input-daterange" data-date-format="yyyy/M/dd">
                                <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                                    <label style="text-align: right">تاریخ</label>
                                    <%--<input type="text" id="datepicker">--%>
                                    <input class="form-control" type="text" id="datepicker" onchange="SetDate(this);" value="01/Oct/2017" autocomplete="off" onfocus="this.removeAttribute('readonly');" />
                                    <script type="text/javascript">
                                        function SetDate(object) {
                                            document.getElementById("<%= txtSelectedDate.ClientID %>").value = object.value;
                                        }
                                    </script>
                                    <asp:TextBox ID="txtSelectedDate" runat="server" style="display:none;"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label style="text-align: right; direction:rtl;">* قبل از انتخاب تاریخ به زمان اجرای تور توجه فرمایید</label>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row" style="direction:rtl; text-align:right;">
                        <div class="col-md-12">
                            <div id="ChildAges" class="form-group" runat="server" visible="true" dir="rtl" style="text-align: right">
                                <label ID="lblChildAges" runat="server" style="text-align: right; display:none;">سن خردسال</label>
                                <table dir="rtl">
                                    <tr>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlChild7" runat="server" Width="100%" style="display:none;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2px"></td>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlChild6" runat="server" Width="100%" style="display:none;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2px"></td>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlChild5" runat="server" Width="100%" style="display:none;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2px"></td>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlChild4" runat="server" Width="100%" style="display:none;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2px"></td>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlChild3" runat="server" Width="100%" style="display:none;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2px"></td>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlChild2" runat="server" Width="100%" style="display:none;">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 2px"></td>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlChild1" runat="server" Width="100%" style="display:none;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label style="text-align: right; font-weight: bold;" dir="rtl">مشخصات خریدار تور :</label>
                                <div class="row">
                                    <div class="col-md-6">
                                            <label style="text-align: right">نام خانوادگی</label>
                                            <asp:TextBox style="text-align:right" class="form-control" ID="txtFamily" runat="server" CausesValidation="True"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="لطفا نام خانوادگی خود را وارد کنید" ControlToValidate="txtFamily"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                            <label style="text-align: right">نام</label>
                                            <asp:TextBox style="text-align:right" class="form-control" ID="txtName" runat="server" CausesValidation="True"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="لطفا نام خود را وارد کنید" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                            <label style="text-align: right">ایمیل</label>
                                        <asp:TextBox style="text-align:right" class="form-control" ID="txtEmail" runat="server" CausesValidation="True"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="ایمیل صحیح نمی باشد"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-md-6">
                                            <label style="text-align: right">شماره تماس</label>
                                        <asp:TextBox style="text-align:right" class="form-control" ID="txtPhone" runat="server" CausesValidation="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="لطفا شماره تماس خود را وارد کنید" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPhone" Type="Integer"
                                                        Operator="DataTypeCheck" ErrorMessage="شماره تلفن صحیح نمی باشد" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                            <label style="text-align: right; font-weight: bold;" dir="rtl">توضیحات :</label>
                                        <asp:TextBox style="text-align:right" class="form-control" ID="txtDescription" runat="server" Height="100" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row" id="DivExtraServices" runat="server" visible="false">
                                    <div class="col-md-12">
                                        <input ID="txtServicesDB" runat="server" type="text"  style="display:none;"/>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtExtraQTY" runat="server" Text="0" style="display:none;"></asp:TextBox>
                                                <asp:Button ID="btnPriceCalc" runat="server" Text="calc" CausesValidation="False" style="display:none;"/>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <label style="text-align: right; font-weight: bold;" dir="rtl">سایر خدمات :</label>
                                        <table class="table table-striped" style="width:100%;">
                                            <thead class="thead-inverse" style="background-color:Black; color:White;">
                                                <tr>
                                                    <td style="width:40%; text-align:center;">خدمات</td>
                                                    <td style="width:25%; text-align:center;">قیمت تک</td>
                                                    <td style="width:10%; text-align:center;">تعداد</td>
                                                    <td style="width:25%; text-align:center;">قیمت کل</td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <%--<tr>
                                                    <td style="width:40%; text-align:center;"></td>
                                                    <td style="width:25%; text-align:center;" id="tdSingle1">25</td>
                                                    <td style="width:10%; text-align:center;">
                                                        <select id="txtQty1" onchange="ExtraServiceCalc('1');">
                                                            <option>0</option>
                                                            <option>1</option>
                                                            <option>2</option>
                                                            <option>3</option>
                                                            <option>4</option>
                                                            <option>5</option>
                                                            <option>6</option>
                                                            <option>7</option>
                                                            <option>8</option>
                                                            <option>9</option>
                                                            <option>10</option>
                                                        </select>
                                                    </td>
                                                    <td style="width:25%; text-align:center;" id="tdSum1">0</td>
                                                </tr>--%>
                                                <div  id="TbodyExtraServices" runat="server">
                                                
                                                </div>
                                                <tr>
                                                    <td style="text-align:right;" colspan="3">جمع کل : </td>
                                                    <td style="width:25%; text-align:center; background-color:Orange; color:White;">
                                                        <input  ID="ExtraServicestxtSumTotal" runat="server" type="text" value="0 $" style="text-align:center; color:White; border:none;" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                            <script type="text/javascript">
                                                function ExtraServiceCalc(Code) {
                                                    var Single1 = document.getElementById("tdSingle" + Code).innerHTML;
                                                    var Qty1 = document.getElementById("txtQty" + Code).value;
                                                    document.getElementById("tdSum" + Code).innerHTML = Single1 * Qty1;
                                                    SumAllExtraServices();
                                                };

                                                function CreateServicesDB(ServiceName, Object) {

                                                    var ServiceCount = Object.options[Object.selectedIndex].value;
                                                    var tmpSelectedServices = document.getElementById("<%= txtServicesDB.ClientID %>").value;
                                                    var Result = 'False'
                                                    var tmpDB = tmpSelectedServices.split("|");
                                                    var NewResult = '';
                                                    for (i = 0; i < tmpDB.length; i++) {
                                                        var SelectedService = tmpDB[i].split(",");
                                                        if (SelectedService[0] == ServiceName) {
                                                            tmpDB[i] = ServiceCount;
                                                            Result = 'True'
                                                            if (ServiceCount > 0) {
                                                                NewResult = NewResult + SelectedService[0] + ',' + ServiceCount + '|';
                                                            }
                                                        } else {
                                                            if (tmpDB[i].length > 0) {
                                                                NewResult = NewResult + tmpDB[i] + '|';
                                                            }
                                                        };
                                                    }

                                                    if (Result == 'False') {
                                                        document.getElementById("<%= txtServicesDB.ClientID %>").value = tmpSelectedServices + ServiceName + ',' + ServiceCount + '|';
                                                    } else {
                                                        document.getElementById("<%= txtServicesDB.ClientID %>").value = NewResult;
                                                    }
                                                }

                                                function SumAllExtraServices() {
                                                    var tmpExtraQTY = document.getElementById("<%= txtExtraQTY.ClientID %>").value;
                                                    var TotalSum = 0;

                                                    for (i = 0; i < parseInt(tmpExtraQTY); i++) {
                                                        TotalSum = parseInt(TotalSum) + parseInt(document.getElementById("tdSum" + (i)).innerHTML);
                                                    }

                                                    document.getElementById("<%= ExtraServicestxtSumTotal.ClientID %>").value = TotalSum + " $";
                                                    document.getElementById("<%= btnPriceCalc.ClientID %>").click();
                                                }
                                            </script>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table class="table table-striped" style="width:100%;">
                                        <thead class="thead-inverse" style="background-color:Black; color:White;">
                                            <tr>
                                                <th style="text-align:center;">مبلغ کل</th>
                                                <th></th>
                                                <th style="text-align:center;">تخفیف</th>
                                                <th></th>
                                                <th style="text-align:center;">کمیسیون آژانس</th>
                                                <th></th>
                                                <th style="text-align:center;">سایر خدمات</th>
                                                <th></th>
                                                <th style="text-align:center;">قابل پرداخت</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td style="text-align:center;"><asp:Label ID="lblSumTotalPrice" runat="server" Text="0"></asp:Label></td>
                                                <td>-</td>
                                                <td style="text-align:center;"><asp:Label ID="lblDiscount" runat="server" Text="0"></asp:Label></td>
                                                <td>-</td>
                                                <td style="text-align:center;"><asp:Label ID="lblAgencyCommission" runat="server" Text="0"></asp:Label></td>
                                                <td>+</td>
                                                <td style="text-align:center;"><asp:Label ID="lblExtraServices" runat="server" Text="0"></asp:Label></td>
                                                <td>=</td>
                                                <td style="text-align:center;"><asp:Label ID="lblTotalPriceDefaultCurrency" runat="server" Text="0"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12" style="text-align:right;">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnSendRequest" runat="server" Text="پرداخت"  style="display:none;"/>
                                    <span id="Span2" class="btn btn-default btn-primary" onclick="LoadFrom1(this)" style="width: 100%;"><span>اضافه به سبد : </span> <asp:Label ID="lblTotalPriceTooman" runat="server" Text="0"></asp:Label></span>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="gap"></div>
    </div>
            <div class="gap gap-small"></div>
</div>

<!-- /.modal -->

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

<div id="page4Modal" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content" >
            <div class="modal-header">
                <h4 class="modal-title">ثبت درخواست</h4>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="booking-item-dates-change">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblMessageBox" runat="server" Text="Message"></asp:Label>
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
    function LoadFrom1() {
        var tmpchilderrormsg = ""
        var tmpfalg = "false"
        var tmpchildno = document.getElementById("<%= ddlChild.ClientID %>").value
        

            if (document.getElementById("<%= ddlChild1.ClientID %>").value == "" && tmpchildno >=1) {
                document.getElementById("<%= ddlChild1.ClientID %>").style.borderColor = "red";
                tmpfalg = "true";
            } else {
                document.getElementById("<%= ddlChild1.ClientID %>").style.borderColor = "";
            }
            //----------------------------------

            if (document.getElementById("<%= ddlChild2.ClientID %>").value == "" && tmpchildno >= 2) {
                document.getElementById("<%= ddlChild2.ClientID %>").style.borderColor = "red";
                tmpfalg = "true";
            } else {
                document.getElementById("<%= ddlChild2.ClientID %>").style.borderColor = "";
            }
            //----------------------------------

            if (document.getElementById("<%= ddlChild3.ClientID %>").value == "" && tmpchildno >= 3) {
                document.getElementById("<%= ddlChild3.ClientID %>").style.borderColor = "red";
                tmpfalg = "true";
            } else {
                document.getElementById("<%= ddlChild3.ClientID %>").style.borderColor = "";
            }
            //----------------------------------

            if (document.getElementById("<%= ddlChild4.ClientID %>").value == "" && tmpchildno >= 4) {
                document.getElementById("<%= ddlChild4.ClientID %>").style.borderColor = "red";
                tmpfalg = "true";
            } else {
                document.getElementById("<%= ddlChild4.ClientID %>").style.borderColor = "";
            }
            //----------------------------------

            if (document.getElementById("<%= ddlChild5.ClientID %>").value == "" && tmpchildno >= 5) {
                document.getElementById("<%= ddlChild5.ClientID %>").style.borderColor = "red";
                tmpfalg = "true";
            } else {
                document.getElementById("<%= ddlChild5.ClientID %>").style.borderColor = "";
            }
            //----------------------------------

            if (document.getElementById("<%= ddlChild6.ClientID %>").value == "" && tmpchildno >= 6) {
                document.getElementById("<%= ddlChild6.ClientID %>").style.borderColor = "red";
                tmpfalg = "true";
            } else {
                document.getElementById("<%= ddlChild6.ClientID %>").style.borderColor = "";
            }
            //----------------------------------

            if (document.getElementById("<%= ddlChild7.ClientID %>").value == "" && tmpchildno >= 7) {
                document.getElementById("<%= ddlChild7.ClientID %>").style.borderColor = "red";
                tmpfalg = "true";
            } else {
                document.getElementById("<%= ddlChild7.ClientID %>").style.borderColor = "";
            }
            //----------------------------------


            document.getElementById("lblFinishingMessage").innerHTML = document.getElementById("<%= txtName.ClientID %>").value + " " + document.getElementById("<%= txtFamily.ClientID %>").value + " عزیز " + "<br />" + "با تشکر از حسن انتخاب شما" + "<br />" + "درخواست شما در حال ثبت می باشد" + "<br />" + "لطفا چند لحظه منتظر بمانید" + "<br />" + "با تشکر";

            var tmpfinalFlag = "false"
            if (document.getElementById("<%= txtName.ClientID %>").value == "") {
                document.getElementById("<%= txtName.ClientID %>").style.borderColor = "red";
                tmpfinalFlag = "true";
            } else {
                document.getElementById("<%= txtName.ClientID %>").style.borderColor = "";
            }

            if (document.getElementById("<%= txtFamily.ClientID %>").value == "") {
                document.getElementById("<%= txtFamily.ClientID %>").style.borderColor = "red";
                tmpfinalFlag = "true";
            } else {
                document.getElementById("<%= txtFamily.ClientID %>").style.borderColor = "";
            }

            if (document.getElementById("<%= txtPhone.ClientID %>").value == "") {
                document.getElementById("<%= txtPhone.ClientID %>").style.borderColor = "red";
                tmpfinalFlag = "true";
            } else {
                document.getElementById("<%= txtPhone.ClientID %>").style.borderColor = "";
            }

            if (document.getElementById("<%= txtEmail.ClientID %>").value == "") {
                document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = "red";
                tmpfinalFlag = "true";
            } else {
                document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = "";
            }

            //------------- Email Validation ----------------------------------------------
            var Emailvalidator = validateEmail(document.getElementById("<%= txtEmail.ClientID %>").value);
            if (Emailvalidator == false) {
                document.getElementById("<%= txtEmail.ClientID %>").style.borderColor = "red";
                tmpfinalFlag = "true";
            }


            //---------------------------------------


        if (tmpfalg == "true") {

            alert("لطفاً سن کودکان را وارد کنید");
        }
        else if (tmpfinalFlag == "true") {
            alert("لطفا کلیه مشخصات را بصورت صحیح وارد کنید");

        }
        else {
            document.getElementById("<%= btnSendRequest.ClientID %>").click();
        }
    }
</script>

<script type="text/javascript">

   $(".modal-wide").on("show.bs.modal", function () {
        var height = $(window).height() - 200;
    });
    // --------------------------------------------------

    function validateEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }

    // ------------------------------------------------------------
    function ddlchildclicked() {

        document.getElementById("<%= ddlchild1.ClientID %>").style.display = "none";
        document.getElementById("<%= ddlchild2.ClientID %>").style.display = "none";
        document.getElementById("<%= ddlchild3.ClientID %>").style.display = "none";
        document.getElementById("<%= ddlchild4.ClientID %>").style.display = "none";
        document.getElementById("<%= ddlchild5.ClientID %>").style.display = "none";
        document.getElementById("<%= ddlchild6.ClientID %>").style.display = "none";
        document.getElementById("<%= ddlchild7.ClientID %>").style.display = "none";
        document.getElementById("<%= lblChildAges.ClientID %>").style.display = "none";

        var tmpchild = document.getElementById("<%= ddlchild.ClientID %>").value;

        if (tmpchild >= 7) {
            document.getElementById("<%= ddlchild7.ClientID %>").style.display = ""
        } 
        //-----------------------------------------
        if (tmpchild >= 6) {
            document.getElementById("<%= ddlchild6.ClientID %>").style.display = ""
        }
        //-----------------------------------------
        if (tmpchild >= 5) {
            document.getElementById("<%= ddlchild5.ClientID %>").style.display = ""
        }
        //-----------------------------------------
        if (tmpchild >= 4) {
            document.getElementById("<%= ddlchild4.ClientID %>").style.display = ""
        }
        //----------------------------------------
        if (tmpchild >= 3) {
            document.getElementById("<%= ddlchild3.ClientID %>").style.display = ""
        }
        //-----------------------------------------
        if (tmpchild >= 2) {
            document.getElementById("<%= ddlchild2.ClientID %>").style.display = ""
        }
        //-----------------------------------------
        if (tmpchild >= 1) {
            document.getElementById("<%= ddlchild1.ClientID %>").style.display = ""
            document.getElementById("<%= lblChildAges.ClientID %>").style.display = ""
        };
        //-----------------------------------------
    };


  //-------------------------------------------------


    function openmessagebox(object) {
        $("#page3Modal").modal('show');
    }

    function teram() {
        $("#page3Modal").modal('show');
    }

</script>
 
    <script src="js/fotorama.js"></script>


</asp:Content>

