using System;
using CSharpCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestCalculator
{

    [TestClass]
    public class MSTest_Divide
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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "DivideData.xml", "DivideMethodDouble", DataAccessMethod.Sequential)]
        [DeploymentItem("Data")]
        [TestMethod]
        public void DivideMethodDouble()
        {
            double input_a = Convert.ToDouble(_testContextInstance.DataRow["InputParameter1"]);
            double input_b = Convert.ToDouble(_testContextInstance.DataRow["InputParameter2"]);
            double expectedResult = Convert.ToDouble(_testContextInstance.DataRow["Result"]);
            double actualResult = testCalculator.Divide(input_a, input_b);

            Assert.AreEqual(expectedResult, actualResult, $"Result of dividing '{input_a}' to '{input_b}'is incorrect");
        }

        [TestCleanup]
        public void CleanUpData()
        {
            testCalculator = null;
        }
    }
}
