using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            int numsLength = numbers.Length;
            bool hasOneElement = numsLength >= 2 ? false : true;
            int index = 0;
            long maxProduct = long.MinValue;
            for (int i = 1; i < numsLength; i++)
                if (numbers[i] > numbers[index])
                    index = i;

            (numbers[numsLength - 1], numbers[index]) = (numbers[index], numbers[numsLength - 1]);
            index = 0;
            for (int i = 1; i < numsLength - 1; i++)
                if (numbers[i] > numbers[index])
                    index = i;
            if (!hasOneElement)
                (numbers[numsLength - 2], numbers[index]) = (numbers[index], numbers[numsLength - 2]);

            maxProduct = !hasOneElement ? numbers[numsLength - 2] * numbers[numsLength - 1]
                                        : maxProduct = numbers[0];
            return maxProduct;
        }
    }
}
