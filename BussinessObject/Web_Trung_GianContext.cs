using BussinessObject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
                optionsBuilder.UseSqlServer("server=localhost;database=Web_Trung_Gian;uid=sa;pwd=123;TrustServerCertificate=True;");
            }
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
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
                    .HasForeignKey(a => a.role_id).OnDelete(DeleteBehavior.Restrict);

                //WALLET
                entity.HasMany(a => a.Wallets)
                    .WithOne(w => w.Account)
                    .HasForeignKey(w => w.account_id).OnDelete(DeleteBehavior.Restrict); ;

                entity.HasMany(a => a.WalletUpdates)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by).OnDelete(DeleteBehavior.Restrict); ;

                //ORDER
                entity.HasMany(a => a.Orders)
                    .WithOne(o => o.Account)
                    .HasForeignKey(o => o.account_id).OnDelete(DeleteBehavior.Restrict); ;

                entity.HasMany(a => a.OrderCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by).OnDelete(DeleteBehavior.Restrict); ;

                entity.HasMany(a => a.OrderUpdate)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by).OnDelete(DeleteBehavior.Restrict); ;

                //PRODUCT
                entity.HasMany(a => a.ProductCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by).OnDelete(DeleteBehavior.Restrict); ;


                entity.HasMany(a => a.ProductUpdates)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by).OnDelete(DeleteBehavior.Restrict);

                //DEPOSIT
                entity.HasMany(a => a.DepositCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by).OnDelete(DeleteBehavior.Restrict);


                entity.HasMany(a => a.DepositUpdates)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by).OnDelete(DeleteBehavior.Restrict);

                //WITHDRAWAL
                entity.HasMany(a => a.WithdrawalCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by).OnDelete(DeleteBehavior.Restrict);


                entity.HasMany(a => a.WithdrawalUpdates)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by).OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(a => a.id);
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.HasKey(r => r.id);
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Wallet)
                .WithMany(w => w.Deposits)
                .HasForeignKey(d => d.wallet_id).OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<Withdrawal>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Wallet)
                .WithMany(w => w.Withdrawals)
                .HasForeignKey(d => d.wallet_id).OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Product)
                .WithMany(w => w.Orders)
                .HasForeignKey(d => d.product_id).OnDelete(DeleteBehavior.Restrict); ;

                entity.HasOne(a => a.Account)
                .WithMany(w => w.Orders)
                .HasForeignKey(o => o.account_id).OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasMany(p => p.Orders)
                .WithOne(w => w.Product)
                .HasForeignKey(d => d.product_id).OnDelete(DeleteBehavior.Restrict); ;
            });


            base.OnModelCreating(modelBuilder);

        }


    }


}
