using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            long[][][] LCSMatrix = GetLCSMatrix(seq1.Length, seq2.Length, seq3.Length);
            for (long i = 1; i <= seq1.Length; i++)
                for (long j = 1; j <= seq2.Length; j++)
                    for (long k = 1; k <= seq3.Length; k++)
                    {
                        if ((seq1[i - 1] == seq2[j - 1]) && (seq2[j - 1] == seq3[k - 1]))
                            LCSMatrix[i][j][k] = LCSMatrix[i - 1][j - 1][k - 1] + 1;

                        if ((seq1[i - 1] != seq2[j - 1]) || (seq1[i - 1] != seq3[k - 1]) ||
                            (seq2[j - 1] != seq3[k - 1]))
                            LCSMatrix[i][j][k] = Max(LCSMatrix[i - 1][j][k],
                                                     LCSMatrix[i][j - 1][k],
                                                     LCSMatrix[i][j][k - 1]);
                    }
            return LCSMatrix[seq1.Length][seq2.Length][seq3.Length];
        }

        //Max Method returning the maximum number in an array
        private long Max(params long[] numbers)
        {
            long max = long.MinValue;
            for (long i = 0; i < numbers.Length; i++)
                if (numbers[i] > max)
                    max = numbers[i];
            return max;
        }

        //GetLCSMatrix Method returning the LCS matrix
        private long[][][] GetLCSMatrix(long length1, long length2, long length3)
        {
            long[][][] LCSMatrix = new long[length1 + 1][][];
            for (long i = 0; i <= length1; i++)
            {
                LCSMatrix[i] = new long[length2 + 1][];
                for (long j = 0; j <= length2; j++)
                    LCSMatrix[i][j] = new long[length3 + 1];
            }
            return LCSMatrix;
        }
    }
}
