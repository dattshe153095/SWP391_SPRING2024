using Business.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Library;

namespace DataAccess.DAO
{
    public class DepositDAO
    {
        public static List<Deposit> GetAllDeposit()
        {
            List<Deposit> list = new List<Deposit>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Deposits.ToList();
            }
            return list;
        }

        public static Deposit GetDepositById(string id)
        {
            return GetAllDeposit().FirstOrDefault(x => x.id == id);
        }

        public static Deposit GetDepositTransactionCode(int wallet_id, string id)
        {
            return GetAllDeposit().FirstOrDefault(x => x.wallet_id == wallet_id && x.id == id);
        }

        public static void UpdateDeposit(Deposit deposit)
        {
            Deposit d = GetDepositById(deposit.id);
            if (d != null)
            {
                d.update_at = DateTime.Now;
                using (var context = new Web_Trung_GianContext())
                {
                    var deposits = context.Set<Deposit>();
                    deposits.Update(deposit);
                    context.SaveChanges();
                }
            }
        }

        public static void CreateDeposit(Deposit deposit)
        {

            deposit.status = StatusEnum.DANG_CHO_XAC_NHAN;
            deposit.create_at = DateTime.Now;
            deposit.update_at = DateTime.Now;

            using (var context = new Web_Trung_GianContext())
            {
                var deposits = context.Set<Deposit>();
                deposits.Add(deposit);
                context.SaveChanges();
            }
        }

        public static void UpdateStatusDeposit()
        {
            //Deposit d = GetDepositById(deposit.id);
            //if (d != null)
            //{
            //    deposit.status = StatusEnum.XAC_NHAN_THANH_CONG;
            //    deposit.update_at = DateTime.Now;

            //    using (var context = new Web_Trung_GianContext())
            //    {
            //        var deposits = context.Set<Deposit>();
            //        deposits.Update(deposit);
            //        context.SaveChanges();
            //    }
            //}
        }


        public static void DepositAction()
        {
            List<Deposit> deposits = GetAllDeposit().Where(x => x.status == StatusEnum.XAC_NHAN_THANH_CONG).ToList();
            foreach (var deposit in deposits)
            {
                if (deposit.status != StatusEnum.HOAN_THANH)
                {
                    deposit.status = StatusEnum.HOAN_THANH;
                    WalletDAO.UpdateWalletDepositBalance(deposit.wallet_id, deposit.amount);
                }
            }
            using (var context = new Web_Trung_GianContext())
            {
                var de = context.Set<Deposit>();
                de.UpdateRange(deposits);
                context.SaveChanges();
            }
        }
    }
}
