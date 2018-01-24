using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pcpcalculator.Models
{
    public class FinanceData
    {
        [DataType(DataType.Currency)]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        [DataType(DataType.Currency)]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "Deposit can't be negative")]
        public double Deposit { get; set; }

        [DataType(DataType.Currency)]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "Dealer Contribution can't be negative")]
        public double DealerContribution { get; set; }

        [Range(minimum: 1, maximum: uint.MaxValue, ErrorMessage = "Term must be greater than 0")]
        public uint Term { get; set; }

        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "Rate can't be negative")]
        public double Rate { get; set; }

        [DataType(DataType.Currency)]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "Final Payment can't be negative")]
        public double FinalPayment { get; set; }
    }
}
