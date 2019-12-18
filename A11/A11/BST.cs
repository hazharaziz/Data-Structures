using System;
using System.Collections.Generic;

namespace A11
{
    public class BinaryTree<T> : Comparer<T>
    {
        public Node<T>[] Tree { get; private set; }
        public long Size { get; private set; }

        public BinaryTree(T[][] nodes)
        {
            Size = nodes.Length;
            Tree = MakeTree(nodes);
        }

        private Node<T>[] MakeTree(T[][] nodes)
        {
            Node<T>[] tree = new Node<T>[Size];
            for (long i = 0; i < Size; i++)
            {
                T key = nodes[i][0];
                long leftChild = (long)Convert.ChangeType(nodes[i][1], typeof(long));
                long rightChild = (long)Convert.ChangeType(nodes[i][2], typeof(long));
                tree[i] = new Node<T>(key, leftChild, rightChild);
            }
            return tree;
        }

        /// <summary>
        /// Returns true if the tree is a binary search tree
        /// </summary>
        /// <returns></returns>
        public bool IsBST()
        {
            bool result = true;
            Stack<long> stack = new Stack<long>();
            Node<T> root = Tree[0];
            root.Min = long.MinValue;
            root.Max = long.MaxValue;
            long right, left;
            stack.Push(0);
            while (stack.Count != 0)
            {
                root = Tree[stack.Pop()];
                right = (root.RightChild != -1) ? root.RightChild : -1;
                left = (root.LeftChild != -1) ? root.LeftChild : -1;
                if (right != -1)
                {
                    stack.Push(right);
                    Tree[right].Min = ConvertToLong(root.Key);
                    Tree[right].Max = root.Max;
                    result = (!Tree[right].isValid()) ? false : result;
                }
                if (left != -1)
                {
                    stack.Push(left);
                    Tree[left].Min = root.Min;
                    Tree[left].Max = ConvertToLong(root.Key);
                    result = (!Tree[left].isValid()) ? false : result;
                }
            }
            return result;
        }
        
        /// <summary>
        /// Returns the preOrder traversal of the binary tree
        /// </summary>
        /// <returns></returns>
        public T[] PreOrderTraversal()
        {
            T[] preOrder = new T[Tree.Length];
            Node<T> root = Tree[0];
            long current = 0;
            Stack<long> stack = new Stack<long>();
            stack.Push(current);
            long index = 0;

            while (stack.Count != 0)
            {
                root = Tree[stack.Pop()];
                preOrder[index] = root.Key;
                if (root.RightChild != -1) { stack.Push(root.RightChild); }
                if (root.LeftChild != -1) { stack.Push(root.LeftChild); }
                index++;
            }

            return preOrder;
        }

        /// <summary>
        /// Returns the inOrder traversal of the binary tree
        /// </summary>
        /// <returns></returns>
        public T[] InOrderTraversal()
        {
            T[] inOrder = new T[Tree.Length];
            Stack<long> stack = new Stack<long>();
            Node<T> root = Tree[0];
            long current = 0;
            stack.Push(current);
            long index = 0;

            while (stack.Count != 0 && index < Tree.Length)
            {
                if (current != -1)
                {
                    stack.Push(current);
                    current = (root.LeftChild != -1) ? root.LeftChild : -1;
                    root = (current != -1) ? Tree[current] : root;
                }
                else
                {
                    current = stack.Pop();
                    root = Tree[current];
                    inOrder[index] = Tree[current].Key;
                    current = (root.RightChild != -1) ? root.RightChild : -1;
                    root = (current != -1) ? Tree[current] : root;
                    index++;
                }
            }
            return inOrder;
        }

        /// <summary>
        /// Returns the postOrder of the binary tree
        /// </summary>
        /// <returns></returns>
        public T[] PostOrderTraversal()
        {
            T[] postOrder = new T[Tree.Length];
            Node<T> root = Tree[0];
            long current = 0;
            Stack<long> firstStack = new Stack<long>();
            Stack<T> secondStack = new Stack<T>();
            firstStack.Push(current);

            while (firstStack.Count != 0)
            {
                current = firstStack.Pop();
                secondStack.Push(Tree[current].Key);
                root = Tree[current];
                if (root.LeftChild != -1) { firstStack.Push(root.LeftChild); }
                if (root.RightChild != -1) { firstStack.Push(root.RightChild); }
            }

            for (long i = 0; i < Tree.Length; i++)
                postOrder[i] = secondStack.Pop();

            return postOrder;
        }

        public override int Compare(T x, T y)
        {
            long a = (long)Convert.ChangeType(x, typeof(long));
            long b = (long)Convert.ChangeType(y, typeof(long));

            return (a < b) ? -1 : 1;
        }

        public long ConvertToLong(T value)
            => (long)Convert.ChangeType(value, typeof(long));
    }
}