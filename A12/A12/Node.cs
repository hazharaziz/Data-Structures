using System.Collections.Generic;

namespace A12
{
    public class Node
    {
        public List<long> Children;
        public long InDegree { get; set; }
        public Node()
        {
            Children = new List<long>();
        }
    }
}