using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    public partial class UpdateWallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Deposits");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Withdrawals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Deposits",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

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
                    { 1, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2503), null, "waterball208@gmail.com", false, "Quốc tổ Hùng Vương", "hungvuong123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2503), "hungvuong" },
                    { 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2505), null, "waterball208@gmail.com", false, "Hai Bà Trưng", "haibatrung123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2506), "haibatrung" },
                    { 3, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2507), null, "waterball208@gmail.com", false, "Lý Nam Đế", "lynamde123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2508), "lynamde" },
                    { 4, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2509), null, "waterball208@gmail.com", false, "Ngô Quyền", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2510), "ngoquyen" },
                    { 5, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2512), null, "waterball208@gmail.com", false, "Đinh Bộ Lĩnh", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2512), "dinhbolinh" },
                    { 6, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2514), null, "waterball208@gmail.com", false, "Lê Hoàn", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2514), "lehoan123" },
                    { 7, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2516), null, "waterball208@gmail.com", false, "Lý Công Uẩn", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2516), "lyconguan" },
                    { 8, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2517), null, "waterball208@gmail.com", false, "Lý Thường Kiệt", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2518), "lythuongkiet" },
                    { 9, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2519), null, "waterball208@gmail.com", false, "Trần Nhân Tông", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2520), "trannhantong" },
                    { 10, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2521), null, "waterball208@gmail.com", false, "Trần Hưng Đạo", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2522), "tranhungdao" },
                    { 11, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2523), null, "waterball208@gmail.com", false, "Lê Lợi", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2524), "leloi123" },
                    { 12, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2526), null, "waterball208@gmail.com", false, "Nguyễn Trãi", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2526), "nguyentrai" },
                    { 13, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2527), null, "waterball208@gmail.com", false, "Nguyễn Huệ", "pass123", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2528), "quangtrung" },
                    { 14, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2533), null, "waterball208@gmail.com", false, "Admin", "admin", "0987654321", 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2533), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "categories", "code", "create_at", "create_by", "desctiption", "image", "is_delete", "link", "price", "quantity", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, "DH31UIHI3", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2665), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2666), 14 },
                    { 2, 2, "SOD2IF6AP8F", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2668), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2668), 14 },
                    { 3, 3, "AL6HEB14E", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2670), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2671), 14 },
                    { 4, 1, "IH189AOFA31OH", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2672), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2673), 14 },
                    { 5, 2, "JVY8F1KB4VOL", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2674), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2675), 14 },
                    { 6, 3, "PO0PM7MO9J", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2676), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2677), 14 },
                    { 7, 1, "ATF142DW4YT", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2678), 14, null, null, false, "#", 1000, 100, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2679), 14 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "id", "account_id", "balance", "update_at", "update_by" },
                values: new object[,]
                {
                    { 1, 1, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2555), 1 },
                    { 2, 2, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2556), 2 },
                    { 3, 3, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2557), 3 },
                    { 4, 4, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2558), 4 },
                    { 5, 5, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2559), 5 },
                    { 6, 6, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2560), 6 },
                    { 7, 7, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2561), 7 },
                    { 8, 8, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2562), 8 },
                    { 9, 9, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2563), 9 },
                    { 10, 10, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2565), 10 },
                    { 11, 11, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2565), 11 },
                    { 12, 12, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2566), 12 },
                    { 13, 13, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2567), 13 },
                    { 14, 14, 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2568), 14 }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "id", "amount", "create_at", "create_by", "desctiption", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2582), 1, null, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2583), 1, 1 },
                    { 2, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2585), 2, null, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2585), 2, 2 },
                    { 3, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2587), 3, null, 500, false, "error", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2587), 3, 3 },
                    { 4, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2589), 4, null, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2590), 4, 4 },
                    { 5, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2591), 5, null, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2591), 5, 5 },
                    { 6, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2593), 6, null, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2593), 6, 6 },
                    { 7, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2595), 7, null, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2595), 7, 7 },
                    { 8, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2597), 8, null, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2597), 8, 8 },
                    { 9, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2598), 9, null, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2599), 9, 9 },
                    { 10, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2600), 10, null, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2601), 10, 10 },
                    { 11, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2602), 11, null, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2603), 11, 11 },
                    { 12, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2604), 12, null, 500, false, "error", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2604), 12, 12 },
                    { 13, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2606), 13, null, 500, false, "error", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2606), 13, 13 },
                    { 14, 10000, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2608), 14, null, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2608), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "TransactionError",
                columns: new[] { "id", "create_at", "create_by", "description", "status", "title", "type", "wallet_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2691), 1, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 1 },
                    { 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2692), 4, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 4 },
                    { 3, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2697), 7, "Lỗi Nạp tiền", "done", "Lỗi Nạp Tiền", "Deposit", 7 },
                    { 4, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2699), 10, "Lỗi rút tiền", "pending", "Lỗi rút Tiền", "Withdrawal", 10 }
                });

            migrationBuilder.InsertData(
                table: "Withdrawals",
                columns: new[] { "id", "amount", "bank_name", "bank_number", "bank_user", "create_at", "create_by", "fee", "is_delete", "status", "update_at", "update_by", "wallet_id" },
                values: new object[,]
                {
                    { 1, 10000, "TP Bank", "789654312", "Quốc Tổ Hùng Vương", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2622), 1, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2623), 1, 1 },
                    { 2, 10000, "TP Bank", "789654312", "Hai Bà Trưng", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2625), 2, 500, false, "error", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2625), 2, 2 },
                    { 3, 10000, "TP Bank", "789654312", "Lý Nam Đế", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2628), 3, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2628), 3, 3 },
                    { 4, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2630), 4, 500, false, "error", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2630), 4, 4 },
                    { 5, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2632), 5, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2632), 5, 5 },
                    { 6, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2634), 6, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2634), 6, 6 },
                    { 7, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2636), 7, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2636), 7, 7 },
                    { 8, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2638), 8, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2638), 8, 8 },
                    { 9, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2640), 9, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2640), 9, 9 },
                    { 10, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2642), 10, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2642), 10, 10 },
                    { 11, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2644), 11, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2644), 11, 11 },
                    { 12, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2646), 12, 500, false, "done", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2646), 12, 12 },
                    { 13, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2648), 13, 500, false, "pending", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2648), 13, 13 },
                    { 14, 10000, "TP Bank", "789654312", "Bank User Name", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2650), 14, 500, false, "error", new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2651), 14, 14 }
                });

            migrationBuilder.InsertData(
                table: "ProcessedTransactionInfo",
                columns: new[] { "id", "create_at", "create_by", "processed_message", "transaction_error_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2709), 14, "Đã xử lí", 4 },
                    { 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2711), 14, "Đã xử lí", 3 },
                    { 3, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2712), 14, "Đã xử lí", 1 },
                    { 4, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2713), 14, "Đã xử lí", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessedTransactionInfo_transaction_error_id",
                table: "ProcessedTransactionInfo",
                column: "transaction_error_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionError_wallet_id",
                table: "TransactionError",
                column: "wallet_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessedTransactionInfo");

            migrationBuilder.DropTable(
                name: "TransactionError");

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Withdrawals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Deposits",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
