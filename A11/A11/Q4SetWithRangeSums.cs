using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q4SetWithRangeSums : Processor
    {
        public Q4SetWithRangeSums(string testDataName) : base(testDataName)
        {
            CommandDict =
                        new Dictionary<char, Func<string, string>>()
                        {
                            ['+'] = Add,
                            ['-'] = Del,
                            ['?'] = Find,
                            ['s'] = Sum
                        };
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public readonly Dictionary<char, Func<string, string>> CommandDict;

        public const long M = 1_000_000_001;

        public long X = 0;

        protected List<long> Data;

        public string[] Solve(string[] lines)
        {
            X = 0;
            Data = new List<long>();
            List<string> result = new List<string>();
            foreach (var line in lines)
            {
                char cmd = line[0];
                string args = line.Substring(1).Trim();
                var output = CommandDict[cmd](args);
                if (null != output)
                    result.Add(output);
            }
            return result.ToArray();
        }

        private long Convert(long i)
            => i = (i + X) % M;

        private string Add(string arg)
        {
            long i = Convert(long.Parse(arg));
            int idx = Data.BinarySearch(i);
            if (idx < 0)
                Data.Insert(~idx, i);

            return null;
        }

        private string Del(string arg)
        {
            long i = Convert(long.Parse(arg));
            int idx = Data.BinarySearch(i);
            if (idx >= 0)
                Data.RemoveAt(idx);

            return null;
        }

        private string Find(string arg)
        {
            long i = Convert(int.Parse(arg));
            int idx = Data.BinarySearch(i);
            return idx < 0 ?
                "Not found" : "Found";
        }

        private string Sum(string arg)
        {
            var toks = arg.Split();
            long l = Convert(long.Parse(toks[0]));
            long r = Convert(long.Parse(toks[1]));

            l = Data.BinarySearch(l);
            if (l < 0)
                l = ~l;

            r = Data.BinarySearch(r);
            if (r < 0)
                r = (~r - 1);
            // If not ~r will point to a position with
            // a larger number. So we should not include 
            // that position in our search.

            long sum = 0;
            for (int i = (int)l; i <= r && i < Data.Count; i++)
                sum += Data[i];

            X = sum;

            return sum.ToString();
        }
    }
}
