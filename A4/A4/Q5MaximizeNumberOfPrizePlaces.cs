using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            List<long> result = new List<long>();
            long subtract = 1;
            while (n > 0)
            {
                if ((n - subtract) == subtract)
                    subtract = n;
                if ((n - subtract) >= subtract || (n - subtract) == 0)
                {
                    n -= subtract;
                    result.Add(subtract);
                }
                subtract++;
            }
            return result.ToArray();
        }
    }
}

