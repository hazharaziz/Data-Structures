using System;
using System.Linq;
using TestCommon;

namespace E1b
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        {
            this.ExcludeTestCaseRangeInclusive(13, 40);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            long maxSum = 0;

            long k = 0;

            while (k < n)
            {
                long i = k;
                long tempSum = 0;
                while (i < n)
                {
                    tempSum += numbers[i];
                    if (tempSum > maxSum)
                        maxSum = tempSum;
                    i++;
                }
                k++;
            }

            return maxSum;
        }   
    }
}
