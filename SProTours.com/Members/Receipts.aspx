<%@ Page Title="" Language="VB" MasterPageFile="~/Members/MasterPage.master" AutoEventWireup="false" CodeFile="Receipts.aspx.vb" Inherits="Members_Receipts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="row">
            <div class="col-md-12">
                <div class="MyMasterBox">
                    <label>ثبت فیش واریزی</label>
                    <div class="MyBox5050">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>تصویر فیش واریزی</label>
                                    <asp:FileUpload ID="uploadReceipt" runat="server" style="width:100%; height:34px; border-width:1px; border-style:solid; border-color:Orange;"/>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon"></i>
                                    <label>مبلغ واریز (تومان)</label>
                                    <asp:TextBox class="form-control" ID="Receipt_Amount_New" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon"></i>
                                    <label>شماره پیگیری</label>
                                    <asp:TextBox class="form-control" ID="Receipt_TarackingNo_New" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9">
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnSaveReceipt" runat="server" style="width:100%;" class="btn btn-primary" Text="ثبت فیش" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <div class="MyMasterBox">
                            <div class="row">
                                <div class="col-md-9">
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlFilter" class="form-control" runat="server" AutoPostBack="True">
                                        <asp:ListItem>واریزی های جدید</asp:ListItem>
                                        <asp:ListItem>واریزی های تایید شده</asp:ListItem>
                                        <asp:ListItem>واریزی های تایید نشده</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                    
                            <div class="MyBox5050">
                                <div style="width:100%; max-height:200px; overflow: auto;">
                                    <asp:GridView ID="gvReceips" runat="server" CellPadding="4" CellSpacing="1" Font-Bold="True" Font-Names="Times New Roman" Font-Size="12pt" Font-Underline="False" ForeColor="#333333" Style="text-align: center" Width="100%" HeaderText="Assigned" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
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
                                <div style="text-align:left; direction:ltr; background-color:White; height:auto; width:auto; padding:10px;" >
                                    <asp:Label ID="lblSumPrice" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="DivReceiptDetails" runat="server" visible="false">
                    <div class="col-md-12">
                        <div class="MyMasterBox">
                            <div class="row">
                                <div class="col-md-12">
                                    <label>جزئیات فیش واریزی</label>
                                    <asp:Label ID="Receipt_ID" runat="server" Text="" Visible="false"></asp:Label>
                                    <div class="row MyBox" style="margin-top:5px;">
                                        <div class="col-md-6">
                                            <asp:Image ID="imgReceipt" runat="server" style="width:100%; height:100%;" />
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-12" style="margin-top:10px;">
                                                    <label>شماره حساب/کارت واریز کننده</label>
                                                    <asp:TextBox ID="Receipt_AccountNo" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="margin-top:10px;">
                                                    <label>نام و نام خانوادگی صاحب حساب/کارت</label>
                                                    <asp:TextBox ID="Receipt_AccountOwner" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <label>زمان واریز</label>
                                                    <asp:TextBox ID="Receipt_PayTime" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <label>تاریخ واریز</label>
                                                    <asp:TextBox ID="Receipt_PayDate" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <label>مبلغ واریزی (تومان)</label>
                                                    <asp:TextBox ID="Receipt_Amount" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6" style="margin-top:10px;">
                                                    <label>شماره پیگیری فیش واریزی</label>
                                                    <asp:TextBox ID="Receipt_TarackingNo" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12" style="margin-top:10px;">
                                                <label>توضیحات واحد حسابداری</label>
                                                <asp:TextBox ID="Receipt_Descriptions" runat="server" class="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        
        <script src="../js/core/jquery-2.1.1.min.js"></script>
        <script src="../js/fotorama.js"></script>


</asp:Content>

