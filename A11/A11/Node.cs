namespace A11
{
    public class Node
    {
        public long Key { get; set; }
        public long LeftChild { get; set; }
        public long RightChild { get; set; }
        public Node(long key, long leftChild, long rightChild)
        {
            Key = key;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}