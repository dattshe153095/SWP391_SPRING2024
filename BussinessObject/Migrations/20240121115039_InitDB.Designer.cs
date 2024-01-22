﻿// <auto-generated />
using System;
using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BussinessObject.Migrations
{
    [DbContext(typeof(Web_Trung_GianContext))]
    [Migration("20240121115039_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BussinessObject.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_delete")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.HasIndex("role_id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BussinessObject.Models.AccountRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("desctiption")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("id");

                    b.ToTable("AccountRoles");
                });

            modelBuilder.Entity("BussinessObject.Models.Deposit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("create_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("desctiption")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("fee")
                        .HasColumnType("int");

                    b.Property<bool>("is_delete")
                        .HasColumnType("bit");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("update_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("wallet_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("create_by");

                    b.HasIndex("update_by");

                    b.HasIndex("wallet_id");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("BussinessObject.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("account_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("create_by")
                        .HasColumnType("int");

                    b.Property<bool>("is_delete")
                        .HasColumnType("bit");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("total_price")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("update_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("account_id");

                    b.HasIndex("create_by");

                    b.HasIndex("product_id");

                    b.HasIndex("update_by");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BussinessObject.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("categories")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("create_by")
                        .HasColumnType("int");

                    b.Property<string>("desctiption")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("image")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("is_delete")
                        .HasColumnType("bit");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("update_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("create_by");

                    b.HasIndex("update_by");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BussinessObject.Models.Wallet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("account_id")
                        .HasColumnType("int");

                    b.Property<int>("balance")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("update_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("account_id");

                    b.HasIndex("update_by");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("BussinessObject.Models.Withdrawal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("bank_name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("bank_number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("bank_user")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("create_by")
                        .HasColumnType("int");

                    b.Property<int>("fee")
                        .HasColumnType("int");

                    b.Property<bool>("is_delete")
                        .HasColumnType("bit");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("update_by")
                        .HasColumnType("int");

                    b.Property<int>("wallet_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("create_by");

                    b.HasIndex("update_by");

                    b.HasIndex("wallet_id");

                    b.ToTable("Withdrawals");
                });

            modelBuilder.Entity("BussinessObject.Models.Account", b =>
                {
                    b.HasOne("BussinessObject.Models.AccountRole", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BussinessObject.Models.Deposit", b =>
                {
                    b.HasOne("BussinessObject.Models.Account", "AccountCreate")
                        .WithMany("DepositCreates")
                        .HasForeignKey("create_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Account", "AccountUpdate")
                        .WithMany("DepositUpdates")
                        .HasForeignKey("update_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Wallet", "Wallet")
                        .WithMany("Deposits")
                        .HasForeignKey("wallet_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AccountCreate");

                    b.Navigation("AccountUpdate");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("BussinessObject.Models.Order", b =>
                {
                    b.HasOne("BussinessObject.Models.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("account_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Account", "AccountCreate")
                        .WithMany("OrderCreates")
                        .HasForeignKey("create_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Account", "AccountUpdate")
                        .WithMany("OrderUpdate")
                        .HasForeignKey("update_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("AccountCreate");

                    b.Navigation("AccountUpdate");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BussinessObject.Models.Product", b =>
                {
                    b.HasOne("BussinessObject.Models.Account", "AccountCreate")
                        .WithMany("ProductCreates")
                        .HasForeignKey("create_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Account", "AccountUpdate")
                        .WithMany("ProductUpdates")
                        .HasForeignKey("update_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AccountCreate");

                    b.Navigation("AccountUpdate");
                });

            modelBuilder.Entity("BussinessObject.Models.Wallet", b =>
                {
                    b.HasOne("BussinessObject.Models.Account", "Account")
                        .WithMany("Wallets")
                        .HasForeignKey("account_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Account", "AccountUpdate")
                        .WithMany("WalletUpdates")
                        .HasForeignKey("update_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("AccountUpdate");
                });

            modelBuilder.Entity("BussinessObject.Models.Withdrawal", b =>
                {
                    b.HasOne("BussinessObject.Models.Account", "AccountCreate")
                        .WithMany("WithdrawalCreates")
                        .HasForeignKey("create_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Account", "AccountUpdate")
                        .WithMany("WithdrawalUpdates")
                        .HasForeignKey("update_by")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Wallet", "Wallet")
                        .WithMany("Withdrawals")
                        .HasForeignKey("wallet_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AccountCreate");

                    b.Navigation("AccountUpdate");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("BussinessObject.Models.Account", b =>
                {
                    b.Navigation("DepositCreates");

                    b.Navigation("DepositUpdates");

                    b.Navigation("OrderCreates");

                    b.Navigation("OrderUpdate");

                    b.Navigation("Orders");

                    b.Navigation("ProductCreates");

                    b.Navigation("ProductUpdates");

                    b.Navigation("WalletUpdates");

                    b.Navigation("Wallets");

                    b.Navigation("WithdrawalCreates");

                    b.Navigation("WithdrawalUpdates");
                });

            modelBuilder.Entity("BussinessObject.Models.AccountRole", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BussinessObject.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BussinessObject.Models.Wallet", b =>
                {
                    b.Navigation("Deposits");

                    b.Navigation("Withdrawals");
                });
#pragma warning restore 612, 618
        }
    }
}
