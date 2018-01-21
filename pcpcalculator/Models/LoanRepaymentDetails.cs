using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pcpcalculator.Models
{
    public class LoanRepaymentDetails
    {
        private readonly ILoan loan;

        public LoanRepaymentDetails(ILoan loan)
        {
            this.loan = loan;
        }

        public double MonthlyRepayment => loan.MonthlyPayment();

        public IEnumerable<DebtPayment> Repayments => loan.DebtPayments;

        public double TotalInterestAccrued => Math.Round(loan.TotalInterestCharged, 2);
    }
}
