using FinanceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceCalculator.Interfaces
{
    public interface IFinanceCalculatorService
    {
        string CalculateMonthlyPayment(FinanceData data);
        LoanRepaymentDetails LoanRepayments(FinanceData data);
        LoanRepaymentDetails PcpLoanRepayments(FinanceData data);
    }
}
