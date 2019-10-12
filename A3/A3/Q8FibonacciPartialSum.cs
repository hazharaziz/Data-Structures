using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            Q7FibonacciSum q7 = new Q7FibonacciSum("TD8");
            if (a <= b)
                (a, b) = (b, a);
            long greaterLastDigit = q7.Solve(a);
            long smallerLastDigit = q7.Solve(b - 1);

            if (greaterLastDigit < smallerLastDigit)
                return (greaterLastDigit + 10) - smallerLastDigit;
            return q7.Solve(a) - q7.Solve(b - 1);
        }
    }
}
