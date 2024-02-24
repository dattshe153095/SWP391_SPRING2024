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
                name: "AccountRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desctiption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => x.id);
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
                        name: "FK_Accounts_AccountRoles_role_id",
                        column: x => x.role_id,
                        principalTable: "AccountRoles",
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
                table: "AccountRoles",
                columns: new[] { "id", "desctiption" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "id", "desctiption" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "create_at", "description", "email", "is_delete", "name", "password", "phone", "role_id", "update_at", "username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5570), null, "waterball208@gmail.com", false, "Hoàng Minh Nguyệt", "minhnguyet", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5571), "minhnguyet" },
                    { 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5583), null, "waterball208@gmail.com", false, "Nguyễn Thùy Dương", "thuyduong", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5584), "thuyduong" },
                    { 3, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5586), null, "waterball208@gmail.com", false, "Lê Thạc Hoành", "thachoanh", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5587), "thachoanh" },
                    { 4, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5589), null, "waterball208@gmail.com", false, "Nguyễn Quang Vị", "quangvi", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5590), "quangvi" },
                    { 5, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5592), null, "waterball208@gmail.com", false, "Nguyễn Mạnh Cường", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5592), "manhcuong" },
                    { 6, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5596), null, "waterball208@gmail.com", false, "Nguyễn Việt Hân", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5596), "viethan" },
                    { 7, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5599), null, "waterball208@gmail.com", false, "Nguyễn Trung Hiếu", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5600), "trunghieu" },
                    { 8, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5602), null, "waterball208@gmail.com", false, "Nguyễn Văn Tuấn", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5602), "vantuan" },
                    { 9, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5604), null, "waterball208@gmail.com", false, "Ngô Gia Thiện", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5605), "giathien" },
                    { 10, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5607), null, "waterball208@gmail.com", false, "Phan Thế Anh", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5607), "theanh" },
                    { 11, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5610), null, "waterball208@gmail.com", false, "Nguyễn Ngọc Hoàng", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5610), "ngochoang" },
                    { 12, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5612), null, "waterball208@gmail.com", false, "Nguyễn Quang Lộc", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5613), "quangloc" },
                    { 13, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5615), null, "waterball208@gmail.com", false, "Nguyễn Hải Đan", "pass123", "0987654321", 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5615), "haidan123" },
                    { 14, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5617), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5618), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 20000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5636), 1 },
                    { 2, 2, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5638), 2 },
                    { 3, 3, 20000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5639), 3 },
                    { 4, 4, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5640), 4 },
                    { 5, 5, 20000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5641), 5 },
                    { 6, 6, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5642), 6 },
                    { 7, 7, 20000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5643), 7 },
                    { 8, 8, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5645), 8 },
                    { 9, 9, 20000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5646), 9 },
                    { 10, 10, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5647), 10 },
                    { 11, 11, 20000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5648), 11 },
                    { 12, 12, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5649), 12 },
                    { 13, 13, 20000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5650), 13 },
                    { 14, 14, 1000000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5651), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "description", "is_delete", "state", "status", "trans_code", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5670), 1, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "1DY75F3K26T", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5671), 1, 1 },
                    { 2, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5673), 2, "nạp tiền", false, "đang xử lí", "đang chờ xử lí", "2DI83A9M0P", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5674), 2, 2 },
                    { 3, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5676), 3, "nạp tiền", false, "thành công", "xác nhận thành công", "3DW29E6G3T", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5676), 3, 3 },
                    { 4, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5679), 4, "nạp tiền", false, "thất bại", "xác nhận thất bại", "4DX64S7S9Y", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5679), 4, 4 },
                    { 5, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5681), 5, "nạp tiền", false, "thành công", "hoàn thành", "5DB17K9Y8X", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5682), 5, 5 },
                    { 6, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5684), 6, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "6DP96C3I5V", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5684), 6, 6 },
                    { 7, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5686), 7, "nạp tiền", false, "đang xử lí", "đang chờ xử lí", "7DD50M1A7Q", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5687), 7, 7 },
                    { 8, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5689), 8, "nạp tiền", false, "thành công", "xác nhận thành công", "8DR05R0J6X", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5690), 8, 8 },
                    { 9, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5692), 9, "nạp tiền", false, "thất bại", "xác nhận thất bại", "9DG63J9F6H", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5692), 9, 9 },
                    { 10, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5694), 10, "nạp tiền", false, "thành công", "hoàn thành", "10DL81T2G8Z", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5695), 10, 10 },
                    { 11, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5697), 11, "nạp tiền", false, "đang xử lí", "đang chờ xác nhận", "11DF85R8K6S", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5697), 11, 11 },
                    { 12, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5700), 12, "nạp tiền", false, "đang xử lí", "đang chờ xử lí", "12DM14S4P4V", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5701), 12, 12 },
                    { 13, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5703), 13, "nạp tiền", false, "thành công", "xác nhận thành công", "13DP76J5J1R", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5703), 13, 13 },
                    { 14, 10000, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5705), 14, "nạp tiền", false, "thất bại", "xác nhận thất bại", "14DS57C4B8K", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5706), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "is_delete", "state", "status", "trans_code", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 5000, "TP Bank", "789654312", "Hoàng Minh Nguyệt", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5724), 1, false, "đang xử lí", "đang chờ xác nhận", "1W0U5V1I0", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5725), 1, 1 },
                    { 2, 1000, "TP Bank", "789654312", "Nguyễn Thùy Dương", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5729), 2, false, "đang xử lí", "đang chờ xử lí", "2W4F4Y9E7", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5729), 2, 2 },
                    { 3, 5000, "TP Bank", "789654312", "Lê Thạc Hoành", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5731), 3, false, "thành công", "xác nhận thành công", "3W3C1J8P1", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5732), 3, 3 },
                    { 4, 1000, "TP Bank", "789654312", "Nguyễn Quang Vị", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5734), 4, false, "thất bại", "xác nhận thất bại", "4W6O2Q2R4", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5735), 4, 4 },
                    { 5, 5000, "TP Bank", "789654312", "Nguyễn Mạnh Cường", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5737), 5, false, "thành công", "hoàn thành", "5W8O2W1A3", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5738), 5, 5 },
                    { 6, 1000, "TP Bank", "789654312", "Nguyễn Việt Hân", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5740), 6, false, "đang xử lí", "đang chờ xác nhận", "6W2Z1O6B1", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5741), 6, 6 },
                    { 7, 5000, "TP Bank", "789654312", "Nguyễn Trung Hiếu", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5743), 7, false, "đang xử lí", "đang chờ xử lí", "7W3T0N3S0", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5743), 7, 7 },
                    { 8, 10000, "TP Bank", "789654312", "Nguyễn Văn Tuấn", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5745), 8, false, "thành công", "xác nhận thành công", "8W4I2D8D0", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5746), 8, 8 },
                    { 9, 5000, "TP Bank", "789654312", "Ngô Gia Thiện", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5749), 9, false, "thất bại", "xác nhận thất bại", "9W6H6F3O2", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5749), 9, 9 },
                    { 10, 10000, "TP Bank", "789654312", "Phan Thế Anh", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5757), 10, false, "thành công", "hoàn thành", "10W1B4L3R5", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5757), 10, 10 },
                    { 11, 5000, "TP Bank", "789654312", "Nguyễn Ngọc Hoàng", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5759), 11, false, "đang xử lí", "đang chờ xác nhận", "11W8I7T8V7", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5760), 11, 11 },
                    { 12, 10000, "TP Bank", "789654312", "Nguyễn Quang Lộc", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5762), 12, false, "đang xử lí", "đang chờ xử lí", "12W6M7E2D3", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5762), 12, 12 },
                    { 13, 5000, "TP Bank", "789654312", "Nguyễn Hải Đan", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5764), 13, false, "thành công", "xác nhận thành công", "13W4Q0L0L6", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5765), 13, 13 },
                    { 14, 10000, "TP Bank", "789654312", "Bank Admin", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5767), 14, false, "thất bại", "xác nhận thất bại", "14W9C9M5F4", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5768), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "DepositResponses",
                columns: new[] { "id", "create_at", "create_by", "deposit_id", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5784), 14, 1, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5785), 14 },
                    { 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5788), 14, 2, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5789), 14 },
                    { 3, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5791), 14, 3, "Giao dịch thành công", false, "thành công", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5791), 14 },
                    { 4, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5797), 14, 4, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5797), 14 },
                    { 5, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5800), 14, 5, "Giao dịch thành công", false, "thành công", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5800), 14 },
                    { 6, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5803), 14, 6, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5804), 14 },
                    { 7, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5806), 14, 7, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5807), 14 },
                    { 8, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5809), 14, 8, "Giao dịch thành công", false, "thành công", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5809), 14 },
                    { 9, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5811), 14, 9, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5812), 14 },
                    { 10, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5814), 14, 10, "Giao dịch thành công", false, "thành công", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5815), 14 },
                    { 11, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5817), 14, 11, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5818), 14 },
                    { 12, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5820), 14, 12, "Đang xử lí", false, "đang xử lí", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5820), 14 },
                    { 13, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5822), 14, 13, "Giao dịch thành công", false, "thành công", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5823), 14 },
                    { 14, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5825), 14, 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "nạp tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5825), 14 }
                });

            migrationBuilder.InsertData(
                table: "WithdrawalResponses",
                columns: new[] { "id", "create_at", "create_by", "description", "is_delete", "state", "status", "type_transaction", "update_at", "update_by", "withdrawal_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5844), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5845), 14, 1 },
                    { 2, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5848), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5848), 14, 2 },
                    { 3, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5851), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5851), 14, 3 },
                    { 4, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5854), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5854), 14, 4 },
                    { 5, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5857), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5857), 14, 5 },
                    { 6, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5860), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5860), 14, 6 },
                    { 7, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5862), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5863), 14, 7 },
                    { 8, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5865), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5866), 14, 8 },
                    { 9, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5868), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5868), 14, 9 },
                    { 10, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5870), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5870), 14, 10 },
                    { 11, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5873), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5873), 14, 11 },
                    { 12, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5877), 14, "Đang xử lí", false, "đang xử lí", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5878), 14, 12 },
                    { 13, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5880), 14, "Giao dịch thành công", false, "thành công", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5880), 14, 13 },
                    { 14, new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5882), 14, "Giao dịch thất bại", false, "thất bại", "đang xử lí", "rút tiền", new DateTime(2024, 2, 24, 17, 40, 26, 800, DateTimeKind.Local).AddTicks(5883), 14, 14 }
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
                name: "AccountRoles");
        }
    }
}
