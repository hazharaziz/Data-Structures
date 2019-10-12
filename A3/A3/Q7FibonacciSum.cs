using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long pisanoPeriodLength = PisanoPeriodLength(10);
            n = n % pisanoPeriodLength;
            return FibonacciLastDigit(n, 10);
        }

        // FibonacciLastDigit method returning the last digit of fibonacci number
        public long FibonacciLastDigit(long n, long mod)
        {
            long[] fibModArr = new long[n + 1];
            fibModArr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                fibModArr[i] = (fibModArr[i - 1] + fibModArr[i - 2]) % mod;
            }
            return fibModArr.Sum() % 10;
        }

        // PisanoPeriodLength method for returning the length of 
        // the pisano sequence
        public long PisanoPeriodLength(long mod)
        {
            long prev = 0;
            long current = 1;
            long pisanoPeriodLength = 0;
            for (int i = 0; i < mod * mod; i++)
            {
                (prev, current) = (current, (prev + current) % mod);

                if (prev == 0 && current == 1)
                {
                    pisanoPeriodLength = i + 1;
                    break;
                }
            }
            return pisanoPeriodLength;
        }
    }
}
