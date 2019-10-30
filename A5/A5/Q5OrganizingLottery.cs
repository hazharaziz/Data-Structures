using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            long[] result = new long[points.Length];
            long[] numbers = new long[startSegments.Length + endSegment.Length + points.Length];
            string[] states = new string[startSegments.Length + endSegment.Length + points.Length];
            Dictionary<long, long> pointsCount = new Dictionary<long, long>();
            SortNumbers(ref numbers, ref states, startSegments, endSegment, points, ref pointsCount);
            SortStates(ref states, numbers, pointsCount);
            long startCount = 0;
            for (long i = 0; i < numbers.Length; i++)
            {
                if (states[i] == "S")
                    startCount++;
                else if (states[i] == "E")
                    startCount--;
                else
                    if (pointsCount[numbers[i]] == 0)
                        pointsCount[numbers[i]] += startCount;
            }

            for (long i = 0; i < result.Length; i++)
                result[i] = pointsCount[points[i]];
            return result;
        }

        //SortStates Method for sorting the states
        private void SortStates(ref string[] states, long[] numbers,
                                    Dictionary<long, long> pointsCount)
        {
            foreach (long point in pointsCount.Keys)
            {
                long i = Array.IndexOf(numbers, point);
                long j = i;
                long lastIndex = i;
                while (i < states.Length)
                {
                    if (numbers[i] == point)
                    {
                        if (states[i] == "S")
                        {
                            (states[i], states[lastIndex]) = (states[lastIndex], states[i]);
                            lastIndex++;
                        }
                        i++;
                    }
                    else
                        break;
                }
                while (j < states.Length)
                {
                    if (numbers[j] == point)
                    {
                        if (states[j] == "P")
                        {
                            (states[j], states[lastIndex]) = (states[lastIndex], states[j]);
                            lastIndex++;
                        }
                        j++;
                    }
                    else
                        break;
                }
            }
        }

        //SortNumbers Method for sorting the numbers of the points, 
        //start numbers, and end numbers 
        private static void SortNumbers(ref long[] numbers, ref string[] states, long[] startSegments, long[] endSegment,
                                            long[] points, ref Dictionary<long, long> keyValuePairs)
        {
            long index = 0;
            for (long i = 0; i < startSegments.Length; i++)
            {
                numbers[index] = startSegments[i];
                states[index] = "S";
                index++;
            }

            for (long i = 0; i < endSegment.Length; i++)
            {
                numbers[index] = endSegment[i];
                states[index] = "E";
                index++;
            }

            for (long i = 0; i < points.Length; i++)
            {
                numbers[index] = points[i];
                states[index] = "P";
                keyValuePairs[points[i]] = 0;
                index++;
            }

            QuickSort(ref numbers, ref states,  0, numbers.Length - 1);
        }

        private static void QuickSort(ref long[] arr, ref string[] states, long low, long high)
        {
            if (low < high)
            {
                long[] partitions = Partition(ref arr, ref states, low, high);
                long leftPartition = partitions[0];
                long rightPartition = partitions[1];
                QuickSort(ref arr, ref states, low, leftPartition - 1);
                QuickSort(ref arr, ref states, rightPartition + 1, high);
            }
        }

        //3-way partition
        private static long[] Partition(ref long[] arr, ref string[] states, long low, long high)
        {
            long leftPartition = low;
            long rightPartition = high;
            long pivot = arr[low];
            for (long i = low; i <= high; i++)
            {
                if (arr[i] < pivot)
                {
                    (arr[i], arr[leftPartition]) = (arr[leftPartition], arr[i]);
                    (states[i], states[leftPartition]) = (states[leftPartition], states[i]);
                    leftPartition++;
                }
            }
            for (long i = high; i >= low; i--)
            {
                if (arr[i] > pivot)
                {
                    (arr[i], arr[rightPartition]) = (arr[rightPartition], arr[i]);
                    (states[i], states[rightPartition]) = (states[rightPartition], states[i]);
                    rightPartition--;
                }
            }
            return new long[] { leftPartition, rightPartition };
        }
    }
}
