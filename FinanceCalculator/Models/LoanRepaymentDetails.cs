using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceCalculator.Models
{
    public class LoanRepaymentDetails
    {
        private readonly ILoan loan;

        public LoanRepaymentDetails(ILoan loan)
        {
            this.loan = loan;
        }

        public double MonthlyRepayment => Math.Round(loan.MonthlyPayment(), 2);

        public IEnumerable<DebtPayment> Repayments => loan.DebtPayments;

        public double TotalInterestAccrued => Math.Round(loan.TotalInterestCharged, 2);

        public double TotalPayable => Math.Round(loan.TotalPayable, 2);

        public double CostToBuy => Math.Round(loan.CostToBuy, 2);
    }
}
