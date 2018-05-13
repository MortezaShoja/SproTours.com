<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HotelInvoice.aspx.vb" Inherits="HotelInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="booking-item-details">
            <div class="booking-item-header">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-5" >
                            </div>
                            <div class="col-md-3" >
                                <div class="form-group form-group-lg form-group-icon-left"><i class="fa fa-envelope input-icon-inline"></i>
                                    <input type="text" class="form-control" placeholder="yourname@company.com" />
                                </div>
                            </div>
                            <div class="col-md-4" >
                                <span id="Span3" class="btn btn-default btn-primary btn-lg" style="width: auto;height:43px;"><span style="font-size:10pt;"><i class="fa fa-envelope"></i> Email</span></span>
                                <span id="Span2" class="btn btn-default btn-primary btn-lg" style="width: auto;height:43px;"><span style="font-size:10pt;"><i class="fa fa-file-pdf-o"></i> PDF</span></span>
                                <span id="Span1" class="btn btn-default btn-primary btn-lg" style="width: auto;height:43px;"><span style="font-size:10pt;" onclick="printDiv('divInvoice');"><i class="fa fa-print"></i> Print</span></span>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="divInvoice" class="row">
                    <div class="col-md-12">
                        <div class="booking-item-dates-change mb20">
                            <asp:Label ID="lblRequestInvoice" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
</asp:Content>

