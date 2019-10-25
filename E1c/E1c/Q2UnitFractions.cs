using System;
using System.Collections.Generic;
using TestCommon;

namespace E1c
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }


        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {
            double maxDenominator = 1;
            if (nr % dr == 0)
                maxDenominator = 1;
            else if (nr == 1)
                maxDenominator = dr;
            else
            {
                while (nr > 0)
                {
                    double denominator = dr / nr;
                    while (denominator * nr < dr)
                        denominator++;
                    nr = (long)(denominator * nr) - dr;
                    dr *= (long)denominator;
                    maxDenominator = denominator;
                }
            }
            return (long)maxDenominator;
        }
    }
}
