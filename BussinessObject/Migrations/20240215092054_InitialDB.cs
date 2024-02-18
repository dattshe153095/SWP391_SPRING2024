using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    public partial class InitialDB : Migration
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
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    categories = table.Column<int>(type: "int", nullable: false),
                    desctiption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    link = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    image = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Accounts_create_by",
                        column: x => x.create_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Accounts_update_by",
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
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    total_price = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_create_by",
                        column: x => x.create_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_update_by",
                        column: x => x.update_by,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
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
                    fee = table.Column<int>(type: "int", nullable: false),
                    desctiption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    status = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
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
                name: "TransactionError",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wallet_id = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    status = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionError", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransactionError_Wallets_wallet_id",
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
                    fee = table.Column<int>(type: "int", nullable: false),
                    bank_user = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    bank_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    bank_name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "ProcessedTransactionInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_error_id = table.Column<int>(type: "int", nullable: false),
                    processed_message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    create_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessedTransactionInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProcessedTransactionInfo_TransactionError_transaction_error_id",
                        column: x => x.transaction_error_id,
                        principalTable: "TransactionError",
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
                    { 1, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8096), null, "waterball208@gmail.com", false, "Quốc tổ Hùng Vương", "hungvuong123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8097), "hungvuong" },
                    { 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8099), null, "waterball208@gmail.com", false, "Hai Bà Trưng", "haibatrung123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8099), "haibatrung" },
                    { 3, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8100), null, "waterball208@gmail.com", false, "Lý Nam Đế", "lynamde123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8101), "lynamde" },
                    { 4, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8102), null, "waterball208@gmail.com", false, "Ngô Quyền", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8102), "ngoquyen" },
                    { 5, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8103), null, "waterball208@gmail.com", false, "Đinh Bộ Lĩnh", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8104), "dinhbolinh" },
                    { 6, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8105), null, "waterball208@gmail.com", false, "Lê Hoàn", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8105), "lehoan123" },
                    { 7, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8106), null, "waterball208@gmail.com", false, "Lý Công Uẩn", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8107), "lyconguan" },
                    { 8, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8108), null, "waterball208@gmail.com", false, "Lý Thường Kiệt", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8108), "lythuongkiet" },
                    { 9, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8109), null, "waterball208@gmail.com", false, "Trần Nhân Tông", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8110), "trannhantong" },
                    { 10, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8111), null, "waterball208@gmail.com", false, "Trần Hưng Đạo", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8111), "tranhungdao" },
                    { 11, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8112), null, "waterball208@gmail.com", false, "Lê Lợi", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8113), "leloi123" },
                    { 12, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8114), null, "waterball208@gmail.com", false, "Nguyễn Trãi", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8114), "nguyentrai" },
                    { 13, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8115), null, "waterball208@gmail.com", false, "Nguyễn Huệ", "pass123", "0987654321", 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8115), "quangtrung" },
                    { 14, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8117), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8117), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "categories", "code", "create_at", "create_by", "desctiption", "image", "is_delete", "link", "price", "quantity", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, "DH31UIHI3", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8211), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8211), 14 },
                    { 2, 2, "SOD2IF6AP8F", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8213), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8214), 14 },
                    { 3, 3, "AL6HEB14E", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8215), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8215), 14 },
                    { 4, 1, "IH189AOFA31OH", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8216), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8217), 14 },
                    { 5, 2, "JVY8F1KB4VOL", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8218), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8218), 14 },
                    { 6, 3, "PO0PM7MO9J", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8219), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8220), 14 },
                    { 7, 1, "ATF142DW4YT", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8221), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8221), 14 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8126), 1 },
                    { 2, 2, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8128), 2 },
                    { 3, 3, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8128), 3 },
                    { 4, 4, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8129), 4 },
                    { 5, 5, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8130), 5 },
                    { 6, 6, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8131), 6 },
                    { 7, 7, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8131), 7 },
                    { 8, 8, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8132), 8 },
                    { 9, 9, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8133), 9 },
                    { 10, 10, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8133), 10 },
                    { 11, 11, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8134), 11 },
                    { 12, 12, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8135), 12 },
                    { 13, 13, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8136), 13 },
                    { 14, 14, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8136), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "desctiption", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8145), 1, null, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8146), 1, 1 },
                    { 2, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8148), 2, null, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8148), 2, 2 },
                    { 3, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8149), 3, null, 500, false, "error", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8150), 3, 3 },
                    { 4, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8151), 4, null, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8151), 4, 4 },
                    { 5, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8152), 5, null, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8152), 5, 5 },
                    { 6, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8154), 6, null, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8154), 6, 6 },
                    { 7, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8155), 7, null, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8155), 7, 7 },
                    { 8, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8156), 8, null, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8157), 8, 8 },
                    { 9, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8158), 9, null, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8158), 9, 9 },
                    { 10, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8159), 10, null, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8159), 10, 10 },
                    { 11, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8161), 11, null, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8161), 11, 11 },
                    { 12, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8162), 12, null, 500, false, "error", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8162), 12, 12 },
                    { 13, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8163), 13, null, 500, false, "error", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8164), 13, 13 },
                    { 14, 10000, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8165), 14, null, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8165), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "TransactionError",
                columns: new[] { "id", "create_at", "create_by", "description", "status", "title", "type", "wallet_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8228), 1, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 1 },
                    { 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8229), 4, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 4 },
                    { 3, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8231), 7, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 7 },
                    { 4, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8232), 10, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 10 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, "TP Bank", "789654312", "Quốc Tổ Hùng Vương", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8175), 1, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8175), 1, 1 },
                    { 2, 10000, "TP Bank", "789654312", "Hai Bà Trưng", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8177), 2, 500, false, "error", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8177), 2, 2 },
                    { 3, 10000, "TP Bank", "789654312", "Lý Nam Đế", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8179), 3, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8179), 3, 3 },
                    { 4, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8180), 4, 500, false, "error", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8181), 4, 4 },
                    { 5, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8188), 5, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8188), 5, 5 },
                    { 6, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8189), 6, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8189), 6, 6 },
                    { 7, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8191), 7, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8191), 7, 7 },
                    { 8, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8192), 8, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8193), 8, 8 },
                    { 9, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8194), 9, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8194), 9, 9 },
                    { 10, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8195), 10, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8196), 10, 10 },
                    { 11, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8197), 11, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8197), 11, 11 },
                    { 12, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8198), 12, 500, false, "done", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8199), 12, 12 },
                    { 13, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8200), 13, 500, false, "pending", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8200), 13, 13 },
                    { 14, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8201), 14, 500, false, "error", new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8202), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "ProcessedTransactionInfo",
                columns: new[] { "id", "create_at", "create_by", "processed_message", "transaction_error_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8237), 14, "Đã xử lí", 4 },
                    { 2, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8239), 14, "Đã xử lí", 3 },
                    { 3, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8240), 14, "Đã xử lí", 1 },
                    { 4, new DateTime(2024, 2, 15, 16, 20, 54, 722, DateTimeKind.Local).AddTicks(8241), 14, "Đã xử lí", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_role_id",
                table: "Accounts",
                column: "role_id");

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
                name: "IX_Orders_account_id",
                table: "Orders",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_create_by",
                table: "Orders",
                column: "create_by");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_product_id",
                table: "Orders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_update_by",
                table: "Orders",
                column: "update_by");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessedTransactionInfo_transaction_error_id",
                table: "ProcessedTransactionInfo",
                column: "transaction_error_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_create_by",
                table: "Products",
                column: "create_by");

            migrationBuilder.CreateIndex(
                name: "IX_Products_update_by",
                table: "Products",
                column: "update_by");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionError_wallet_id",
                table: "TransactionError",
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
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProcessedTransactionInfo");

            migrationBuilder.DropTable(
                name: "Withdrawals");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TransactionError");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountRoles");
        }
    }
}
