using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceCalculator.Models
{
    public interface ILoan
    {
        double MonthlyPayment();

        IList<DebtPayment> DebtPayments { get; }

        double TotalInterestCharged { get; }

        double TotalPayable { get; }

        double CostToBuy { get; }
    }
}
