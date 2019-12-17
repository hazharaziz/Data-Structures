using System;
using System.Linq;

namespace A11
{
    public class Node
    {
        public long Key { get; set; }
        public long LeftChild { get; set; }
        public long RightChild { get; set; }
        public bool Visited { get; set; }

        public Node(long key, long leftChild, long rightChild)
        {
            Key = key;
            LeftChild = leftChild;
            RightChild = rightChild;
            Visited = false;
        }

        public bool ChildrenAllVisited(Node[] tree)
        {
            bool result = false;
            Node right = (RightChild != -1) ? tree[RightChild] : null;
            Node left = (LeftChild != -1) ? tree[LeftChild] : null;
            if (right != null && left == null)
                if (right.Visited)
                    result = true;
            if (right == null && left != null)
                if (left.Visited)
                    result = true;
            if (right != null && left != null)
                if (right.Visited && left.Visited)
                    result = true;
            return result;
        }
    }
}