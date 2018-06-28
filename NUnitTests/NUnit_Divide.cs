using System;
using System.Text;
using NUnit.Framework;
using CSharpCalculator;


namespace NUnitTests
{
    [TestFixture]
    public class NUnit_Divide
    {
        private Calculator testCalculator;

        [SetUp]
        public void SetUpData()
        {
            testCalculator = new Calculator();
        }

        [TestCase(-1, -1, 1)]
        [TestCase(1, 0, double.NaN)]
        [TestCase(10, -5, -2)]
        public void AbsNUnitTestDouble(double num1, double num2, double expectedResult)
        {
            double actualResult = testCalculator.Divide(num1, num2);
            Assert.AreEqual(expectedResult, actualResult, $"Result of dividing '{num1}' to '{num2}'is incorrect");
        }
    }
}
