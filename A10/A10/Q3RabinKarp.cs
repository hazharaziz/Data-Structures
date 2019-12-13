using System;
using System.Collections.Generic;
using System.Linq;
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
            string Text, int P, long p, long x)
        {
            int T = Text.Length;
            long[] result = new long[T - P + 1];
            string S = Text.Substring(T - P, P);
            result[T - P] = Q2HashingWithChain.PolyHash(S, 0, S.Length, p, x);
            long y = 1;
            for (long i = 1; i <= P; i++)
                y = (y * x) % p;
            for (int i = T - P - 1; i >= 0; i--)
            {
                result[i] = (x * result[i + 1] + (p * 10) +
                             Convert.ToInt32(Text[i]) -
                             (y * Convert.ToInt32(Text[i + P]))) % p;
            }
            return result;
        }
    }
}
