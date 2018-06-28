using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpCalculator;

namespace MSTestCalculator
{
    [TestClass]
    public class MSTest_Multiply
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
            testCalculator = new CSharpCalculator.Calculator();
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "MultiplyData.xml", "MultiplyMethodDouble", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void MultiplyMethodDouble()
        {
            double input_a = Convert.ToDouble(_testContextInstance.DataRow["InputParameter1"]);
            double input_b = Convert.ToDouble(_testContextInstance.DataRow["InputParameter2"]);
            double expectedResult = Convert.ToDouble(_testContextInstance.DataRow["Result"]);
            double actualResult = testCalculator.Multiply(input_a, input_b);

            Assert.AreEqual(expectedResult, actualResult, $"incorrect result of multiply '{input_a}' and '{input_b}'");
        }

        [TestCleanup]
        public void CleanUpData()
        {
            testCalculator = null;
        }
    }
}
