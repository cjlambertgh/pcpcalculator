using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pcpcalculator.Models;
using pcpcalculator.Services;

namespace pcpcalculator.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public FinanceData FinanceData { get; set; }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("Payments", new
            {
                price = FinanceData.Price,
                deposit = FinanceData.Deposit,
                dealer = FinanceData.DealerContribution,
                term = FinanceData.Term,
                rate = FinanceData.Rate,
                gmfv = FinanceData.FinalPayment
            });
        }
    }
}