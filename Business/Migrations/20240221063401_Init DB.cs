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
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    categories = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                name: "TransactionErrors",
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
                    table.PrimaryKey("PK_TransactionErrors", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransactionErrors_Wallets_wallet_id",
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
                    bank_user = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    bank_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    bank_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                name: "ProcessedTransactionInfos",
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
                    table.PrimaryKey("PK_ProcessedTransactionInfos", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProcessedTransactionInfos_TransactionErrors_transaction_error_id",
                        column: x => x.transaction_error_id,
                        principalTable: "TransactionErrors",
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
                    { 1, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5123), null, "waterball208@gmail.com", false, "Quốc tổ Hùng Vương", "hungvuong123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5124), "hungvuong" },
                    { 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5128), null, "waterball208@gmail.com", false, "Hai Bà Trưng", "haibatrung123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5128), "haibatrung" },
                    { 3, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5131), null, "waterball208@gmail.com", false, "Lý Nam Đế", "lynamde123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5131), "lynamde" },
                    { 4, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5133), null, "waterball208@gmail.com", false, "Ngô Quyền", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5134), "ngoquyen" },
                    { 5, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5136), null, "waterball208@gmail.com", false, "Đinh Bộ Lĩnh", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5137), "dinhbolinh" },
                    { 6, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5139), null, "waterball208@gmail.com", false, "Lê Hoàn", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5140), "lehoan123" },
                    { 7, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5142), null, "waterball208@gmail.com", false, "Lý Công Uẩn", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5142), "lyconguan" },
                    { 8, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5144), null, "waterball208@gmail.com", false, "Lý Thường Kiệt", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5145), "lythuongkiet" },
                    { 9, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5146), null, "waterball208@gmail.com", false, "Trần Nhân Tông", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5147), "trannhantong" },
                    { 10, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5149), null, "waterball208@gmail.com", false, "Trần Hưng Đạo", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5149), "tranhungdao" },
                    { 11, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5151), null, "waterball208@gmail.com", false, "Lê Lợi", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5152), "leloi123" },
                    { 12, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5154), null, "waterball208@gmail.com", false, "Nguyễn Trãi", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5154), "nguyentrai" },
                    { 13, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5156), null, "waterball208@gmail.com", false, "Nguyễn Huệ", "pass123", "0987654321", 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5157), "quangtrung" },
                    { 14, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5159), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5159), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "categories", "code", "content", "create_at", "create_by", "desctiption", "image", "is_delete", "link", "name", "price", "quantity", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, "DH31UIHI3", "Tài khoản Chat GBT /n TK: admin /n MK: admin", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5337), 14, null, null, false, "#", "Tài khoản Chat GBT", 1000, 100, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5338), 14 },
                    { 2, 2, "SOD2IF6AP8F", "Tài khoản Chat GBT /n TK: admin /n MK: admin", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5341), 14, null, null, false, "#", "Tài khoản Canvas", 1000, 100, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5341), 14 },
                    { 3, 3, "AL6HEB14E", "Tài khoản Chat GBT /n TK: admin /n MK: admin", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5344), 14, null, null, false, "#", "Code Game", 1000, 100, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5345), 14 },
                    { 4, 1, "IH189AOFA31OH", "Tài khoản Chat GBT /n TK: admin /n MK: admin", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5347), 14, null, null, false, "#", "Tài Khoản Game", 1000, 100, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5347), 14 },
                    { 5, 2, "JVY8F1KB4VOL", "Tài khoản Chat GBT /n TK: admin /n MK: admin", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5349), 14, null, null, false, "#", "Tài Khoản Facebook", 1000, 100, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5350), 14 },
                    { 6, 3, "PO0PM7MO9J", "Tài khoản Chat GBT /n TK: admin /n MK: admin", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5352), 14, null, null, false, "#", "Win bản quyền", 1000, 100, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5353), 14 },
                    { 7, 1, "ATF142DW4YT", "Tài khoản Chat GBT /n TK: admin /n MK: admin", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5355), 14, null, null, false, "#", "Office bản quyền", 1000, 100, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5355), 14 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5179), 1 },
                    { 2, 2, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5181), 2 },
                    { 3, 3, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5182), 3 },
                    { 4, 4, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5184), 4 },
                    { 5, 5, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5186), 5 },
                    { 6, 6, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5187), 6 },
                    { 7, 7, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5189), 7 },
                    { 8, 8, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5190), 8 },
                    { 9, 9, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5191), 9 },
                    { 10, 10, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5192), 10 },
                    { 11, 11, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5194), 11 },
                    { 12, 12, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5195), 12 },
                    { 13, 13, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5196), 13 },
                    { 14, 14, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5197), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "desctiption", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5216), 1, null, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5218), 1, 1 },
                    { 2, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5221), 2, null, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5222), 2, 2 },
                    { 3, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5223), 3, null, 500, false, "error", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5224), 3, 3 },
                    { 4, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5226), 4, null, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5226), 4, 4 },
                    { 5, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5228), 5, null, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5229), 5, 5 },
                    { 6, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5231), 6, null, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5231), 6, 6 },
                    { 7, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5233), 7, null, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5234), 7, 7 },
                    { 8, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5236), 8, null, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5237), 8, 8 },
                    { 9, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5239), 9, null, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5239), 9, 9 },
                    { 10, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5241), 10, null, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5241), 10, 10 },
                    { 11, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5243), 11, null, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5244), 11, 11 },
                    { 12, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5246), 12, null, 500, false, "error", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5246), 12, 12 },
                    { 13, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5248), 13, null, 500, false, "error", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5248), 13, 13 },
                    { 14, 10000, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5250), 14, null, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5251), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "TransactionErrors",
                columns: new[] { "id", "create_at", "create_by", "description", "status", "title", "type", "wallet_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5370), 1, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 1 },
                    { 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5372), 4, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 4 },
                    { 3, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5373), 7, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 7 },
                    { 4, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5375), 10, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 10 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, "TP Bank", "789654312", "Quốc Tổ Hùng Vương", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5278), 1, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5278), 1, 1 },
                    { 2, 10000, "TP Bank", "789654312", "Hai Bà Trưng", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5282), 2, 500, false, "error", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5282), 2, 2 },
                    { 3, 10000, "TP Bank", "789654312", "Lý Nam Đế", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5285), 3, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5285), 3, 3 },
                    { 4, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5287), 4, 500, false, "error", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5288), 4, 4 },
                    { 5, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5290), 5, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5290), 5, 5 },
                    { 6, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5293), 6, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5293), 6, 6 },
                    { 7, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5296), 7, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5297), 7, 7 },
                    { 8, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5299), 8, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5299), 8, 8 },
                    { 9, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5301), 9, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5302), 9, 9 },
                    { 10, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5304), 10, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5304), 10, 10 },
                    { 11, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5307), 11, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5307), 11, 11 },
                    { 12, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5309), 12, 500, false, "done", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5310), 12, 12 },
                    { 13, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5312), 13, 500, false, "pending", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5313), 13, 13 },
                    { 14, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5315), 14, 500, false, "error", new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5316), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "ProcessedTransactionInfos",
                columns: new[] { "id", "create_at", "create_by", "processed_message", "transaction_error_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5387), 14, "Đã xử lí", 4 },
                    { 2, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5389), 14, "Đã xử lí", 3 },
                    { 3, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5391), 14, "Đã xử lí", 1 },
                    { 4, new DateTime(2024, 2, 21, 13, 34, 1, 221, DateTimeKind.Local).AddTicks(5392), 14, "Đã xử lí", 2 }
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
                name: "IX_ProcessedTransactionInfos_transaction_error_id",
                table: "ProcessedTransactionInfos",
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
                name: "IX_TransactionErrors_wallet_id",
                table: "TransactionErrors",
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
                name: "ProcessedTransactionInfos");

            migrationBuilder.DropTable(
                name: "Withdrawals");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TransactionErrors");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountRoles");
        }
    }
}
