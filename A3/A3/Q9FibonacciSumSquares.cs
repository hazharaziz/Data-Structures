using System;
using System.Linq;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            Q6FibonacciMod q6 = new Q6FibonacciMod("TD6");
            long lastFib = q6.Solve(n, 10);
            long preLastFib = q6.Solve(n - 1, 10);
            return (lastFib * (preLastFib + lastFib)) % 10;
        }

    }
}
