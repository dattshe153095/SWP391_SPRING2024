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
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IntermediateOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    fee_type = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    contact = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    hidden_content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    is_public = table.Column<bool>(type: "bit", nullable: false),
                    fee = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    buy_by = table.Column<int>(type: "int", nullable: true),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntermediateOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_IntermediateOrders_Accounts_buy_by",
                        column: x => x.buy_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntermediateOrders_Accounts_create_by",
                        column: x => x.create_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntermediateOrders_Accounts_update_by",
                        column: x => x.update_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wallets_Accounts_update_by",
                        column: x => x.update_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Deposits_Accounts_create_by",
                        column: x => x.create_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deposits_Accounts_update_by",
                        column: x => x.update_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deposits_Wallets_wallet_id",
                        column: x => x.wallet_id,
                        principalTable: "Wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Withdrawals_Accounts_create_by",
                        column: x => x.create_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Withdrawals_Accounts_update_by",
                        column: x => x.update_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Withdrawals_Wallets_wallet_id",
                        column: x => x.wallet_id,
                        principalTable: "Wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_DepositResponses_Accounts_create_by",
                        column: x => x.create_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepositResponses_Accounts_update_by",
                        column: x => x.update_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepositResponses_Deposits_deposit_id",
                        column: x => x.deposit_id,
                        principalTable: "Deposits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_WithdrawalResponses_Accounts_create_by",
                        column: x => x.create_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WithdrawalResponses_Accounts_update_by",
                        column: x => x.update_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WithdrawalResponses_Withdrawals_withdrawal_id",
                        column: x => x.withdrawal_id,
                        principalTable: "Withdrawals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "desctiption" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "desctiption" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "create_at", "description", "email", "is_delete", "name", "password", "phone", "role_id", "update_at", "username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3151), null, "waterball208@gmail.com", false, "Hoàng Minh Nguyệt", "minhnguyet", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3151), "minhnguyet" },
                    { 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3154), null, "waterball208@gmail.com", false, "Nguyễn Thùy Dương", "thuyduong", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3154), "thuyduong" },
                    { 3, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3156), null, "waterball208@gmail.com", false, "Lê Thạc Hoành", "thachoanh", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3156), "thachoanh" },
                    { 4, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3158), null, "waterball208@gmail.com", false, "Nguyễn Quang Vị", "quangvi", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3158), "quangvi" },
                    { 5, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3160), null, "waterball208@gmail.com", false, "Nguyễn Mạnh Cường", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3160), "manhcuong" },
                    { 6, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3162), null, "waterball208@gmail.com", false, "Nguyễn Việt Hân", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3162), "viethan" },
                    { 7, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3164), null, "waterball208@gmail.com", false, "Nguyễn Trung Hiếu", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3164), "trunghieu" },
                    { 8, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3166), null, "waterball208@gmail.com", false, "Nguyễn Văn Tuấn", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3166), "vantuan" },
                    { 9, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3167), null, "waterball208@gmail.com", false, "Ngô Gia Thiện", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3168), "giathien" },
                    { 10, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3169), null, "waterball208@gmail.com", false, "Phan Thế Anh", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3170), "theanh" },
                    { 11, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3171), null, "waterball208@gmail.com", false, "Nguyễn Ngọc Hoàng", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3172), "ngochoang" },
                    { 12, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3173), null, "waterball208@gmail.com", false, "Nguyễn Quang Lộc", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3174), "quangloc" },
                    { 13, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3175), null, "waterball208@gmail.com", false, "Nguyễn Hải Đan", "pass123", "0987654321", 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3176), "haidan123" },
                    { 14, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3178), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3179), "admin" }
                });

            migrationBuilder.InsertData(
                table: "IntermediateOrders",
                columns: new[] { "id", "buy_by", "contact", "create_at", "create_by", "description", "fee", "fee_type", "hidden_content", "is_delete", "is_public", "name", "price", "state", "status", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3405), 1, "tài khoản Office ", 5, true, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Office", 1000, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3406), 1 },
                    { 2, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3408), 2, "tài khoản GBT ", 5, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản GBT", 500, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3409), 1 },
                    { 3, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3411), 3, "tài khoản Facebook ", 5, true, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Facebook", 1500, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3411), 1 },
                    { 4, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3414), 4, "tài khoản Game ", 5, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Game", 2000, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3415), 1 },
                    { 5, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3417), 5, "tài khoản Unity ", 5, true, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Unity", 500, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3417), 1 },
                    { 6, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3419), 6, "tài khoản Microsoft", 5, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Microsoft", 1000, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3419), 1 },
                    { 7, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3421), 7, "tài khoản Spine ", 5, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Spine", 1500, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3422), 1 },
                    { 8, 1, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3425), 8, "tài khoản Adobephotoshop ", 5, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Adobephotoshop", 2000, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3425), 1 },
                    { 9, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3427), 9, "tài khoản Ai ", 5, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Ai", 500, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3428), 1 },
                    { 10, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3429), 10, "tài khoản Gmail ", 5, false, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Gmail", 1000, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3430), 1 },
                    { 11, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3432), 11, "tài khoản Git ", 5, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Git", 1500, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3432), 1 },
                    { 12, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3438), 12, "tài khoản Netflix ", 5, false, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Netflix", 2000, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3438), 1 },
                    { 13, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3440), 13, "tài khoản Youtube ", 5, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Vip Youtube", 500, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3440), 1 },
                    { 14, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3442), 14, "tài khoản Duolingo ", 5, false, "tài khoản: account, mật khẩu: password", false, false, "Tài Khoản Duolingo", 1000, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3442), 1 },
                    { 15, null, "facebook, mess,zalo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3444), 10, "tài khoản Coursera ", 10, true, "tài khoản: account, mật khẩu: password", false, true, "Tài Khoản Coursera", 1000, "đang xử lí", "mới tạo", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3445), 1 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 20000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3198), 1 },
                    { 2, 2, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3200), 2 },
                    { 3, 3, 20000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3201), 3 },
                    { 4, 4, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3203), 4 },
                    { 5, 5, 20000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3204), 5 },
                    { 6, 6, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3204), 6 },
                    { 7, 7, 20000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3205), 7 },
                    { 8, 8, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3206), 8 },
                    { 9, 9, 20000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3207), 9 },
                    { 10, 10, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3208), 10 },
                    { 11, 11, 20000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3209), 11 },
                    { 12, 12, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3210), 12 },
                    { 13, 13, 20000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3211), 13 },
                    { 14, 14, 1000000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3212), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "description", "is_delete", "state", "status", "trans_code", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3228), 1, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "1DY75F3K26T", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3228), 1, 1 },
                    { 2, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3231), 2, "nạp tiền", false, "đang xử lí", "đang xử lí", "2DI83A9M0P", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3231), 2, 2 },
                    { 3, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3233), 3, "nạp tiền", false, "thành công", "xác nhận thành công", "3DW29E6G3T", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3233), 3, 3 },
                    { 4, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3235), 4, "nạp tiền", false, "thất bại", "xác nhận thất bại", "4DX64S7S9Y", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3236), 4, 4 },
                    { 5, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3237), 5, "nạp tiền", false, "thành công", "hoàn thành", "5DB17K9Y8X", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3238), 5, 5 },
                    { 6, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3239), 6, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "6DP96C3I5V", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3240), 6, 6 },
                    { 7, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3241), 7, "nạp tiền", false, "đang xử lí", "đang xử lí", "7DD50M1A7Q", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3242), 7, 7 },
                    { 8, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3243), 8, "nạp tiền", false, "thành công", "xác nhận thành công", "8DR05R0J6X", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3244), 8, 8 },
                    { 9, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3245), 9, "nạp tiền", false, "thất bại", "xác nhận thất bại", "9DG63J9F6H", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3246), 9, 9 },
                    { 10, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3248), 10, "nạp tiền", false, "thành công", "hoàn thành", "10DL81T2G8Z", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3248), 10, 10 },
                    { 11, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3249), 11, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "11DF85R8K6S", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3250), 11, 11 },
                    { 12, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3252), 12, "nạp tiền", false, "đang xử lí", "đang xử lí", "12DM14S4P4V", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3252), 12, 12 },
                    { 13, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3254), 13, "nạp tiền", false, "thành công", "xác nhận thành công", "13DP76J5J1R", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3254), 13, 13 },
                    { 14, 10000, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3255), 14, "nạp tiền", false, "thất bại", "xác nhận thất bại", "14DS57C4B8K", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3256), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "is_delete", "state", "status", "trans_code", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 5000, "TP Bank", "789654312", "Hoàng Minh Nguyệt", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3272), 1, false, "đang xử lí", "đang chờ xác nhận", "1W0U5V1I0", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3273), 1, 1 },
                    { 2, 1000, "TP Bank", "789654312", "Nguyễn Thùy Dương", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3275), 2, false, "đang xử lí", "đang xử lí", "2W4F4Y9E7", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3276), 2, 2 },
                    { 3, 5000, "TP Bank", "789654312", "Lê Thạc Hoành", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3281), 3, false, "thành công", "xác nhận thành công", "3W3C1J8P1", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3282), 3, 3 },
                    { 4, 1000, "TP Bank", "789654312", "Nguyễn Quang Vị", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3284), 4, false, "thất bại", "xác nhận thất bại", "4W6O2Q2R4", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3284), 4, 4 },
                    { 5, 5000, "TP Bank", "789654312", "Nguyễn Mạnh Cường", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3286), 5, false, "thành công", "hoàn thành", "5W8O2W1A3", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3286), 5, 5 },
                    { 6, 1000, "TP Bank", "789654312", "Nguyễn Việt Hân", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3288), 6, false, "đang xử lí", "đang chờ xác nhận", "6W2Z1O6B1", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3289), 6, 6 },
                    { 7, 5000, "TP Bank", "789654312", "Nguyễn Trung Hiếu", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3290), 7, false, "đang xử lí", "đang xử lí", "7W3T0N3S0", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3291), 7, 7 },
                    { 8, 10000, "TP Bank", "789654312", "Nguyễn Văn Tuấn", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3292), 8, false, "thành công", "xác nhận thành công", "8W4I2D8D0", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3293), 8, 8 },
                    { 9, 5000, "TP Bank", "789654312", "Ngô Gia Thiện", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3294), 9, false, "thất bại", "xác nhận thất bại", "9W6H6F3O2", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3295), 9, 9 },
                    { 10, 10000, "TP Bank", "789654312", "Phan Thế Anh", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3297), 10, false, "thành công", "hoàn thành", "10W1B4L3R5", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3297), 10, 10 },
                    { 11, 5000, "TP Bank", "789654312", "Nguyễn Ngọc Hoàng", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3299), 11, false, "đang xử lí", "đang xác nhận", "11W8I7T8V7", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3300), 11, 11 },
                    { 12, 10000, "TP Bank", "789654312", "Nguyễn Quang Lộc", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3302), 12, false, "đang xử lí", "đang xử lí", "12W6M7E2D3", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3302), 12, 12 },
                    { 13, 5000, "TP Bank", "789654312", "Nguyễn Hải Đan", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3304), 13, false, "thành công", "xác nhận thành công", "13W4Q0L0L6", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3305), 13, 13 },
                    { 14, 10000, "TP Bank", "789654312", "Bank Admin", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3306), 14, false, "thất bại", "xác nhận thất bại", "14W9C9M5F4", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3307), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "DepositResponses",
                columns: new[] { "id", "create_at", "create_by", "deposit_id", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3320), 14, 1, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3321), 14 },
                    { 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3323), 14, 2, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3324), 14 },
                    { 3, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3326), 14, 3, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3326), 14 },
                    { 4, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3328), 14, 4, "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3328), 14 },
                    { 5, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3330), 14, 5, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3330), 14 },
                    { 6, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3331), 14, 6, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3332), 14 },
                    { 7, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3333), 14, 7, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3334), 14 },
                    { 8, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3335), 14, 8, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3336), 14 },
                    { 9, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3338), 14, 9, "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3338), 14 },
                    { 10, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3340), 14, 10, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3340), 14 },
                    { 11, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3342), 14, 11, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3342), 14 },
                    { 12, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3344), 14, 12, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3344), 14 },
                    { 13, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3346), 14, 13, "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3346), 14 },
                    { 14, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3348), 14, 14, "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3348), 14 }
                });

            migrationBuilder.InsertData(
                table: "WithdrawalResponses",
                columns: new[] { "id", "create_at", "create_by", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by", "withdrawal_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3363), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3364), 14, 1 },
                    { 2, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3366), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3367), 14, 2 },
                    { 3, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3368), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3369), 14, 3 },
                    { 4, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3370), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3371), 14, 4 },
                    { 5, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3372), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3373), 14, 5 },
                    { 6, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3374), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3375), 14, 6 },
                    { 7, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3377), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3377), 14, 7 },
                    { 8, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3379), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3379), 14, 8 },
                    { 9, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3381), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3381), 14, 9 },
                    { 10, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3383), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3383), 14, 10 },
                    { 11, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3385), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3385), 14, 11 },
                    { 12, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3387), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3387), 14, 12 },
                    { 13, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3389), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3389), 14, 13 },
                    { 14, new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3391), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 2, 25, 18, 32, 47, 434, DateTimeKind.Local).AddTicks(3391), 14, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_role_id",
                table: "Accounts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_DepositResponses_create_by",
                table: "DepositResponses",
                column: "create_by");

            migrationBuilder.CreateIndex(
                name: "IX_DepositResponses_deposit_id",
                table: "DepositResponses",
                column: "deposit_id");

            migrationBuilder.CreateIndex(
                name: "IX_DepositResponses_update_by",
                table: "DepositResponses",
                column: "update_by");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_create_by",
                table: "Deposits",
                column: "create_by");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_update_by",
                table: "Deposits",
                column: "update_by");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_wallet_id",
                table: "Deposits",
                column: "wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateOrders_buy_by",
                table: "IntermediateOrders",
                column: "buy_by");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateOrders_create_by",
                table: "IntermediateOrders",
                column: "create_by");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateOrders_update_by",
                table: "IntermediateOrders",
                column: "update_by");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_account_id",
                table: "Wallets",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_update_by",
                table: "Wallets",
                column: "update_by");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalResponses_create_by",
                table: "WithdrawalResponses",
                column: "create_by");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalResponses_update_by",
                table: "WithdrawalResponses",
                column: "update_by");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalResponses_withdrawal_id",
                table: "WithdrawalResponses",
                column: "withdrawal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_create_by",
                table: "Withdrawals",
                column: "create_by");

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_update_by",
                table: "Withdrawals",
                column: "update_by");

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
                name: "IntermediateOrders");

            migrationBuilder.DropTable(
                name: "WithdrawalResponses");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Withdrawals");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
