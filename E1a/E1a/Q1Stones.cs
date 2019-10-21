using System;
using TestCommon;

namespace E1a
{
    public class Q1Stones : Processor
    {
        public Q1Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] stones)
        {
            throw new NotImplementedException();
        }
    }
}
