using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            throw new NotImplementedException();
        }
    }
}
