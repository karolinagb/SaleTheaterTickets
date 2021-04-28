$(document).ready(function () {
    $('#showPassword').on('click', function () {

        var passwordField = $('#password');
        var passwordFieldType = passwordField.attr('type');

        if (passwordFieldType == 'password') {
            passwordField.attr('type', 'text');
            $(this).val('Esconder');
        }
        else {
            passwordField.attr('type', 'password');
            $(this).val('Mostrar');
        }
    });
    $('#showConfirmPassword').on('click', function () {

        var passwordField = $('#confirmPassword');
        var passwordFieldType = passwordField.attr('type');

        if (passwordFieldType == 'password') {
            passwordField.attr('type', 'text');
            $(this).val('Esconder');
        }
        else {
            passwordField.attr('type', 'password');
            $(this).val('Mostrar');
        }
    });
});