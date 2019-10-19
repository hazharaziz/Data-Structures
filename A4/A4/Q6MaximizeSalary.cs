using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        public virtual string Solve(long n, long[] numbers)
        {
            List<long> nums = numbers.ToList();
            string result = "";
            long count = 0;
            while (count < n)
            {
                long maxDigit = GetMaxNumber(nums);
                nums.RemoveAt(nums.IndexOf(maxDigit));
                result += maxDigit;
                count++;
            }
            return result;
        }

        //GetMaxNumber method returning the maximum number of the list by specific comparison
        private long GetMaxNumber(List<long> numbers)
        {
            long maxDigit = 0;
            foreach (long number in numbers)
                if (IsGreaterOrEqual(number, maxDigit))
                {
                    maxDigit = number;
                }

            return maxDigit;
        }

        //IsGreaterOrEqual method checking the greatness of two numbers by checking their permutations
        private bool IsGreaterOrEqual(long number, long maxDigit)
        {
            bool result = false;
            string n1 = $"{number}{maxDigit}";
            string n2 = $"{maxDigit}{number}";
            result = (long.Parse(n1) - long.Parse(n2) >= 0) ? true : false;
            return result;
        }
    }
}

