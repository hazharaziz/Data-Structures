using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            throw new NotImplementedException();
        }
    }
}
