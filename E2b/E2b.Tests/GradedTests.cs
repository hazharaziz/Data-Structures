using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestCommon;

namespace E2b.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2000)]
        public void SolveTest_Q1ImplementNextForBST()
        {
            RunTest(new Q1ImplementNextForBST("TD1"));
        }

        [TestMethod(), Timeout(15000)]
        public void SolveTest_Q2HashTableAttack()
        {
            Assert.Inconclusive();
            Processor p = new Q2HashTableAttack("TD2");
            TestTools.RunLocalTest("E2b", p.Process, p.TestDataName, HashVerifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
               excludedTestCases: p.ExcludedTestCases);
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E2b", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
               excludedTestCases: p.ExcludedTestCases);
        }

        public static void HashVerifier(string inputFileName, string testResult)
        {
            long bucketCount = long.Parse(File.ReadAllText(inputFileName));
            string[] result = testResult.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries);
            Assert.IsTrue(result.Length == bucketCount * 0.9);
            long bucketNumber = Q2HashTableAttack.GetBucketNumber(result[0], bucketCount);
            foreach (string str in result)
                Assert.AreEqual(bucketNumber, Q2HashTableAttack.GetBucketNumber(str, bucketCount));
        }
    }
}