using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Models;
using WebClient2.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using DataAccess.DAO;

namespace WebClient2.Controllers
{
    public class DepositsController : Controller
    {
        private readonly Web_Trung_GianContext _context;
        private readonly IVnPayService _vpnPayService;
        public DepositsController(Web_Trung_GianContext context, IVnPayService vnPayServices)
        {
            _context = context;
            _vpnPayService = vnPayServices;
        }

        // GET: Deposits
        public async Task<IActionResult> Index()
        {
            return _context.Deposits != null ?
                        View(await _context.Deposits.ToListAsync()) :
                        Problem("Entity set 'Web_Trung_GianContext.Deposits'  is null.");
        }

        // GET: Deposits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Deposits == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits
                .FirstOrDefaultAsync(m => m.id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // GET: Deposits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deposits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,wallet_id,amount,status,state,description,create_by,create_at,update_by,update_at,is_delete")] Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deposit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }

        // GET: Deposits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Deposits == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }

        // POST: Deposits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,wallet_id,amount,status,state,description,create_by,create_at,update_by,update_at,is_delete")] Deposit deposit)
        {
            if (id != deposit.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deposit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositExists(deposit.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }

        // GET: Deposits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Deposits == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits
                .FirstOrDefaultAsync(m => m.id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // POST: Deposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Deposits == null)
            {
                return Problem("Entity set 'Web_Trung_GianContext.Deposits'  is null.");
            }
            var deposit = await _context.Deposits.FindAsync(id);
            if (deposit != null)
            {
                _context.Deposits.Remove(deposit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepositExists(string id)
        {
            return (_context.Deposits?.Any(e => e.id == id)).GetValueOrDefault();
        }


        #region VNPAY
        public IActionResult VnPay(Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                var vnPayModel = new VnPaymentRequestModel
                {
                    Amount = deposit.amount,
                    CreatedDate = DateTime.Now,
                    Description = deposit.description,
                    Id = deposit.id,
                };
                return Redirect(_vpnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
            }
            return NotFound();
        }

        public IActionResult PaymentFail()
        {
            return View();
        }

        public IActionResult PaymentSuccess()
        {
            return View("PaymentSuccess");
        }

        public IActionResult PaymentCallBack()
        {
            if (Request.Query.Count == 0)
            {
                TempData["Message"] = $"Lỗi thanh toán VN Pay"; return RedirectToAction("PaymentFail");
            }

            var response = _vpnPayService.PaymentExecute(Request.Query);
            try
            {


                if (response == null || response.VnPayReponseCode != "00") // Gia tri 00 la thanh cong
                {
                    TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayReponseCode}";
                    return RedirectToAction("PaymentFail");
                }

                //Lưu đơn hàng cho Database
                //Deposit d = new Deposit { };
                // DepositDAO.CreateDeposit();
                //string id = 
                //WalletDAO.UpdateWalletDepositBalance(deposit.wallet_id, deposit.amount);

                TempData["Message"] = $"Thanh toán VN Pay thành công";
                return RedirectToAction("PaymentSuccess");
            }
            catch (Exception ex) { TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayReponseCode}"; return RedirectToAction("PaymentFail"); }

        }
        #endregion
    }
}
