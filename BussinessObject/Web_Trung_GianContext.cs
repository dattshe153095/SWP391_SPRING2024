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

            // Init Data base
            modelBuilder.Entity<AccountRole>().HasData(
                new AccountRole { desctiption = "Admin" },
                new AccountRole { desctiption = "User" }
            );

            modelBuilder.Entity<Account>().HasData(
                 new Account { name = "Quốc tổ Hùng Vương", username = "hungvuong", email = "waterball208@gmail.com", phone = "0987654321", password = "hungvuong123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Hai Bà Trưng", username = "haibatrung", email = "waterball208@gmail.com", phone = "0987654321", password = "haibatrung123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Lý Nam Đế", username = "lynamde", email = "waterball208@gmail.com", phone = "0987654321", password = "lynamde123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Ngô Quyền", username = "ngoquyen", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Đinh Bộ Lĩnh", username = "dinhbolinh", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Lê Hoàn", username = "lehoan123", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Lý Công Uẩn", username = "lyconguan", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Lý Thường Kiệt", username = "lythuongkiet", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Trần Nhân Tông", username = "trannhantong", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Trần Hưng Đạo", username = "tranhungdao", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Lê Lợi", username = "leloi123", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Nguyễn Trãi", username = "nguyentrai", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Nguyễn Huệ", username = "quangtrung", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { name = "Admin", username = "admin", email = "waterball208@gmail.com", phone = "0987654321", password = "admin", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now }
             // Thêm dữ liệu mẫu khác nếu cần
             );

            modelBuilder.Entity<Wallet>().HasData(
                new Wallet { balance = 0, account_id = 1, update_by = 1, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 2, update_by = 2, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 3, update_by = 3, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 4, update_by = 4, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 5, update_by = 5, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 6, update_by = 6, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 7, update_by = 7, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 8, update_by = 8, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 9, update_by = 9, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 10, update_by = 10, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 11, update_by = 11, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 12, update_by = 12, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 13, update_by = 13, update_at = DateTime.Now },
                new Wallet { balance = 0, account_id = 14, update_by = 14, update_at = DateTime.Now }
                );

            modelBuilder.Entity<Deposit>().HasData(
                new Deposit { wallet_id = 1, amount = 10000, fee = 500, status = true, create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now, },
                new Deposit { wallet_id = 2, amount = 10000, fee = 500, status = false, create_by = 2, create_at = DateTime.Now, update_by = 2, update_at = DateTime.Now, },
                new Deposit { wallet_id = 3, amount = 10000, fee = 500, status = true, create_by = 3, create_at = DateTime.Now, update_by = 3, update_at = DateTime.Now, },
                new Deposit { wallet_id = 4, amount = 10000, fee = 500, status = false, create_by = 4, create_at = DateTime.Now, update_by = 4, update_at = DateTime.Now, },
                new Deposit { wallet_id = 5, amount = 10000, fee = 500, status = true, create_by = 5, create_at = DateTime.Now, update_by = 5, update_at = DateTime.Now, },
                new Deposit { wallet_id = 6, amount = 10000, fee = 500, status = false, create_by = 6, create_at = DateTime.Now, update_by = 6, update_at = DateTime.Now, },
                new Deposit { wallet_id = 7, amount = 10000, fee = 500, status = true, create_by = 7, create_at = DateTime.Now, update_by = 7, update_at = DateTime.Now, },
                new Deposit { wallet_id = 8, amount = 10000, fee = 500, status = false, create_by = 8, create_at = DateTime.Now, update_by = 8, update_at = DateTime.Now, },
                new Deposit { wallet_id = 9, amount = 10000, fee = 500, status = true, create_by = 9, create_at = DateTime.Now, update_by = 9, update_at = DateTime.Now, },
                new Deposit { wallet_id = 10, amount = 10000, fee = 500, status = false, create_by = 10, create_at = DateTime.Now, update_by = 10, update_at = DateTime.Now, },
                new Deposit { wallet_id = 11, amount = 10000, fee = 500, status = true, create_by = 11, create_at = DateTime.Now, update_by = 11, update_at = DateTime.Now, },
                new Deposit { wallet_id = 12, amount = 10000, fee = 500, status = false, create_by = 12, create_at = DateTime.Now, update_by = 12, update_at = DateTime.Now, },
                new Deposit { wallet_id = 13, amount = 10000, fee = 500, status = true, create_by = 13, create_at = DateTime.Now, update_by = 13, update_at = DateTime.Now, },
                new Deposit { wallet_id = 14, amount = 10000, fee = 500, status = false, create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                );

            modelBuilder.Entity<Withdrawal>().HasData(
                new Withdrawal { wallet_id = 1, amount = 10000, fee = 500, bank_user = "Quốc Tổ Hùng Vương", bank_number = "789654312", bank_name = "TP Bank", status = true, create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 2, amount = 10000, fee = 500, bank_user = "Hai Bà Trưng", bank_number = "789654312", bank_name = "TP Bank", status = false, create_by = 2, create_at = DateTime.Now, update_by = 2, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 3, amount = 10000, fee = 500, bank_user = "Lý Nam Đế", bank_number = "789654312", bank_name = "TP Bank", status = true, create_by = 3, create_at = DateTime.Now, update_by = 3, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 4, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = false, create_by = 4, create_at = DateTime.Now, update_by = 4, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 5, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = true, create_by = 5, create_at = DateTime.Now, update_by = 5, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 6, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = false, create_by = 6, create_at = DateTime.Now, update_by = 6, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 7, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = true, create_by = 7, create_at = DateTime.Now, update_by = 7, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 8, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = false, create_by = 8, create_at = DateTime.Now, update_by = 8, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 9, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = true, create_by = 9, create_at = DateTime.Now, update_by = 9, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 10, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = false, create_by = 10, create_at = DateTime.Now, update_by = 10, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 11, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = true, create_by = 11, create_at = DateTime.Now, update_by = 11, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 12, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = false, create_by = 12, create_at = DateTime.Now, update_by = 12, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 13, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = true, create_by = 13, create_at = DateTime.Now, update_by = 13, update_at = DateTime.Now, },
                new Withdrawal { wallet_id = 14, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = false, create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },

         );

            modelBuilder.Entity<Product>().HasData(
                new Product { code = "DH31UIHI3", price = 1000, quantity = 100, categories = 1, link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { code = "SOD2IF6AP8F", price = 1000, quantity = 100, categories = 2, link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { code = "AL6HEB14E", price = 1000, quantity = 100, categories = 3, link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { code = "IH189AOFA31OH", price = 1000, quantity = 100, categories = 1, link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { code = "JVY8F1KB4VOL", price = 1000, quantity = 100, categories = 2, link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { code = "PO0PM7MO9J", price = 1000, quantity = 100, categories = 3, link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { code = "ATF142DW4YT", price = 1000, quantity = 100, categories = 1, link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now }
                );

            base.OnModelCreating(modelBuilder);

        }


    }


}
