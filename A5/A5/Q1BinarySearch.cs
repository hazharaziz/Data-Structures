using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
            long[] indices = new long[b.Length];
            for (long i = 0; i < b.Length; i++)
            {
                indices[i] = BinarySearch(a, b[i], 0, a.Length - 1);
            }
            return indices;
        }

        private long BinarySearch(long[] arr, long key, long low, long high)
        {
            long mid = (low + high) / 2;
            if (high < low)
                return -1;
            if (arr[mid] == key)
                return mid;
            else if (key < arr[mid])
                return BinarySearch(arr, key, low, mid - 1);
            else
                return BinarySearch(arr, key, mid + 1, high);
        }
    }
}
