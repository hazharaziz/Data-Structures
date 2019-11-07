using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            long[][] LCSMatrix = GetLCSMatrix(seq1, seq2);
            for (long i = 1; i <= seq1.Length; i++)
                for (long j = 1; j <= seq2.Length; j++)
                {
                    if (seq1[i - 1] == seq2[j - 1])
                        LCSMatrix[i][j] = LCSMatrix[i - 1][j - 1] + 1;
                    else
                        LCSMatrix[i][j] = Math.Max(LCSMatrix[i - 1][j], LCSMatrix[i][j - 1]);

                }
            return LCSMatrix[seq1.Length][seq2.Length];
        }

        //GetLCSMatrix Method returning the LCS matrix
        private long[][] GetLCSMatrix(long[] seq1, long[] seq2)
        {
            long[][] LCSMatrix = new long[seq1.Length + 1][];
            for (long i = 0; i <= seq1.Length; i++)
                LCSMatrix[i] = new long[seq2.Length + 1];
            for (long i = 0; i <= seq1.Length; i++)
                LCSMatrix[i][0] = 0;
            for (long i = 0; i <= seq2.Length; i++)
                LCSMatrix[0][i] = 0;
            return LCSMatrix;
        }
    }
}
