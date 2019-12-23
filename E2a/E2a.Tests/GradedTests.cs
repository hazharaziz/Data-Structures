using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestCommon;

namespace E2a.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2600)]
        public void SolveTest_Q1BSTInOrderTraverse()
        {
            RunTest(new Q1BSTInOrderTraverse("TD1"));
        }


        [TestMethod(), Timeout(1700)]
        public void SolveTest_Q2ThreeChildrenMinHeap()
        {
            RunTest(new Q2ThreeChildrenMinHeap("TD2"));
        }
     
        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E2a", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
               excludedTestCases: p.ExcludedTestCases);
        }

    }
}