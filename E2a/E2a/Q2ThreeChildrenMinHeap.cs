using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2a
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            long n;
            long changeIndex, changeValue;
            long[] heap;
            using (StringReader reader = new StringReader(inStr))
            {
                n = long.Parse(reader.ReadLine());

                string line = null;
                line = reader.ReadLine();

                TestTools.ParseTwoNumbers(line, out changeIndex, out changeValue);

                line = reader.ReadLine();
                heap = line.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x)).ToArray();
            }

            return string.Join("\n", Solve(n, changeIndex, changeValue, heap));

        }
        public long[] Solve(
            long n, 
            long changeIndex, 
            long changeValue, 
            long[] heap)
        {
            long size = heap.Length;
            heap[changeIndex] += changeValue;   
            for (long i = (size / 3); i >= 0; i--)
                SiftDown(heap, i, size);
            return heap;
        }

        private void SiftDown(long[] heap, long j, long size)
        {
            long minIndex = j;
            long left = (3 * j + 1);
            long middle = (3 * j + 2);
            long right = (3 * j + 3);
            minIndex = (left < size && heap[left] <= heap[minIndex]) ? left : minIndex;
            minIndex = (middle < size && heap[middle] <= heap[minIndex]) ? middle : minIndex;
            minIndex = (right < size && heap[right] <= heap[minIndex]) ? right : minIndex;
            if (j != minIndex)
            {
                (heap[j], heap[minIndex]) = (heap[minIndex], heap[j]);
                SiftDown(heap, minIndex, size);
            }
        }
    }
}
