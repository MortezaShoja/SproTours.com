<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CreateAccount.aspx.vb" Inherits="CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="main" role="main">
    <div id="content" class="content full">
        <div class="container">
            <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
                rel="stylesheet" type="text/css" />
            <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
                type="text/javascript"></script>
            <div class="tab-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div id="DivMemberInfo">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="MyMasterBox">
                                        <label style="margin-right:10px; text-align:right; direction:rtl;">فرم درخواست عضویت</label>
                                        <p style="margin-right:10px; text-align:right; direction:rtl; color:Red;">قابل توجه همکاران محترم،</p>
                                        <p style="margin-right:10px; text-align:right; direction:rtl; color:Red;">* فرم درخواست عضویت فقط ویژه ثبت اطلاعات مربوط به مدیریت آژانس / شرکت می باشد. * جهت سایر پرسنل و کانترهای محترم از قیمت "ایجاد حساب کاربری پرسنل" اقدام فرمایید.</p>
                                        <div class="MyBox">
                                            <div class="row">
                                                <div class="col-md-6" style="height:100%;">
                                                    <div class="row" style="padding-right:20px; padding-left:10px;">
                                                        <div class="form-group">
                                                            <label>شماره / آی دی تلگرام :</label>
                                                            <asp:TextBox ID="MemberInfo_TelegramID" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3" style="height:100%;">
                                                    <div class="row" style="padding-right:20px; padding-left:10px;">
                                                        <div id="DivAgencyType" style="display:;">
                                                            <div class="form-group">
                                                                <label>نوع مجوز فعالیت :</label>
                                                                <asp:DropDownList ID="MemberInfo_ddlAgencyType" runat="server" class="form-control" style="direction:rtl;">
                                                                    <asp:ListItem Selected="True"></asp:ListItem>
                                                                    <asp:ListItem>بند الف</asp:ListItem>
                                                                    <asp:ListItem>بند ب</asp:ListItem>
                                                                    <asp:ListItem>بند پ</asp:ListItem>
                                                                    <asp:ListItem>بند الف و ب</asp:ListItem>
                                                                    <asp:ListItem>بند الف و پ</asp:ListItem>
                                                                    <asp:ListItem>بند ب و پ</asp:ListItem>
                                                                    <asp:ListItem>بند الف و ب و پ</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3" style="height:100%;">
                                                    <div class="row" style="padding-right:20px; padding-left:10px;">
                                                        <div class="form-group" style="margin:0px;">
                                                            <label>نوع حساب کاربری :</label>
                                                            <asp:DropDownList ID="MemberInfo_ddlUserType" runat="server" onchange="CoAgencySelector();" class="form-control" style="direction:rtl;">
                                                                <asp:ListItem Selected="True"></asp:ListItem>
                                                                <asp:ListItem>آژانس خدمات مسافرتی - B2C</asp:ListItem>
                                                                <asp:ListItem>شرکت خدمات مسافرتی - B2B</asp:ListItem>
                                                                <asp:ListItem>آژانس - شرکت خدمات مسافرتی</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6" style="height:100%;">
                                                    <div class="row" style="padding-right:20px; padding-left:10px;">
                                                        <div class="form-group">
                                                            <label>وب سایت :</label>
                                                            <asp:TextBox ID="MemberInfo_WebSite" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled" onkeypress="return isEnglishOnly(event)"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>استان - فارسی :</label>
                                                            <asp:TextBox ID="MemberInfo_Region" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled" onkeypress="return isPersianOnly(event)"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>شهر - فارسی :</label>
                                                            <asp:TextBox ID="MemberInfo_City" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled" onkeypress="return isPersianOnly(event)"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>کد پستی :</label>
                                                            <asp:TextBox ID="MemberInfo_PostalCode" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>آدرس - فارسی :</label>
                                                            <asp:TextBox ID="MemberInfo_FullAddress" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled" TextMode="MultiLine" Height="182px" onkeypress="return isPersianOnly(event)"></asp:TextBox>
                                                        </div>

                                                        <div class="form-group">
                                                            <asp:Button ID="MemberInfo_btnUsers" class="mygray" runat="server" Text="ایجاد حساب کاربری پرسنل" Width="100%" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-6" style="height:100%;">
                                                    <asp:Label ID="MemberInfo_ID" runat="server" Text="" Visible="false"></asp:Label>
                                                    <div class="row" style="padding-right:20px; padding-left:10px;">
                                            
                                                        <div id="lblCoType" class="form-group" style="display:none;">
                                                            <label id="Label2">نوع فعالیت شرکت :</label>
                                                            <asp:TextBox ID="MemberInfo_CoType" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>

                                                        <div id="DivCoAgencyType" style="display:;">
                                                            <div class="form-group">
                                                                <label id="lblAgancyName">نام آژانس/شرکت مسافرتی - لاتین :</label>
                                                                <asp:TextBox ID="MemberInfo_CoAgancyName" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled" onkeypress="return isEnglishOnly(event)"></asp:TextBox>
                                                            </div>

                                                            <div class="form-group">
                                                                <label id="lblAgancyNamePersian">نام آژانس/شرکت مسافرتی - فارسی :</label>
                                                                <asp:TextBox ID="MemberInfo_CoAgancyNamePersian" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled" onkeypress="return isPersianOnly(event)"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label id="lblAgancyManagerName">نام و نام خانوادگی مدیر آژانس/شرکت - لاتین :</label>
                                                            <asp:TextBox ID="MemberInfo_FullName" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled" onkeypress="return isEnglishOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="padding-right:5px;">
                                                        <div class="col-md-9" style="height:100%;">
                                                            <label>تلفن ثابت :</label>
                                                            <asp:TextBox ID="MemberInfo_LandPhone" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3" style="height:100%;">
                                                            <label>کد شهر :</label>
                                                            <asp:TextBox ID="MemberInfo_LandPhone_Code" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="padding-right:20px; padding-left:10px; margin-top:10px;">
                                                        <div class="form-group">
                                                            <label>موبایل :</label>
                                                            <asp:TextBox ID="MemberInfo_Mobile" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>ایمیل :</label>
                                                            <asp:TextBox ID="MemberInfo_Email" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled" onkeypress="return isEnglishOnly(event)"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>رمز عبور :</label>
                                                            <asp:TextBox ID="MemberInfo_Password" runat="server" style="background-color:White;" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                                                                      
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row" style="padding-right:20px; padding-left:10px;">
                                                <div>
                                                    <asp:Button ID="MemberInfo_BtnRegNew" class="myorange" runat="server" Text="ثبت اطلاعات" Width="100%" style="margin-top:5px; margin-left:0px; margin-right:0px;" />
                                                    <asp:Label ID="lblRegisterMessage" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                   </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="pageModalUsers" class="modal fade" style="text-align: right;">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <button type="button" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" style="z-index:999; position:absolute;left:20px;top:10px;">&times;</button>
                                    <asp:Label ID="Users_lblUserCount" runat="server" Text="(0)"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-body">
                            <div class="MyBox" style="direction:rtl;">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <div style="display:none;">
                                            <asp:TextBox ID="Users_txtRow" runat="server"></asp:TextBox>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12" style="margin-top:10px;">
                                                <div class="form-group">
                                                    <div style="width:100%; max-height:200px; overflow: auto;">
                                                        <asp:GridView ID="Users_gv" runat="server" CellPadding="4" CellSpacing="1" Font-Bold="True" Font-Names="Times New Roman" Font-Size="12pt" Font-Underline="False" ForeColor="#333333" Style="text-align: center" Width="100%" HeaderText="Assigned" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            <RowStyle BackColor="#d3d3d3" Height="40px" />
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#9d9d9d" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#555c66" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#555c66" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:ButtonField ButtonType="Button" CommandName="btnView" Text="نمایش" />
                                                            </Columns>
                                                            <EditRowStyle BackColor="#9d9d9d" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" runat="server" id="Users_MSG_Div" visible="true">
                                            <hr />

                                            <div class="row">
                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <div class="form-group">
                                                        <label>بخش</label>
                                                        <asp:DropDownList class="form-control" ID="Users_MSG_ddlDepartment" runat="server">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>رزرواسیون</asp:ListItem>
                                                            <asp:ListItem>اپراسیون</asp:ListItem>
                                                            <asp:ListItem>حسابداری</asp:ListItem>
                                                            <asp:ListItem>کانتر فروش</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                        
                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <div class="form-group">
                                                        <label>نام و نام خانوادگی</label>
                                                        <asp:TextBox class="form-control" ID="Users_MSG_FullName" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>                        
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6" style="margin-top:10px; direction:ltr;">
                                                    <div class="form-group">
                                                        <label>شماره / آی دی تلگرام</label>
                                                        <asp:TextBox class="form-control" ID="Users_MSG_TelegramID" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <div class="form-group">
                                                        <label>موبایل</label>
                                                        <asp:TextBox class="form-control" ID="Users_MSG_Mobile" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <div class="form-group">
                                                        <label>رمز عبور</label>
                                                        <asp:TextBox class="form-control" ID="Users_MSG_Password" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <div class="form-group">
                                                        <label>ایمیل</label>
                                                        <asp:TextBox class="form-control" ID="Users_MSG_Email" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Label ID="Users_MSG_Message" runat="server" Text=""></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-2">
                                                <asp:Image ID="imgloaderFinalStep" Width="100%" runat="server" ImageUrl="~/images/Loader/loading2.gif" />
                                            </div>
                                            <div class="col-md-10">
                                                <label id="lblFinishingUser">سیستم در حال بررسی درخواست شما می باشد</label>
                                                <label id="Label1">لطفاً چند لحظه صبر کنید</label>
                                            </div>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                    
                        </div>
                        <div class="modal-footer">
                            <div class="row">
                                <div class="col-md-2">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:Button class="btn btn-primary" ID="Users_btnAddEdit" Width="100%" runat="server" Text="ثبت" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-8">
     
                                </div>
                                <div class="col-md-2">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:Button class="btn btn-primary" ID="Users_btnNew" Width="100%" runat="server" Text="جدید" Visible="false" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-10">
                                </div>
                            </div>
                        </div>
                    </div><!-- /.modal-content -->
                </div><!-- /.modal-dialog -->
            </div>
   
            <script type="text/javascript">

                function CoAgencySelector() {
                    document.getElementById('lblCoType').style.display = 'none';
                    document.getElementById('lblAgancyManagerName').innerText = 'نام و نام خانوادگی مدیر آژانس :';
                    document.getElementById('lblAgancyName').innerText = 'نام آژانس مسافرتی - لاتین :';
                    document.getElementById('lblAgancyNamePersian').innerText = 'نام آژانس مسافرتی - فارسی :';

//                    var si = document.getElementById("<%= MemberInfo_ddlUserType.ClientID %>").selectedIndex;
//                    switch (si) {
//                        case 0:
//                            document.getElementById('DivCoAgencyType').style.display = '';
//                            document.getElementById('DivAgencyType').style.display = '';
//                            document.getElementById('lblCoType').style.display = 'none';
//                            document.getElementById('lblAgancyManagerName').innerText = 'نام و نام خانوادگی مدیر آژانس :';
//                            document.getElementById('lblAgancyName').innerText = 'نام آژانس مسافرتی - لاتین :';
//                            document.getElementById('lblAgancyNamePersian').innerText = 'نام آژانس مسافرتی - فارسی :';
//                            break;
//                        case 1:
//                            document.getElementById('DivCoAgencyType').style.display = '';
//                            document.getElementById('DivAgencyType').style.display = 'none';
//                            document.getElementById('lblCoType').style.display = '';
//                            document.getElementById('lblAgancyManagerName').innerText = 'نام و نام خانوادگی مدیرعامل :';
//                            document.getElementById('lblAgancyName').innerText = 'نام آژانس مسافرتی - لاتین :';
//                            document.getElementById('lblAgancyNamePersian').innerText = 'نام آژانس مسافرتی - فارسی :';
//                            document.getElementById("<%= MemberInfo_ddlAgencyType.ClientID %>").value = '';
//                            break;
//                        case 2:
//                            document.getElementById('DivCoAgencyType').style.display = 'none';
//                            document.getElementById('DivAgencyType').style.display = 'none';
//                            document.getElementById('lblCoType').style.display = 'none';
//                            document.getElementById('lblAgancyManagerName').innerText = 'نام و نام خانوادگی :';
//                            document.getElementById("<%= MemberInfo_CoAgancyName.ClientID %>").value = '';
//                            document.getElementById("<%= MemberInfo_ddlAgencyType.ClientID %>").value = '';
//                            break;
//                        default:
//                            document.getElementById('DivCoAgencyType').style.display = '';
//                            document.getElementById('DivAgencyType').style.display = '';
//                            document.getElementById('lblCoType').style.display = 'none';
//                            document.getElementById('lblAgancyManagerName').innerText = 'نام و نام خانوادگی مدیر آژانس :';
//                            document.getElementById('lblAgancyName').innerText = 'نام آژانس مسافرتی';
//                    }
                }

            </script>
        </div>
    </div>
</div>
</asp:Content>

