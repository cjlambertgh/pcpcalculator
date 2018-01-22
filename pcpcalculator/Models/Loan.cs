using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pcpcalculator.Models
{
    public class Loan: ILoan
    {
        private readonly double loanAmount;
        private readonly double annualInterestRate;
        private readonly uint numberOfMonths;
        private readonly double monthlyInterestRate;
        private readonly double decimalMonthlyInterestRate;
        private readonly double monthlyPayment;

        public Loan(double loanAmount, double annualInterest, uint numberOfMonths)
        {
            this.loanAmount = loanAmount;
            this.annualInterestRate = annualInterest;
            this.numberOfMonths = numberOfMonths;
            monthlyInterestRate = annualInterest / 12;
            decimalMonthlyInterestRate = monthlyInterestRate / 100;
            monthlyPayment = CalculateMonthlyPayment();
            Calculate();
        }

        public Loan(double loanAmount, double annualInterest, uint numberOfMonths, double monthlyPayment)
        {
            this.loanAmount = loanAmount;
            this.annualInterestRate = annualInterest;
            this.numberOfMonths = numberOfMonths;
            monthlyInterestRate = annualInterest / 12;
            decimalMonthlyInterestRate = monthlyInterestRate / 100;
            this.monthlyPayment = monthlyPayment;
            Calculate();
        }

        public virtual IList<DebtPayment> DebtPayments { get; set; } = new List<DebtPayment>();

        public virtual double TotalInterestCharged => DebtPayments.Sum(p => p.InterestPaid);

        public double TotalPayable => MonthlyPayment() * numberOfMonths;

        public double CostToBuy => TotalPayable;

        public virtual double MonthlyPayment()
        {
            return monthlyPayment;
        }

        private double CalculateMonthlyPayment()
        {
            var OnePlusRate = 1 + decimalMonthlyInterestRate;
            var top = (Math.Pow(OnePlusRate, numberOfMonths)) - 1;
            var bottom = decimalMonthlyInterestRate * (Math.Pow(OnePlusRate, numberOfMonths));
            var discountFactor = top / bottom;
            var monthlyPayment = loanAmount / discountFactor;
            return monthlyPayment;
        }

        private void Calculate()
        {
            var currentBalance = loanAmount;
            for (uint month = 0; month < numberOfMonths; month++)
            {
                var interestAccrued = currentBalance * decimalMonthlyInterestRate;
                var principalRepaid = monthlyPayment - interestAccrued;
                currentBalance -= principalRepaid;
                DebtPayments.Add(new DebtPayment
                {
                    InterestPaid = interestAccrued,
                    MonthNumber = month,
                    TotalPayment = monthlyPayment,
                    Principal = principalRepaid,
                    RemainingDebt = Math.Round(currentBalance)
                });

            }
        }
    }
}
