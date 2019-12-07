using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q3Froggie : Processor
    {
        public Q3Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[], long[], long>)Solve);

        public long Solve(long initialDistance, long initialEnergy,
                                            long[] distance, long[] food)
        {
            long length = distance.Length;
            MaxHeap maxHeap = new MaxHeap(length + 1);
            FoodStop[] foodStops = new FoodStop[length + 1];
            for (long i = 0; i < length; i++)
                foodStops[i] = new FoodStop(distance[i], food[i]);
            foodStops[length] = new FoodStop(0);
            foodStops = foodStops.OrderByDescending(fs => fs.Distance).ToArray();
            FoodStop[] pq = new FoodStop[length];


            long stopCount = 0;
                

            for (long i = 0; i <= length; i++)
            {
                if (initialDistance - foodStops[i].Distance <= initialEnergy)
                {
                    initialEnergy -= (initialDistance - foodStops[i].Distance);
                    initialDistance = foodStops[i].Distance;
                    maxHeap.Insert(foodStops[i]);
                }
                else
                {
                    while (maxHeap.Size > 0 &&
                        initialDistance - foodStops[i].Distance > initialEnergy)
                    {
                        initialEnergy += maxHeap.ExtractMax();
                        stopCount++;
                    }
                    if (initialDistance - foodStops[i].Distance > initialEnergy)
                        return -1;
                    i--;
                }

            }

            return stopCount;
        }
    }
}
