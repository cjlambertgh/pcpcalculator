using pcpcalculator.Models;
using System.Collections.Generic;

namespace pcpcalculator.Services
{
    public interface IFinanceCalculatorService
    {
        string CalculateMonthlyPayment(FinanceData data);
        LoanRepaymentDetails LoanRepayments(FinanceData data);
        LoanRepaymentDetails PcpLoanRepayments(FinanceData data);
    }
}