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
                alert(`Registered Successfully : ${data.Id}!`)
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
                if(data)
                    alert(`Login Successfully`)
                else 
                    alert(`Login failed.! Try again`)
            },
            contentType: "application/json",
            dataType: 'json'
        });
    });
});
