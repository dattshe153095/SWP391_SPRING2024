using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5387), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5388) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5391), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5391) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5393), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5393) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5394), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5395) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5396), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5397) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5398), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5400), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5402), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5402) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5404), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5404) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5405), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5406) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5407), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5407) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5410), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5413), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5414) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "role_id", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5415), 1, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5458), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5459) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5460), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5461) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5462), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5468), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5469) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5470), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5472), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5472) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5474), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5474) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5476), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5476) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5477), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5478) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5479), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5481), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5483), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5485), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5486), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5487) });

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfo",
                keyColumn: "id",
                keyValue: 1,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfo",
                keyColumn: "id",
                keyValue: 2,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfo",
                keyColumn: "id",
                keyValue: 3,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfo",
                keyColumn: "id",
                keyValue: 4,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5546), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5547) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5549), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5551), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5552) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5553), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5553) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5555), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5555) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5557), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5557) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5559), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5559) });

            migrationBuilder.UpdateData(
                table: "TransactionError",
                keyColumn: "id",
                keyValue: 1,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "TransactionError",
                keyColumn: "id",
                keyValue: 2,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "TransactionError",
                keyColumn: "id",
                keyValue: 3,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "TransactionError",
                keyColumn: "id",
                keyValue: 4,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5431) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5432) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5433) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5434) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5436) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5438) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5439) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5441) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5443) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5444) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5503), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5503) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5506), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5508), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5510), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5510) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5512), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5512) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5514), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5516), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5518), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5518) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5519), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5521), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5522) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5523), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5524) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5528), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5530), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5532), new DateTime(2024, 2, 15, 15, 32, 32, 13, DateTimeKind.Local).AddTicks(5532) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2503), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2503) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2505), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2507), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2508) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2509), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2510) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2512), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2512) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2514), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2514) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2516), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2517), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2518) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2519), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2520) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2521), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2522) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2523), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2524) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2526), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2527), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2528) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "role_id", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2533), 2, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2533) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2582), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2585), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2585) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2587), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2587) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2589), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2590) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2591), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2591) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2593), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2593) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2595), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2595) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2597), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2597) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2598), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2599) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2600), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2601) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2602), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2603) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2604), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2604) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2606), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2606) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2608), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfo",
                keyColumn: "id",
                keyValue: 1,
                column: "create_at",
                value: new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfo",
                keyColumn: "id",
                keyValue: 2,
                column: "create_at",
                value: new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfo",
                keyColumn: "id",
                keyValue: 3,
                column: "create_at",
                value: new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfo",
                keyColumn: "id",
                keyValue: 4,
                column: "create_at",
                value: new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2665), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2666) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2668), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2668) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2670), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2671) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2672), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2673) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2674), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2675) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2676), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2677) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2678), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2679) });

            migrationBuilder.UpdateData(
                table: "TransactionError",
                keyColumn: "id",
                keyValue: 1,
                column: "create_at",
                value: new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "TransactionError",
                keyColumn: "id",
                keyValue: 2,
                column: "create_at",
                value: new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "TransactionError",
                keyColumn: "id",
                keyValue: 3,
                column: "create_at",
                value: new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "TransactionError",
                keyColumn: "id",
                keyValue: 4,
                column: "create_at",
                value: new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2699));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2556) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2558) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2559) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2560) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2561) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2562) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2563) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2565) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2565) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2566) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 0, new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2568) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2622), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2623) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2625), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2625) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2628), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2628) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2630), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2632), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2632) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2634), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2634) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2636), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2636) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2638), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2638) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2640), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2642), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2642) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2644), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2646), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2646) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2648), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2648) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2650), new DateTime(2024, 2, 11, 23, 28, 55, 722, DateTimeKind.Local).AddTicks(2651) });
        }
    }
}
