using BussinessObject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

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

        public virtual DbSet<TransactionError> TransactionErrors { get; set; }
        public virtual DbSet<ProcessedTransactionInfo> ProcessedTransactionInfos { get; set; }




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

            modelBuilder.Entity<TransactionError>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Wallet)
                .WithMany(w => w.TransactionErrors)
                .HasForeignKey(d => d.wallet_id).OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<ProcessedTransactionInfo>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.TransactionError)
                .WithMany(w => w.ProcessedTransactionInfos)
                .HasForeignKey(d => d.transaction_error_id).OnDelete(DeleteBehavior.Restrict); ;
            });




            // Init Data base
            modelBuilder.Entity<AccountRole>().HasData(
                new AccountRole { id = 1, desctiption = "Admin" },
                new AccountRole { id = 2, desctiption = "User" }
            );

            modelBuilder.Entity<Account>().HasData(
                 new Account { id = 1, name = "Quốc tổ Hùng Vương", username = "hungvuong", email = "waterball208@gmail.com", phone = "0987654321", password = "hungvuong123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 2, name = "Hai Bà Trưng", username = "haibatrung", email = "waterball208@gmail.com", phone = "0987654321", password = "haibatrung123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 3, name = "Lý Nam Đế", username = "lynamde", email = "waterball208@gmail.com", phone = "0987654321", password = "lynamde123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 4, name = "Ngô Quyền", username = "ngoquyen", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 5, name = "Đinh Bộ Lĩnh", username = "dinhbolinh", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 6, name = "Lê Hoàn", username = "lehoan123", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 7, name = "Lý Công Uẩn", username = "lyconguan", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 8, name = "Lý Thường Kiệt", username = "lythuongkiet", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 9, name = "Trần Nhân Tông", username = "trannhantong", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 10, name = "Trần Hưng Đạo", username = "tranhungdao", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 11, name = "Lê Lợi", username = "leloi123", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 12, name = "Nguyễn Trãi", username = "nguyentrai", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 13, name = "Nguyễn Huệ", username = "quangtrung", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 14, name = "Admin", username = "admin", email = "waterball208@gmail.com", phone = "0987654321", password = "admin", role_id = 1, create_at = DateTime.Now, update_at = DateTime.Now }
             // Thêm dữ liệu mẫu khác nếu cần
             );

            modelBuilder.Entity<Wallet>().HasData(
                new Wallet { id = 1, balance = 10000, account_id = 1, update_by = 1, update_at = DateTime.Now },
                new Wallet { id = 2, balance = 10000, account_id = 2, update_by = 2, update_at = DateTime.Now },
                new Wallet { id = 3, balance = 10000, account_id = 3, update_by = 3, update_at = DateTime.Now },
                new Wallet { id = 4, balance = 10000, account_id = 4, update_by = 4, update_at = DateTime.Now },
                new Wallet { id = 5, balance = 10000, account_id = 5, update_by = 5, update_at = DateTime.Now },
                new Wallet { id = 6, balance = 10000, account_id = 6, update_by = 6, update_at = DateTime.Now },
                new Wallet { id = 7, balance = 10000, account_id = 7, update_by = 7, update_at = DateTime.Now },
                new Wallet { id = 8, balance = 10000, account_id = 8, update_by = 8, update_at = DateTime.Now },
                new Wallet { id = 9, balance = 10000, account_id = 9, update_by = 9, update_at = DateTime.Now },
                new Wallet { id = 10, balance = 10000, account_id = 10, update_by = 10, update_at = DateTime.Now },
                new Wallet { id = 11, balance = 10000, account_id = 11, update_by = 11, update_at = DateTime.Now },
                new Wallet { id = 12, balance = 10000, account_id = 12, update_by = 12, update_at = DateTime.Now },
                new Wallet { id = 13, balance = 10000, account_id = 13, update_by = 13, update_at = DateTime.Now },
                new Wallet { id = 14, balance = 10000, account_id = 14, update_by = 14, update_at = DateTime.Now }
                );

            modelBuilder.Entity<Deposit>().HasData(
                new Deposit { id = 1, wallet_id = 1, amount = 10000, fee = 500, status = "done", create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now, },
                new Deposit { id = 2, wallet_id = 2, amount = 10000, fee = 500, status = "pending", create_by = 2, create_at = DateTime.Now, update_by = 2, update_at = DateTime.Now, },
                new Deposit { id = 3, wallet_id = 3, amount = 10000, fee = 500, status = "error", create_by = 3, create_at = DateTime.Now, update_by = 3, update_at = DateTime.Now, },
                new Deposit { id = 4, wallet_id = 4, amount = 10000, fee = 500, status = "pending", create_by = 4, create_at = DateTime.Now, update_by = 4, update_at = DateTime.Now, },
                new Deposit { id = 5, wallet_id = 5, amount = 10000, fee = 500, status = "pending", create_by = 5, create_at = DateTime.Now, update_by = 5, update_at = DateTime.Now, },
                new Deposit { id = 6, wallet_id = 6, amount = 10000, fee = 500, status = "pending", create_by = 6, create_at = DateTime.Now, update_by = 6, update_at = DateTime.Now, },
                new Deposit { id = 7, wallet_id = 7, amount = 10000, fee = 500, status = "pending", create_by = 7, create_at = DateTime.Now, update_by = 7, update_at = DateTime.Now, },
                new Deposit { id = 8, wallet_id = 8, amount = 10000, fee = 500, status = "done", create_by = 8, create_at = DateTime.Now, update_by = 8, update_at = DateTime.Now, },
                new Deposit { id = 9, wallet_id = 9, amount = 10000, fee = 500, status = "done", create_by = 9, create_at = DateTime.Now, update_by = 9, update_at = DateTime.Now, },
                new Deposit { id = 10, wallet_id = 10, amount = 10000, fee = 500, status = "done", create_by = 10, create_at = DateTime.Now, update_by = 10, update_at = DateTime.Now, },
                new Deposit { id = 11, wallet_id = 11, amount = 10000, fee = 500, status = "pending", create_by = 11, create_at = DateTime.Now, update_by = 11, update_at = DateTime.Now, },
                new Deposit { id = 12, wallet_id = 12, amount = 10000, fee = 500, status = "error", create_by = 12, create_at = DateTime.Now, update_by = 12, update_at = DateTime.Now, },
                new Deposit { id = 13, wallet_id = 13, amount = 10000, fee = 500, status = "error", create_by = 13, create_at = DateTime.Now, update_by = 13, update_at = DateTime.Now, },
                new Deposit { id = 14, wallet_id = 14, amount = 10000, fee = 500, status = "done", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }
                );

            modelBuilder.Entity<Withdrawal>().HasData(
                new Withdrawal { id = 1, wallet_id = 1, amount = 10000, fee = 500, bank_user = "Quốc Tổ Hùng Vương", bank_number = "789654312", bank_name = "TP Bank", status = "done", create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now, },
                new Withdrawal { id = 2, wallet_id = 2, amount = 10000, fee = 500, bank_user = "Hai Bà Trưng", bank_number = "789654312", bank_name = "TP Bank", status = "error", create_by = 2, create_at = DateTime.Now, update_by = 2, update_at = DateTime.Now, },
                new Withdrawal { id = 3, wallet_id = 3, amount = 10000, fee = 500, bank_user = "Lý Nam Đế", bank_number = "789654312", bank_name = "TP Bank", status = "done", create_by = 3, create_at = DateTime.Now, update_by = 3, update_at = DateTime.Now, },
                new Withdrawal { id = 4, wallet_id = 4, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "error", create_by = 4, create_at = DateTime.Now, update_by = 4, update_at = DateTime.Now, },
                new Withdrawal { id = 5, wallet_id = 5, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "pending", create_by = 5, create_at = DateTime.Now, update_by = 5, update_at = DateTime.Now, },
                new Withdrawal { id = 6, wallet_id = 6, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "done", create_by = 6, create_at = DateTime.Now, update_by = 6, update_at = DateTime.Now, },
                new Withdrawal { id = 7, wallet_id = 7, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "done", create_by = 7, create_at = DateTime.Now, update_by = 7, update_at = DateTime.Now, },
                new Withdrawal { id = 8, wallet_id = 8, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "pending", create_by = 8, create_at = DateTime.Now, update_by = 8, update_at = DateTime.Now, },
                new Withdrawal { id = 9, wallet_id = 9, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "pending", create_by = 9, create_at = DateTime.Now, update_by = 9, update_at = DateTime.Now, },
                new Withdrawal { id = 10, wallet_id = 10, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "pending", create_by = 10, create_at = DateTime.Now, update_by = 10, update_at = DateTime.Now, },
                new Withdrawal { id = 11, wallet_id = 11, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "pending", create_by = 11, create_at = DateTime.Now, update_by = 11, update_at = DateTime.Now, },
                new Withdrawal { id = 12, wallet_id = 12, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "done", create_by = 12, create_at = DateTime.Now, update_by = 12, update_at = DateTime.Now, },
                new Withdrawal { id = 13, wallet_id = 13, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "pending", create_by = 13, create_at = DateTime.Now, update_by = 13, update_at = DateTime.Now, },
                new Withdrawal { id = 14, wallet_id = 14, amount = 10000, fee = 500, bank_user = "Bank User Name", bank_number = "789654312", bank_name = "TP Bank", status = "error", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }

         );

            modelBuilder.Entity<Product>().HasData(
                new Product { id = 1, code = "DH31UIHI3", name = "Tài khoản Chat GBT", price = 1000, quantity = 100, categories = 1, content = "Tài khoản Chat GBT /n TK: admin /n MK: admin", link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { id = 2, code = "SOD2IF6AP8F", name = "Tài khoản Canvas", price = 1000, quantity = 100, categories = 2, content = "Tài khoản Chat GBT /n TK: admin /n MK: admin", link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { id = 3, code = "AL6HEB14E", name = "Code Game", price = 1000, quantity = 100, categories = 3, content = "Tài khoản Chat GBT /n TK: admin /n MK: admin", link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { id = 4, code = "IH189AOFA31OH", name = "Tài Khoản Game", price = 1000, quantity = 100, categories = 1, content = "Tài khoản Chat GBT /n TK: admin /n MK: admin", link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { id = 5, code = "JVY8F1KB4VOL", name = "Tài Khoản Facebook", price = 1000, quantity = 100, categories = 2, content = "Tài khoản Chat GBT /n TK: admin /n MK: admin", link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { id = 6, code = "PO0PM7MO9J", name = "Win bản quyền", price = 1000, quantity = 100, categories = 3, content = "Tài khoản Chat GBT /n TK: admin /n MK: admin", link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now },
                new Product { id = 7, code = "ATF142DW4YT", name = "Office bản quyền", price = 1000, quantity = 100, categories = 1, content = "Tài khoản Chat GBT /n TK: admin /n MK: admin", link = "#", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now }
                );

            modelBuilder.Entity<TransactionError>().HasData(
                new TransactionError { id = 1, wallet_id = 1, type = "Deposit", title = "Lỗi Nạp Tiền", description = "Lỗi Nạp tiền", status = "done", create_at = DateTime.Now, create_by = 1 },
                new TransactionError { id = 2, wallet_id = 4, type = "Withdrawal", title = "Lỗi rút Tiền", description = "Lỗi rút tiền", status = "pending", create_at = DateTime.Now, create_by = 4 },
                new TransactionError { id = 3, wallet_id = 7, type = "Deposit", title = "Lỗi Nạp Tiền", description = "Lỗi Nạp tiền", status = "done", create_at = DateTime.Now, create_by = 7 },
                new TransactionError { id = 4, wallet_id = 10, type = "Withdrawal", title = "Lỗi rút Tiền", description = "Lỗi rút tiền", status = "pending", create_at = DateTime.Now, create_by = 10 }
                );

            modelBuilder.Entity<ProcessedTransactionInfo>().HasData(
                new ProcessedTransactionInfo { id = 1, transaction_error_id = 4, processed_message = "Đã xử lí", create_at = DateTime.Now, create_by = 14 },
                new ProcessedTransactionInfo { id = 2, transaction_error_id = 3, processed_message = "Đã xử lí", create_at = DateTime.Now, create_by = 14 },
                new ProcessedTransactionInfo { id = 3, transaction_error_id = 1, processed_message = "Đã xử lí", create_at = DateTime.Now, create_by = 14 },
                new ProcessedTransactionInfo { id = 4, transaction_error_id = 2, processed_message = "Đã xử lí", create_at = DateTime.Now, create_by = 14 }
        );

            base.OnModelCreating(modelBuilder);

        }


    }


}
