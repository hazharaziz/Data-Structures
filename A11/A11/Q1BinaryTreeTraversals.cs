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
            long[] postOrder = new long[tree.Length];
            Node root = tree[0];
            long current = 0;
            long right, left;
            Stack<long> firstStack = new Stack<long>();
            Stack<long> secondStack = new Stack<long>();
            firstStack.Push(current);
            while (firstStack.Count != 0)
            {
                current = firstStack.Pop();
                secondStack.Push(tree[current].Key);
                root = tree[current];
                right = (root.RightChild != -1) ? root.RightChild : -1;
                left = (root.LeftChild != -1) ? root.LeftChild : -1;
                if (left != -1) { firstStack.Push(left); }
                if (right != -1) { firstStack.Push(right); }
            }

            for (long i = 0; i < tree.Length; i++)
                postOrder[i] = secondStack.Pop();
            return postOrder;
        }

        private long[] PreOrderTraversal(Node[] tree)
        {
            long[] preOrder = new long[tree.Length];
            Node root = tree[0];
            long current = 0;
            long right, left;
            Stack<long> stack = new Stack<long>();
            stack.Push(current);
            long index = 0;
            while (stack.Count != 0)
            {
                root = tree[stack.Pop()];
                preOrder[index] = root.Key;
                right = (root.RightChild != -1) ? root.RightChild : -1;
                left = (root.LeftChild != -1) ? root.LeftChild : -1;
                if (right != -1) { stack.Push(right); }
                if (left != -1) { stack.Push(left); }
                index++;
            }
            return preOrder;
        }

        public long[] InOrderTraversal(Node[] tree)
        {
            long[] inOrder = new long[tree.Length];
            Stack<long> stack = new Stack<long>();
            Node root = tree[0];
            long current = 0;
            stack.Push(current);
            long index = 0;
            while (stack.Count != 0 && index < tree.Length)
            {
                if (current != -1)
                {
                    stack.Push(current);
                    current = (root.LeftChild != -1) ? root.LeftChild : -1;
                    root = (current != -1) ? tree[current] : root;
                }
                else
                {
                    current = stack.Pop();
                    root = tree[current];
                    inOrder[index] = tree[current].Key;
                    current = (root.RightChild != -1) ? root.RightChild : -1;
                    root = (current != -1) ? tree[current] : root;
                    index++;
                }
            }
            return inOrder;
        }
    }
}