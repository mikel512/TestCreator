// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Login validation
$("#loginButton").click(function (e) {
    if ($("#emailTextBox").val() == "") {
        $("#emailSpan").text("Enter Email");
    }
    else {
        $("#emailSpan").text("");
    }
    if ($("#passwordTextBox").val() == "") {
        $("#passwordSpan").text("Enter Password");
    }
    else {
        $("#passwordSpan").text("");
    }

    var data = {};
    data.Email = $("#emailTextBox").val();
    data.Password = $(#)
    $.ajax({
        type:   "POST",
        url:    
    })
})
