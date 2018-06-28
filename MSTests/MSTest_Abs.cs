using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSharpCalculator;

namespace UnitTesting.Tests
{
    [TestClass()]
    public class MSTest_Abs
    {
        private Calculator testCalculator;
        private static TestContext _testContextInstance;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _testContextInstance = context;
        }

        [TestInitialize]
        public void SetUpData()
        {
            testCalculator = new Calculator();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "AbsData.xml", "AbsMethodDouble", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        public void AbsMSTestDouble()
        {
            double input = Convert.ToDouble(_testContextInstance.DataRow["InputParameter"]);
            double expectedResult = Convert.ToDouble(_testContextInstance.DataRow["Result"]);
            double actualResult = testCalculator.Abs(input);

            Assert.AreEqual(expectedResult, actualResult, $"Absorption value of double '{input}' is incorrect");
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "AbsData.xml", "AbsMethodString", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        public void AbsMSTestString()
        {
            string input = _testContextInstance.DataRow["InputParameter"].ToString();
            string expectedResult = _testContextInstance.DataRow["Result"].ToString();
            double actualResult = testCalculator.Abs(input);

            Assert.AreEqual(Convert.ToDouble(expectedResult), actualResult, $"Absorption value of string '{input}' is incorrect");
        }

        [TestCleanup]
        public void CleanUpData()
        {
            testCalculator = null;
            
        }
    }
}