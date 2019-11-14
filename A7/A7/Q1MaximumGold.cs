using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            goldBars = goldBars.OrderByDescending(gb => gb).ToArray();
            long[,] valueMatrix = new long[W + 1, goldBars.Length + 1];

            for (long i = 1; i <= goldBars.Length; i++)
            {
                for (long j = 1; j <= W; j++)
                {
                    valueMatrix[j,i] = valueMatrix[j,i - 1];
                    if (goldBars[i - 1] <= j)
                    {
                        long val = valueMatrix[j - goldBars[i - 1], i - 1] 
                                              + goldBars[i - 1];
                        if (valueMatrix[j, i] < val)
                            valueMatrix[j, i] = val;
                    }
                }
            }
            return valueMatrix[W, goldBars.Length];
        }
    }
}
