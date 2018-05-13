<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Packages.aspx.vb" Inherits="Packages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
            width: 169px;
        }
        .style25
        {
            width: 169px;
            height: 26px;
        }
        .style35
        {
            width: 45px;
        }
        .style36
        {
            width: 45px;
            height: 26px;
        }
        .style37
        {
            width: 195px;
        }
        .style38
        {
            width: 299px;
        }
        .style40
        {
            text-align: center;
            width: 170px;
        }
        .style41
        {
            width: 170px;
        }
        .style42
        {
            width: 170px;
            height: 26px;
        }
        
        
        thead   {display: table-header-group;   }
 
        tfoot   {display: table-footer-group;   }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main" role="main">
    <div id="content" class="content full">
        <div class="container">
            <div class="MyMasterBox">    
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <div class="main-header-search">
                                <div class="form-group form-group-icon-left form-group-focus">
                                    <i class="fa fa-search input-icon" style="color:Black; cursor: pointer;" onclick="Search();"></i>
                                    <script type="text/javascript">
                                        function Search() {
                                            document.getElementById("<%= btnSearch.ClientID %>").click();
                                        }

                                        function handle(e) {
                                            if (e.keyCode === 13) {
                                                e.preventDefault(); // Ensure it is only this code that rusn

                                                document.getElementById("<%= btnSearch.ClientID %>").click();
                                            }
                                        }
                                    </script>
                                    <asp:Button ID="btnSearch" runat="server" Text="جستجو" class="btn btn-primary"  style="display:none;"/>
                                    <asp:TextBox ID="txtSearch" onkeypress="handle(event)" class="form-control" placeholder="Search Hotel Name, Location" runat="server" style="text-align: left; background-color: #FFFFFF; border-color:Orange; color: #000000;" dir="ltr"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlSearch_Filter" runat="server"  style="text-align: left; background-color: #FFFFFF; border-color:Orange; color: #9d9b9c; margin-top:5px; border-radius: 5px;" dir="ltr" AutoPostBack="true">
                                <asp:ListItem>مرتب سازی بر اساس ستاره</asp:ListItem>
                                <asp:ListItem>مرتب سازی بر اساس منطقه</asp:ListItem>
                                <asp:ListItem> مرتب سازی بر اساس قیمت</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlSearch_PackageType" runat="server"  style="text-align: left; background-color: #FFFFFF; border-color:Orange; color: #9d9b9c; margin-top:5px; border-radius: 5px;" dir="ltr" AutoPostBack="true">
                                <asp:ListItem>نرخ های عادی</asp:ListItem>
                                <asp:ListItem>نرخ های آفر</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlSearch_City" runat="server"  style="text-align: left; background-color: #FFFFFF; border-color:Orange; color: #9d9b9c; margin-top:5px; border-radius: 5px;" dir="ltr" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlSearch_Country" runat="server"  style="text-align: left; background-color: #FFFFFF; border-color:Orange; color: #9d9b9c; margin-top:5px; border-radius: 5px;" dir="ltr" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <hr />

            <div class="MyMasterBox" style="direction:ltr; text-align:left;">
                <div class="row">
                    <div class="col-md-2">
                        <asp:Button class="btn btn-primary" ID="btnPrintToPDF" runat="server" Text="چاپ" Width="100%" />
                        <span class="btn btn-primary" onclick="printdiv('DivPackages');" style="width:100%; display:none;">چاپ</span>
                    </div>
                    <div class="col-md-10" style="direction:ltr; text-align:right;">
                        <asp:Label  style="margin-top:15px; height:34; padding:6px 12px; font-size:14px; vertical-align:middle; text-align: right; background-color: #FFFFFF; border-style:solid; border-width:1px; border-color:Orange; color: #9d9b9c; border-radius: 5px; width:auto;" dir="ltr" ID="lblHotelsQTY" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <hr style="border-color:White; border-width:1px; border-style:groove;" />
                <div class="row">
                    <div id="DivPackages" class="col-md-12" style="padding-top:20px;">
                        <div id="tblPackages" runat="server"></div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>

    

    <script type="text/javascript">

        function printdiv(printpage) {
            try {
                var headstr = "<html><head><title></title></head><body>";
                var footstr = "</body>";
                var newstr = document.all.item(printpage).innerHTML;
                var oldstr = document.body.innerHTML;
                document.body.innerHTML = headstr + newstr + footstr;
                window.print();
                document.body.innerHTML = oldstr;
                return false;
            }
            catch (e) {
                alert(e);
            }

        }

        function PrintDivContent(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint =
                window.open('', '', 'letf=0,top=0,toolbar=0,sta­tus=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
        }
    </script>
        
</asp:Content>

