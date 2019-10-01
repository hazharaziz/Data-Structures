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
            int index = 0;
            long maxProduct = long.MinValue;

            SetIndex(numbers, ref index, 1, numsLength);
            Swap(ref numbers[numsLength - 1], ref numbers[index]);
            index = 0;
            SetIndex(numbers, ref index, 1, numsLength - 1);
            if (numsLength >= 2)
                Swap(ref numbers[numsLength - 2], ref numbers[index]);
            maxProduct = (numsLength >= 2) ? numbers[numsLength - 2] * numbers[numsLength - 1]
                                           : maxProduct = numbers[0];
            return maxProduct;
        }
        
        /// <summary>
        /// SetIndex method for setting the index of maximum number
        /// </summary>
        /// <param name="nums">array of numbers</param>
        /// <param name="index">index to be set</param>
        /// <param name="startPoint">start point of for loop</param>
        /// <param name="endPoint">end point of for loop</param>
        private void SetIndex(long[] nums, ref int index, 
                                int startPoint, int endPoint)
        {
            for (int i = startPoint; i < endPoint; i++)
                if (nums[i] > nums[index])
                    index = i;
        }

        /// <summary>
        /// Swap method for swapping the given values
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        private void Swap(ref long v1, ref long v2)
        {
            (v1, v2) = (v2, v1);
        }
    }
}
