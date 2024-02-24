using Business.Models;
using Business;
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

        public static void UpdateWithdrawal(Withdrawal withdrawal)
        {
            Withdrawal d = GetWithdrawalById(withdrawal.id);
            if (d != null)
            {
                d.update_at = DateTime.Now;
                using (var context = new Web_Trung_GianContext())
                {
                    var withdrawals = context.Set<Withdrawal>();
                    withdrawals.Update(withdrawal);
                    context.SaveChanges();
                }
            }
        }

        public static void CreateWithdrawal(Withdrawal withdrawal)
        {
            withdrawal.create_at = DateTime.Now;
            withdrawal.update_at = DateTime.Now;
            if (withdrawal != null)
            {

                using (var context = new Web_Trung_GianContext())
                {
                    var withdrawals = context.Set<Withdrawal>();
                    withdrawals.Add(withdrawal);
                    context.SaveChanges();
                }
            }
        }
    }
}
