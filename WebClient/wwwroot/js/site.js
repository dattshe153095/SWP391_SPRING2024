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
        url: "/Home/RefreshCaptcha", // Thay thế bằng đường dẫn của action cập nhật captcha
        success: function (result) {
            // Cập nhật ảnh captcha mới
            $("#captchaImage").attr("src", "data:image/png;base64," + result);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function sendEmail() {
    var email = $("#email").val();

    $.ajax({
        type: "POST", // hoặc "GET" tùy thuộc vào loại yêu cầu của bạn
        url: "/Home/SendEmailForgot", // Thay thế bằng đường dẫn của action bạn muốn gọi
        data: { email: email },
        success: function (result) {
            // Xử lý kết quả từ action nếu cần
            console.log(result);
            alert("Email Have Send Check Email To Get Code");
        },
        error: function (error) {
            // Xử lý lỗi nếu có
            console.log(error);
        }
    });
 
}
$(document).ready(function () {
    // Bắt sự kiện khi người dùng nhập vào input
    $('#username, #password, #captcha').on('input', function () {
        var inputId = $(this).attr('id');
        var errorId = inputId + 'Error';
        var inputValue = $(this).val();

        // Kiểm tra nếu giá trị là rỗng, hiển thị thông báo
        if (!inputValue) {
            $('#' + errorId).text('Vui lòng nhập thông tin.').show();
        } else {
            $('#' + errorId).hide(); // Ẩn thông báo nếu có giá trị
        }
    });

    // Bắt sự kiện khi nút đăng nhập được nhấn
    $('form').submit(function (e) {
        e.preventDefault(); // Ngăn chặn form tự động submit

        // Ẩn tất cả các thông báo lỗi
        $('.a-alert-content').hide();

        // Lấy giá trị từ các input
        var username = $('#username').val();
        var password = $('#password').val();
        var captcha = $('#captcha').val();

        // Kiểm tra xem có thiếu input không và hiển thị thông báo
        if (!username) {
            $('#usernameError').text('Vui lòng nhập tên người dùng.').show();
        }
        if (!password) {
            $('#passwordError').text('Vui lòng nhập mật khẩu.').show();
        }
        if (!captcha) {
            $('#captchaError').text('Vui lòng nhập captcha.').show();
        }

        // Tiếp tục xử lý đăng nhập nếu không có lỗi
        // ...

    });