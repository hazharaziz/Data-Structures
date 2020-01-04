﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q4OrderOfCourse: Processor
    {
        public Q4OrderOfCourse(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);

        public long[] Solve(long nodeCount, long[][] edges)
        {
            Node[] nodes = Q3Acyclic.GetDirectedGraph(nodeCount, edges);

            Queue<long> queue = new Queue<long>();
            for (long i = 0; i < nodeCount; i++)
                if (nodes[i].InDegree == 0)
                    queue.Enqueue(i);
            long[] topologicalSort = new long[nodeCount];
            long index = 0;
            long current = 0;

            while (queue.Count != 0)
            {
                current = queue.Dequeue();
                topologicalSort[index] = current + 1;
                index++;
                if (nodes[current] != null)
                    foreach (long child in nodes[current].Children)
                    {
                        if (nodes[child] != null)
                        {
                            nodes[child].InDegree--;
                            if (nodes[child].InDegree == 0)
                                queue.Enqueue(child);
                        }
                    }
            }
            return topologicalSort;
        }

        public override Action<string, string> Verifier { get; set; } = TopSortVerifier;

        public static void TopSortVerifier(string inFileName, string strResult)
        {
            long[] topOrder = strResult.Split(TestTools.IgnoreChars)
                .Select(x => long.Parse(x)).ToArray();

            long count;
            long[][] edges;
            TestTools.ParseGraph(File.ReadAllText(inFileName), out count, out edges);

            // Build an array for looking up the position of each node in topological order
            // for example if topological order is 2 3 4 1, topOrderPositions[2] = 0, 
            // because 2 is first in topological order.
            long[] topOrderPositions = new long[count];
            for (int i = 0; i < topOrder.Length; i++)
                topOrderPositions[topOrder[i] - 1] = i;
            // Top Order nodes is 1 based (not zero based).

            // Make sure all direct depedencies (edges) of the graph are met:
            //   For all directed edges u -> v, u appears before v in the list
            foreach (var edge in edges)
                if (topOrderPositions[edge[0] - 1] >= topOrderPositions[edge[1] - 1])
                    throw new InvalidDataException(
                        $"{Path.GetFileName(inFileName)}: " +
                        $"Edge dependency violoation: {edge[0]}->{edge[1]}");
        }
    }
}
