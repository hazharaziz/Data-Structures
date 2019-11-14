using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public Dictionary<string, Func<long, long, long>> Operators =
            new Dictionary<string, Func<long, long, long>>()
            {
                { "+", (x,y) => x + y },
                { "-", (x,y) => x - y },
                { "*", (x,y) => x * y },
                { "/", (x,y) => x / y }
            };

        public long Solve(string expression)
        {
            long numsLength = (expression.Length + 1) / 2;
            long operatorsLength = (expression.Length - 1) / 2;
            long[,] minMatrix = new long[numsLength, numsLength];
            long[,] maxMatrix = new long[numsLength, numsLength];
            long[] numbers = GetNumbers(expression, numsLength);
            string[] operators = GetOperators(expression, operatorsLength);
            for (long i = 0; i < numsLength; i++)
            {
                minMatrix[i,i] = numbers[i];
                maxMatrix[i,i] = numbers[i];
            }
            
            for (long s = 0; s < numsLength - 1; s++)
            {
                for (long i = 0; i < numsLength - s; i++)
                {
                    if (i + s + 1 > numsLength - 1)
                        break;
                    long j = i + s + 1;
                    (minMatrix[i, j], maxMatrix[i, j]) = SetMinAndMax(minMatrix, maxMatrix,
                                                                      operators, i, j);
                }
            }

            return maxMatrix[0, numsLength - 1];
        }

        /// <summary>
        /// Sets the minimum and maximum numbers of the matrices
        /// </summary>
        /// <param name="minMatrix"></param>
        /// <param name="maxMatrix"></param>
        /// <param name="operators"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private (long, long) SetMinAndMax(long[,] minMatrix, long[,] maxMatrix, 
                                            string[] operators, long i, long j)
        {
            long min = long.MaxValue;
            long max = long.MinValue;
            for (long k = i; k < j; k++)
            {
                long a = Operators[operators[k]](maxMatrix[i, k], maxMatrix[k + 1, j]);
                long b = Operators[operators[k]](maxMatrix[i, k], minMatrix[k + 1, j]);
                long c = Operators[operators[k]](minMatrix[i, k], maxMatrix[k + 1, j]);
                long d = Operators[operators[k]](minMatrix[i, k], minMatrix[k + 1, j]);
                min = GetMin(min, a, b, c, d);
                max = GetMax(max, a, b, c, d);
            }
            return (min, max);
        }

        /// <summary>
        /// Returns the maximum number of an array
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private long GetMax(params double[] numbers) =>
            (long)numbers.Max();

        /// <summary>
        /// Returns the minimum number of an array
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private long GetMin(params double[] numbers) =>
            (long)numbers.Min();

        /// <summary>
        /// Returns the numbers array of the expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private long[] GetNumbers(string expression, long length)
        {
            long[] result = new long[length];
            long idx = 0;
            for (int i = 0; i < expression.Length; i += 2)
            {
                result[idx] = long.Parse(expression[i].ToString());
                idx++;
            }
            return result;
        }

        /// <summary>
        /// Returns the operators array of the expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string[] GetOperators(string expression, long length)
        {
            string[] result = new string[length];
            long idx = 0;
            for (int i = 1; i < expression.Length; i += 2)
            {
                result[idx] = expression[i].ToString();
                idx++;
            }
            return result;
        }
    }
}
