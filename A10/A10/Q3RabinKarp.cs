using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            List<long> occurrences = new List<long>();
            int startIdx = 0;
            int foundIdx = 0;
            while ((foundIdx = text.IndexOf(pattern, startIdx)) >= startIdx)
            {
                startIdx = foundIdx + 1;
                occurrences.Add(foundIdx);
            }
            return occurrences.ToArray();
        }


        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            return new long[] { };
        }
    }
}
