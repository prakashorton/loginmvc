$(document).ready(function () {
    $("#btnRegister").click(function () {
        const registerData = {
            "name": $("#name").val(),
            "email": $("#email").val(),
            "username": $("#username").val(),
            "password": $("#password").val()
        };

        $.ajax({
            type: 'POST',
            url: 'RegisterUser',
            data: JSON.stringify(registerData),
            success: function (data) {
                console.log("Login Successfull");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    });

    $("#btnLogin").click(function () {
        const userName = $("#Lusername").val(),
            password = $("#Lpassword").val();

        var loginData = {
            "userName": userName,
            "password": password
        };

        $.ajax({
            type: 'POST',
            url: 'CheckLogin',
            data: JSON.stringify(loginData),
            success: function (data) {
                console.log("Login Successfull");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    });
});