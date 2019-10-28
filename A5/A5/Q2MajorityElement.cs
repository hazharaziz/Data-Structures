using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            a = a.OrderByDescending(num => num).Reverse().ToArray();
            long majCandidate = SetCandidate(a);
            long count = 0;
            long result = 0;
            for (long i = 0; i < n; i++)
            {
                if (a[i] == majCandidate)
                {
                    count++;
                }
                if (count > n / 2)
                {
                    result = 1;
                    break;
                }
            }
            return result;
        }

        private long SetCandidate(long[] arr)
        {
            long majIndex = 0;
            long count = 1;
            for (long i = 0; i < arr.Length; i++)
            {
                if (arr[majIndex] == arr[i])
                    count++;
                else
                    count--;
                if (count == 0)
                {
                    majIndex = i;
                    count = 1;
                }
            }
            return arr[majIndex];
        }
    }
}
