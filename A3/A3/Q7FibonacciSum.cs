using System;
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
            //long[] fibLastDigitArr = new long[n + 1];
            //if (n != 0)
            //    fibLastDigitArr[1] = 1;
            //FibonacciSolution(n, ref fibLastDigitArr);
            //return fibLastDigitArr.Sum() % 10;
            throw new NotImplementedException();
        }

        public void FibonacciSolution(long n, long mod,
                                                ref long[] fibArr)
        {
            for (int i = 2; i <= n; i++)
                fibArr[i] = (fibArr[i - 1] + fibArr[i - 2]) % 10;
        }

    }

}
