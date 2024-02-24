using Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Business
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
        public virtual DbSet<Role> AccountRoles { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Withdrawal> Withdrawals { get; set; }
        public virtual DbSet<DepositResponse> DepositResponses { get; set; }
        public virtual DbSet<WithdrawalResponse> WithdrawalResponses { get; set; }





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

                //DEPOSIT RESPONSE
                entity.HasMany(a => a.DepositResponseCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by).OnDelete(DeleteBehavior.Restrict); ;

                entity.HasMany(a => a.DepositResponseUpdates)
                    .WithOne(o => o.AccountUpdate)
                    .HasForeignKey(o => o.update_by).OnDelete(DeleteBehavior.Restrict); ;

                //WITHDRAWAL RESPONSE
                entity.HasMany(a => a.WithdrawalResponseCreates)
                    .WithOne(o => o.AccountCreate)
                    .HasForeignKey(o => o.create_by).OnDelete(DeleteBehavior.Restrict); ;


                entity.HasMany(a => a.WithdrawalResponseUpdates)
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

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.id);
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Wallet)
                .WithMany(w => w.Deposits)
                .HasForeignKey(d => d.wallet_id).OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Withdrawal>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Wallet)
                .WithMany(w => w.Withdrawals)
                .HasForeignKey(d => d.wallet_id).OnDelete(DeleteBehavior.Restrict); ;
            });


            modelBuilder.Entity<DepositResponse>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Deposit)
                .WithMany(w => w.DepositResponses)
                .HasForeignKey(d => d.deposit_id).OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<WithdrawalResponse>(entity =>
            {
                entity.HasKey(u => u.id);

                entity.HasOne(w => w.Withdrawal)
                .WithMany(w => w.WithdrawalResponsess)
                .HasForeignKey(d => d.withdrawal_id).OnDelete(DeleteBehavior.Restrict); ;
            });



            // Init Data base
            modelBuilder.Entity<Role>().HasData(
                new Role { id = 1, desctiption = "Admin" },
                new Role { id = 2, desctiption = "User" }
            );

            modelBuilder.Entity<Account>().HasData(
                 new Account { id = 1, name = "Hoàng Minh Nguyệt", username = "minhnguyet", email = "waterball208@gmail.com", phone = "0987654321", password = "minhnguyet", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 2, name = "Nguyễn Thùy Dương", username = "thuyduong", email = "waterball208@gmail.com", phone = "0987654321", password = "thuyduong", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 3, name = "Lê Thạc Hoành", username = "thachoanh", email = "waterball208@gmail.com", phone = "0987654321", password = "thachoanh", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 4, name = "Nguyễn Quang Vị", username = "quangvi", email = "waterball208@gmail.com", phone = "0987654321", password = "quangvi", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 5, name = "Nguyễn Mạnh Cường", username = "manhcuong", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 6, name = "Nguyễn Việt Hân", username = "viethan", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 7, name = "Nguyễn Trung Hiếu", username = "trunghieu", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 8, name = "Nguyễn Văn Tuấn", username = "vantuan", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 9, name = "Ngô Gia Thiện", username = "giathien", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 10, name = "Phan Thế Anh", username = "theanh", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 11, name = "Nguyễn Ngọc Hoàng", username = "ngochoang", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 12, name = "Nguyễn Quang Lộc", username = "quangloc", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 13, name = "Nguyễn Hải Đan", username = "haidan123", email = "waterball208@gmail.com", phone = "0987654321", password = "pass123", role_id = 2, create_at = DateTime.Now, update_at = DateTime.Now },
                 new Account { id = 14, name = "Admin", username = "admin", email = "waterball208@gmail.com", phone = "0987654321", password = "admin", role_id = 1, create_at = DateTime.Now, update_at = DateTime.Now }
             // Thêm dữ liệu mẫu khác nếu cần
             );

            modelBuilder.Entity<Wallet>().HasData(
                new Wallet { id = 1, balance = 20000, account_id = 1, update_by = 1, update_at = DateTime.Now },
                new Wallet { id = 2, balance = 10000, account_id = 2, update_by = 2, update_at = DateTime.Now },
                new Wallet { id = 3, balance = 20000, account_id = 3, update_by = 3, update_at = DateTime.Now },
                new Wallet { id = 4, balance = 10000, account_id = 4, update_by = 4, update_at = DateTime.Now },
                new Wallet { id = 5, balance = 20000, account_id = 5, update_by = 5, update_at = DateTime.Now },
                new Wallet { id = 6, balance = 10000, account_id = 6, update_by = 6, update_at = DateTime.Now },
                new Wallet { id = 7, balance = 20000, account_id = 7, update_by = 7, update_at = DateTime.Now },
                new Wallet { id = 8, balance = 10000, account_id = 8, update_by = 8, update_at = DateTime.Now },
                new Wallet { id = 9, balance = 20000, account_id = 9, update_by = 9, update_at = DateTime.Now },
                new Wallet { id = 10, balance = 10000, account_id = 10, update_by = 10, update_at = DateTime.Now },
                new Wallet { id = 11, balance = 20000, account_id = 11, update_by = 11, update_at = DateTime.Now },
                new Wallet { id = 12, balance = 10000, account_id = 12, update_by = 12, update_at = DateTime.Now },
                new Wallet { id = 13, balance = 20000, account_id = 13, update_by = 13, update_at = DateTime.Now },
                new Wallet { id = 14, balance = 1000000, account_id = 14, update_by = 14, update_at = DateTime.Now }
                );

            modelBuilder.Entity<Deposit>().HasData(
                new Deposit { id = 1, wallet_id = 1, amount = 10000, trans_code = "1DY75F3K26T", status = "đang chờ xác nhận", state = "đang xử lí", description = "nạp tiền", create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now, },
                new Deposit { id = 2, wallet_id = 2, amount = 10000, trans_code = "2DI83A9M0P", status = "đang chờ xử lí", state = "đang xử lí", description = "nạp tiền", create_by = 2, create_at = DateTime.Now, update_by = 2, update_at = DateTime.Now, },
                new Deposit { id = 3, wallet_id = 3, amount = 10000, trans_code = "3DW29E6G3T", status = "xác nhận thành công", state = "thành công", description = "nạp tiền", create_by = 3, create_at = DateTime.Now, update_by = 3, update_at = DateTime.Now, },
                new Deposit { id = 4, wallet_id = 4, amount = 10000, trans_code = "4DX64S7S9Y", status = "xác nhận thất bại", state = "thất bại", description = "nạp tiền", create_by = 4, create_at = DateTime.Now, update_by = 4, update_at = DateTime.Now, },
                new Deposit { id = 5, wallet_id = 5, amount = 10000, trans_code = "5DB17K9Y8X", status = "hoàn thành", state = "thành công", description = "nạp tiền", create_by = 5, create_at = DateTime.Now, update_by = 5, update_at = DateTime.Now, },
                new Deposit { id = 6, wallet_id = 6, amount = 10000, trans_code = "6DP96C3I5V", status = "đang chờ xác nhận", state = "đang xử lí", description = "nạp tiền", create_by = 6, create_at = DateTime.Now, update_by = 6, update_at = DateTime.Now, },
                new Deposit { id = 7, wallet_id = 7, amount = 10000, trans_code = "7DD50M1A7Q", status = "đang chờ xử lí", state = "đang xử lí", description = "nạp tiền", create_by = 7, create_at = DateTime.Now, update_by = 7, update_at = DateTime.Now, },
                new Deposit { id = 8, wallet_id = 8, amount = 10000, trans_code = "8DR05R0J6X", status = "xác nhận thành công", state = "thành công", description = "nạp tiền", create_by = 8, create_at = DateTime.Now, update_by = 8, update_at = DateTime.Now, },
                new Deposit { id = 9, wallet_id = 9, amount = 10000, trans_code = "9DG63J9F6H", status = "xác nhận thất bại", state = "thất bại", description = "nạp tiền", create_by = 9, create_at = DateTime.Now, update_by = 9, update_at = DateTime.Now, },
                new Deposit { id = 10, wallet_id = 10, amount = 10000, trans_code = "10DL81T2G8Z", status = "hoàn thành", state = "thành công", description = "nạp tiền", create_by = 10, create_at = DateTime.Now, update_by = 10, update_at = DateTime.Now, },
                new Deposit { id = 11, wallet_id = 11, amount = 10000, trans_code = "11DF85R8K6S", status = "đang chờ xác nhận", state = "đang xử lí", description = "nạp tiền", create_by = 11, create_at = DateTime.Now, update_by = 11, update_at = DateTime.Now, },
                new Deposit { id = 12, wallet_id = 12, amount = 10000, trans_code = "12DM14S4P4V", status = "đang chờ xử lí", state = "đang xử lí", description = "nạp tiền", create_by = 12, create_at = DateTime.Now, update_by = 12, update_at = DateTime.Now, },
                new Deposit { id = 13, wallet_id = 13, amount = 10000, trans_code = "13DP76J5J1R", status = "xác nhận thành công", state = "thành công", description = "nạp tiền", create_by = 13, create_at = DateTime.Now, update_by = 13, update_at = DateTime.Now, },
                new Deposit { id = 14, wallet_id = 14, amount = 10000, trans_code = "14DS57C4B8K", status = "xác nhận thất bại", state = "thất bại", description = "nạp tiền", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }
                );

            modelBuilder.Entity<Withdrawal>().HasData(
                new Withdrawal { id = 1, wallet_id = 1, amount = 5000, trans_code = "1W0U5V1I0", bank_user = "Hoàng Minh Nguyệt", bank_number = "789654312", bank_name = "TP Bank", status = "đang chờ xác nhận", state = "đang xử lí", create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now, },
                new Withdrawal { id = 2, wallet_id = 2, amount = 1000, trans_code = "2W4F4Y9E7", bank_user = "Nguyễn Thùy Dương", bank_number = "789654312", bank_name = "TP Bank", status = "đang chờ xử lí", state = "đang xử lí", create_by = 2, create_at = DateTime.Now, update_by = 2, update_at = DateTime.Now, },
                new Withdrawal { id = 3, wallet_id = 3, amount = 5000, trans_code = "3W3C1J8P1", bank_user = "Lê Thạc Hoành", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thành công", state = "thành công", create_by = 3, create_at = DateTime.Now, update_by = 3, update_at = DateTime.Now, },
                new Withdrawal { id = 4, wallet_id = 4, amount = 1000, trans_code = "4W6O2Q2R4", bank_user = "Nguyễn Quang Vị", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thất bại", state = "thất bại", create_by = 4, create_at = DateTime.Now, update_by = 4, update_at = DateTime.Now, },
                new Withdrawal { id = 5, wallet_id = 5, amount = 5000, trans_code = "5W8O2W1A3", bank_user = "Nguyễn Mạnh Cường", bank_number = "789654312", bank_name = "TP Bank", status = "hoàn thành", state = "thành công", create_by = 5, create_at = DateTime.Now, update_by = 5, update_at = DateTime.Now, },
                new Withdrawal { id = 6, wallet_id = 6, amount = 1000, trans_code = "6W2Z1O6B1", bank_user = "Nguyễn Việt Hân", bank_number = "789654312", bank_name = "TP Bank", status = "đang chờ xác nhận", state = "đang xử lí", create_by = 6, create_at = DateTime.Now, update_by = 6, update_at = DateTime.Now, },
                new Withdrawal { id = 7, wallet_id = 7, amount = 5000, trans_code = "7W3T0N3S0", bank_user = "Nguyễn Trung Hiếu", bank_number = "789654312", bank_name = "TP Bank", status = "đang chờ xử lí", state = "đang xử lí", create_by = 7, create_at = DateTime.Now, update_by = 7, update_at = DateTime.Now, },
                new Withdrawal { id = 8, wallet_id = 8, amount = 10000, trans_code = "8W4I2D8D0", bank_user = "Nguyễn Văn Tuấn", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thành công", state = "thành công", create_by = 8, create_at = DateTime.Now, update_by = 8, update_at = DateTime.Now, },
                new Withdrawal { id = 9, wallet_id = 9, amount = 5000, trans_code = "9W6H6F3O2", bank_user = "Ngô Gia Thiện", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thất bại", state = "thất bại", create_by = 9, create_at = DateTime.Now, update_by = 9, update_at = DateTime.Now, },
                new Withdrawal { id = 10, wallet_id = 10, amount = 10000, trans_code = "10W1B4L3R5", bank_user = "Phan Thế Anh", bank_number = "789654312", bank_name = "TP Bank", status = "hoàn thành", state = "thành công", create_by = 10, create_at = DateTime.Now, update_by = 10, update_at = DateTime.Now, },
                new Withdrawal { id = 11, wallet_id = 11, amount = 5000, trans_code = "11W8I7T8V7", bank_user = "Nguyễn Ngọc Hoàng", bank_number = "789654312", bank_name = "TP Bank", status = "đang chờ xác nhận", state = "đang xử lí", create_by = 11, create_at = DateTime.Now, update_by = 11, update_at = DateTime.Now, },
                new Withdrawal { id = 12, wallet_id = 12, amount = 10000, trans_code = "12W6M7E2D3", bank_user = "Nguyễn Quang Lộc", bank_number = "789654312", bank_name = "TP Bank", status = "đang chờ xử lí", state = "đang xử lí", create_by = 12, create_at = DateTime.Now, update_by = 12, update_at = DateTime.Now, },
                new Withdrawal { id = 13, wallet_id = 13, amount = 5000, trans_code = "13W4Q0L0L6", bank_user = "Nguyễn Hải Đan", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thành công", state = "thành công", create_by = 13, create_at = DateTime.Now, update_by = 13, update_at = DateTime.Now, },
                new Withdrawal { id = 14, wallet_id = 14, amount = 10000, trans_code = "14W9C9M5F4", bank_user = "Bank Admin", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thất bại", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }
                );

            modelBuilder.Entity<DepositResponse>().HasData(
                new DepositResponse { id = 1, deposit_id = 1, type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 2, deposit_id = 2, type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 3, deposit_id = 3, type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 4, deposit_id = 4, type_transaction = "nạp tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 5, deposit_id = 5, type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 6, deposit_id = 6, type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 7, deposit_id = 7, type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 8, deposit_id = 8, type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 9, deposit_id = 9, type_transaction = "nạp tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 10, deposit_id = 10, type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 11, deposit_id = 11, type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 12, deposit_id = 12, type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 13, deposit_id = 13, type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 14, deposit_id = 14, type_transaction = "nạp tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }


         );

            modelBuilder.Entity<WithdrawalResponse>().HasData(
                 new WithdrawalResponse { id = 1, withdrawal_id = 1, type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 2, withdrawal_id = 2, type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 3, withdrawal_id = 3, type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 4, withdrawal_id = 4, type_transaction = "rút tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 5, withdrawal_id = 5, type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 6, withdrawal_id = 6, type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 7, withdrawal_id = 7, type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 8, withdrawal_id = 8, type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 9, withdrawal_id = 9, type_transaction = "rút tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 10, withdrawal_id = 10, type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 11, withdrawal_id = 11, type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 12, withdrawal_id = 12, type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 13, withdrawal_id = 13, type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 14, withdrawal_id = 14, type_transaction = "rút tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }
);



            base.OnModelCreating(modelBuilder);

        }


    }


}
