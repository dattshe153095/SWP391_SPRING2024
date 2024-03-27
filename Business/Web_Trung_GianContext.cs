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
                //File appsettings.json in Webclient2 project
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("ConnectionString"));
            }
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Withdrawal> Withdrawals { get; set; }
        public virtual DbSet<DepositResponse> DepositResponses { get; set; }
        public virtual DbSet<WithdrawalResponse> WithdrawalResponses { get; set; }
        public virtual DbSet<IntermediateOrder> IntermediateOrders { get; set; }
        public virtual DbSet<Notifi> Notifis { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.id);
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(a => a.id);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.id);
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
                new Deposit { id = "1DY75F3K26T", wallet_id = 1, amount = 10000, status = "đang chờ xác nhận", state = "đang xử lí", description = "nạp tiền", create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now, },
                new Deposit { id = "2DI83A9M0P", wallet_id = 2, amount = 10000, status = "đang xử lí", state = "đang xử lí", description = "nạp tiền", create_by = 2, create_at = DateTime.Now, update_by = 2, update_at = DateTime.Now, },
                new Deposit { id = "3DW29E6G3T", wallet_id = 3, amount = 10000, status = "xác nhận thành công", state = "thành công", description = "nạp tiền", create_by = 3, create_at = DateTime.Now, update_by = 3, update_at = DateTime.Now, },
                new Deposit { id = "4DX64S7S9Y", wallet_id = 4, amount = 10000, status = "xác nhận thất bại", state = "thất bại", description = "nạp tiền", create_by = 4, create_at = DateTime.Now, update_by = 4, update_at = DateTime.Now, },
                new Deposit { id = "5DB17K9Y8X", wallet_id = 5, amount = 10000, status = "hoàn thành", state = "thành công", description = "nạp tiền", create_by = 5, create_at = DateTime.Now, update_by = 5, update_at = DateTime.Now, },
                new Deposit { id = "6DP96C3I5V", wallet_id = 6, amount = 10000, status = "đang chờ xác nhận", state = "đang xử lí", description = "nạp tiền", create_by = 6, create_at = DateTime.Now, update_by = 6, update_at = DateTime.Now, },
                new Deposit { id = "7DD50M1A7Q", wallet_id = 7, amount = 10000, status = "đang xử lí", state = "đang xử lí", description = "nạp tiền", create_by = 7, create_at = DateTime.Now, update_by = 7, update_at = DateTime.Now, },
                new Deposit { id = "8DR05R0J6X", wallet_id = 8, amount = 10000, status = "xác nhận thành công", state = "thành công", description = "nạp tiền", create_by = 8, create_at = DateTime.Now, update_by = 8, update_at = DateTime.Now, },
                new Deposit { id = "9DG63J9F6H", wallet_id = 9, amount = 10000, status = "xác nhận thất bại", state = "thất bại", description = "nạp tiền", create_by = 9, create_at = DateTime.Now, update_by = 9, update_at = DateTime.Now, },
                new Deposit { id = "10DL81T2G8Z", wallet_id = 10, amount = 10000, status = "hoàn thành", state = "thành công", description = "nạp tiền", create_by = 10, create_at = DateTime.Now, update_by = 10, update_at = DateTime.Now, },
                new Deposit { id = "11DF85R8K6S", wallet_id = 11, amount = 10000, status = "đang chờ xác nhận", state = "đang xử lí", description = "nạp tiền", create_by = 11, create_at = DateTime.Now, update_by = 11, update_at = DateTime.Now, },
                new Deposit { id = "12DM14S4P4V", wallet_id = 12, amount = 10000, status = "đang xử lí", state = "đang xử lí", description = "nạp tiền", create_by = 12, create_at = DateTime.Now, update_by = 12, update_at = DateTime.Now, },
                new Deposit { id = "13DP76J5J1R", wallet_id = 13, amount = 10000, status = "xác nhận thành công", state = "thành công", description = "nạp tiền", create_by = 13, create_at = DateTime.Now, update_by = 13, update_at = DateTime.Now, },
                new Deposit { id = "14DS57C4B8K", wallet_id = 14, amount = 10000, status = "xác nhận thất bại", state = "thất bại", description = "nạp tiền", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }
                );

            modelBuilder.Entity<Withdrawal>().HasData(
                new Withdrawal { id = "1W0U5V1I0", wallet_id = 1, amount = 5000, bank_user = "Hoàng Minh Nguyệt", bank_number = "789654312", bank_name = "TP Bank", status = "đang chờ xác nhận", state = "đang xử lí", create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now, },
                new Withdrawal { id = "2W4F4Y9E7", wallet_id = 2, amount = 1000, bank_user = "Nguyễn Thùy Dương", bank_number = "789654312", bank_name = "TP Bank", status = "đang xử lí", state = "đang xử lí", create_by = 2, create_at = DateTime.Now, update_by = 2, update_at = DateTime.Now, },
                new Withdrawal { id = "3W3C1J8P1", wallet_id = 3, amount = 5000, bank_user = "Lê Thạc Hoành", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thành công", state = "thành công", create_by = 3, create_at = DateTime.Now, update_by = 3, update_at = DateTime.Now, },
                new Withdrawal { id = "4W6O2Q2R4", wallet_id = 4, amount = 1000, bank_user = "Nguyễn Quang Vị", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thất bại", state = "thất bại", create_by = 4, create_at = DateTime.Now, update_by = 4, update_at = DateTime.Now, },
                new Withdrawal { id = "5W8O2W1A3", wallet_id = 5, amount = 5000, bank_user = "Nguyễn Mạnh Cường", bank_number = "789654312", bank_name = "TP Bank", status = "hoàn thành", state = "thành công", create_by = 5, create_at = DateTime.Now, update_by = 5, update_at = DateTime.Now, },
                new Withdrawal { id = "6W2Z1O6B1", wallet_id = 6, amount = 1000, bank_user = "Nguyễn Việt Hân", bank_number = "789654312", bank_name = "TP Bank", status = "đang chờ xác nhận", state = "đang xử lí", create_by = 6, create_at = DateTime.Now, update_by = 6, update_at = DateTime.Now, },
                new Withdrawal { id = "7W3T0N3S0", wallet_id = 7, amount = 5000, bank_user = "Nguyễn Trung Hiếu", bank_number = "789654312", bank_name = "TP Bank", status = "đang xử lí", state = "đang xử lí", create_by = 7, create_at = DateTime.Now, update_by = 7, update_at = DateTime.Now, },
                new Withdrawal { id = "8W4I2D8D0", wallet_id = 8, amount = 10000, bank_user = "Nguyễn Văn Tuấn", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thành công", state = "thành công", create_by = 8, create_at = DateTime.Now, update_by = 8, update_at = DateTime.Now, },
                new Withdrawal { id = "9W6H6F3O2", wallet_id = 9, amount = 5000, bank_user = "Ngô Gia Thiện", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thất bại", state = "thất bại", create_by = 9, create_at = DateTime.Now, update_by = 9, update_at = DateTime.Now, },
                new Withdrawal { id = "10W1B4L3R5", wallet_id = 10, amount = 10000, bank_user = "Phan Thế Anh", bank_number = "789654312", bank_name = "TP Bank", status = "hoàn thành", state = "thành công", create_by = 10, create_at = DateTime.Now, update_by = 10, update_at = DateTime.Now, },
                new Withdrawal { id = "11W8I7T8V7", wallet_id = 11, amount = 5000, bank_user = "Nguyễn Ngọc Hoàng", bank_number = "789654312", bank_name = "TP Bank", status = "đang xác nhận", state = "đang xử lí", create_by = 11, create_at = DateTime.Now, update_by = 11, update_at = DateTime.Now, },
                new Withdrawal { id = "12W6M7E2D3", wallet_id = 12, amount = 10000, bank_user = "Nguyễn Quang Lộc", bank_number = "789654312", bank_name = "TP Bank", status = "đang xử lí", state = "đang xử lí", create_by = 12, create_at = DateTime.Now, update_by = 12, update_at = DateTime.Now, },
                new Withdrawal { id = "13W4Q0L0L6", wallet_id = 13, amount = 5000, bank_user = "Nguyễn Hải Đan", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thành công", state = "thành công", create_by = 13, create_at = DateTime.Now, update_by = 13, update_at = DateTime.Now, },
                new Withdrawal { id = "14W9C9M5F4", wallet_id = 14, amount = 10000, bank_user = "Bank Admin", bank_number = "789654312", bank_name = "TP Bank", status = "xác nhận thất bại", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }
                );

            modelBuilder.Entity<DepositResponse>().HasData(
                new DepositResponse { id = 1, deposit_id = "1DY75F3K26T", type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 2, deposit_id = "2DI83A9M0P", type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 3, deposit_id = "3DW29E6G3T", type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "hoàn thành", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 4, deposit_id = "4DX64S7S9Y", type_transaction = "nạp tiền", description = "Giao dịch thất bại", status = "xác nhận thất bại", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 5, deposit_id = "5DB17K9Y8X", type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "hoàn thành", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 6, deposit_id = "6DP96C3I5V", type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 7, deposit_id = "7DD50M1A7Q", type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 8, deposit_id = "8DR05R0J6X", type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "hoàn thành", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 9, deposit_id = "9DG63J9F6H", type_transaction = "nạp tiền", description = "Giao dịch thất bại", status = "xác nhận thất bại", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 10, deposit_id = "10DL81T2G8Z", type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "hoàn thành", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 11, deposit_id = "11DF85R8K6S", type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 12, deposit_id = "12DM14S4P4V", type_transaction = "nạp tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 13, deposit_id = "13DP76J5J1R", type_transaction = "nạp tiền", description = "Giao dịch thành công", status = "hoàn thành", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new DepositResponse { id = 14, deposit_id = "14DS57C4B8K", type_transaction = "nạp tiền", description = "Giao dịch thất bại", status = "xác nhận thất bại", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }
            );

            modelBuilder.Entity<WithdrawalResponse>().HasData(
                 new WithdrawalResponse { id = 1, withdrawal_id = "1W0U5V1I0", type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 2, withdrawal_id = "2W4F4Y9E7", type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 3, withdrawal_id = "3W3C1J8P1", type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 4, withdrawal_id = "4W6O2Q2R4", type_transaction = "rút tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 5, withdrawal_id = "5W8O2W1A3", type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 6, withdrawal_id = "6W2Z1O6B1", type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 7, withdrawal_id = "7W3T0N3S0", type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 8, withdrawal_id = "8W4I2D8D0", type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 9, withdrawal_id = "9W6H6F3O2", type_transaction = "rút tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 10, withdrawal_id = "10W1B4L3R5", type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 11, withdrawal_id = "11W8I7T8V7", type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 12, withdrawal_id = "12W6M7E2D3", type_transaction = "rút tiền", description = "Đang xử lí", status = "đang xử lí", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 13, withdrawal_id = "13W4Q0L0L6", type_transaction = "rút tiền", description = "Giao dịch thành công", status = "đang xử lí", state = "thành công", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, },
                new WithdrawalResponse { id = 14, withdrawal_id = "14W9C9M5F4", type_transaction = "rút tiền", description = "Giao dịch thất bại", status = "đang xử lí", state = "thất bại", create_by = 14, create_at = DateTime.Now, update_by = 14, update_at = DateTime.Now, }
            );

            modelBuilder.Entity<IntermediateOrder>().HasData(
                new IntermediateOrder { id = "FjNnwZdR", name = "Tài Khoản Office", price = 1000, fee_type = true, description = "tài khoản Office ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = false, status = "mới tạo", state = "đang xử lí", create_by = 1, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "tCWyd9xS", name = "Tài Khoản GBT", price = 500, fee_type = false, description = "tài khoản GBT ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 2, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "Kk3us7mV", name = "Tài Khoản Facebook", price = 1500, fee_type = true, description = "tài khoản Facebook ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = false, status = "mới tạo", state = "đang xử lí", create_by = 3, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "yh2LnbGk", name = "Tài Khoản Game", price = 2000, fee_type = false, description = "tài khoản Game ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 4, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "6zqRwHEu", name = "Tài Khoản Unity", price = 500, fee_type = true, description = "tài khoản Unity ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = false, status = "mới tạo", state = "đang xử lí", create_by = 5, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "I1mJYvoA", name = "Tài Khoản Microsoft", price = 1000, fee_type = false, description = "tài khoản Microsoft", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 6, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "OnvTBGFk", name = "Tài Khoản Spine", price = 1500, fee_type = true, description = "tài khoản Spine ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 7, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "a2D1PC0L", name = "Tài Khoản Adobephotoshop", price = 2000, fee_type = false, description = "tài khoản Adobephotoshop ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 8, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "Q9XWqMr3", name = "Tài Khoản Ai", price = 500, fee_type = true, description = "tài khoản Ai ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 9, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "hwPm5QZR", name = "Tài Khoản Gmail", price = 1000, fee_type = false, description = "tài khoản Gmail ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = false, status = "mới tạo", state = "đang xử lí", create_by = 10, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "fDlco4Ii", name = "Tài Khoản Git", price = 1500, fee_type = true, description = "tài khoản Git ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 11, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "LziBV2fq", name = "Tài Khoản Netflix", price = 2000, fee_type = false, description = "tài khoản Netflix ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 12, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "2n3mMgFy", name = "Tài Khoản Vip Youtube", price = 500, fee_type = true, description = "tài khoản Youtube ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 13, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "eSgvtQo6", name = "Tài Khoản Duolingo", price = 1000, fee_type = false, description = "tài khoản Duolingo ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = false, status = "mới tạo", state = "đang xử lí", create_by = 14, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now },
                new IntermediateOrder { id = "wFzU6Nvj", name = "Tài Khoản Coursera", price = 1000, fee_type = true, description = "tài khoản Coursera ", contact = "facebook, mess,zalo", hidden_content = "tài khoản: account, mật khẩu: password", is_public = true, status = "mới tạo", state = "đang xử lí", create_by = 10, create_at = DateTime.Now, update_by = 1, update_at = DateTime.Now }
                );

            base.OnModelCreating(modelBuilder);

        }


    }


}
