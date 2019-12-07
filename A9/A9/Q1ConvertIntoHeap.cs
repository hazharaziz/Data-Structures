using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long,  long>[] Solve(long[] array)
        {
            List<Tuple<long, long>> swapPairs = new List<Tuple<long, long>>();
            long size = array.Length;
            for (long i = size / 2; i >= 0; i--)
            {
                SiftDown(ref swapPairs, array, i, size);
            }
            return swapPairs.ToArray();
        }

        private void SiftDown(ref List<Tuple<long, long>> swapPairs, 
                                long[] array, long i, long size)
        {
            long minIndex = i;
            long left = LeftChild(i);
            if (left < size && array[left] < array[minIndex])
                minIndex = left;
            long right = RightChild(i);
            if (right < size && array[right] < array[minIndex])
                minIndex = right;
            if (minIndex != i)
            {
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
                swapPairs.Add(new Tuple<long, long>(i, minIndex));
                SiftDown(ref swapPairs, array, minIndex, size);
            }
        }

        private long RightChild(long index)
            => (2 * index) + 2;

        private long LeftChild(long index)
            => (2 * index) + 1;

        public long Parent(long[] arr, long index)
            => (index - 1) / 2;

    }
}
