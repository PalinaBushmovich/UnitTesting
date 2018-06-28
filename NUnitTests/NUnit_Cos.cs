using System;
using System.Text;
using NUnit.Framework;
using CSharpCalculator;


namespace NUnitTests
{
    [TestFixture]
    public class NUnit_Cos
    {
        private Calculator testCalculator;

        [SetUp]
        public void SetUpData()
        {
            testCalculator = new Calculator();
        }

        [TestCase(0, 1)]
        [TestCase(180, -1)]
        [TestCase(270, 0)]
        [TestCase(-0, double.NaN)]
        public void CosNUnitTestDouble(double num, double expectedResult)
        {
            double actualResult = testCalculator.Cos(num);
            Assert.AreEqual(expectedResult, actualResult, $"Cos of double'{num}' is incorrect");
        }

        [TestCase("0", "1")]
        [TestCase("180", "-1")]
        [TestCase("-0", "NaN")]
        public void CosNUnitTestString(string num, string expectedResult)
        {
            double actualResult = testCalculator.Cos(num);
            Assert.AreEqual(System.Convert.ToDouble(expectedResult), actualResult, 0.0001, $"Cos of string '{num}' is incorrect");

        }
    }
}
