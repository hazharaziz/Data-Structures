using System;
using TestCommon;

namespace E1a
{
    public class Q1Stones : Processor
    {
        public Q1Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        
        public virtual long Solve(long n, long[] stones)
        {
            long resultDay = 0;
            long stoneCount = 0;

            while (stoneCount <= n)
            {
                if (resultDay >= stones.Length)
                {
                    resultDay = 0;
                    break;
                }

                stoneCount += stones[resultDay];
                resultDay++;

                if (stoneCount >= n)
                    break;
            }
            return resultDay;
        }
    }
}
