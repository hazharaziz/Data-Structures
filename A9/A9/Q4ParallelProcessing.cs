using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q4ParallelProcessing : Processor
    {
        public Q4ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            throw new NotImplementedException();
        }
    }
}
