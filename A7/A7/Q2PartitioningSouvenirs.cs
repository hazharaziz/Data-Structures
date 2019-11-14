using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            bool result = false;
            long sum = souvenirs.Sum();
            if (sum % 3 != 0)
                result = false;
            else
            {
                long[,,] matrix = MatrixInit(souvenirsCount, sum);
                for (long i = 1; i <= souvenirsCount; i++)
                {
                    for (long j = 1; j <= sum / 3; j++)
                    {
                        for (long k = 1; k <= sum / 3; k++)
                        {
                            if (matrix[i,] ) 
                        }
                    }
                }
            }
            return (result) ? 1 : 0;
        }

        private long[,,] MatrixInit(long souvenirsCount, long sum)
        {
            long[,,] result = new long[souvenirsCount + 1, sum / 3 + 1, sum / 3 + 1];
            for (long i = 0; i <= souvenirsCount; i++)
            {
                result[i, 0, 0] = 1;
            }
            return result;
        }

        private long[][] GetSubsets(long[] souvenirs)
        {
            long[][] result = new long[souvenirs.Length + 1][];
            for (long i = 0; i < result.Length; i++)
            {
                result[i] = new long[i];

            }
            return result;
        }
    }
}
