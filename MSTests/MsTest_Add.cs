using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpCalculator;

namespace MSTestCalculator
{

    /// <summary>
    /// Summary description for MsTest_Add
    /// </summary>
    [TestClass]
    public class MsTest_Add
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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "AddData.xml", "AddMethodDouble", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void AddMethodDouble()
        {
            double input_a = Convert.ToDouble(_testContextInstance.DataRow["InputParameter1"]);
            double input_b = Convert.ToDouble(_testContextInstance.DataRow["InputParameter2"]);
            double expectedResult = Convert.ToDouble(_testContextInstance.DataRow["Result"]);
            double actualResult = testCalculator.Add(input_a, input_b);

            Assert.AreEqual(expectedResult, actualResult, $"Incorrect result of sum '{input_a}' and '{input_a}' when using double values");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "AddData.xml", "AddMethodString", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void AddMethodString()
        {
            string input_a = _testContextInstance.DataRow["InputParameter1"].ToString();
            string input_b = _testContextInstance.DataRow["InputParameter2"].ToString();
            double expectedResult = Convert.ToDouble(_testContextInstance.DataRow["Result"]);
            double actualResult = testCalculator.Add(input_a, input_b);

            Assert.AreEqual(expectedResult, actualResult, $"Incorrect result of sum '{input_a}' and '{input_a}' when using string values");
        }

        [TestCleanup]
        public void CleanUpData()
        {
            testCalculator = null;
        }
    }
}
