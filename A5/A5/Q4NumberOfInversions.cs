using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            //long count = 0;
            //for (long i = 0; i < n; i++)
            //    for (long j = i + 1; j < n; j++)
            //        if (a[i] > a[j])
            //            count++;
            //return count;

            long count = 0;
            long[] sortedArray = MergeSort(a, ref count);
            return count;
        }

        private long[] MergeSort(long[] arr, ref long count)
        {
            if (arr.Length == 1)
                return arr;
            long mid = arr.Length / 2;
            long[] leftHalf = SubArray(arr, 0, mid);
            long[] rightHalf = SubArray(arr, mid, arr.Length);
            long[] right = MergeSort(rightHalf, ref count);
            long[] left = MergeSort(leftHalf, ref count);
            long[] result = Merge(left, right, ref count);
            return result;
        }

        private long[] Merge(long[] left, long[] right, ref long count)
        {
            long[] result = new long[right.Length + left.Length];
            long mid = left.Length;
            long i = 0;
            long j = 0;
            long k = 0;

            while (j < right.Length && i < left.Length)
            {
                if (left[i] > right[j])
                {
                    result[k] = right[j];
                    count += (mid - i);   
                    j++;
                }
                else
                {
                    result[k] = left[i];
                    i++;
                }
                k++;
            }

            while (j < right.Length)
            {
                result[k] = right[j];
                j++;
                k++;
            }

            while (i < left.Length)
            {
                result[k] = left[i];
                i++;
                k++;
            }
            return result;
        }

        private long[] SubArray(long[] arr, long startPoint, long endPoint)
        {
            long[] subArray = new long[endPoint - startPoint];
            long j = 0;
            for (long i = startPoint; i < endPoint; i++)
            {
                subArray[j] = arr[i];
                j++;
            }
            return subArray;
        }
    }
}
