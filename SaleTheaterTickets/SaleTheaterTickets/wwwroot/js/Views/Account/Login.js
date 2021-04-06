$(document).ready(function () {
    $('#showPassword').on('click', function () {

        var passwordField = $('#password');
        var passwordFielType = passwordField.attr('type');

        if (passwordFielType == 'password') {
            passwordField.attr('type', 'text');
            $(this).val('Esconder');
        }
        else {
            passwordField.attr('type', 'password');
            $(this).val('Mostrar');
        }
    });
});