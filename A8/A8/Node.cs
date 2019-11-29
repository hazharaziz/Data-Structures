using System.Collections.Generic;

namespace A8
{
    public class Node
    {
        public long Value { get; set; }
        public List<long> Children { get; set; }
        public Node(long value)
        {
            Value = value;
            Children = new List<long>();
        }

        public void AddChild(long child)
        {
            Children.Add(child);
        }
    }
}