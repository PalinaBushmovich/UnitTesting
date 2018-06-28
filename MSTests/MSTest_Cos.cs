using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpCalculator;

namespace MSTestsCalculator
{
    [TestClass]
    public class MSTest_Cos
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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "CosData.xml", "CosMethodDouble", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void CosMethodDouble()
        {
            double input = Convert.ToDouble(_testContextInstance.DataRow["InputParameter"]);
            double expectedResult = Convert.ToDouble(_testContextInstance.DataRow["Result"]);
            double actualResult = testCalculator.Cos(input);

            Assert.AreEqual(expectedResult, actualResult, 0.0001, $"Cos of double '{input}' is incorrect");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "CosData.xml", "CosMethodString", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void CosMethodString()
        {
            string input = _testContextInstance.DataRow["InputParameter"].ToString();
            double expectedResult = Convert.ToDouble(_testContextInstance.DataRow["Result"]);
            double actualResult = testCalculator.Cos(input);

            Assert.AreEqual(expectedResult, actualResult, 0.0001, $"Cos of string '{input}' is incorrect");
        }

        [TestCleanup]
        public void CleanUpData()
        {
            testCalculator = null;
        }
    }
}
