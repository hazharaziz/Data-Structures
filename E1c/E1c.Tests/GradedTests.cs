using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace E1c.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {

        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q2UnitFractions()
        {
            RunTest(new Q2UnitFractions("TD2"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q3MaxSubarraySum()
        {
            RunTest(new Q3MaxSubarraySum("TD3"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E1a", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
