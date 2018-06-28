using NUnit.Framework;
using CSharpCalculator;

namespace NUnitTests
{
    [TestFixture]
    public class NUnit_Sqrt
    {
        private Calculator testCalculator;

        [SetUp]
        public void SetUpData()
        {
            testCalculator = new Calculator();
        }

        [TestCase(2.7, 1.6431)]
        [TestCase(-3, double.NaN)]
        [TestCase(0,0)]
        public void SqrtNUnitTestDouble(double input, double expectedResult)
        {
            double actualResult = testCalculator.Sqrt(input);
            Assert.AreEqual(expectedResult, actualResult, 0.01, $"Incorrect square root for double '{input}'");

        }

        [TestCase("2.7", "1.6431")]
        [TestCase("-3", "NaN")]
        [TestCase("0", "0")]
        public void SqrtNUnitTestString(string input, string expectedResult)
        {
            double actualResult = testCalculator.Sqrt(input);
            Assert.AreEqual(System.Convert.ToDouble(expectedResult), actualResult, 0.0001, $"Incorrect square root for string '{input}'");

        }

    }

}