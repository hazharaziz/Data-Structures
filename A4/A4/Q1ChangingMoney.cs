using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            int[] coins = { 10, 5, 1 };
            long count = 0;
            int index = 0;
            long subtractValue = 0;
            while (money > 0)
            {
                subtractValue = money - (money % coins[index]);
                count += (coins[index] != 1) ? subtractValue / coins[index] : 1;
                money -= (coins[index] != 1) ? subtractValue : 1;
                index += (coins[index] != 1) ? 1 : 0;
            }
            return count;
        }
    }
}
