using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            bool[] visited = new bool[nodeCount];
            Node[] nodes = Q1MazeExit.GetUndirectedGraph(nodeCount, edges);
            long count = 0;
            for (long i = 0; i < nodeCount; i++)
            {
                if (!visited[i])
                {
                    Explore(visited, nodes, i);
                    count++;
                }
            }
            return count;
        }

        private static void Explore(bool[] visited, Node[] nodes, long i)
        {
            long current = i;
            Stack<long> stack = new Stack<long>();
            stack.Push(current);
            while (stack.Count != 0)
            {
                current = stack.Pop();
                visited[current] = true;
                if (nodes[current] != null)
                    foreach (long child in nodes[current].Children)
                        if (!visited[child])
                            stack.Push(child);
            }
        }
    }
}
