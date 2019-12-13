using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        Node[] HashTable;

        public string[] Solve(long bucketCount, string[] commands)
        {
            HashTable = new Node[bucketCount];
            List<string> result = new List<string>();
            long hash = 0;
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];
                hash = PolyHash(arg, arg.Length, arg.Length) % bucketCount;

                switch (cmdType)
                {
                    case "add":
                        Add(arg, hash);
                        break;
                    case "del":
                        Delete(arg, hash);
                        break;
                    case "find":
                        result.Add(Find(arg, hash));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            long ascii;
            for (int i = start - 1; i >= 0; i--)
            {
                ascii = Convert.ToInt32(str[i]);
                hash = checked((hash * ChosenX + ascii) % p); 
            }
            return hash;
        }

        public void Add(string str, long hash)
        {
            Node temp = HashTable[hash];
            if (temp == null)
                temp = new Node(str);
            else
            {
                if (Find(str, hash) == "no")
                {
                    Node newNode = new Node(str);
                    newNode.Next = temp;
                    temp = newNode;
                }
            }
            HashTable[hash] = temp;
        }

        public string Find(string str, long hash)
        {
            Node temp = HashTable[hash];
            while (temp != null)
            {
                if (temp.Word == str)
                    return "yes";
                temp = temp.Next;
            }
            return "no";
        }

        public void Delete(string str, long hash)
        {
            Node temp = HashTable[hash];
            if (temp != null)
            {
                if (temp.Word == str)
                    temp = temp.Next;
                else
                {
                    Node newNode = new Node(temp.Word);
                    temp = temp.Next;
                    while (temp != null)
                    {
                        if (temp.Word == str)
                        {
                            if (temp.Next != null)
                            {
                                AddLast(newNode, temp.Next.Word);
                                temp = temp.Next;
                            }
                        }
                        else
                            AddLast(newNode, temp.Word);
                        temp = (temp.Next != null) ? temp.Next : null;
                    }
                    temp = newNode;
                }
                HashTable[hash] = temp;
            }
            HashTable[hash] = temp;
        }

        public void AddLast(Node head, string word)
        {
            Node newNode = new Node(word);
            if (head == null)
                head = newNode;
            else
            {
                Node lastNode = GetLastNode(head);
                lastNode.Next = newNode;
            }
        }

        private Node GetLastNode(Node head)
        {
            Node temp = head;
            while (temp.Next != null)
                temp = temp.Next;
            return temp;
        }


        public string Check(int i)
        {
            string result = "";
            Node temp = HashTable[i];
            while (temp != null)
            {
                result += (temp.Next != null) ? $"{temp.Word} " : $"{temp.Word}";
                temp = temp.Next;
            }
            return (result == "") ? "-" : result;
        }
    }
}
