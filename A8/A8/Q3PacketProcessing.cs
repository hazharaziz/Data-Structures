using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            long[] startTimes = new long[0];
            long length = arrivalTimes.Length;
            Queue<long> finishTimes = new Queue<long>();
            if (length > 0)
            {
                startTimes = new long[length];
                long index = 0;
                long time = arrivalTimes[0];
                for (long i = 0; i < length; i++)
                {
                    while (finishTimes.Count > 0 &&
                        finishTimes.Peek() <= arrivalTimes[i])
                        finishTimes.Dequeue();
                    if (finishTimes.Count < bufferSize)
                    {
                        finishTimes.Enqueue(time + processingTimes[i]);
                        startTimes[index] = (arrivalTimes[i] > time) ?
                                            arrivalTimes[i] : time;
                        time += (arrivalTimes[i] > time) ?
                                arrivalTimes[i] - time : processingTimes[i];
                    }
                    else
                        startTimes[index] = -1;
                    index++;
                }
            }
            return startTimes;
        }
    }
}