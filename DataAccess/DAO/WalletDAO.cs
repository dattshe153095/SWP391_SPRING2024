using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
