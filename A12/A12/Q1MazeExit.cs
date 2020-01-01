using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
            bool result = false;
            bool[] visited = new bool[nodeCount];
            Node[] nodes = new Node[nodeCount];
            for (long i = 0; i < edges.Length; i++)
            {
                long start = edges[i][0] - 1;
                long end = edges[i][1] - 1;
                if (nodes[start] == null)
                    nodes[start] = new Node();
                if (nodes[end] == null)
                    nodes[end] = new Node();
                nodes[start].Children.Add(end);
                nodes[end].Children.Add(start);
            }
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(StartNode - 1);
            long current = 0;
            while (queue.Count != 0 && !result)
            {
                current = (queue.Count != 0) ? queue.Dequeue() : current;
                visited[current] = true; 
                if (current == EndNode - 1) { result = true; }
                if (nodes[current] != null)
                    foreach (long n in nodes[current].Children)
                        if (!visited[n])
                            queue.Enqueue(n);
            }
            return (result) ? 1 : 0;
        }
     }
}
