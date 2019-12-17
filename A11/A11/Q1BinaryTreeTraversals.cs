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
            BinaryTree<long> bt = new BinaryTree<long>(nodes);
            return new long[][]
            {
                bt.InOrderTraversal(),
                bt.PreOrderTraversal(),
                bt.PostOrderTraversal()
            };
        }
    }
}