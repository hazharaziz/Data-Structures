using System;
using TestCommon;

namespace A3
{
    public class Q4GCD : Processor
    {
        public Q4GCD(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            (a, b) = (a <= b) ? (b, a) : (a, b);
            return (b == 0) ? a : Solve(b, a % b);
        }
    }
}
