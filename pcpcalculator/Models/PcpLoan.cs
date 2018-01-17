using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pcpcalculator.Models
{
    public class PcpLoan : ILoan
    {
        private readonly Loan repaymentLoan;
        private readonly Loan baloonLoan;

        public PcpLoan(FinanceData data)
        {
            repaymentLoan = new Loan(data.Price - data.Deposit - data.DealerContribution - data.FinalPayment, data.Rate, data.Term);
            baloonLoan = new Loan(data.FinalPayment, data.Rate, data.Term, 0);
        }

        public IList<DebtPayment> DebtPayments => repaymentLoan.DebtPayments;

        public double TotalInterestCharged => (repaymentLoan.TotalInterestCharged + baloonLoan.TotalInterestCharged);

        public double MonthlyPayment()
        {
            return repaymentLoan.MonthlyPayment();
        }
    }
}
