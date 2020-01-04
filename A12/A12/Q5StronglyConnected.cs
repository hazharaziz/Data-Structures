using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q5StronglyConnected: Processor
    {
        public Q5StronglyConnected(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            Stack<long> stack = new Stack<long>();
            bool[] visited = new bool[nodeCount];
            Node[] nodes = Q3Acyclic.GetDirectedGraph(nodeCount, edges);

            for (long i = 0; i < nodeCount; i++)
            {
                if (!visited[i])
                    FillOrder(i, nodes, visited, stack);
            }
            Node[] reversedGraph = GetReversedGraph(nodeCount, edges);

            visited = new bool[nodeCount];
            long curr = 0;
            long count = 0;
            while (stack.Count != 0)
            {
                curr = stack.Pop();
                if (!visited[curr])
                {
                    DFS(reversedGraph, curr, visited);
                    count++;
                }
            }

            return count;
        }

        private void DFS(Node[] nodes, long curr, bool[] visited)
        {
            visited[curr] = true;
            if (nodes[curr] != null)
                foreach (long child in nodes[curr].Children)
                    if (!visited[child])
                        DFS(nodes, child, visited);
        }

        private Node[] GetReversedGraph(long nodeCount, long[][] edges)
        {
            Node[] nodes = new Node[nodeCount];
            for (long i = 0; i < nodeCount; i++)
                nodes[i] = new Node();
            long start;
            long end;
            for (long i = 0; i < edges.Length; i++)
            {
                start = edges[i][1] - 1;
                end = edges[i][0] - 1;
                if (nodes[start] == null)
                    nodes[start] = new Node();
                nodes[start].Children.Add(end);
                if (nodes[end] == null)
                    nodes[end] = new Node();
            }
            return nodes;
        }

        private void FillOrder(long i, Node[] nodes, 
                               bool[] visited, Stack<long> stack)
        {
            visited[i] = true;
            if (nodes[i] != null)
                foreach (long child in nodes[i].Children)
                    if (!visited[child])
                        FillOrder(child, nodes, visited, stack);
            stack.Push(i);
        }
    }
}
