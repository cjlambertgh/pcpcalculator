using FinanceCalculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.FinanceCalculatorServiceTests
{
    [TestClass]
    public class LoanTests
    {
        [TestMethod]
        public void CanCreateLoan()
        {
            var obj = new Loan(0,0,0);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(Loan));
        }

        [TestMethod]
        public void CanCreateLoanWithPayment()
        {
            var obj = new Loan(0, 0, 0, 0);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(Loan));
        }

        [TestMethod]
        public void LoanWith6PaymentsReturns6Payments()
        {
            var amount = 100;
            var interest = 3;
            uint months = 6;
            var loan = new Loan(amount, interest, months);

            Assert.AreEqual(6, loan.DebtPayments.Count);
        }

        [TestMethod]
        public void LoanZeroInterestReturnsZeroInterest()
        {
            var amount = 100;
            var interest = 0;
            uint months = 6;
            var loan = new Loan(amount, interest, months);

            Assert.AreEqual(0, loan.TotalInterestCharged);
        }
    }
}
