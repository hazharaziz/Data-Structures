using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            Item[] items = GetSortedItems(weights.Length, weights, values);
            long maxValue = 0;
            long totalWeight = 0;
            long index = 0;

            while (totalWeight < capacity)
            {
                if ((totalWeight + items[index].Weight <= capacity))
                {
                    maxValue += items[index].Value;
                    totalWeight += items[index].Weight;
                }
                else
                {
                    long difference = capacity - totalWeight;
                    maxValue += Convert.ToInt64((difference * (items[index].Value) / items[index].Weight));
                    totalWeight += difference;
                }
                index++;
            }
            return maxValue;
        }

        //GetSortedItems method returning the sorted items(sorted by value per weight)
        private Item[] GetSortedItems(int length, long[] weights, long[] values)
        {
            Item[] items = new Item[weights.Length];
            long itemsLength = items.Length;
            for (int i = 0; i < itemsLength; i++)
                items[i] = new Item(weights[i], values[i]);
            items = items.OrderByDescending(i => i.ValueDensity).ToArray();
            return items;
        }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
