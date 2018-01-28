using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceCalculator.Models
{
    public class DebtPayment
    {
        public double TotalPayment { get; set; }
        public double Principal { get; set; }
        public double InterestPaid { get; set; }
        public uint MonthNumber { get; set; }
        public double RemainingDebt { get; set; }
    }
}
