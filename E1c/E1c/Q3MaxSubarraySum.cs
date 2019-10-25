using System;
using TestCommon;

namespace E1c
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            long maxSum = long.MinValue;
            long currentSum = 0;

            for (long i = 0; i < n; i++)
            {
                if (currentSum <= 0)
                    currentSum = numbers[i];
                else
                    currentSum += numbers[i];
                if (currentSum > maxSum)
                    maxSum = currentSum;
            }

            return maxSum;
        }
    }
}
