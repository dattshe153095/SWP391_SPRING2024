using BussinessObject.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class WalletController : Controller
    {
        #region WALLET
        public ActionResult Index()
        {
            List<Wallet> wallets = new List<Wallet>();
            wallets = WalletDAO.GetAllWallet();
            ViewBag.Wallets = wallets;
            return View();
        }

        public ActionResult WalletDetail(int userId)
        {
            Wallet wallet = new Wallet();
            wallet = WalletDAO.GetWalletByAccountId(userId);
            ViewBag.Wallet = wallet;
            return View();
        }
        #endregion

        #region WITHDRAWAL
        public ActionResult WithdrawalTransaction()
        {
            List<Withdrawal> withdrawals = new List<Withdrawal>();
            withdrawals = WithdrawalDAO.GetAllWithdrawal();
            ViewBag.Withdrawals = withdrawals;
            return View();
        }

        public ActionResult WithdrawalDetail(int withdrawal_id)
        {
            Withdrawal withdrawal = new Withdrawal();
            withdrawal = WithdrawalDAO.GetWithdrawalById(withdrawal_id);
            ViewBag.Withdrawal = withdrawal;
            return View();
        }

        [HttpPost]
        public ActionResult WithdrawalHandle(int withdrawal_id, string status)
        {
            Withdrawal withdrawal = new Withdrawal();
            withdrawal = WithdrawalDAO.GetWithdrawalById(withdrawal_id);
            if (WalletDAO.GetWalletById(withdrawal.wallet_id).balance >= (withdrawal.amount + withdrawal.fee))
            {
                WalletDAO.RemoveBalanceWallet(withdrawal.wallet_id, withdrawal.amount + withdrawal.fee);
                withdrawal.status = status;
                WithdrawalDAO.UpdateWithdrawal(withdrawal);

                return RedirectToAction("WithdrawalDetail", new { withdrawal_id = withdrawal_id });
            }
            else
            {
                return RedirectToAction("WithdrawalDetail", new { withdrawal_id = withdrawal_id });
            }
          
        }

        #endregion
        #region DEPOSIT
        public ActionResult DepositTransaction()
        {
            List<Deposit> deposits = new List<Deposit>();
            deposits = DepositDAO.GetAllDeposit();
            ViewBag.Deposits = deposits;
            return View();
        }

        [HttpGet]
        public ActionResult DepositDetail(int deposit_id)
        {
            Deposit deposit = new Deposit();
            deposit = DepositDAO.GetDepositById(deposit_id);
            ViewBag.Deposit = deposit;
            return View();
        }

        [HttpPost]
        public ActionResult DepositHandle(int deposit_id, string status)
        {
            Deposit deposit = new Deposit();
            deposit = DepositDAO.GetDepositById(deposit_id);
            WalletDAO.AddBalanceWallet(deposit.wallet_id, deposit.amount - deposit.fee);
            deposit.status = status;
            DepositDAO.UpdateDeposit(deposit);

            return RedirectToAction("DepositDetail", new { deposit_id = deposit_id });
        }
        #endregion

        public ActionResult ReportTransaction()
        {
            List<TransactionError> transactionErrors = new List<TransactionError>();
            transactionErrors = TransactionErrorDAO.GetAllTransactionError();
            ViewBag.TransactionErrors = transactionErrors;
            return View();
        }

        public ActionResult ReportTransactionDetail(int id)
        {
            TransactionError transactionError = new TransactionError();
            transactionError = TransactionErrorDAO.GetTransactionErrorById(id);
            ViewBag.TransactionError = transactionError;

            ProcessedTransactionInfo processedTransactionInfo = new ProcessedTransactionInfo();
            processedTransactionInfo = ProcessedTransactionInfoDAO.GetProcessedTransactionInfoByTransactionErrorId(id);
            ViewBag.ProcessedTransactionInfo = processedTransactionInfo;
            return View();
        }

        [HttpPost]
        public ActionResult HandleReportWallet(int id_processedTransactionInfo, string processed_message)
        {
            ProcessedTransactionInfo processedTransactionInfo = new ProcessedTransactionInfo();
            processedTransactionInfo = ProcessedTransactionInfoDAO.GetProcessedTransactionInfoById(id_processedTransactionInfo);
            processedTransactionInfo.processed_message = processed_message;
            ProcessedTransactionInfoDAO.UpdateProcessedTransactionInfo(processedTransactionInfo);
            return RedirectToAction("ReportTransactionDetail", new { id = processedTransactionInfo.transaction_error_id });
        }
    }
}
