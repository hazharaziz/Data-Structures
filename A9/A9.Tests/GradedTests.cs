﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace A9.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q1ConvertIntoHeap()
        {
            RunTest(new Q1ConvertIntoHeap("TD1"));
        }

        [TestMethod(), Timeout(2000)]
        public void SolveTest_Q2MergingTables()
        {
            RunTest(new Q2MergingTables("TD2"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q3Froggie()
        {
            RunTest(new Q3Froggie("TD3"));
        }


        [TestMethod(), Timeout(3000)]
        public void SolveTest_Q4ParallelProcessing()
        {
            Assert.Inconclusive();
            RunTest(new Q4ParallelProcessing("TD4"));
        }


        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A9", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
