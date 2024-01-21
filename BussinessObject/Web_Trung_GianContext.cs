using System;
using System.Collections.Generic;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BussinessObject
{
    public class Web_Trung_GianContext : DbContext
    {
        public Web_Trung_GianContext()
        {
        }

        public Web_Trung_GianContext(DbContextOptions<Web_Trung_GianContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost;database=Web_Trung_Gian;uid=sa;pwd=123456;TrustServerCertificate=True;");
            }
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Withdrawal> Withdrawals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.id);

                entity.HasOne(a => a.Role)
                    .WithMany(r => r.Accounts)
                    .HasForeignKey(a => a.role_id);

                //WALLET
                entity.HasOne(a => a.Wallet)
                    .WithOne(w => w.Account)
                    .HasForeignKey<Wallet>(w => w.account_id);

                entity.HasMany(a => a.WalletUpdates)
                .WithOne(o => o.Account)
                .HasForeignKey(o => o.update_by);

                //ORDER
                entity.HasMany(a => a.Orders)
                    .WithOne(o => o.Account)
                    .HasForeignKey(o => o.account_id);

                entity.HasMany(a => a.OrderCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by);

                entity.HasMany(a => a.OrderUpdate)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by);

                //PRODUCT
                entity.HasMany(a => a.ProductCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by);


                entity.HasMany(a => a.ProductUpdates)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by);

                //DEPOSIT
                entity.HasMany(a => a.DepositCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by);


                entity.HasMany(a => a.DepositUpdates)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by);

                //WITHDRAWAL
                entity.HasMany(a => a.WithdrawalCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by);


                entity.HasMany(a => a.WithdrawalUpdates)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by);

            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(a => a.id);

                entity.HasOne(w => w.Account)
                     .WithOne(a => a.Wallet)
                     .HasForeignKey<Account>(w => w.wallet_id);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.id);
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Wallet)
                .WithMany(w => w.Deposits)
                .HasForeignKey(d => d.wallet_id);
            });

            modelBuilder.Entity<Withdrawal>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Wallet)
                .WithMany(w => w.Withdrawals)
                .HasForeignKey(d => d.wallet_id);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Product)
                .WithMany(w => w.Orders)
                .HasForeignKey(d => d.product_id);

                entity.HasOne(a => a.Account)
                .WithMany(w => w.Orders)
                .HasForeignKey(o => o.account_id);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasMany(p => p.Orders)
                .WithOne(w => w.Product)
                .HasForeignKey(d => d.product_id);
            });


            base.OnModelCreating(modelBuilder);
        }


    }


}
