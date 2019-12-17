using System;
using System.Linq;

namespace A11
{
    public class Node<T>
    {
        public T Key { get; set; }
        public long LeftChild { get; set; }
        public long RightChild { get; set; }
        public bool Visited { get; set; }

        public Node(T key, long leftChild, long rightChild)
        {
            Key = key;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}