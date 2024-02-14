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
            Wallet wallet = new Wallet();

            using (var context = new Web_Trung_GianContext())
            {
                wallet = context.Wallets.ToList().FirstOrDefault(x => x.id == id);

            }
            return wallet;
        }
    }
}
