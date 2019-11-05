using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            // write your code here
            throw new NotImplementedException();
        }
    }
}
