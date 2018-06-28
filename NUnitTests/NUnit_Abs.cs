using System;
using System.Text;
using NUnit.Framework;
using CSharpCalculator;



namespace NUnitTests
{
    [TestFixture]
    public class NUnit_Abs
    {

       private Calculator testCalculator;

        [SetUp]
        public void SetUpData()
        {
            testCalculator = new Calculator();
        }

        [TestCase(-1, 1)]
        [TestCase(-3.5, 3.5)]
        [TestCase(0, 0)]
        public void AbsNUnitTestDouble(double num, double expectedResult)
        {
            double actualResult = testCalculator.Abs(num);
            Assert.AreEqual(expectedResult, actualResult, $"Absorption value of double '{num}' is incorrect");
        }

        [TestCase("-1", "1")]
        [TestCase("-3.5", "3.5")]
        [TestCase("0", "0")]
        public void AbstNUnitTestString(string num, string expectedResult)
        {
            double actualResult = testCalculator.Abs(num);
            Assert.AreEqual(System.Convert.ToDouble(expectedResult), actualResult, 0.0001, $"Absorption value of string '{num}' is incorrect");

        }
    }
}
