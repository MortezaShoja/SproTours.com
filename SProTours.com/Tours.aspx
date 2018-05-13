<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Tours.aspx.vb" Inherits="Tours" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="main" role="main">
    <div id="content" class="content full">
   		<div class="container">
          <div class="row">
              <!--<div class="col-md-12 main-menu-wrapper">-->
              <div class="col-md-9">
                <ul ID="ToursHeader" class="nav nav-pills sort-source" data-sort-id="portfolio" data-option-key="filter" runat="server">
                    <!--Generate From database-->
                </ul>
             </div>
             <div class="col-md-3" style="text-align: right">
                <%--<div class="main-header-search">
                    <div class="form-group form-group-icon-left form-group-focus">
                        <i class="fa fa-search input-icon" style="color:Black"></i>
                            <input class="form-control" type="text" placeholder="جستجو" style="text-align: right; background-color: #FFFFFF; border-color:Orange; color: #000000;" dir="rtl">
                    </div>
                </div>--%>
             </div>
             <!--<div class=" dima-navbar-wrap mobile-nav">
               <ul class="nav nav-pills sort-source" data-sort-id="portfolio" data-option-key="filter" style="text-align: center">
                    <li data-option-value="*" class="active" style="width: 100%"><a href="#">TÜMÜ</a></li>
                    <li data-option-value=".2" style="width: 100%; background-color: #808080;"><a href="#">M.I.C.E.</a></li>
                    <li data-option-value=".3" style="width: 100%"><a href="#">M.I.C.E. PLUS</a></li>
                    <li data-option-value=".4" style="width: 100%"><a href="#">FUAR</a></li>
                    <li data-option-value=".1" style="width: 100%"><a href="#">KURUMSAL SEYAHAT</a></li>
                </ul>
             </div>-->
          </div>
          <div class="row">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                <ul id="SubCategory" class="isotope-grid sort-destination" data-sort-id="portfolio" runat="server">

                </ul>
              </ContentTemplate>
         </asp:UpdatePanel>
         	</div>
      	</div>
    </div>
  </div>

<!--*-->

<div id="page1Modal" class="modal fade" style="text-align: right">
    <div class="modal-dialog">
        <div class="modal-content" >
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <label>جهت اطلاع از قیمت و تاریخ حرکت این تور فرم زیر را تکمیل نمایید</label>
            </div>
            <div class="modal-body">
                  
                    <!--<h4>Title</h4>-->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="booking-item-dates-change mb40">
                                <span dir="rtl">نام پکیج تور : </span><asp:Label ID="lbltourname" runat="server" Text="Label"></asp:Label>
                           </div>
                        </div>
                    </div>

                    <label id="lbltourname2" runat="server" style="text-align: right; font-weight: bold;" dir="rtl"></label>
                    <div class="booking-item-dates-change mb40">
                    <label style="text-align: right; font-weight: bold;" dir="rtl">تاریخ تقریبی سفر خود را وارد نمایید :</label>
                    <div class="row">
                <div class="input-daterange" data-date-format="yyyy/M/dd">
                    <div class="col-md-6">
                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                            <label style="text-align: right">از تاریخ</label>
                            <input id="start" class="form-control" name="start" type="text" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-calendar input-icon input-icon-highlight"></i>
                            <label style="text-align: right">تا تاریخ</label>
                            <input id="end" class="form-control" name="end" type="text"/>
                        </div>
                    </div>
                </div>
                </div>
                    <label style="text-align: right; font-weight: bold;" dir="rtl">تعداد نفرات :</label>
                    <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
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
                    </div>

                    
                    <div class="col-md-2">

                        <div class="form-group">
                            <label style="text-align: right">خردسال</label>
                            <asp:DropDownList class="form-control" ID="ddlChild" runat="server" 
                                Width="100%" onclick="ddlchildclicked()">
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

                    <div class="col-md-8">

                        <div id="ChildAges" class="form-group" runat="server" visible="true" dir="rtl" style="text-align: right">
                            <label ID="lblChildAges" runat="server" style="text-align: right; display:none;">خردسال</label>
                                        <table dir="rtl">
                                        <tr>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlChild7" runat="server" 
                                                Width="100%" style="display:none;">
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
                                            <asp:DropDownList class="form-control" ID="ddlChild6" runat="server" 
                                                Width="100%" style="display:none;">
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
                                            <asp:DropDownList class="form-control" ID="ddlChild5" runat="server" 
                                                Width="100%" style="display:none;">
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
                                            <asp:DropDownList class="form-control" ID="ddlChild4" runat="server" 
                                                Width="100%" style="display:none;">
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
                                            <asp:DropDownList class="form-control" ID="ddlChild3" runat="server" 
                                                Width="100%" style="display:none;">
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
                                            <asp:DropDownList class="form-control" ID="ddlChild2" runat="server" 
                                                Width="100%" style="display:none;">
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
                                            <asp:DropDownList class="form-control" ID="ddlChild1" runat="server" 
                                                Width="100%" style="display:none;">
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
                    </div>

                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label style="text-align: right; font-weight: bold;" dir="rtl">مشخصات رزرو کننده :</label>
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
                            </div>
                        </div>
                    </div>
                    </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">انصراف</button>
                        <span id="Span3" class="btn btn-default btn-primary" onclick="doSendRequestPostback(this)">ارسال درخواست</span>
                        <asp:Button style="display:none;" class="btn btn-primary" ID="btnSendRequest" runat="server" Text="ارسال درخواست" CausesValidation="True" />
            </div>

        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>

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


<script type="text/javascript">
    function LoadFrom1(tourname) {
        document.getElementById("<%= lbltourname.ClientID %>").innerText = tourname;
        $("#page1Modal").modal('show');
    };


    function validateEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    };

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

    function doSendRequestPostback(object) {
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
                $("#page1Modal").modal('hide');
                $("#page3Modal").modal('show');
                document.getElementById("<%= btnSendRequest.ClientID %>").click();
            }

    };

    function peygham() {

        //$("#page1Modal").modal('show');
        //document.getElementById('page2Modal').showModal();
        alert("قیمت تور مورد انتخاب شما در اسرع وقت به ایمیل شماارسال خواهد شد");
        window.location = "Tours.aspx";
    }

</script>



<script src="js/core/jquery-2.1.1.min.js"></script>
<script src="js/bootstrap.js"></script> <!-- UI -->
 <script src="vendor/prettyphoto/js/prettyphoto.js"></script> <!-- PrettyPhoto Plugin --> 

 <script src="js/helper-plugins.js"></script> <!-- Plugins --> 
 <script src="vendor/iswiper/js/idangerous.swiper-2.1.min.js"></script> <!-- iSwiper Carousel --> 
<script src="js/init.js"></script> <!-- All Scripts -->  




    <script src="js/slimmenu.js"></script>
    <script src="js/nicescroll.js"></script>
    <script src="js/typeahead.js"></script>
    <script src="js/customtypeahead.js"></script>

            <script src="js/bootstrap-datepicker.js"></script>
        <script src="js/bootstrap-timepicker.js"></script>

</asp:Content>


