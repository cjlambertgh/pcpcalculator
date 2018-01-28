using FinanceCalculator.Implementations;
using FinanceCalculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.FinanceCalculatorServiceTests
{
    [TestClass]
    public class FinanceCalculatorTests
    {
        [TestMethod]
        public void CanCreateSerivce()
        {
            var svc = new FinanceCalculatorService();

            Assert.IsNotNull(svc);
            Assert.IsInstanceOfType(svc, typeof(FinanceCalculatorService));
        }

        [TestMethod]
        public void CalculateMonthlyRepaymentReturnsString()
        {
            var svc = new FinanceCalculatorService();

            var result = svc.CalculateMonthlyPayment(new FinanceData());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void LoanRepaymentReturnsLoanRepaymentDetails()
        {
            var svc = new FinanceCalculatorService();

            var result = svc.LoanRepayments(new FinanceData());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(LoanRepaymentDetails));
        }

        [TestMethod]
        public void PcpLoanRepaymentReturnsLoanRepaymentDetails()
        {
            var svc = new FinanceCalculatorService();

            var result = svc.PcpLoanRepayments(new FinanceData());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(LoanRepaymentDetails));
        }
    }
}
