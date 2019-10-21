using System;
using System.Linq;
using TestCommon;

namespace E1b
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[] first = new long[n];
            long[] second = new long[n];
            first[0] = numbers[0][0];
            second[0] = numbers[1][0];

            for (int i = 1; i < n; i++)
            {
                first[i] = numbers[0][i] + Math.Max(first[i - 1], second[i - 1] - p);
                second[i] = numbers[1][i] + Math.Max(second[i - 1], first[i - 1] - p);
            }
            return Math.Max(first[first.Length - 1], second[second.Length - 1]);
        }
    }
}
