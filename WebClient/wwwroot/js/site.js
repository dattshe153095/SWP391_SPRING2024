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
function searchByUsername() {
    var username = $("#searchUsername").val();

    $.ajax({
        type: "GET",
        url: "/Wallet/SearchByUsername",
        data: { username: username },
        success: function (result) {
            updateTable(result);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function updateTable(result) {
    var tableBody = $("#walletTable");
    tableBody.empty(); // Xóa tất cả các dòng hiện tại trong bảng
    console.log(result);
    for (var i = 0; i < result.length; i++) {
        var account = resultt[i];
        var row = "<tr id='row_" + account.id + "'>" +
            "<td>" + account.id + "</td>" +
            "<td id='name' data-name='" + account.name + "'>" +
            account.name + "</td>" +
            "<td>" + wallet.balance + "</td>" +
            "<td>" + account.update_at + "</td>" +
            "<td><a asp-controller='Wallet' asp-action='Transaction' asp-route-userId='" + account.id + "'>Detail</a></td>" +
            "</tr>";

        tableBody.append(row); // Thêm các dòng mới từ kết quả tìm kiếm
    }
}

