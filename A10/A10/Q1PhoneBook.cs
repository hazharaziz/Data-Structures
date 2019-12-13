using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Contact
    {
        public string Name;
        public int Number;

        public Contact(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }

    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);
            
        public Node[] PhoneBookList;

        public string[] Solve(string[] commands)
        {

            long length = commands.Length;
            PhoneBookList = new Node[length];
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                long hash = Hash(number, length);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number, hash);
                        break;
                    case "del":
                        Delete(number, hash);
                        break;
                    case "find":
                        result.Add(Find(number, hash));
                        break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number, long hash)
        {
            Node temp = PhoneBookList[hash];
            if (temp == null)
                temp = new Node(name, number);
            else
            {
                if (Find(number, hash) == "not found")
                    temp = InsertFront(name, number, temp);
                else
                    OverrideNode(name, number, temp);
            }
            PhoneBookList[hash] = temp;
        }

        private void OverrideNode(string name, int number, Node temp)
        {
            Node result = temp;
            while (result != null)
            {
                if (result.Contact.Number == number)
                    result.Contact.Name = name;
                result = result.Next;
            }
        }

        private Node InsertFront(string name, int number, Node temp)
        {
            Node newNode = new Node(name, number);
            newNode.Next = temp;
            temp = newNode;
            return temp;
        }

        public string Find(int number, long hash)
        {
            Node temp = PhoneBookList[hash];
            while (temp != null)
            {
                if (temp.Contact.Number == number)
                    return temp.Contact.Name;
                temp = temp.Next;
            }
            return "not found";
        }

        public void Delete(int number, long hash)
        {
            Node temp = PhoneBookList[hash];
            if (temp != null)
            {
                if (temp.Contact.Number == number)
                    temp = temp.Next;
                else
                {
                    Node pre = FindPrev(temp, number);
                    Node next = null;
                    if (pre.Next != null)
                    {
                        next = pre.Next.Next;
                        pre.Next.Next = null;
                    }
                    pre.Next = next;
                }
            }
            PhoneBookList[hash] = temp;
        }

        public Node FindPrev(Node head, int number)
        {
            Node result = head;
            if (result != null)
            {
                while (result.Next != null && result.Next.Contact.Number != number)
                {
                    result = result.Next;
                }
            }
            return result;
        }

        public void AddLast(Node head, string name, int number)
        {
            Node newNode = new Node(name, number);
            if (head == null)
                head = newNode;
            else
            {
                Node lastNode = GetLastNode(head);
                lastNode.Next = newNode;
            }
        }

        public Node GetLastNode(Node head)
        {
            Node temp = head;
            while (temp.Next != null)
                temp = temp.Next;
            return temp;
        }

        public long Hash(long number, long length)
        {
            long p = 6721739;
            long a = 100;
            long b = 200;
            return ((a * number + b) % p) % length;
        }
    }
}
