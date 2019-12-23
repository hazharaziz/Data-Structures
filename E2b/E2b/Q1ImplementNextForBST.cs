using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2b
{
    public class Q1ImplementNextForBST : Processor
    {
        public Q1ImplementNextForBST(string testDataName) : base(testDataName) 
        {
            //this.ExcludeTestCaseRangeInclusive(1, 10);
        }
        public override string Process(string inStr)
        {
            long n, node;
            var lines = inStr.Split(TestTools.NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            TestTools.ParseTwoNumbers(lines[0], out n, out node);
            var bst = lines[1].Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            return Solve(n, node, bst).ToString();
        }

        public long Solve(long n, long node, long[] BST)
        {
            return Next(n, node, BST);
        }

        private long Next(long n, long node, long[] bst)
        {
            if (bst[2 * node + 2] != -1)
                return LeftDescendant(n, 2 * node + 2, bst);
            else
                return RightAscendant(n, node, bst);
        }

        private long RightAscendant(long n, long node, long[] bst)
        {
            long parent = (node - 1) / 2;
            if (parent == 0 && bst[parent] < bst[node])
                return -1;
            if (bst[node] < bst[parent])
                return parent;
            else
                return RightAscendant(n, parent, bst);
        }

        private long LeftDescendant(long n, long node, long[] bst)
        {
            if (bst[2 * node + 1] == -1)
                return node;
            else
                return LeftDescendant(n, 2 * node + 1, bst);
        }
    }
}