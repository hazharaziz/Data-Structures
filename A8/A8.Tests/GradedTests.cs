using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace A8.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(300)]
        public void SolveTest_Q1CheckBrackets()
        {
            RunTest(new Q1CheckBrackets("TD1"));
        }

        [TestMethod(), Timeout(1400)]
        public void SolveTest_Q2TreeHeight()
        {
            RunTest(new Q2TreeHeight("TD2"));
        }

        [TestMethod(), Timeout(500)]
        public void SolveTest_Q3PacketProcessing()
        {
            RunTest(new Q3PacketProcessing("TD3"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A8", p.Process, p.TestDataName, p.Verifier, 
                VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}