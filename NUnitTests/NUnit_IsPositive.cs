using System;
using System.Text;
using NUnit.Framework;
using CSharpCalculator;


namespace NUnitTests
{
    [TestFixture]
    public class NUnit_IsPositive
    {
        private Calculator testCalculator;

        [SetUp]
        public void SetUpData()
        {
            testCalculator = new Calculator();
        }

        [TestCase(0, double.NaN)]
        [TestCase(180, true)]
        [TestCase(-2, false)]
        [TestCase(-0.7, false)]
        public void IsPositiveNUnitTestDouble(double input, double expectedResult)
        {
            bool actualResult = testCalculator.isPositive(input);
            Assert.AreEqual(expectedResult, actualResult, $"Incorrect 'IsPositive' value for string '{input}'");
        }

        [TestCase("0", "NaN")]
        [TestCase("180", "true")]
        [TestCase("-6", "false")]
        public void IsPositiveNUnitTestString(string input, string expectedResult)
        {
            bool actualResult = testCalculator.isPositive(input);
            Assert.AreEqual(expectedResult, actualResult, $"Incorrect 'IsPositive' value for string '{input}'");

        }
    }
}
