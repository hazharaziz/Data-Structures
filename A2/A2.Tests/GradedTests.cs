using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            Q1NaiveMaxPairWise q1NaiveMaxPairWise = new Q1NaiveMaxPairWise("TD1");
            Q2FastMaxPairWise q2FastMaxPairWise = new Q2FastMaxPairWise("TD2");
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (true)
            {
                Random rnd = new Random();
                int n = rnd.Next(1, 10);
                int m = rnd.Next(1, 10);
                long[] arr = new long[n];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = rnd.Next(1, m);
                long result1 = q1NaiveMaxPairWise.Solve(arr);
                long result2 = q2FastMaxPairWise.Solve(arr);
                Assert.AreEqual(result1,result2);
                if (stopwatch.ElapsedMilliseconds >= 5000)
                    break;
            }
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}