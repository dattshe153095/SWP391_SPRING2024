using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
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
                    { 1, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2364), null, "waterball208@gmail.com", false, "Quốc tổ Hùng Vương", "hungvuong123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2365), "hungvuong" },
                    { 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2368), null, "waterball208@gmail.com", false, "Hai Bà Trưng", "haibatrung123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2368), "haibatrung" },
                    { 3, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2370), null, "waterball208@gmail.com", false, "Lý Nam Đế", "lynamde123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2371), "lynamde" },
                    { 4, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2373), null, "waterball208@gmail.com", false, "Ngô Quyền", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2373), "ngoquyen" },
                    { 5, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2375), null, "waterball208@gmail.com", false, "Đinh Bộ Lĩnh", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2375), "dinhbolinh" },
                    { 6, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2377), null, "waterball208@gmail.com", false, "Lê Hoàn", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2378), "lehoan123" },
                    { 7, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2379), null, "waterball208@gmail.com", false, "Lý Công Uẩn", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2380), "lyconguan" },
                    { 8, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2382), null, "waterball208@gmail.com", false, "Lý Thường Kiệt", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2383), "lythuongkiet" },
                    { 9, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2385), null, "waterball208@gmail.com", false, "Trần Nhân Tông", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2385), "trannhantong" },
                    { 10, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2387), null, "waterball208@gmail.com", false, "Trần Hưng Đạo", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2387), "tranhungdao" },
                    { 11, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2389), null, "waterball208@gmail.com", false, "Lê Lợi", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2390), "leloi123" },
                    { 12, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2392), null, "waterball208@gmail.com", false, "Nguyễn Trãi", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2392), "nguyentrai" },
                    { 13, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2394), null, "waterball208@gmail.com", false, "Nguyễn Huệ", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2394), "quangtrung" },
                    { 14, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2396), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2397), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "categories", "code", "create_at", "create_by", "desctiption", "image", "is_delete", "link", "price", "quantity", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, "DH31UIHI3", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2558), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2559), 14 },
                    { 2, 2, "SOD2IF6AP8F", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2562), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2562), 14 },
                    { 3, 3, "AL6HEB14E", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2564), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2565), 14 },
                    { 4, 1, "IH189AOFA31OH", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2567), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2567), 14 },
                    { 5, 2, "JVY8F1KB4VOL", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2569), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2569), 14 },
                    { 6, 3, "PO0PM7MO9J", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2571), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2572), 14 },
                    { 7, 1, "ATF142DW4YT", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2574), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2574), 14 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2415), 1 },
                    { 2, 2, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2417), 2 },
                    { 3, 3, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2418), 3 },
                    { 4, 4, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2419), 4 },
                    { 5, 5, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2420), 5 },
                    { 6, 6, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2422), 6 },
                    { 7, 7, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2423), 7 },
                    { 8, 8, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2424), 8 },
                    { 9, 9, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2425), 9 },
                    { 10, 10, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2426), 10 },
                    { 11, 11, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2428), 11 },
                    { 12, 12, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2430), 12 },
                    { 13, 13, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2431), 13 },
                    { 14, 14, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2432), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "desctiption", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2456), 1, null, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2457), 1, 1 },
                    { 2, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2459), 2, null, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2460), 2, 2 },
                    { 3, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2461), 3, null, 500, false, "error", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2462), 3, 3 },
                    { 4, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2464), 4, null, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2465), 4, 4 },
                    { 5, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2467), 5, null, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2467), 5, 5 },
                    { 6, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2469), 6, null, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2469), 6, 6 },
                    { 7, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2471), 7, null, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2471), 7, 7 },
                    { 8, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2473), 8, null, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2474), 8, 8 },
                    { 9, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2475), 9, null, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2476), 9, 9 },
                    { 10, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2478), 10, null, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2478), 10, 10 },
                    { 11, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2480), 11, null, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2480), 11, 11 },
                    { 12, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2483), 12, null, 500, false, "error", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2484), 12, 12 },
                    { 13, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2485), 13, null, 500, false, "error", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2486), 13, 13 },
                    { 14, 10000, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2487), 14, null, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2488), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "TransactionErrors",
                columns: new[] { "id", "create_at", "create_by", "description", "status", "title", "type", "wallet_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2587), 1, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 1 },
                    { 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2589), 4, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 4 },
                    { 3, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2591), 7, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 7 },
                    { 4, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2593), 10, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 10 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, "TP Bank", "789654312", "Quốc Tổ Hùng Vương", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2507), 1, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2508), 1, 1 },
                    { 2, 10000, "TP Bank", "789654312", "Hai Bà Trưng", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2511), 2, 500, false, "error", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2512), 2, 2 },
                    { 3, 10000, "TP Bank", "789654312", "Lý Nam Đế", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2514), 3, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2514), 3, 3 },
                    { 4, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2516), 4, 500, false, "error", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2517), 4, 4 },
                    { 5, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2519), 5, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2520), 5, 5 },
                    { 6, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2521), 6, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2522), 6, 6 },
                    { 7, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2524), 7, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2524), 7, 7 },
                    { 8, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2526), 8, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2527), 8, 8 },
                    { 9, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2529), 9, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2530), 9, 9 },
                    { 10, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2532), 10, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2532), 10, 10 },
                    { 11, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2534), 11, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2535), 11, 11 },
                    { 12, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2536), 12, 500, false, "done", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2537), 12, 12 },
                    { 13, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2539), 13, 500, false, "pending", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2539), 13, 13 },
                    { 14, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2541), 14, 500, false, "error", new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2542), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "ProcessedTransactionInfos",
                columns: new[] { "id", "create_at", "create_by", "processed_message", "transaction_error_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2605), 14, "Đã xử lí", 4 },
                    { 2, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2607), 14, "Đã xử lí", 3 },
                    { 3, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2608), 14, "Đã xử lí", 1 },
                    { 4, new DateTime(2024, 2, 18, 13, 47, 30, 347, DateTimeKind.Local).AddTicks(2610), 14, "Đã xử lí", 2 }
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
