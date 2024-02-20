using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace DataAccess.DAO
{
    public class WalletDAO
    {
        public static List<Wallet> GetAllWallet()
        {
            List<Wallet> list = new List<Wallet>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Wallets.ToList();

            }
            return list;
        }

        public static Wallet GetWalletById(int id)
        {
            return GetAllWallet().FirstOrDefault(x => x.id == id);
        }

        public static Account GetWalletAccountById(int id)
        {
            return AccountDAO.GetAccountWithId(GetWalletById(id).account_id);
        }

        public static Wallet GetWalletByAccountId(int id)
        {
            return GetAllWallet().FirstOrDefault(x=>x.account_id==id);
        }

        public static string AddBalanceWallet(int id, int amount)
        {
            Wallet wallet = GetWalletById(id);
            if (wallet != null)
            {
                wallet.balance += amount;
                wallet.update_at = DateTime.Now;
                using (var context = new Web_Trung_GianContext())
                {
                    var wallets = context.Set<Wallet>();
                    wallets.Update(wallet);
                    context.SaveChanges();
                }
                return "done";
            }
            else
            {
                return "error";
            }
        }

        public static string RemoveBalanceWallet(int id, int amount)
        {
            Wallet wallet = GetWalletById(id);
            if (wallet != null)
            {
                wallet.balance -= amount;
                wallet.update_at = DateTime.Now;
                using (var context = new Web_Trung_GianContext())
                {
                    var wallets = context.Set<Wallet>();
                    wallets.Update(wallet);
                    context.SaveChanges();
                }
                return "done";
            }
            else
            {
                return "error";
            }
        }

    }
}
