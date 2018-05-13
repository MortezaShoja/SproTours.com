<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>www.Turkorder.com</title>

    <meta content="text/html;charset=utf-8" http-equiv="Content-Type" />
    <meta name="keywords" content="Template, html, premium, themeforest" />
    <meta name="description" content="Traveler - Premium template for travel companies" />
    <meta name="author" content="Tsoy" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- GOOGLE FONTS -->
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,100,500,700' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600' rel='stylesheet' type='text/css' />
    <!-- /GOOGLE FONTS -->
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/font-awesome.css" />
    <link rel="stylesheet" href="css/icomoon.css" />
    <link rel="stylesheet" href="css/styles.css" />
    <link rel="stylesheet" href="css/mystyles.css" />
    <script src="js/modernizr.js"></script>

    <link rel="stylesheet" href="css/switcher.css" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/bright-turquoise.css" title="bright-turquoise" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/turkish-rose.css" title="turkish-rose" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/salem.css" title="salem" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/hippie-blue.css" title="hippie-blue" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/mandy.css" title="mandy" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/green-smoke.css" title="green-smoke" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/horizon.css" title="horizon" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/cerise.css" title="cerise" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/brick-red.css" title="brick-red" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/de-york.css" title="de-york" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/shamrock.css" title="shamrock" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/studio.css" title="studio" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/leather.css" title="leather" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/denim.css" title="denim" media="all" />
    <link rel="alternate stylesheet" type="text/css" href="css/schemes/scarlet.css" title="scarlet" media="all" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Logo.png" Width="239px" Height="103px" />
    </div>

    <div class="gap"></div>

    <div class="container">
        <div class="row" data-gutter="60">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <h4>ورود به حساب کاربری</h4>
                    <div class="form-group form-group-icon-left"><i class="fa fa-user input-icon input-icon-show"></i>
                        <label>ایمیل</label>
                        <asp:TextBox class="form-control" placeholder="e.g. myname@gmail.com" ID="txtLoginUserName" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon input-icon-show"></i>
                        <label>کلمه عبور</label>
                        <asp:TextBox class="form-control" placeholder="my secret password" 
                            ID="txtLoginPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon input-icon-show"></i>
                        <asp:Label ID="lblLoginMessages" runat="server" ForeColor="#CC0000" style="text-align:right; direction:rtl;"></asp:Label>
                    </div>
                    <asp:Button class="btn btn-primary" ID="btnLogin" runat="server" Text="ورود" />
            </div>
            <div class="col-md-4">
                <h4>بازیابی رمز عبور</h4>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group form-group-icon-left"><i class="fa fa-user input-icon input-icon-show"></i>
                            <label>ایمیل</label>
                            <asp:TextBox class="form-control" placeholder="e.g. myname@gmail.com" ID="txtRequestPassword" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group form-group-icon-left"><i class="fa fa-lock input-icon input-icon-show"></i>
                            <asp:Label ID="lblRecoverPassword" runat="server" ForeColor="#CC0000" style="text-align:right; direction:rtl;"></asp:Label>
                        </div>
                        <asp:Button class="btn btn-primary" ID="btnRecoverPassword" runat="server" Text="بازیابی" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            </div>
            </div>
    </form>


</body>
</html>
