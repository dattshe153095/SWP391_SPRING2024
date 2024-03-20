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
                    deposit_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    wallet_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
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
                    id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    fee_rate = table.Column<float>(type: "real", nullable: false),
                    fee_type = table.Column<bool>(type: "bit", nullable: false),
                    payment_amount = table.Column<float>(type: "real", nullable: false),
                    earn_amount = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    contact = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    hidden_content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    is_public = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    buy_user = table.Column<int>(type: "int", nullable: true),
                    buy_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    link_product = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntermediateOrders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notifis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifis", x => x.id);
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
                name: "Transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    wallet_id = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<bool>(type: "bit", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalResponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    withdrawal_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    wallet_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "create_at", "description", "email", "is_delete", "name", "password", "phone", "role_id", "update_at", "username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8014), null, "waterball208@gmail.com", false, "Hoàng Minh Nguyệt", "minhnguyet", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8015), "minhnguyet" },
                    { 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8018), null, "waterball208@gmail.com", false, "Nguyễn Thùy Dương", "thuyduong", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8018), "thuyduong" },
                    { 3, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8020), null, "waterball208@gmail.com", false, "Lê Thạc Hoành", "thachoanh", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8021), "thachoanh" },
                    { 4, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8023), null, "waterball208@gmail.com", false, "Nguyễn Quang Vị", "quangvi", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8024), "quangvi" },
                    { 5, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8026), null, "waterball208@gmail.com", false, "Nguyễn Mạnh Cường", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8026), "manhcuong" },
                    { 6, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8028), null, "waterball208@gmail.com", false, "Nguyễn Việt Hân", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8029), "viethan" },
                    { 7, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8031), null, "waterball208@gmail.com", false, "Nguyễn Trung Hiếu", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8032), "trunghieu" },
                    { 8, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8034), null, "waterball208@gmail.com", false, "Nguyễn Văn Tuấn", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8034), "vantuan" },
                    { 9, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8036), null, "waterball208@gmail.com", false, "Ngô Gia Thiện", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8037), "giathien" },
                    { 10, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8039), null, "waterball208@gmail.com", false, "Phan Thế Anh", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8039), "theanh" },
                    { 11, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8041), null, "waterball208@gmail.com", false, "Nguyễn Ngọc Hoàng", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8042), "ngochoang" },
                    { 12, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8045), null, "waterball208@gmail.com", false, "Nguyễn Quang Lộc", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8045), "quangloc" },
                    { 13, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8048), null, "waterball208@gmail.com", false, "Nguyễn Hải Đan", "pass123", "0987654321", 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8048), "haidan123" },
                    { 14, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8050), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8051), "admin" }
                });

            migrationBuilder.InsertData(
                table: "DepositResponses",
                columns: new[] { "id", "create_at", "create_by", "deposit_id", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8287), 14, "1DY75F3K26T", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8288), 14 },
                    { 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8290), 14, "2DI83A9M0P", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8291), 14 },
                    { 3, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8293), 14, "3DW29E6G3T", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8294), 14 },
                    { 4, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8296), 14, "4DX64S7S9Y", "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8297), 14 },
                    { 5, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8299), 14, "5DB17K9Y8X", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8299), 14 },
                    { 6, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8302), 14, "6DP96C3I5V", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8302), 14 },
                    { 7, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8304), 14, "7DD50M1A7Q", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8305), 14 },
                    { 8, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8308), 14, "8DR05R0J6X", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8308), 14 },
                    { 9, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8310), 14, "9DG63J9F6H", "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8311), 14 },
                    { 10, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8313), 14, "10DL81T2G8Z", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8314), 14 },
                    { 11, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8316), 14, "11DF85R8K6S", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8316), 14 },
                    { 12, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8318), 14, "12DM14S4P4V", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8319), 14 },
                    { 13, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8321), 14, "13DP76J5J1R", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8322), 14 },
                    { 14, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8324), 14, "14DS57C4B8K", "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8324), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "description", "is_delete", "state", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { "10DL81T2G8Z", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8191), 10, "nạp tiền", false, "thành công", "hoàn thành", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8191), 10, 10 },
                    { "11DF85R8K6S", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8193), 11, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8194), 11, 11 },
                    { "12DM14S4P4V", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8196), 12, "nạp tiền", false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8197), 12, 12 },
                    { "13DP76J5J1R", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8199), 13, "nạp tiền", false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8200), 13, 13 },
                    { "14DS57C4B8K", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8203), 14, "nạp tiền", false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8204), 14, 14 },
                    { "1DY75F3K26T", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8165), 1, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8166), 1, 1 },
                    { "2DI83A9M0P", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8169), 2, "nạp tiền", false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8170), 2, 2 },
                    { "3DW29E6G3T", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8172), 3, "nạp tiền", false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8173), 3, 3 },
                    { "4DX64S7S9Y", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8175), 4, "nạp tiền", false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8176), 4, 4 },
                    { "5DB17K9Y8X", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8178), 5, "nạp tiền", false, "thành công", "hoàn thành", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8178), 5, 5 },
                    { "6DP96C3I5V", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8180), 6, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8181), 6, 6 },
                    { "7DD50M1A7Q", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8183), 7, "nạp tiền", false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8184), 7, 7 },
                    { "8DR05R0J6X", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8186), 8, "nạp tiền", false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8186), 8, 8 },
                    { "9DG63J9F6H", 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8188), 9, "nạp tiền", false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8189), 9, 9 }
                });

            migrationBuilder.InsertData(
                table: "IntermediateOrders",
                columns: new[] { "id", "buy_at", "buy_user", "contact", "create_at", "create_by", "description", "earn_amount", "fee_rate", "fee_type", "hidden_content", "is_delete", "is_public", "link_product", "name", "payment_amount", "price", "state", "status", "update_at", "update_by" },
                values: new object[,]
                {
                    { "2n3mMgFy", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8485), 13, "tài khoản Youtube ", 475f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Vip Youtube", 500f, 500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8486), 1 },
                    { "6zqRwHEu", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8460), 5, "tài khoản Unity ", 475f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Unity", 500f, 500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8461), 1 },
                    { "a2D1PC0L", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8469), 8, "tài khoản Adobephotoshop ", 2000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Adobephotoshop", 2100f, 2000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8470), 1 },
                    { "eSgvtQo6", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8488), 14, "tài khoản Duolingo ", 1000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Duolingo", 1050f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8489), 1 },
                    { "fDlco4Ii", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8478), 11, "tài khoản Git ", 1425f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Git", 1500f, 1500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8478), 1 },
                    { "FjNnwZdR", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8404), 1, "tài khoản Office ", 950f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Office", 1000f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8404), 1 },
                    { "hwPm5QZR", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8475), 10, "tài khoản Gmail ", 1000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Gmail", 1050f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8475), 1 },
                    { "I1mJYvoA", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8463), 6, "tài khoản Microsoft", 1000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Microsoft", 1050f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8464), 1 },
                    { "Kk3us7mV", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8453), 3, "tài khoản Facebook ", 1425f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Facebook", 1500f, 1500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8454), 1 },
                    { "LziBV2fq", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8481), 12, "tài khoản Netflix ", 2000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Netflix", 2100f, 2000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8482), 1 },
                    { "OnvTBGFk", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8466), 7, "tài khoản Spine ", 1425f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Spine", 1500f, 1500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8467), 1 },
                    { "Q9XWqMr3", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8472), 9, "tài khoản Ai ", 475f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Ai", 500f, 500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8472), 1 },
                    { "tCWyd9xS", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8408), 2, "tài khoản GBT ", 500f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản GBT", 525f, 500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8408), 1 },
                    { "wFzU6Nvj", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8491), 10, "tài khoản Coursera ", 950f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Coursera", 1000f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8492), 1 },
                    { "yh2LnbGk", null, null, "facebook, mess,zalo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8457), 4, "tài khoản Game ", 2000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Game", 2100f, 2000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8457), 1 }
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
                table: "WithdrawalResponses",
                columns: new[] { "id", "create_at", "create_by", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by", "withdrawal_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8346), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8347), 14, "1W0U5V1I0" },
                    { 2, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8350), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8351), 14, "2W4F4Y9E7" },
                    { 3, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8354), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8354), 14, "3W3C1J8P1" },
                    { 4, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8356), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8357), 14, "4W6O2Q2R4" },
                    { 5, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8359), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8360), 14, "5W8O2W1A3" },
                    { 6, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8363), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8363), 14, "6W2Z1O6B1" },
                    { 7, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8365), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8366), 14, "7W3T0N3S0" },
                    { 8, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8368), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8369), 14, "8W4I2D8D0" },
                    { 9, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8371), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8371), 14, "9W6H6F3O2" },
                    { 10, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8373), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8374), 14, "10W1B4L3R5" },
                    { 11, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8376), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8377), 14, "11W8I7T8V7" },
                    { 12, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8379), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8379), 14, "12W6M7E2D3" },
                    { 13, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8381), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8382), 14, "13W4Q0L0L6" },
                    { 14, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8384), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8385), 14, "14W9C9M5F4" }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 20000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8073), 1 },
                    { 2, 2, 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8075), 2 },
                    { 3, 3, 20000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8076), 3 },
                    { 4, 4, 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8078), 4 },
                    { 5, 5, 20000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8079), 5 },
                    { 6, 6, 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8081), 6 },
                    { 7, 7, 20000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8082), 7 },
                    { 8, 8, 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8083), 8 },
                    { 9, 9, 20000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8085), 9 },
                    { 10, 10, 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8086), 10 },
                    { 11, 11, 20000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8088), 11 },
                    { 12, 12, 10000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8089), 12 },
                    { 13, 13, 20000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8090), 13 },
                    { 14, 14, 1000000, new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8092), 14 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "is_delete", "state", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { "10W1B4L3R5", 10000, "TP Bank", "789654312", "Phan Thế Anh", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8254), 10, false, "thành công", "hoàn thành", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8254), 10, 10 },
                    { "11W8I7T8V7", 5000, "TP Bank", "789654312", "Nguyễn Ngọc Hoàng", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8257), 11, false, "đang xử lí", "đang xác nhận", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8258), 11, 11 },
                    { "12W6M7E2D3", 10000, "TP Bank", "789654312", "Nguyễn Quang Lộc", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8260), 12, false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8261), 12, 12 },
                    { "13W4Q0L0L6", 5000, "TP Bank", "789654312", "Nguyễn Hải Đan", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8263), 13, false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8263), 13, 13 },
                    { "14W9C9M5F4", 10000, "TP Bank", "789654312", "Bank Admin", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8266), 14, false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8266), 14, 14 },
                    { "1W0U5V1I0", 5000, "TP Bank", "789654312", "Hoàng Minh Nguyệt", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8227), 1, false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8228), 1, 1 },
                    { "2W4F4Y9E7", 1000, "TP Bank", "789654312", "Nguyễn Thùy Dương", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8231), 2, false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8231), 2, 2 },
                    { "3W3C1J8P1", 5000, "TP Bank", "789654312", "Lê Thạc Hoành", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8234), 3, false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8234), 3, 3 },
                    { "4W6O2Q2R4", 1000, "TP Bank", "789654312", "Nguyễn Quang Vị", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8237), 4, false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8237), 4, 4 },
                    { "5W8O2W1A3", 5000, "TP Bank", "789654312", "Nguyễn Mạnh Cường", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8239), 5, false, "thành công", "hoàn thành", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8240), 5, 5 },
                    { "6W2Z1O6B1", 1000, "TP Bank", "789654312", "Nguyễn Việt Hân", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8242), 6, false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8243), 6, 6 },
                    { "7W3T0N3S0", 5000, "TP Bank", "789654312", "Nguyễn Trung Hiếu", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8245), 7, false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8246), 7, 7 },
                    { "8W4I2D8D0", 10000, "TP Bank", "789654312", "Nguyễn Văn Tuấn", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8248), 8, false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8249), 8, 8 },
                    { "9W6H6F3O2", 5000, "TP Bank", "789654312", "Ngô Gia Thiện", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8251), 9, false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 20, 14, 22, 41, 988, DateTimeKind.Local).AddTicks(8252), 9, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_account_id",
                table: "Wallets",
                column: "account_id");

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
                name: "Notifis");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Transactions");

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
