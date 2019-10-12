using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            if (n == 1)
                return a;

            int middle = a.Length / 2;

            long[] rightHalf = subArray(a, 0, middle);
            long[] leftHalf = subArray(a, middle, a.Length);

            long[] right = Solve(rightHalf.Length, rightHalf);
            long[] left = Solve(leftHalf.Length, leftHalf);

            long[] result = Merge(right, left);

            return result;
        }

        //Merge method for merging two arrays
        private long[] Merge(long[] right, long[] left)
        {
            long[] result = new long[right.Length + left.Length];
            int k = 0;
            int i = 0;
            int j = 0;


            while (i < right.Length && j < left.Length)
            {
                result[k] = (right[i] <= left[j]) ? right[i] : left[j];

                if (right[i] <= left[j])
                    i++;
                else
                    j++;

                k++;
            }

            while (i < right.Length)
            {
                result[k] = right[i];
                i++;
                k++;
            }
            
            while (j < left.Length)
            {
                result[k] = left[j];
                j++;
                k++;
            }

            return result;
        }

        //subArray method returning the subArray of an array in a specified range
        private long[] subArray(long[] a, int startIndex, int lastIndex)
        {
            long[] result = new long[lastIndex - startIndex];
            int i = 0;
            for (int j = startIndex; j < lastIndex; j++)
            {
                result[i] = a[j];
                i++;
            }
            return result.ToArray();
        }
    }
}
