using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpCalculator;

namespace MSTestCalculator
{
    /// <summary>
    /// Summary description for MsTest_IsPositive
    /// </summary>
    [TestClass]
    public class MSTest_IsPositive
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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "IsPositiveData.xml", "IsPositiveMethodDouble", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void IsPositiveMethodDouble()
        {
            double input = Convert.ToDouble(_testContextInstance.DataRow["InputParameter"]);
            bool expectedResult = Convert.ToBoolean(_testContextInstance.DataRow["Result"]);
            bool actualResult = testCalculator.isPositive(input);

            Assert.AreEqual(expectedResult, actualResult, $"Incorrect 'IsPositive' value for double '{input}'");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "IsPositiveData.xml", "IsPositiveMethodString", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void IsPositiveMethodString()
        {
            string input = _testContextInstance.DataRow["InputParameter"].ToString();
            bool expectedResult = Convert.ToBoolean(_testContextInstance.DataRow["Result"]);
            bool actualResult = testCalculator.isPositive(input);

            Assert.AreEqual(expectedResult, actualResult, $"Incorrect 'IsPositive' value for string '{input}'");
        }

        [TestCleanup]
        public void CleanUpData()
        {
            testCalculator = null;
        }
    }
}
