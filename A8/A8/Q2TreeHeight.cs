using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            Node[] nodes = new Node[nodeCount];
            for (long i = 0; i < nodeCount; i++)
                nodes[i] = new Node(tree[i]);
            long rootIndex = MakeGraph(nodeCount, tree, nodes);
            long treeHight = TreeHeight(nodes, rootIndex);
            return treeHight;
        }

        /// <summary>
        /// Returns the tree hight
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="rootIndex"></param>
        /// <returns></returns>
        private long TreeHeight(Node[] nodes, long rootIndex)
        {
            long height = 0;
            Queue<long> indices = new Queue<long>();
            indices.Enqueue(rootIndex);
            while (indices.Count > 0)
            {
                long nodeCount = indices.Count;
                height++;
                while (nodeCount > 0)
                {
                    long temp = indices.Dequeue();
                    foreach (long child in nodes[temp].Children)
                        indices.Enqueue(child);
                    nodeCount--;
                }
            }
            return height;
        }

        /// <summary>
        /// Returns the root index of the tree and constructs the graph
        /// </summary>
        /// <param name="nodeCount"></param>
        /// <param name="tree"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private long MakeGraph(long nodeCount, long[] tree, Node[] nodes)
        {
            long rootIndex = 0;
            for (long i = 0; i < nodeCount; i++)
            {
                long parent = nodes[i].Value;
                if (parent == -1)
                    rootIndex = i;
                else
                    nodes[parent].AddChild(i);
            }
            return rootIndex;
        }
    }
}
