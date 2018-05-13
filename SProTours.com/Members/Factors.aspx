<%@ Page Title="" Language="VB" MasterPageFile="~/Members/MasterPage.master" AutoEventWireup="false" CodeFile="Factors.aspx.vb" Inherits="Members_Factors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="row" id="DivUnderprocessOrders" runat="server" visible="true">
            <div class="col-md-12">
                <div class="MyMasterBox">
                    <label>فاکتورهای صادر شده</label>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="MyBox5050">
                                <div style="width:100%; max-height:200px; overflow: auto;">
                                    <asp:GridView ID="gvFactors" runat="server" CellPadding="4" CellSpacing="1" Font-Bold="True" Font-Names="Times New Roman" Font-Size="12pt" Font-Underline="False" ForeColor="#333333" Style="text-align: center" Width="100%" HeaderText="Assigned" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
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
                                <div style="text-align:left; direction:ltr; background-color:#e27513; color:White; height:auto; width:auto; padding:10px;" >
                                    <asp:Label ID="lblSumPrice" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div id="pageModalFactor" class="modal fade" style="text-align: right;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal-dialog-large">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" style="z-index:999; position:absolute;left:20px;top:10px;">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblFactorNo" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="MyBox">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblFactorDetails" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal" aria-hidden="true">بستن</button>
                            </div>

                        </div><!-- /.modal-content -->
                    </div><!-- /.modal-dialog -->
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <script src="../js/core/jquery-2.1.1.min.js"></script>
        <script src="../js/fotorama.js"></script>
</asp:Content>

