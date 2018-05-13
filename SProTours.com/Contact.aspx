<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Contact.aspx.vb" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
    .google-maps {
        position: relative;
        padding-bottom: 83%; 
        height: 0;
        overflow: hidden;
    }
    .google-maps iframe {
        position: absolute;
        top: 0;
        left: 0;
        width: 100% !important;
        height: 100% !important;
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main" role="main">
    <div id="content" class="content full">
        <div class="container">
            <div class="row" style="background-color: #FFFFFF">
                <div class="static-pages clearfix">
                    <div class="col-md-6">
                        <div class="google-maps">
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3009.138310268748!2d28.983607015802843!3d41.04410437929716!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab76dc434af87%3A0xbf3366387be23796!2zxLBuw7Zuw7wgTWFoYWxsZXNpLCBCYWJpbCBTay4gTm86NCwgMzQzNzMgxZ5pxZ9saS9Jc3RhbmJ1bCwgVHVya2V5!5e0!3m2!1sen!2sse!4v1504182664212" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class="col-md-6" dir="rtl">
                        <div class="row">
                            <div class="col-md-12" style="text-align: right">
                                <h4>تماس با ما</h4>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="txtMessage" runat="server" class="form-control input-lg" placeholder="پیام*" style="height: 167px" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="txtName" runat="server" class="form-control input-lg" placeholder="نام و نام خانوادگی*"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control input-lg" placeholder="*Email" onkeypress="return isEnglishOnly(event)" style="text-align:left; direction:ltr;"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtTelephone" runat="server" class="form-control input-lg" placeholder="تلفن"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12" style="text-align: left">
                                <asp:Button class="btn btn-primary btn-lg pull-right" ID="btnSend" runat="server" Text="ارسال" />
                            </div>
                        </div>

                        <div class="main-menu-wrapper" style="height: 15px; background-color: #FFFFFF;">
                        </div>


                        <div class="row" dir="ltr">
                            <div class="col-md-12">
                                <span style="color: #000000"><i class="fa fa-envelope-o"></i> <a  href="mailto:Hotel@Sprotours.com" style=" font-family: Helvetica, Arial, sans-serif; text-decoration: underline; font-size: small;color: #000000;">Hotel@Sprotours.com</a></span>
                                <br />
                                <span style="color: #000000"> <i class="fa fa-mobile-phone"></i> <a style="font-size: small;color: #000000;">+90 (212) 465 66 12</a></span>
                                <br />
                                <span style="color: #000000"><i class="fa fa-fax"></i> <a style="font-size: small;color: #000000;">+90 (212) 465 66 13</a></span>
                            </div>
                        </div>
                        <div class="row" dir="ltr">
                            <div class="col-md-12">
                                <span style="color: #000000"><i class="fa fa-map-marker"></i> <a style="font-size: small;color: #000000;">İnönü Mahallesi, Babil Sokak, No:4, Daire:1, Harbiye, Şişli, İstanbul, Türkiye</a></span>
                            </div>
                        </div>
                    </div>
                </div>


                <script src="js/jquery-2.0.0.min.js"></script>
                <!-- Jquery Library Call -->
                <script src="vendor/prettyphoto/js/prettyphoto.js"></script>
                <!-- PrettyPhoto Plugin -->
                <script src="vendor/flexslider/js/jquery.flexslider.js"></script>
                <!-- FlexSlider -->
                <script src="js/helper-plugins.js"></script>
                <!-- Plugins -->
                <script src="js/bootstrap.js"></script>
                <!-- UI -->
                <script src="vendor/iswiper/js/idangerous.swiper-2.1.min.js"></script>
                <!-- iSwiper Carousel -->
                <script src="js/init.js"></script>
                <!-- All Scripts -->
                <script src="vendor/rs-plugin/js/jquery.themepunch.plugins.min.js"></script>
                <script src="vendor/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>
                <script src="js/revolution-slider-init.js"></script>
                <!-- Revolutions Slider Intialization -->
                <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
                <script type="text/javascript">
                    var geocoder = new google.maps.Geocoder();
                    var address = "2500 CityWest Blvd. - Suite 300 Houston, Texas - 77042 USA"; //Add your address here, all on one line.
                    var latitude;
                    var longitude;
                    var color = "#4fc1e9"; //Set your tint color. Needs to be a hex value.

                    function getGeocode() {
                        geocoder.geocode({
                            'address': address
                        }, function (results, status) {
                            if (status == google.maps.GeocoderStatus.OK) {
                                latitude = results[0].geometry.location.lat();
                                longitude = results[0].geometry.location.lng();
                                initGoogleMap();
                            }
                        });
                    }

                    function initGoogleMap() {
                        var styles = [{
                            stylers: [{
                                saturation: -100
                            }]
                        }];

                        var options = {
                            mapTypeControlOptions: {
                                mapTypeIds: ['Styled']
                            },
                            center: new google.maps.LatLng(latitude, longitude),
                            zoom: 13,
                            scrollwheel: false,
                            navigationControl: false,
                            mapTypeControl: false,
                            zoomControl: true,
                            disableDefaultUI: true,
                            mapTypeId: 'Styled'
                        };
                        var div = document.getElementById('googleMap');
                        var map = new google.maps.Map(div, options);
                        marker = new google.maps.Marker({
                            map: map,
                            draggable: false,
                            animation: google.maps.Animation.DROP,
                            position: new google.maps.LatLng(latitude, longitude)
                        });
                        var styledMapType = new google.maps.StyledMapType(styles, {
                            name: 'Styled'
                        });
                        map.mapTypes.set('Styled', styledMapType);

                        var infowindow = new google.maps.InfoWindow({
                            content: "<div class='iwContent'>" + address + "</div>"
                        });
                        google.maps.event.addListener(marker, 'click', function () {
                            infowindow.open(map, marker);
                        });


                        bounds = new google.maps.LatLngBounds(
                            new google.maps.LatLng(-40.9858526, -28.8304705),
                            new google.maps.LatLng(40.9858526, 28.8304705));

                        rect = new google.maps.Rectangle({
                            bounds: bounds,
                            fillColor: color,
                            fillOpacity: 0.2,
                            strokeWeight: 0,
                            map: map
                        });
                    }
                    google.maps.event.addDomListener(window, 'load', getGeocode);
                </script>
            </div>
        </div>
    </div>
</div>
</asp:Content>

