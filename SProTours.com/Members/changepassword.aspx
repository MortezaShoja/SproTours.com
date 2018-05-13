<%@ Page Title="" Language="VB" MasterPageFile="~/Members/MasterPage.master" AutoEventWireup="false" CodeFile="changepassword.aspx.vb" Inherits="changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-4 col-md-offset-1">
            <h4>تغییر رمز عبور</h4>
                <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon"></i>
                    <label>رمز عبور فعلی</label>
                    <asp:TextBox class="form-control" ID="txtCurrentPassword" runat="server" 
                        TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon"></i>
                    <label>رمز عبور جدید</label>
                    <asp:TextBox class="form-control" ID="txtNewPassword" runat="server" 
                        TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon"></i>
                    <label>تکرار رمز عبور جدید</label>
                    <asp:TextBox class="form-control" ID="txtNewPaswordAgain" runat="server" 
                        TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon input-icon-show"></i>
                    <asp:Label ID="lblMessages" runat="server" ForeColor="#CC0000" style="text-align:right; direction:rtl;"></asp:Label>
                </div>
                <hr />
                <asp:Button class="btn btn-primary" ID="btnChangePassword" runat="server" Text="تغییر رمز عبور" />
        </div>
    </div>
</asp:Content>

