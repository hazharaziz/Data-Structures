using System;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {
        long[] parent;
        long[] tableSizes;
        long[] rank;

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, 
                                                long[] sourceTables)
        {
            long max = tableSizes.Max();
            long length = tableSizes.Length;
            long[] maxSizes = new long[targetTables.Length];
            long tempSize;
            long source;
            long dest;
            parent = new long[length];
            for (long i = 0; i < length; i++)
                parent[i] = i + 1;

            rank = tableSizes;

            for (long i = 0; i < targetTables.Length; i++)
            {
                source = Find(sourceTables[i]);
                dest = Find(targetTables[i]);
                if (source != dest)
                {
                    rank[dest - 1] += rank[source - 1];
                    rank[source - 1] = 0;
                    parent[source - 1] = dest;
                }
                tempSize = rank[dest - 1];

                max = (tempSize > max) ? tempSize : max;
                maxSizes[i] = max;
            }
            return maxSizes;
        }

        public long Find(long i)
        {
            while (i != parent[i - 1])
                i = parent[i - 1];
            return i;
        }
    }
}
