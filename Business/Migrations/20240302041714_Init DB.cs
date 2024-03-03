using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DepositResponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deposit_id = table.Column<int>(type: "int", nullable: false),
                    type_transaction = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositResponses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wallet_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    trans_code = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IntermediateOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    is_pay = table.Column<bool>(type: "bit", nullable: false),
                    sell_user = table.Column<int>(type: "int", nullable: false),
                    buy_user = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    payment_amount = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    link_product = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntermediateOrders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IntermediateProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    fee_create = table.Column<int>(type: "int", nullable: false),
                    fee_type = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    contact = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    hidden_content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    is_public = table.Column<bool>(type: "bit", nullable: false),
                    fee = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntermediateProducts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desctiption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Wallets_Accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Withdrawals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wallet_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    trans_code = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    bank_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    bank_user = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    bank_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdrawals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Withdrawals_Wallets_wallet_id",
                        column: x => x.wallet_id,
                        principalTable: "Wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalResponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    withdrawal_id = table.Column<int>(type: "int", nullable: false),
                    type_transaction = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalResponses", x => x.id);
                    table.ForeignKey(
                        name: "FK_WithdrawalResponses_Withdrawals_withdrawal_id",
                        column: x => x.withdrawal_id,
                        principalTable: "Withdrawals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "create_at", "description", "email", "is_delete", "name", "password", "phone", "role_id", "update_at", "username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3893), null, "waterball208@gmail.com", false, "Hoàng Minh Nguyệt", "minhnguyet", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3893), "minhnguyet" },
                    { 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3896), null, "waterball208@gmail.com", false, "Nguyễn Thùy Dương", "thuyduong", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3896), "thuyduong" },
                    { 3, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3937), null, "waterball208@gmail.com", false, "Lê Thạc Hoành", "thachoanh", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3937), "thachoanh" },
                    { 4, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3939), null, "waterball208@gmail.com", false, "Nguyễn Quang Vị", "quangvi", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3940), "quangvi" },
                    { 5, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3941), null, "waterball208@gmail.com", false, "Nguyễn Mạnh Cường", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3942), "manhcuong" },
                    { 6, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3943), null, "waterball208@gmail.com", false, "Nguyễn Việt Hân", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3944), "viethan" },
                    { 7, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3945), null, "waterball208@gmail.com", false, "Nguyễn Trung Hiếu", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3946), "trunghieu" },
                    { 8, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3947), null, "waterball208@gmail.com", false, "Nguyễn Văn Tuấn", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3948), "vantuan" },
                    { 9, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3950), null, "waterball208@gmail.com", false, "Ngô Gia Thiện", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3950), "giathien" },
                    { 10, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3952), null, "waterball208@gmail.com", false, "Phan Thế Anh", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3952), "theanh" },
                    { 11, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3954), null, "waterball208@gmail.com", false, "Nguyễn Ngọc Hoàng", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3954), "ngochoang" },
                    { 12, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3956), null, "waterball208@gmail.com", false, "Nguyễn Quang Lộc", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3956), "quangloc" },
                    { 13, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3958), null, "waterball208@gmail.com", false, "Nguyễn Hải Đan", "pass123", "0987654321", 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3958), "haidan123" },
                    { 14, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3960), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3960), "admin" }
                });

            migrationBuilder.InsertData(
                table: "DepositResponses",
                columns: new[] { "id", "create_at", "create_by", "deposit_id", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4114), 14, 1, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4114), 14 },
                    { 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4117), 14, 2, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4118), 14 },
                    { 3, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4120), 14, 3, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4120), 14 },
                    { 4, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4122), 14, 4, "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4122), 14 },
                    { 5, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4124), 14, 5, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4124), 14 },
                    { 6, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4126), 14, 6, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4126), 14 },
                    { 7, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4128), 14, 7, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4128), 14 },
                    { 8, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4130), 14, 8, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4130), 14 },
                    { 9, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4132), 14, 9, "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4133), 14 },
                    { 10, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4135), 14, 10, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4135), 14 },
                    { 11, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4137), 14, 11, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4137), 14 },
                    { 12, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4172), 14, 12, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4172), 14 },
                    { 13, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4174), 14, 13, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4175), 14 },
                    { 14, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4176), 14, 14, "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4177), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "description", "is_delete", "state", "status", "trans_code", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4015), 1, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "1DY75F3K26T", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4016), 1, 1 },
                    { 2, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4018), 2, "nạp tiền", false, "đang xử lí", "đang xử lí", "2DI83A9M0P", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4019), 2, 2 },
                    { 3, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4020), 3, "nạp tiền", false, "thành công", "xác nhận thành công", "3DW29E6G3T", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4021), 3, 3 },
                    { 4, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4022), 4, "nạp tiền", false, "thất bại", "xác nhận thất bại", "4DX64S7S9Y", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4024), 4, 4 },
                    { 5, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4025), 5, "nạp tiền", false, "thành công", "hoàn thành", "5DB17K9Y8X", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4026), 5, 5 },
                    { 6, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4028), 6, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "6DP96C3I5V", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4029), 6, 6 },
                    { 7, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4030), 7, "nạp tiền", false, "đang xử lí", "đang xử lí", "7DD50M1A7Q", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4031), 7, 7 },
                    { 8, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4032), 8, "nạp tiền", false, "thành công", "xác nhận thành công", "8DR05R0J6X", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4033), 8, 8 },
                    { 9, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4034), 9, "nạp tiền", false, "thất bại", "xác nhận thất bại", "9DG63J9F6H", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4035), 9, 9 },
                    { 10, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4036), 10, "nạp tiền", false, "thành công", "hoàn thành", "10DL81T2G8Z", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4037), 10, 10 },
                    { 11, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4038), 11, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "11DF85R8K6S", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4039), 11, 11 },
                    { 12, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4040), 12, "nạp tiền", false, "đang xử lí", "đang xử lí", "12DM14S4P4V", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4041), 12, 12 },
                    { 13, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4042), 13, "nạp tiền", false, "thành công", "xác nhận thành công", "13DP76J5J1R", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4043), 13, 13 },
                    { 14, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4044), 14, "nạp tiền", false, "thất bại", "xác nhận thất bại", "14DS57C4B8K", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4045), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "IntermediateOrders",
                columns: new[] { "id", "buy_user", "create_at", "is_delete", "is_pay", "link_product", "payment_amount", "product_id", "sell_user", "state", "status", "update_at" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4295), false, false, "#", 1000, 1, 1, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4295) },
                    { 2, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4297), false, false, "#", 505, 2, 2, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4298) },
                    { 3, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4299), false, false, "#", 1500, 3, 3, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4299) },
                    { 4, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4300), false, false, "#", 2005, 4, 4, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4300) },
                    { 5, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4301), false, false, "#", 500, 5, 5, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4302) },
                    { 6, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4302), false, false, "#", 1005, 6, 6, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4303) },
                    { 7, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4304), false, false, "#", 1500, 7, 7, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4304) },
                    { 8, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4305), false, false, "#", 2005, 8, 8, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4305) },
                    { 9, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4306), false, false, "#", 500, 9, 9, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4306) },
                    { 10, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4307), false, false, "#", 1005, 10, 10, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4307) },
                    { 11, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4308), false, false, "#", 1500, 11, 11, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4309) },
                    { 12, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4309), false, false, "#", 2005, 12, 12, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4310) },
                    { 13, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4312), false, false, "#", 500, 13, 13, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4313) },
                    { 14, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4313), false, false, "#", 1005, 14, 14, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4314) },
                    { 15, null, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4315), false, false, "#", 1000, 15, 10, "đang xử lí", "mới tạo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4315) }
                });

            migrationBuilder.InsertData(
                table: "IntermediateProducts",
                columns: new[] { "id", "contact", "create_at", "create_by", "description", "fee", "fee_create", "fee_type", "hidden_content", "is_delete", "is_public", "name", "price", "state", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4245), 1, "tài khoản Office ", 5, 100, true, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Office", 1000, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4245), 1 },
                    { 2, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4248), 2, "tài khoản GBT ", 5, 100, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản GBT", 500, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4248), 1 },
                    { 3, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4251), 3, "tài khoản Facebook ", 5, 100, true, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Facebook", 1500, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4251), 1 },
                    { 4, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4255), 4, "tài khoản Game ", 5, 100, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Game", 2000, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4255), 1 },
                    { 5, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4258), 5, "tài khoản Unity ", 5, 100, true, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Unity", 500, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4258), 1 },
                    { 6, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4260), 6, "tài khoản Microsoft", 5, 100, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Microsoft", 1000, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4260), 1 },
                    { 7, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4262), 7, "tài khoản Spine ", 5, 100, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Spine", 1500, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4263), 1 },
                    { 8, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4264), 8, "tài khoản Adobephotoshop ", 5, 100, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Adobephotoshop", 2000, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4265), 1 },
                    { 9, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4267), 9, "tài khoản Ai ", 5, 100, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Ai", 500, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4267), 1 },
                    { 10, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4269), 10, "tài khoản Gmail ", 5, 100, false, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Gmail", 1000, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4270), 1 },
                    { 11, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4272), 11, "tài khoản Git ", 5, 100, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Git", 1500, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4272), 1 },
                    { 12, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4274), 12, "tài khoản Netflix ", 5, 100, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Netflix", 2000, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4274), 1 },
                    { 13, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4276), 13, "tài khoản Youtube ", 5, 100, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Vip Youtube", 500, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4276), 1 },
                    { 14, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4279), 14, "tài khoản Duolingo ", 5, 100, false, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Duolingo", 1000, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4279), 1 },
                    { 15, "facebook, mess,zalo", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4281), 10, "tài khoản Coursera ", 10, 100, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Coursera", 1000, "đang xử lí", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4281), 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "desctiption" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 20000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3982), 1 },
                    { 2, 2, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3984), 2 },
                    { 3, 3, 20000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3985), 3 },
                    { 4, 4, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3986), 4 },
                    { 5, 5, 20000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3987), 5 },
                    { 6, 6, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3988), 6 },
                    { 7, 7, 20000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3989), 7 },
                    { 8, 8, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3990), 8 },
                    { 9, 9, 20000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3991), 9 },
                    { 10, 10, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3992), 10 },
                    { 11, 11, 20000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3993), 11 },
                    { 12, 12, 10000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3994), 12 },
                    { 13, 13, 20000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3995), 13 },
                    { 14, 14, 1000000, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(3996), 14 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "is_delete", "state", "status", "trans_code", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 5000, "TP Bank", "789654312", "Hoàng Minh Nguyệt", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4062), 1, false, "đang xử lí", "đang chờ xác nhận", "1W0U5V1I0", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4064), 1, 1 },
                    { 2, 1000, "TP Bank", "789654312", "Nguyễn Thùy Dương", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4066), 2, false, "đang xử lí", "đang xử lí", "2W4F4Y9E7", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4067), 2, 2 },
                    { 3, 5000, "TP Bank", "789654312", "Lê Thạc Hoành", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4068), 3, false, "thành công", "xác nhận thành công", "3W3C1J8P1", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4069), 3, 3 },
                    { 4, 1000, "TP Bank", "789654312", "Nguyễn Quang Vị", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4071), 4, false, "thất bại", "xác nhận thất bại", "4W6O2Q2R4", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4071), 4, 4 },
                    { 5, 5000, "TP Bank", "789654312", "Nguyễn Mạnh Cường", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4073), 5, false, "thành công", "hoàn thành", "5W8O2W1A3", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4073), 5, 5 },
                    { 6, 1000, "TP Bank", "789654312", "Nguyễn Việt Hân", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4077), 6, false, "đang xử lí", "đang chờ xác nhận", "6W2Z1O6B1", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4078), 6, 6 },
                    { 7, 5000, "TP Bank", "789654312", "Nguyễn Trung Hiếu", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4079), 7, false, "đang xử lí", "đang xử lí", "7W3T0N3S0", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4080), 7, 7 },
                    { 8, 10000, "TP Bank", "789654312", "Nguyễn Văn Tuấn", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4082), 8, false, "thành công", "xác nhận thành công", "8W4I2D8D0", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4082), 8, 8 },
                    { 9, 5000, "TP Bank", "789654312", "Ngô Gia Thiện", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4084), 9, false, "thất bại", "xác nhận thất bại", "9W6H6F3O2", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4084), 9, 9 },
                    { 10, 10000, "TP Bank", "789654312", "Phan Thế Anh", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4086), 10, false, "thành công", "hoàn thành", "10W1B4L3R5", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4086), 10, 10 },
                    { 11, 5000, "TP Bank", "789654312", "Nguyễn Ngọc Hoàng", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4088), 11, false, "đang xử lí", "đang xác nhận", "11W8I7T8V7", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4088), 11, 11 },
                    { 12, 10000, "TP Bank", "789654312", "Nguyễn Quang Lộc", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4091), 12, false, "đang xử lí", "đang xử lí", "12W6M7E2D3", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4092), 12, 12 },
                    { 13, 5000, "TP Bank", "789654312", "Nguyễn Hải Đan", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4093), 13, false, "thành công", "xác nhận thành công", "13W4Q0L0L6", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4094), 13, 13 },
                    { 14, 10000, "TP Bank", "789654312", "Bank Admin", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4095), 14, false, "thất bại", "xác nhận thất bại", "14W9C9M5F4", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4096), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "WithdrawalResponses",
                columns: new[] { "id", "create_at", "create_by", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by", "withdrawal_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4197), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4197), 14, 1 },
                    { 2, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4199), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4200), 14, 2 },
                    { 3, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4202), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4202), 14, 3 },
                    { 4, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4204), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4204), 14, 4 },
                    { 5, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4206), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4206), 14, 5 },
                    { 6, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4208), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4208), 14, 6 },
                    { 7, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4210), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4211), 14, 7 },
                    { 8, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4212), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4213), 14, 8 },
                    { 9, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4214), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4215), 14, 9 },
                    { 10, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4216), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4217), 14, 10 },
                    { 11, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4219), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4220), 14, 11 },
                    { 12, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4223), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4223), 14, 12 },
                    { 13, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4225), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4225), 14, 13 },
                    { 14, new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4227), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 2, 11, 17, 13, 965, DateTimeKind.Local).AddTicks(4227), 14, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_account_id",
                table: "Wallets",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalResponses_withdrawal_id",
                table: "WithdrawalResponses",
                column: "withdrawal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_wallet_id",
                table: "Withdrawals",
                column: "wallet_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositResponses");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "IntermediateOrders");

            migrationBuilder.DropTable(
                name: "IntermediateProducts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "WithdrawalResponses");

            migrationBuilder.DropTable(
                name: "Withdrawals");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
