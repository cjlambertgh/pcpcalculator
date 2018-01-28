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

        [TestMethod]
        public void CorrectMonthlyPayment()
        {
            var amount = 1000;
            var interest = 0;
            uint months = 10;
            var loan = new Loan(amount, interest, months);

            Assert.AreEqual(100.0, loan.MonthlyPayment());
        }

        [TestMethod]
        public void CorrectInterestAdded()
        {
            var amount = 1000;
            var interest = 12;
            uint months = 1;
            var expectedInterest = 10; //simple one month loan, interest charged = amount * (interest/12)/100
            var loan = new Loan(amount, interest, months);

            Assert.AreEqual(expectedInterest, loan.TotalInterestCharged);
        }

        [TestMethod]
        public void CorrectTotalRepayable()
        {
            var amount = 1000;
            var interest = 12;
            uint months = 1;
            var expectedInterest = 10; //simple one month loan, interest charged = amount * (interest/12)/100
            var loan = new Loan(amount, interest, months);

            Assert.AreEqual(expectedInterest+amount, loan.TotalPayable, 0.001);
        }

        [TestMethod]
        public void CorrectCostToBuy()
        {
            var amount = 1000;
            var interest = 12;
            uint months = 1;
            var expectedInterest = 10; //simple one month loan, interest charged = amount * (interest/12)/100
            var loan = new Loan(amount, interest, months);

            Assert.AreEqual(expectedInterest + amount, loan.CostToBuy, 0.001);
        }

        [TestMethod]
        public void ProvidedMonthlyPaymentUsesMonthlyPayment()
        {
            var amount = 1000;
            var interest = 0;
            uint months = 6;
            var monthlyPayment = 200;
            var loan = new Loan(amount, interest, months, monthlyPayment);

            Assert.AreEqual(monthlyPayment, loan.MonthlyPayment(), 0.001);
        }

        [TestMethod]
        public void ProvidedMonthlyPaymentCorrectNumberOfPayments()
        {
            var amount = 1000;
            var interest = 0;
            uint months = 5;
            var monthlyPayment = 200;
            var loan = new Loan(amount, interest, months, monthlyPayment);

            Assert.AreEqual(5, loan.DebtPayments.Count);
        }

        [TestMethod]
        public void ProvidedMonthlyPaymentReturnsTotalPayable()
        {
            var amount = 1000;
            var interest = 10;
            uint months = 5;
            var monthlyPayment = 600;
            var loan = new Loan(amount, interest, months, monthlyPayment);

            Assert.AreEqual(months * monthlyPayment, loan.TotalPayable);
        }

        [TestMethod]
        public void DebtPaymentsReturnExpectedValues()
        {
            var amount = 1000;
            var interest = 0;
            uint months = 2;
            var loan = new Loan(amount, interest, months);

            var monthOne = loan.DebtPayments[0];
            var monthTwo = loan.DebtPayments[1];

            Assert.AreEqual(500, monthOne.TotalPayment);
            Assert.AreEqual(500, monthTwo.TotalPayment);

            Assert.AreEqual((uint)0, monthOne.MonthNumber);
            Assert.AreEqual((uint)1, monthTwo.MonthNumber);

            Assert.AreEqual(500, monthOne.RemainingDebt, 0.001);
            Assert.AreEqual((uint)0, monthTwo.RemainingDebt, 0.001);
        }

    }
}

