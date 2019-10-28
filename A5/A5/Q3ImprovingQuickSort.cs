using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            QuickSort(a, 0, n - 1);
            return a;
        }

        private void QuickSort(long[] arr, long low, long high)
        {
            if (low < high)
            {
                long[] partitions = Partition(arr, low, high);
                long leftPartition = partitions[0];
                long rightPartition = partitions[1];
                QuickSort(arr, low, leftPartition - 1);
                QuickSort(arr, rightPartition + 1, high);
            }
        }

        private long[] Partition(long[] arr, long low, long high)
        {
            long leftPartition = low;
            long rightPartition = high;
            long pivot = arr[low];
            for (long i = low; i <= high; i++)
            {
                if (arr[i] < pivot)
                {
                    (arr[i], arr[leftPartition]) = (arr[leftPartition], arr[i]);
                    leftPartition++;
                }
            }
            for (long i = high; i >= low; i--)
            {
                if (arr[i] > pivot)
                {
                    (arr[i], arr[rightPartition]) = (arr[rightPartition], arr[i]);
                    rightPartition--;
                }
            }
            return new long[] { leftPartition, rightPartition };
        }
    }
}
