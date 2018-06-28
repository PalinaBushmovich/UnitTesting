using System;
using System.Text;
using NUnit.Framework;
using CSharpCalculator;


namespace NUnitTests
{
    [TestFixture]
    public class NUnit_IsNegative
    {
        private Calculator testCalculator;

        [SetUp]
        public void SetUpData()
        {
            testCalculator = new Calculator();
        }

        [TestCase(0, double.NaN)]
        [TestCase(180, false)]
        [TestCase(-2, true)]
        [TestCase(-0.7, double.NaN)]
        public void IsNegativeNUnitTestDouble(double input, double expectedResult)
        {
            bool actualResult = testCalculator.isNegative(input);
            Assert.AreEqual(expectedResult, actualResult, $"Incorrect 'IsNegative' value for double '{input}'");
        }

        [TestCase("0", "NaN")]
        [TestCase("180", "false")]
        [TestCase("-6", "true")]
        public void IsNegativeNUnitTestString(string input, string expectedResult)
        {
            bool actualResult = testCalculator.isNegative(input);
            Assert.AreEqual(expectedResult, actualResult, $"Incorrect 'IsNegative' value for string '{input}'");

        }
    }
}
