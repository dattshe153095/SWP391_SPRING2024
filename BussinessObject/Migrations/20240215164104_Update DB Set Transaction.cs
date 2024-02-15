using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    public partial class UpdateDBSetTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessedTransactionInfo_TransactionError_transaction_error_id",
                table: "ProcessedTransactionInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionError_Wallets_wallet_id",
                table: "TransactionError");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionError",
                table: "TransactionError");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessedTransactionInfo",
                table: "ProcessedTransactionInfo");

            migrationBuilder.RenameTable(
                name: "TransactionError",
                newName: "TransactionErrors");

            migrationBuilder.RenameTable(
                name: "ProcessedTransactionInfo",
                newName: "ProcessedTransactionInfos");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionError_wallet_id",
                table: "TransactionErrors",
                newName: "IX_TransactionErrors_wallet_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessedTransactionInfo_transaction_error_id",
                table: "ProcessedTransactionInfos",
                newName: "IX_ProcessedTransactionInfos_transaction_error_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionErrors",
                table: "TransactionErrors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessedTransactionInfos",
                table: "ProcessedTransactionInfos",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4201), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4202) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4205), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4208), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4208) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4210), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4213), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4216), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4219), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4221), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4222) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4224), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4227), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4229), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4232), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4234), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4235) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "role_id", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4237), 1, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4295), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4298), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4299) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4301), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4301) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4303), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4306), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4306) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4309), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4311), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4313), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4322), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4322) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4324), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4325) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4326), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4327) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4329), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4331), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4332) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4334), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfos",
                keyColumn: "id",
                keyValue: 1,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfos",
                keyColumn: "id",
                keyValue: 2,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfos",
                keyColumn: "id",
                keyValue: 3,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "ProcessedTransactionInfos",
                keyColumn: "id",
                keyValue: 4,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4406), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4407) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4410), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4412), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4413) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4415), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4415) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4417), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4418) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4420), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4423), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4424) });

            migrationBuilder.UpdateData(
                table: "TransactionErrors",
                keyColumn: "id",
                keyValue: 1,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "TransactionErrors",
                keyColumn: "id",
                keyValue: 2,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "TransactionErrors",
                keyColumn: "id",
                keyValue: 3,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "TransactionErrors",
                keyColumn: "id",
                keyValue: 4,
                column: "create_at",
                value: new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4265) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4268) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4271) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4272) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4273) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "balance", "update_at" },
                values: new object[] { 10000, new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4276) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4352), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4356), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4356) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4359), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4359) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4361), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4365), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4365) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4367), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4370), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4372), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4373) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4376), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4377) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4379), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4382), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4382) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4384), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4385) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4387), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "Withdrawals",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4389), new DateTime(2024, 2, 15, 23, 41, 3, 147, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessedTransactionInfos_TransactionErrors_transaction_error_id",
                table: "ProcessedTransactionInfos",
                column: "transaction_error_id",
                principalTable: "TransactionErrors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionErrors_Wallets_wallet_id",
                table: "TransactionErrors",
                column: "wallet_id",
                principalTable: "Wallets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessedTransactionInfos_TransactionErrors_transaction_error_id",
                table: "ProcessedTransactionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionErrors_Wallets_wallet_id",
                table: "TransactionErrors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionErrors",
                table: "TransactionErrors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessedTransactionInfos",
                table: "ProcessedTransactionInfos");

            migrationBuilder.RenameTable(
                name: "TransactionErrors",
                newName: "TransactionError");

            migrationBuilder.RenameTable(
                name: "ProcessedTransactionInfos",
                newName: "ProcessedTransactionInfo");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionErrors_wallet_id",
                table: "TransactionError",
                newName: "IX_TransactionError_wallet_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessedTransactionInfos_transaction_error_id",
                table: "ProcessedTransactionInfo",
                newName: "IX_ProcessedTransactionInfo_transaction_error_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionError",
                table: "TransactionError",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessedTransactionInfo",
                table: "ProcessedTransactionInfo",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessedTransactionInfo_TransactionError_transaction_error_id",
                table: "ProcessedTransactionInfo",
                column: "transaction_error_id",
                principalTable: "TransactionError",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionError_Wallets_wallet_id",
                table: "TransactionError",
                column: "wallet_id",
                principalTable: "Wallets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
