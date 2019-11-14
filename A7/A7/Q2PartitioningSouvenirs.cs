using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            bool result = false;
            long sum = souvenirs.Sum();
            if (sum % 3 != 0 || sum == 0 || souvenirsCount < 3)
                result = false;
            else
            {
                bool[,,] matrix = MatrixInit(souvenirsCount, sum);
                for (long i = 1; i <= souvenirsCount; i++)
                {
                    for (long j = 0; j <= sum / 3; j++)
                    {
                        for (long k = 0; k <= sum / 3; k++)
                        {
                            bool[] booleans = new bool[4];
                            if (souvenirs[i - 1] <= j && souvenirs[i - 1] <= k)
                                booleans[0] = matrix[i - 1, j - souvenirs[i - 1], k] ||
                                              matrix[i - 1, j, k - souvenirs[i - 1]];
                            if (souvenirs[i - 1] <= j && souvenirs[i - 1] > k)
                                booleans[1] = matrix[i - 1, j - souvenirs[i - 1], k];
                            if (souvenirs[i - 1] > j && souvenirs[i - 1] <= k)
                                booleans[2] = matrix[i - 1, j, k - souvenirs[i - 1]];
                            if (souvenirs[i - 1] > j && souvenirs[i - 1] > k)
                                booleans[3] = matrix[i - 1, j, k];
                            matrix[i, j, k] = (booleans.Any(b => b == true)) ? true : false;
                        }
                    }
                }
                result = matrix[souvenirsCount, sum / 3, sum / 3];
            }
            return (result) ? 1 : 0;
        }

        private bool[,,] MatrixInit(long souvenirsCount, long sum)
        {
            bool[,,] result = new bool[souvenirsCount + 1, sum / 3 + 1, sum / 3 + 1];
            for (long i = 0; i <= souvenirsCount; i++)
                result[i, 0, 0] = true;
            for (long i = 1; i <= sum / 3; i++)
                result[0, i, 0] = true;
            for (long i = 1; i <= sum / 3; i++)
                result[0, 0, i] = true;
            return result;
        }
    }
}
