using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] minCoinsCount = new long[n + 1];
            return ChangeMoney(n, ref minCoinsCount);
        }

        private long ChangeMoney(long n, ref long[] minCoinsCount)
        {
            minCoinsCount[0] = 0;
            for (long m = 1; m <= n; m++)
            {
                minCoinsCount[m] = long.MaxValue;
                for (long i = 0; i < COINS.Length; i++)
                {
                    if (m >= COINS[i])
                    {
                        long coinsCount = minCoinsCount[m - COINS[i]] + 1;
                        if (coinsCount < minCoinsCount[m])
                            minCoinsCount[m] = coinsCount;
                    }
                }
            }
            return minCoinsCount[n];
        }
    }
}
