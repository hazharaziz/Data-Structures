using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
            => IsBST(nodes);

        public static bool IsBST(long[][] nodes)
        {
            bool result = true;
            Stack<long> stack = new Stack<long>();
            long[,] minMax = new long[nodes.Length,2];
            long current = 0;
            long right, left;
            minMax[current,0] = long.MinValue;
            minMax[current,1] = long.MaxValue;
            stack.Push(current);
            while (stack.Count != 0)
            {
                current = stack.Pop();
                right = (nodes[current][2] != -1) ? (nodes[current][2]) : -1;
                left = (nodes[current][1] != -1) ? (nodes[current][1]) : -1;
                if (right != -1)
                {
                    stack.Push(right);
                    minMax[right,0] = nodes[current][0];
                    minMax[right,1] = minMax[current,1];
                    result = (!IsValid(nodes[right][0], minMax[right,0], minMax[right,1])) 
                             ? false : result;
                }
                if (left != -1)
                {
                    stack.Push(left);
                    minMax[left,0] = minMax[current,0];
                    minMax[left,1] = nodes[current][0];
                    result = (!IsValid(nodes[left][0], minMax[left,0], minMax[left,1]))
                             ? false : result;
                }
            }
            return result;
        }

        public static bool IsValid(long key, long min, long max)
            => (key >= min) && (key < max);
    }
}
