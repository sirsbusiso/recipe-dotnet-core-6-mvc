// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Account pages scripts
$(document).ready(function () {
    $("#registerForm").validate({
        errorClass: "error fail-alert",
        validClass: "valid success-alert",
        rules: {
            Password: {
                minlength: 5
            },
            ConfirmPassword: {
                equalTo: '#Password'
            }
        }
    });
});


$('input').focus(function () {
    $("#loginError").text("");
})

$(document).ready(function () {
    $("#loginForm").validate({
        errorClass: "error fail-alert",
        validClass: "valid success-alert"
    });

});


//Recipe pages scripts

$(document).ready(function () {
    $("#display").show();
    $("#add").hide();
    CKEDITOR.replace('#Instructions');
});

$(document).ready(function () {
    $("#recipeForm").validate({
        errorClass: "error fail-alert",
        validClass: "valid success-alert"
    });
});

$(document).ready(function () {
    $("#viewDetails").click(function () {

        var url = $("#detailsForm").attr("action");
        var formData = $("#detailsForm").serialize();
        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                alert(data);
            }
        });

    });

});

$(document).ready(function () {
    $("#showAddDiv").click(function () {
        $("#display").hide();
        $("#add").show();

    });
});
$(document).ready(function () {
    $(".backToList").click(function () {
        {
            $("#display").show();
            $("#add").hide();

        }
    });
})

