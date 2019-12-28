using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q5Rope : Processor
    {
        public Q5Rope(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long[][], string>)Solve);

        public string Solve(string text, long[][] queries)
        {
            throw new NotImplementedException();
        }
    }
}
