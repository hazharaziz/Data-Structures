using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            adRevenue = adRevenue.OrderByDescending(ad => ad).ToArray();
            averageDailyClick = averageDailyClick.OrderByDescending(av => av).ToArray();
            long result = 0;
            for (long i = 0; i < slotCount; i++)
                result += adRevenue[i] * averageDailyClick[i];
            return result;
        }
    }
}
