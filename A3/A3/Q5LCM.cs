﻿using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            Q4GCD gcd = new Q4GCD("TD5");
            return (a * b) / gcd.Solve(a, b);
        }
    }
}
