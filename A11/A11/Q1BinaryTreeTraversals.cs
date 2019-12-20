using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {

        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes)
        {
            return new long[][]
            {
                InOrderTraversal(nodes),
                PreOrderTraversal(nodes),
                PostOrderTraversal(nodes)
            };
        }

        private long[] PostOrderTraversal(long[][] nodes)
        {
            long[] postOrder = new long[nodes.Length];
            long current = 0;
            long right, left;
            Stack<long> firstStack = new Stack<long>();
            Stack<long> secondStack = new Stack<long>();
            firstStack.Push(current);
            while (firstStack.Count != 0)
            {
                current = firstStack.Pop();
                secondStack.Push(nodes[current][0]);
                left = (nodes[current][1] != -1) ? nodes[current][1] : -1;
                right = (nodes[current][2] != -1) ? nodes[current][2] : -1;
                if (left != -1) { firstStack.Push(left); }
                if (right != -1) { firstStack.Push(right); }
            }

            for (long i = 0; i < nodes.Length; i++)
                postOrder[i] = secondStack.Pop();

            return postOrder;
        }

        private long[] PreOrderTraversal(long[][] nodes)
        {
            long[] preOrder = new long[nodes.Length];
            long current = 0;
            long right, left;
            Stack<long> stack = new Stack<long>();
            stack.Push(current);
            long index = 0;
            while (stack.Count != 0 && index < nodes.Length)
            {
                current = stack.Pop();
                preOrder[index] = nodes[current][0];
                right = (nodes[current][2] != -1) ? nodes[current][2] : -1;
                left = (nodes[current][1] != -1) ? nodes[current][1] : -1;
                if (right != -1) { stack.Push(right); }
                if (left != -1) { stack.Push(left); }
                index++;
            }
            return preOrder;
        }

        private static long[] InOrderTraversal(long[][] nodes)
        {
            long[] inOrder = new long[nodes.Length];
            long current = 0;
            Stack<long> stack = new Stack<long>();
            stack.Push(current);
            long index = 0;
            while (stack.Count != 0 && index < nodes.Length)
            {
                if (current != -1)
                {
                    stack.Push(current);
                    current = (nodes[current][1] != -1) ? nodes[current][1] : -1;
                }
                else
                {
                    current = stack.Pop();
                    inOrder[index] = nodes[current][0];
                    current = (nodes[current][2] != -1) ? nodes[current][2] : -1;
                    index++;
                }
            }
            return inOrder;
        }
    }
}