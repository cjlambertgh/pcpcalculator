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
        private readonly FinanceData financeData;

        public PcpLoan(FinanceData data)
        {
            repaymentLoan = new Loan(data.Price - data.Deposit - data.DealerContribution - data.FinalPayment, data.Rate, data.Term);
            baloonLoan = new Loan(data.FinalPayment, data.Rate, data.Term, 0);
            financeData = data;
        }

        public IList<DebtPayment> DebtPayments => repaymentLoan.DebtPayments;

        public double TotalInterestCharged => (repaymentLoan.TotalInterestCharged + baloonLoan.TotalInterestCharged);

        public double TotalCostOfFinance => throw new NotImplementedException();

        public double MonthlyPayment()
        {
            var payment = repaymentLoan.MonthlyPayment();
            var baloonInterest = baloonLoan.DebtPayments.Sum(p => p.InterestPaid);
            var monthlyBaloonInterest = baloonInterest / financeData.Term;
            return payment += monthlyBaloonInterest;
        }
    }
}
