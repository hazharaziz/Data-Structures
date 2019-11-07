using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            long[][] distMatrix = GetDistMatrix(str1, str2);
            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    long insertion = distMatrix[i][j - 1] + 1;
                    long deletion = distMatrix[i - 1][j] + 1;
                    long match = distMatrix[i - 1][j - 1];
                    long mismatch = distMatrix[i - 1][j - 1] + 1;
                    if (str1[i - 1] == str2[j - 1])
                        distMatrix[i][j] = Min(insertion, deletion, match);
                    else
                        distMatrix[i][j] = Min(insertion, deletion, mismatch);
                }
            }
            return distMatrix[str1.Length][str2.Length];
        }

        //GetDistMatrix Method returning the distance matrix
        private static long[][] GetDistMatrix(string str1, string str2)
        {
            long[][] distanceMatrix = new long[str1.Length + 1][];
            for (long i = 0; i <= str1.Length; i++)
                distanceMatrix[i] = new long[str2.Length + 1];
            for (long i = 0; i <= str2.Length; i++)
                distanceMatrix[0][i] = i;
            for (long i = 0; i <= str1.Length; i++)
                distanceMatrix[i][0] = i;
            return distanceMatrix;
        }

        //Min Method returning the minimum number in an array
        private long Min(params long[] numbers)
        {
            long min = long.MaxValue;
            for (long i = 0; i < numbers.Length; i++)
                if (numbers[i] <= min)
                    min = numbers[i];
            return min;
        }

    }
}
