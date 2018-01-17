using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pcpcalculator.Models
{
    public class FinanceData
    {
        public double Price { get; set; }
        public double Deposit { get; set; }
        public double DealerContribution { get; set; }
        public uint Term { get; set; }
        public double Rate { get; set; }
        public double FinalPayment { get; set; }
    }
}
