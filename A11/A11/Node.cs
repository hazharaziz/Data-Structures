using System;
using System.Collections.Generic;
using System.Linq;

namespace A11
{
    public class Node<T>
    {
        public T Key { get; set; }
        public long LeftChild { get; set; }
        public long RightChild { get; set; }
        public bool Visited { get; set; }
        public long Min { get; set; }
        public long Max { get; set; }

        public Node(T key, long leftChild, long rightChild)
        {
            Key = key;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public bool isValid()
        {
            long key = (long)Convert.ChangeType(Key, typeof(long));
            return (Compare(key, Min) == 1) && (Compare(key, Max) == -1);
        }

        private int Compare(long x, long y)
            => (x >= y) ? 1 : -1;
    }
}