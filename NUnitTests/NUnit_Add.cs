using System;
using System.Text;
using NUnit.Framework;
using CSharpCalculator;

namespace NUnitTests
{
    [TestFixture]
    public class NUnit_Add
    {
        private Calculator testCalculator;

        [SetUp]
        public void SetUpData()
        {
            testCalculator = new Calculator();
        }

        [TestCase(-1, -1, -2)]
        [TestCase(0, 1, 1)]
        [TestCase(-2.3, 4, -6.3)]
        public void AbsNUnitTestDouble(double num1, double num2, double expectedResult)
        {
            double actualResult = testCalculator.Add(num1, num2);
            Assert.AreEqual(expectedResult, actualResult, $"Incorrect result of sum '{num1}' and '{num2}' when using double values");
        }

        [TestCase("-1", "-1", "-2")]
        [TestCase("0", "1", "1")]
        [TestCase("-2.3", " 4", "-6.3")]
        public void AbstNUnitTestString(string num1, string num2, string expectedResult)
        {
            double actualResult = testCalculator.Add(num1, num2);
            Assert.AreEqual(System.Convert.ToDouble(expectedResult), actualResult, $"Incorrect result of sum '{num1}' and '{num2}' when using string values");
        }
    }
}
