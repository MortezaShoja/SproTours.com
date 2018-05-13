$(document).ready(function () {


    $('#login-trigger').click(function () {
        $('#register-content').hide();
        $(this).next('#login-content').slideToggle();
        $(this).toggleClass('active');
        event.stopPropagation();
    })


    $('#register-trigger').click(function () {
        $('#login-content').hide();
        $(this).next('#register-content').slideToggle();
        $(this).toggleClass('active');
        event.stopPropagation();
    })

});

