using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            List<long> fibonacciList = new List<long>() { 0, 1 };
            return FibonacciSolution(n, ref fibonacciList);
        }

        private long FibonacciSolution(long n, ref List<long> fibList)
        {
            long result = 0;

            if (n < fibList.Count)
                return fibList[Convert.ToInt32(n)];
            else
            {
                result = FibonacciSolution(n - 1, ref fibList) + FibonacciSolution(n - 2, ref fibList);
                fibList.Add(result);
                return result;
            }

        }
    }
}
