using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            int pisanoPeriodLength = PisanoPeriodLength(b);
            a = a % pisanoPeriodLength;
            return FibonacciLastDigit(a, b, pisanoPeriodLength);
        }

        // FibonacciLastDigit method returning the last digit of a 
        // fibonacci number by dividing the number over mod
        public long FibonacciLastDigit(long n, long mod, int periodLength)
        {
            long[] fibModArr = new long[periodLength];
            if (n != 0)
                fibModArr[1] = 1;
            for (int i = 2; i < periodLength; i++)
            {
                fibModArr[i] = (fibModArr[i - 1] + fibModArr[i - 2]) % mod;
            }
            return fibModArr[n % periodLength];
        }

        // PisanoPeriodLength method for returning the length of 
        // the pisano sequence
        public int PisanoPeriodLength(long mod)
        {
            long prev = 0;
            long current = 1;
            int pisanoPeriodLength = 0;
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
