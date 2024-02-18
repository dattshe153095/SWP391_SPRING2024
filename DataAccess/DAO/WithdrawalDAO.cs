using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.DAO
{
    public class WithdrawalDAO
    {
        public static List<Withdrawal> GetAllWithdrawal()
        {
            List<Withdrawal> list = new List<Withdrawal>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Withdrawals.ToList();

            }
            return list;
        }

        public static Withdrawal GetWithdrawalById(int id)
        {
            return GetAllWithdrawal().FirstOrDefault(x => x.id == id);
        }

        public static List<Withdrawal> SearchWithdrawal(DateTime? create_at, DateTime? update_at, string account_name = "", int id = 0, string bank_user = "", string bank_number = "", string bank_name = "", string status = "")
        {
            List<Withdrawal> list = GetAllWithdrawal();
            if (create_at != null)
            {
                list = GetAllWithdrawal().Where(x => x.create_at <= create_at).ToList();
            }
            if (update_at != null)
            {
                list = GetAllWithdrawal().Where(x => x.update_at <= update_at).ToList();
            }
            //if (account_name != "")
            //{
            //    List<Account> accounts = AccountDAO.GetAccountWithName(account_name);
            //    list = GetAllWithdrawal().Where(x => accounts.Any(a => a.id == x.id)).ToList();
            //}

            if (id != 0)
            {
                list = GetAllWithdrawal().Where(x => x.id == id).ToList();
            }


            if (bank_user != "")
            {
                list = GetAllWithdrawal().Where(x => x.bank_user.ToLower().Contains(bank_user.Trim().ToLower())).ToList();
            }

            if (bank_number != "")
            {
                list = GetAllWithdrawal().Where(x => x.bank_number.ToLower().Contains(bank_number.Trim().ToLower())).ToList();
            }

            if (bank_name != "")
            {
                list = GetAllWithdrawal().Where(x => x.bank_name.ToLower().Contains(bank_name.Trim().ToLower())).ToList();
            }

            if (status != "")
            {
                list = GetAllWithdrawal().Where(x => x.status.ToLower().Contains(status.Trim().ToLower())).ToList();
            }

            return list;

        }
    }
}
