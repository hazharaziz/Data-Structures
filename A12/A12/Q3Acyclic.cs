using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q3Acyclic : Processor
    {
        public Q3Acyclic(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            Node[] nodes = GetDirectedGraph(nodeCount, edges);
            Queue<long> queue = new Queue<long>();
            for (long i = 0; i < nodeCount; i++)
                if (nodes[i] != null)
                    if (nodes[i].InDegree == 0)
                        queue.Enqueue(i);
            long current = 0;
            long count = 0;

            while (queue.Count != 0)
            {
                current = queue.Dequeue();
                if (nodes[current] != null)
                {
                    foreach (long child in nodes[current].Children)
                    {
                        if (nodes[child] != null)
                        {
                            nodes[child].InDegree--;
                            if (nodes[child].InDegree == 0)
                                queue.Enqueue(child);
                        }
                    }
                    count++;
                }
            }

            return (count != nodeCount) ? 1 : 0;
        }

        public static Node[] GetDirectedGraph(long nodeCount, long[][] edges)
        {
            Node[] nodes = new Node[nodeCount];
            long start;
            long end;

            for (long i = 0; i < nodeCount; i++)
                nodes[i] = new Node();

            for (long i = 0; i < edges.Length; i++)
            {
                start = edges[i][0] - 1;
                end = edges[i][1] - 1;
                if (nodes[start] == null)
                    nodes[start] = new Node();
                nodes[start].Children.Add(end);
                if (nodes[end] == null)
                    nodes[end] = new Node();
                nodes[end].InDegree++;
            }

            for (long i = 0; i < nodeCount; i++)
                if (nodes[i] != null)
                    nodes[i].Children.Sort();
            return nodes;
        }
    }
}