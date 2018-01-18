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
        private readonly IFinanceCalculatorService financeCalculatorService;

        public IndexModel(IFinanceCalculatorService financeCalculatorService)
        {
            this.financeCalculatorService = financeCalculatorService;
        }
        public void OnGet()
        {
            //var financeData = new FinanceData
            //{
            //    Price = 10000,
            //    Rate = 6,
            //    DealerContribution = 0,
            //    FinalPayment = 5000,
            //    Deposit = 0,
            //    Term = 36
            //};
            //var payments = financeCalculatorService.LoanRepayments(financeData);
            //var pcpPayments = financeCalculatorService.PcpLoanRepayments(financeData);
        }

        [BindProperty]
        public FinanceData FinanceData { get; set; }

        public LoanRepaymentDetails LoanRepaymentDetails { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            LoanRepaymentDetails = financeCalculatorService.PcpLoanRepayments(FinanceData);
            return Page();
        }

    }

    public class FinanceResult
    {
        FinanceData FinanceData { get; set; }

    }
}