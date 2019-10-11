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
            long[] fibArr = new long[n + 1];
            if (n != 0)
                fibArr[1] = 1;
            return FibonacciSolution(n, ref fibArr);
        }

        private long FibonacciSolution(long n, ref long[] fibArr)
        {
            if (n <= 1)
                return fibArr[n];
            for (int i = 2; i <= n; i++)
                fibArr[i] = fibArr[i - 1] + fibArr[i - 2];

            return fibArr[fibArr.Length - 1];
        }
    }
}
