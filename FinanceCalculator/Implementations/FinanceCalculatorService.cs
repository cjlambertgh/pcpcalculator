using FinanceCalculator.Interfaces;
using FinanceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceCalculator.Implementations
{
    public class FinanceCalculatorService : IFinanceCalculatorService
    {
        public string CalculateMonthlyPayment(FinanceData data)
        {
            var repaymentValue = data.Price - data.Deposit - data.DealerContribution - data.FinalPayment;
            var loan = new Loan(repaymentValue, data.Rate, data.Term);
            var monthlyPayment = loan.MonthlyPayment();
            return monthlyPayment.ToString();
        }

        public LoanRepaymentDetails LoanRepayments(FinanceData data)
        {
            var repaymentValue = data.Price;
            var loan = new Loan(repaymentValue, data.Rate, data.Term);
            var reapayments = new LoanRepaymentDetails(loan);
            return reapayments;
        }

        public LoanRepaymentDetails PcpLoanRepayments(FinanceData data)
        {
            var repaymentValue = data.Price - data.Deposit - data.DealerContribution - data.FinalPayment;
            var loan = new PcpLoan(data);
            var reapayments = new LoanRepaymentDetails(loan);
            return reapayments;
        }
    }
}
