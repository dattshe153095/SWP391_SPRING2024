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
                    { 1, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3243), null, "waterball208@gmail.com", false, "Hoàng Minh Nguyệt", "minhnguyet", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3244), "minhnguyet" },
                    { 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3247), null, "waterball208@gmail.com", false, "Nguyễn Thùy Dương", "thuyduong", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3248), "thuyduong" },
                    { 3, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3252), null, "waterball208@gmail.com", false, "Lê Thạc Hoành", "thachoanh", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3252), "thachoanh" },
                    { 4, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3256), null, "waterball208@gmail.com", false, "Nguyễn Quang Vị", "quangvi", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3256), "quangvi" },
                    { 5, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3259), null, "waterball208@gmail.com", false, "Nguyễn Mạnh Cường", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3260), "manhcuong" },
                    { 6, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3263), null, "waterball208@gmail.com", false, "Nguyễn Việt Hân", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3263), "viethan" },
                    { 7, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3267), null, "waterball208@gmail.com", false, "Nguyễn Trung Hiếu", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3267), "trunghieu" },
                    { 8, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3270), null, "waterball208@gmail.com", false, "Nguyễn Văn Tuấn", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3271), "vantuan" },
                    { 9, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3274), null, "waterball208@gmail.com", false, "Ngô Gia Thiện", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3274), "giathien" },
                    { 10, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3277), null, "waterball208@gmail.com", false, "Phan Thế Anh", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3278), "theanh" },
                    { 11, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3281), null, "waterball208@gmail.com", false, "Nguyễn Ngọc Hoàng", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3282), "ngochoang" },
                    { 12, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3286), null, "waterball208@gmail.com", false, "Nguyễn Quang Lộc", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3286), "quangloc" },
                    { 13, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3290), null, "waterball208@gmail.com", false, "Nguyễn Hải Đan", "pass123", "0987654321", 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3290), "haidan123" },
                    { 14, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3294), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3294), "admin" }
                });

            migrationBuilder.InsertData(
                table: "DepositResponses",
                columns: new[] { "id", "create_at", "create_by", "deposit_id", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3665), 14, "1DY75F3K26T", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3666), 14 },
                    { 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3670), 14, "2DI83A9M0P", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3671), 14 },
                    { 3, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3674), 14, "3DW29E6G3T", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3675), 14 },
                    { 4, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3678), 14, "4DX64S7S9Y", "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3679), 14 },
                    { 5, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3682), 14, "5DB17K9Y8X", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3683), 14 },
                    { 6, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3686), 14, "6DP96C3I5V", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3687), 14 },
                    { 7, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3690), 14, "7DD50M1A7Q", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3691), 14 },
                    { 8, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3693), 14, "8DR05R0J6X", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3694), 14 },
                    { 9, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3697), 14, "9DG63J9F6H", "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3698), 14 },
                    { 10, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3701), 14, "10DL81T2G8Z", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3701), 14 },
                    { 11, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3704), 14, "11DF85R8K6S", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3705), 14 },
                    { 12, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3707), 14, "12DM14S4P4V", "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3708), 14 },
                    { 13, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3711), 14, "13DP76J5J1R", "Giao dịch thành công", false, "thành công", "hoàn thành", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3712), 14 },
                    { 14, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3715), 14, "14DS57C4B8K", "Giao dịch thất bại", false, "thất bại", "xác nhận thất bại", "nạp tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3716), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "description", "is_delete", "state", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { "10DL81T2G8Z", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3432), 10, "nạp tiền", false, "thành công", "hoàn thành", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3433), 10, 10 },
                    { "11DF85R8K6S", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3436), 11, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3437), 11, 11 },
                    { "12DM14S4P4V", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3439), 12, "nạp tiền", false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3440), 12, 12 },
                    { "13DP76J5J1R", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3443), 13, "nạp tiền", false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3443), 13, 13 },
                    { "14DS57C4B8K", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3447), 14, "nạp tiền", false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3447), 14, 14 },
                    { "1DY75F3K26T", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3396), 1, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3397), 1, 1 },
                    { "2DI83A9M0P", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3402), 2, "nạp tiền", false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3403), 2, 2 },
                    { "3DW29E6G3T", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3407), 3, "nạp tiền", false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3407), 3, 3 },
                    { "4DX64S7S9Y", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3411), 4, "nạp tiền", false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3412), 4, 4 },
                    { "5DB17K9Y8X", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3415), 5, "nạp tiền", false, "thành công", "hoàn thành", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3415), 5, 5 },
                    { "6DP96C3I5V", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3418), 6, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3419), 6, 6 },
                    { "7DD50M1A7Q", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3422), 7, "nạp tiền", false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3423), 7, 7 },
                    { "8DR05R0J6X", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3425), 8, "nạp tiền", false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3426), 8, 8 },
                    { "9DG63J9F6H", 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3429), 9, "nạp tiền", false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3430), 9, 9 }
                });

            migrationBuilder.InsertData(
                table: "IntermediateOrders",
                columns: new[] { "id", "buy_at", "buy_user", "contact", "create_at", "create_by", "description", "earn_amount", "fee_rate", "fee_type", "hidden_content", "is_delete", "is_public", "link_product", "name", "payment_amount", "price", "state", "status", "update_at", "update_by" },
                values: new object[,]
                {
                    { "2n3mMgFy", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3947), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3949), 13, "tài khoản Youtube ", 475f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Vip Youtube", 500f, 500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3950), 1 },
                    { "6zqRwHEu", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3879), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3882), 5, "tài khoản Unity ", 475f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Unity", 500f, 500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3882), 1 },
                    { "a2D1PC0L", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3897), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3901), 8, "tài khoản Adobephotoshop ", 2000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Adobephotoshop", 2100f, 2000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3902), 1 },
                    { "eSgvtQo6", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3952), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3954), 14, "tài khoản Duolingo ", 1000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Duolingo", 1050f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3955), 1 },
                    { "fDlco4Ii", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3937), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3940), 11, "tài khoản Git ", 1425f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Git", 1500f, 1500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3941), 1 },
                    { "FjNnwZdR", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3847), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3854), 1, "tài khoản Office ", 950f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Office", 1000f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3855), 1 },
                    { "hwPm5QZR", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3931), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3934), 10, "tài khoản Gmail ", 1000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Gmail", 1050f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3935), 1 },
                    { "I1mJYvoA", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3884), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3886), 6, "tài khoản Microsoft", 1000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Microsoft", 1050f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3887), 1 },
                    { "Kk3us7mV", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3864), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3870), 3, "tài khoản Facebook ", 1425f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, false, "#", "Tài Khoản Facebook", 1500f, 1500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3873), 1 },
                    { "LziBV2fq", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3942), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3944), 12, "tài khoản Netflix ", 2000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Netflix", 2100f, 2000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3945), 1 },
                    { "OnvTBGFk", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3888), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3893), 7, "tài khoản Spine ", 1425f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Spine", 1500f, 1500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3894), 1 },
                    { "Q9XWqMr3", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3905), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3909), 9, "tài khoản Ai ", 475f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Ai", 500f, 500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3910), 1 },
                    { "tCWyd9xS", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3857), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3860), 2, "tài khoản GBT ", 500f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản GBT", 525f, 500f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3861), 1 },
                    { "wFzU6Nvj", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3956), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3959), 10, "tài khoản Coursera ", 950f, 0.05f, true, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Coursera", 1000f, 1000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3959), 1 },
                    { "yh2LnbGk", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3875), null, "facebook, mess,zalo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3877), 4, "tài khoản Game ", 2000f, 0.05f, false, "tài khoản: account, mật khẩu: password", false, true, "#", "Tài Khoản Game", 2100f, 2000f, "đang xử lí", "mới tạo", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3878), 1 }
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
                    { 1, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3754), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3755), 14, "1W0U5V1I0" },
                    { 2, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3759), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3760), 14, "2W4F4Y9E7" },
                    { 3, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3763), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3764), 14, "3W3C1J8P1" },
                    { 4, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3766), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3767), 14, "4W6O2Q2R4" },
                    { 5, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3769), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3770), 14, "5W8O2W1A3" },
                    { 6, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3773), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3774), 14, "6W2Z1O6B1" },
                    { 7, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3777), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3777), 14, "7W3T0N3S0" },
                    { 8, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3780), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3781), 14, "8W4I2D8D0" },
                    { 9, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3783), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3784), 14, "9W6H6F3O2" },
                    { 10, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3787), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3788), 14, "10W1B4L3R5" },
                    { 11, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3790), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3791), 14, "11W8I7T8V7" },
                    { 12, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3793), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3794), 14, "12W6M7E2D3" },
                    { 13, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3796), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3797), 14, "13W4Q0L0L6" },
                    { 14, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3799), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3800), 14, "14W9C9M5F4" }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 20000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3331), 1 },
                    { 2, 2, 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3334), 2 },
                    { 3, 3, 20000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3336), 3 },
                    { 4, 4, 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3338), 4 },
                    { 5, 5, 20000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3340), 5 },
                    { 6, 6, 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3342), 6 },
                    { 7, 7, 20000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3344), 7 },
                    { 8, 8, 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3346), 8 },
                    { 9, 9, 20000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3348), 9 },
                    { 10, 10, 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3350), 10 },
                    { 11, 11, 20000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3352), 11 },
                    { 12, 12, 10000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3354), 12 },
                    { 13, 13, 20000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3356), 13 },
                    { 14, 14, 1000000, new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3358), 14 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "is_delete", "state", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { "10W1B4L3R5", 10000, "TP Bank", "789654312", "Phan Thế Anh", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3606), 10, false, "thành công", "hoàn thành", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3607), 10, 10 },
                    { "11W8I7T8V7", 5000, "TP Bank", "789654312", "Nguyễn Ngọc Hoàng", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3611), 11, false, "đang xử lí", "đang xác nhận", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3612), 11, 11 },
                    { "12W6M7E2D3", 10000, "TP Bank", "789654312", "Nguyễn Quang Lộc", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3614), 12, false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3615), 12, 12 },
                    { "13W4Q0L0L6", 5000, "TP Bank", "789654312", "Nguyễn Hải Đan", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3618), 13, false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3619), 13, 13 },
                    { "14W9C9M5F4", 10000, "TP Bank", "789654312", "Bank Admin", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3622), 14, false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3622), 14, 14 },
                    { "1W0U5V1I0", 5000, "TP Bank", "789654312", "Hoàng Minh Nguyệt", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3563), 1, false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3565), 1, 1 },
                    { "2W4F4Y9E7", 1000, "TP Bank", "789654312", "Nguyễn Thùy Dương", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3569), 2, false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3570), 2, 2 },
                    { "3W3C1J8P1", 5000, "TP Bank", "789654312", "Lê Thạc Hoành", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3574), 3, false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3575), 3, 3 },
                    { "4W6O2Q2R4", 1000, "TP Bank", "789654312", "Nguyễn Quang Vị", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3579), 4, false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3579), 4, 4 },
                    { "5W8O2W1A3", 5000, "TP Bank", "789654312", "Nguyễn Mạnh Cường", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3583), 5, false, "thành công", "hoàn thành", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3583), 5, 5 },
                    { "6W2Z1O6B1", 1000, "TP Bank", "789654312", "Nguyễn Việt Hân", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3587), 6, false, "đang xử lí", "đang chờ xác nhận", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3587), 6, 6 },
                    { "7W3T0N3S0", 5000, "TP Bank", "789654312", "Nguyễn Trung Hiếu", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3591), 7, false, "đang xử lí", "đang xử lí", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3591), 7, 7 },
                    { "8W4I2D8D0", 10000, "TP Bank", "789654312", "Nguyễn Văn Tuấn", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3595), 8, false, "thành công", "xác nhận thành công", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3595), 8, 8 },
                    { "9W6H6F3O2", 5000, "TP Bank", "789654312", "Ngô Gia Thiện", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3602), 9, false, "thất bại", "xác nhận thất bại", new DateTime(2024, 3, 3, 23, 53, 27, 687, DateTimeKind.Local).AddTicks(3603), 9, 9 }
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
