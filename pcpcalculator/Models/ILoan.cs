using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pcpcalculator.Models
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
