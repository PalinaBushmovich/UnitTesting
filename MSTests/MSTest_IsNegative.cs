using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpCalculator;

namespace MSTestCalculator
{
    /// <summary>
    /// Summary description for MSTest_IsNegative
    /// </summary>
    [TestClass]
    public class MSTest_IsNegative
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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "IsNegativeData.xml", "IsNegativeMethodDouble", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void IsNegativeMethodDouble()
        {
            double input = Convert.ToDouble(_testContextInstance.DataRow["InputParameter"]);
            bool expectedResult = Convert.ToBoolean(_testContextInstance.DataRow["Result"]);
            bool actualResult = testCalculator.isNegative(input);

            Assert.AreEqual(expectedResult, actualResult, $"Incorrect 'IsNegative' value for double '{input}'");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "IsNegativeData.xml", "IsNegativeMethodString", DataAccessMethod.Sequential)]

        [TestMethod]
        public void IsNegativeMethodString()
        {
            string input = _testContextInstance.DataRow["InputParameter"].ToString();
            bool expectedResult = Convert.ToBoolean(_testContextInstance.DataRow["Result"]);
            bool actualResult = testCalculator.isNegative(input);

            Assert.AreEqual(expectedResult, actualResult, $"Incorrect 'IsNegative' value for string '{input}'");
        }

        [TestCleanup]
        public void CleanUpData()
        {
            testCalculator = null;
        }
    }
}
