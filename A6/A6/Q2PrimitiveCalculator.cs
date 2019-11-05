using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] Solve(long n)
        {
        	// write your code here
            throw new NotImplementedException();
        }
    }
}
