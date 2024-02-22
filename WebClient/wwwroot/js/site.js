// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Gán sự kiện click cho nút refresh captcha
    $("#refreshCaptcha").on("click", function () {
        refreshCaptchaImage();
    });
});

function refreshCaptchaImage() {
    $.ajax({
        
        type: "POST",
        url: "/Home/RefreshCaptchaLogin", // Thay thế bằng đường dẫn của action cập nhật captcha
        success: function (result) {
            // Cập nhật ảnh captcha mới
            $("#captchaImage").attr("src", "data:image/png;base64," + result);
            $('#captcha').val('');
        },
        error: function (error) {
            console.log(error);
        }
    });
}
