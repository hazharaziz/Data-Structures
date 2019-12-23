using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2a
{
    public class Q1BSTInOrderTraverse : Processor
    {
        public Q1BSTInOrderTraverse(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] BST)
        {
            long count = 0;
            for (long i = 0; i < n; i++)
                count += (BST[i] != -1) ? 1 : 0;
            long[] inOrder = new long[count];
            long current = 0;
            long index = 0;
            Stack<long> stack = new Stack<long>();
            stack.Push(current);
            while (stack.Count != 0)
            {
                if (current == -1)
                {
                    current = stack.Pop();
                    inOrder[index] = BST[current];
                    if ((2 * current + 2) < n)
                        current = (BST[2 * current + 2] != -1) ? (2 * current + 2) : -1;
                    index++;
                }
                else
                {
                    if ((2 * current + 1) < n)
                        current = (BST[2 * current + 1] != -1) ? (2 * current + 1) : -1;
                }
                if (current != -1) { stack.Push(current); }
            }

            return inOrder.ToArray();
        }
    }
}