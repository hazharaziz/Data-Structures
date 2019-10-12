using System;
using TestCommon;

namespace A3
{
    public class Q3FibonacciLastDigit : Processor
    {
        public Q3FibonacciLastDigit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long[] fiblastDigitArr = new long[n + 1];
            if (n != 0)
                fiblastDigitArr[1] = 1;
            return getFibLastDigits(n, ref fiblastDigitArr);
        }

        //getFibLastDigits method for getting the last digit 
        //of fibonacci numbers in the given array
        public long getFibLastDigits(long n, ref long[] fibArr)
        {
            if (n <= 1)
                return fibArr[n] % 10;
            for (int i = 2; i <= n; i++)
                fibArr[i] = (fibArr[i - 1] + fibArr[i - 2]) % 10;

            return fibArr[fibArr.Length - 1];
        }

    }
}
