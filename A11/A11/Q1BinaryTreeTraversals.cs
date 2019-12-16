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
            long[][] result = new long[3][];
            Node[] tree = new Node[nodes.Length];
            long[] tempData;
            for (long i = 0; i < nodes.Length; i++)
            {
                tempData = nodes[i];
                tree[i] = new Node(tempData[0], tempData[1], tempData[2]);
            }

            result[0] = InOrderTraversal(tree);
            result[1] = PreOrderTraversal(tree);
            result[2] = PostOrderTraversal(tree);

            return result;
        }

        private long[] PostOrderTraversal(Node[] tree)
        {
            throw new NotImplementedException();
        }

        private long[] PreOrderTraversal(Node[] tree)
        {
            throw new NotImplementedException();
        }

        public long[] InOrderTraversal(Node[] tree)
        {
            long[] result = new long[tree.Length];
            Node current = tree[0];
            Stack<long> stack = new Stack<long>();
            stack.Push(current.Key);
            long index = 0;
            while (stack.Count != 0)
            {
            }
            return result;
        }
    }
}