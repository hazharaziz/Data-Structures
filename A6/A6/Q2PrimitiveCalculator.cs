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
            long[] counts = minNumsCount(n);
            long[] resultSeq = SequenceNums(n, counts);
            return resultSeq;
        }

        //SequenceNums Method returning the sequence of the numbers
        private long[] SequenceNums(long n, long[] counts)
        {
            long[] result = new long[counts[n] + 1];
            result[0] = n;
            long idx = 1;
            while (n > 1)
            {
                long minCount;
                long index;
                long minusOne = counts[n - 1];
                long divideByTwo = (n % 2 == 0) ? counts[n / 2] : long.MaxValue;
                long divideByThree = (n % 3 == 0) ? counts[n / 3] : long.MaxValue;
                (minCount, index) = Min(minusOne, divideByTwo, divideByThree);
                switch (index)
                {
                    case 0:
                        result[idx] = n - 1;
                        n -= 1;
                        break;
                    case 1:
                        result[idx] = n / 2;
                        n /= 2;
                        break;
                    case 2:
                        result[idx] = n / 3;
                        n /= 3;
                        break;
                }
                idx++;
            }
            return result.Reverse().ToArray();
        }

        //minNumsCount Method returning the numbers minimum count
        private long[] minNumsCount(long n)
        {
            long[] counts = new long[n + 1];
            counts[0] = 0;
            counts[1] = 0;
            counts[2] = 1;
            counts[3] = 1;

            for (long c = 4; c <= n; c++)
            {   
                counts[c] = long.MaxValue;
                long minCount = long.MaxValue;
                long first = counts[c - 1] + 1;
                long second = (c % 2 == 0) ? counts[c / 2] + 1
                                           : long.MaxValue;
                long third = (c % 3 == 0) ? counts[c / 3] + 1
                                          : long.MaxValue;
                long index = 0;
                (minCount, index) = Min(first, second, third);
                if (minCount < counts[c])
                    counts[c] = minCount;
            }
            return counts;
        }

        //Min Method returning the minimum element of an array of numbers and
        //its index
        private (long, long) Min(params long[] numbers)
        {
            long min = long.MaxValue;
            long minIndex = 0;
            for (long i = 0; i < numbers.Length; i++)
                if (numbers[i] <= min)
                {
                    min = numbers[i];
                    minIndex = i;
                }
            return (min, minIndex);
        }
    }
}
