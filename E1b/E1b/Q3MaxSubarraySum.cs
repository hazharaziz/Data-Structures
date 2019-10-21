using System;
using System.Linq;
using TestCommon;

namespace E1b
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            long sum = 0;
            if (n == 1)
                sum += numbers[0];
            else if (n == 2)
                sum += (numbers.Max() > numbers.Sum()) ? numbers.Max() : numbers.Sum();
            else
            {
                long mid = numbers.Length / 2;
            }
            return sum;
        }   
    }
}
