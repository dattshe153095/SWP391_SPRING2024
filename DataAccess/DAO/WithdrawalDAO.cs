using Business.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccess.Library;

namespace DataAccess.DAO
{
    public class WithdrawalDAO
    {

        public static void CreateWithdrawal(Withdrawal withdrawal)
        {
            withdrawal.status = StatusEnum.DANG_CHO_XAC_NHAN;
            withdrawal.state = StateEnum.DANG_XU_LI;
            withdrawal.create_at = DateTime.Now;
            withdrawal.update_at = DateTime.Now;

            using (var context = new Web_Trung_GianContext())
            {
                var deposits = context.Set<Withdrawal>();
                deposits.Add(withdrawal);
                context.SaveChanges();
            }
        }

        public static List<Withdrawal> GetAllWithdrawal()
        {
            List<Withdrawal> list = new List<Withdrawal>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Withdrawals.ToList();

            }
            return list;
        }

        public static List<Withdrawal> GetAllWithdrawalByWalletId(int id)
        {
            List<Withdrawal> list = new List<Withdrawal>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Withdrawals.Where(x=>x.wallet_id == id).ToList();

            }
            return list;
        }

        public static Withdrawal GetWithdrawalById(string id)
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

        public static Withdrawal GetWithdrawalTransactionCode(int wallet_id, string code)
        {
            return GetAllWithdrawal().FirstOrDefault(x => x.wallet_id == wallet_id && x.id == code);
        }

    }
}
