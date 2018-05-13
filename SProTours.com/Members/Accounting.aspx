<%@ Page Title="" Language="VB" MasterPageFile="~/Members/MasterPage.master" AutoEventWireup="false" CodeFile="Accounting.aspx.vb" Inherits="Members_Accounting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-12">
                <div class="MyMasterBox">
                    <div class="row">
                        <div class="col-md-6" style="text-align:left;">
                            <span class="btn btn-primary" onclick="printdiv('DivSummery');"> چاپ </span>
                        </div>
                        <div class="col-md-6" style="text-align:right; direction:rtl;">
                            <label>گردش حساب</label> <asp:Label ID="lblAccounting" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="MyBox5050">
                        <div id="DivSummery" style="width:100%; max-height:200px; overflow: auto; direction:rtl;">
                            <asp:GridView ID="gvAccounting" runat="server" CellPadding="4" CellSpacing="1" Font-Bold="True" Font-Names="Times New Roman" Font-Size="12pt" Font-Underline="False" ForeColor="#333333" Style="text-align: center" Width="100%" HeaderText="Assigned" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">

                                <RowStyle BackColor="#d3d3d3" Height="40px" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#9d9d9d" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#555c66" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#555c66" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <Columns>

                                </Columns>
                                <EditRowStyle BackColor="#9d9d9d" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div style="text-align:left; direction:ltr">
                        <div style="text-align:left; direction:rtl; background-color:White; height:auto; width:310px; padding:10px;" >
                            <table>
                                <tr>
                                    <td>بدهکار (تومان) :</td>
                                    <td style="width:10px;"></td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="lblBedehkar" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>بستانکار (تومان) :</td>
                                    <td style="width:10px;"></td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="lblBestankar" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>مانده (تومان) :</td>
                                    <td style="width:10px;"></td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="lblJameKol" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbltotalJariTitle" runat="server" Text="--"></asp:Label></td>
                                    <td style="width:10px;"></td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="lblJameKoleJari" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>قابل پرداخت (تومان) :</td>
                                    <td style="width:10px;"></td>
                                    <td style="text-align:center;">
                                        <asp:Label style="background-color:#ed8323; color:White;" ID="lblGhabelePardakht" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

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

