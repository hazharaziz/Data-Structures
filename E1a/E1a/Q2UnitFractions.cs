using System;
using System.Collections.Generic;
using TestCommon;

namespace E1a
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {
            double sum = 0;
            double target = (double)nr / dr;
            double latestDr = 1;
            double maxDenominator = latestDr;

            while (sum <= target)
            {
                if (target - sum <= 0.001)
                    break;
                double fraction;
                if (nr % dr == 0)
                {
                    maxDenominator = 1;
                    break;
                }
                if (sum > 0)
                {
                    latestDr = ((nr - (sum * dr)) == 1)
                                    ? (dr)
                                    : (long)Math.Ceiling(dr / (nr - (sum * dr)));
                    fraction = (1 / latestDr);
                    sum += fraction;
                    maxDenominator = latestDr;
                }
                else
                {
                    fraction = 1 / latestDr;
                    sum += ((sum + fraction) <= target) ? (fraction) : 0;

                    maxDenominator = latestDr;
                    latestDr++;
                }
            }

            return (long)maxDenominator;
        }
    }
}
