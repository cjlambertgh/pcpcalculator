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
    public class PaymentsModel : PageModel
    {
        private readonly IFinanceCalculatorService financeCalculatorService;

        public PaymentsModel(IFinanceCalculatorService financeCalculatorService)
        {
            this.financeCalculatorService = financeCalculatorService;
        }

        [BindProperty]
        public FinanceData FinanceData { get; set; }

        public LoanRepaymentDetails LoanRepaymentDetails { get; set; }

        public void OnGet(double price, double deposit, double dealer, uint term, double rate, double gmfv)
        {
            FinanceData = new FinanceData
            {
                Price = price,
                Deposit = deposit,
                DealerContribution = dealer,
                Term = term,
                Rate = rate,
                FinalPayment = gmfv
            };

            LoanRepaymentDetails = financeCalculatorService.PcpLoanRepayments(FinanceData);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
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