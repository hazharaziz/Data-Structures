using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace E1a.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q1Stones()
        {
            RunTest(new Q1Stones("TD1"));
        }
        
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q2UnitFractions()
        {
            RunTest(new Q2UnitFractions("TD2"));
        }


        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E1a", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
