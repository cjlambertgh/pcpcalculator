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
        }

        [BindProperty]
        public FinanceData FinanceData { get; set; }

        public LoanRepaymentDetails LoanRepaymentDetails { get; set; }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                LoanRepaymentDetails = financeCalculatorService.PcpLoanRepayments(FinanceData);
            }            
            return Page();
        }

    }

    public class FinanceResult
    {
        FinanceData FinanceData { get; set; }

    }
}