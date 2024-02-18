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
                    { 1, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(58), null, "waterball208@gmail.com", false, "Quốc tổ Hùng Vương", "hungvuong123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(59), "hungvuong" },
                    { 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(62), null, "waterball208@gmail.com", false, "Hai Bà Trưng", "haibatrung123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(63), "haibatrung" },
                    { 3, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(65), null, "waterball208@gmail.com", false, "Lý Nam Đế", "lynamde123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(66), "lynamde" },
                    { 4, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(68), null, "waterball208@gmail.com", false, "Ngô Quyền", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(69), "ngoquyen" },
                    { 5, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(71), null, "waterball208@gmail.com", false, "Đinh Bộ Lĩnh", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(72), "dinhbolinh" },
                    { 6, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(74), null, "waterball208@gmail.com", false, "Lê Hoàn", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(75), "lehoan123" },
                    { 7, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(78), null, "waterball208@gmail.com", false, "Lý Công Uẩn", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(79), "lyconguan" },
                    { 8, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(81), null, "waterball208@gmail.com", false, "Lý Thường Kiệt", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(82), "lythuongkiet" },
                    { 9, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(84), null, "waterball208@gmail.com", false, "Trần Nhân Tông", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(85), "trannhantong" },
                    { 10, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(87), null, "waterball208@gmail.com", false, "Trần Hưng Đạo", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(87), "tranhungdao" },
                    { 11, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(90), null, "waterball208@gmail.com", false, "Lê Lợi", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(90), "leloi123" },
                    { 12, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(94), null, "waterball208@gmail.com", false, "Nguyễn Trãi", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(94), "nguyentrai" },
                    { 13, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(96), null, "waterball208@gmail.com", false, "Nguyễn Huệ", "pass123", "0987654321", 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(97), "quangtrung" },
                    { 14, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(99), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 1, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(100), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "categories", "code", "create_at", "create_by", "desctiption", "image", "is_delete", "link", "price", "quantity", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, "DH31UIHI3", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(295), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(296), 14 },
                    { 2, 2, "SOD2IF6AP8F", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(300), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(300), 14 },
                    { 3, 3, "AL6HEB14E", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(303), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(304), 14 },
                    { 4, 1, "IH189AOFA31OH", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(306), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(306), 14 },
                    { 5, 2, "JVY8F1KB4VOL", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(309), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(310), 14 },
                    { 6, 3, "PO0PM7MO9J", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(312), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(312), 14 },
                    { 7, 1, "ATF142DW4YT", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(315), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(315), 14 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(123), 1 },
                    { 2, 2, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(126), 2 },
                    { 3, 3, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(127), 3 },
                    { 4, 4, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(128), 4 },
                    { 5, 5, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(136), 5 },
                    { 6, 6, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(137), 6 },
                    { 7, 7, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(139), 7 },
                    { 8, 8, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(140), 8 },
                    { 9, 9, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(142), 9 },
                    { 10, 10, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(143), 10 },
                    { 11, 11, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(144), 11 },
                    { 12, 12, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(146), 12 },
                    { 13, 13, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(147), 13 },
                    { 14, 14, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(149), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "desctiption", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(172), 1, null, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(173), 1, 1 },
                    { 2, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(177), 2, null, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(177), 2, 2 },
                    { 3, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(179), 3, null, 500, false, "error", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(180), 3, 3 },
                    { 4, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(182), 4, null, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(183), 4, 4 },
                    { 5, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(185), 5, null, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(186), 5, 5 },
                    { 6, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(188), 6, null, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(188), 6, 6 },
                    { 7, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(190), 7, null, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(191), 7, 7 },
                    { 8, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(193), 8, null, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(194), 8, 8 },
                    { 9, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(196), 9, null, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(197), 9, 9 },
                    { 10, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(199), 10, null, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(199), 10, 10 },
                    { 11, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(201), 11, null, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(202), 11, 11 },
                    { 12, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(204), 12, null, 500, false, "error", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(205), 12, 12 },
                    { 13, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(207), 13, null, 500, false, "error", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(207), 13, 13 },
                    { 14, 10000, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(210), 14, null, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(210), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "TransactionError",
                columns: new[] { "id", "create_at", "create_by", "description", "status", "title", "type", "wallet_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(332), 1, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 1 },
                    { 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(335), 4, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 4 },
                    { 3, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(337), 7, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 7 },
                    { 4, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(338), 10, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 10 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, "TP Bank", "789654312", "Quốc Tổ Hùng Vương", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(232), 1, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(233), 1, 1 },
                    { 2, 10000, "TP Bank", "789654312", "Hai Bà Trưng", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(236), 2, 500, false, "error", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(237), 2, 2 },
                    { 3, 10000, "TP Bank", "789654312", "Lý Nam Đế", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(240), 3, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(240), 3, 3 },
                    { 4, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(243), 4, 500, false, "error", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(243), 4, 4 },
                    { 5, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(246), 5, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(246), 5, 5 },
                    { 6, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(249), 6, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(249), 6, 6 },
                    { 7, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(252), 7, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(252), 7, 7 },
                    { 8, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(255), 8, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(255), 8, 8 },
                    { 9, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(258), 9, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(258), 9, 9 },
                    { 10, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(261), 10, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(261), 10, 10 },
                    { 11, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(264), 11, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(264), 11, 11 },
                    { 12, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(268), 12, 500, false, "done", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(269), 12, 12 },
                    { 13, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(272), 13, 500, false, "pending", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(273), 13, 13 },
                    { 14, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(275), 14, 500, false, "error", new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(276), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "ProcessedTransactionInfo",
                columns: new[] { "id", "create_at", "create_by", "processed_message", "transaction_error_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(355), 14, "Đã xử lí", 4 },
                    { 2, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(357), 14, "Đã xử lí", 3 },
                    { 3, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(359), 14, "Đã xử lí", 1 },
                    { 4, new DateTime(2024, 2, 18, 20, 47, 4, 910, DateTimeKind.Local).AddTicks(360), 14, "Đã xử lí", 2 }
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
