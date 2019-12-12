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

        protected Dictionary<int, string> PhoneBookList;

        public string[] Solve(string [] commands)
        {

            //PhoneBookList = new Node[10000];
            PhoneBookList = new Dictionary<int, string>();
            List<string> result = new List<string>();
            bool hasKey = false;
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                //int hash = Hash(number);
                hasKey = (PhoneBookList.ContainsKey(number));
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number, hasKey);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(Find(number, hasKey));
                        break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number, bool hasKey)
        {
            if (hasKey)
                PhoneBookList[number] = name;
            else
                PhoneBookList.Add(number, name);
            //if (PhoneBookList[hash] == null)
            //    PhoneBookList[hash] = new Node(name, number);
            //else
            //{
            //    Node newNode = new Node(name, number);
            //    newNode.Next = PhoneBookList[hash];
            //    PhoneBookList[hash] = newNode;
            //}
        }

        public string Find(int number, bool hasKey)
        {
            if (hasKey)
                return PhoneBookList[number];
            return "not found";
            //Node temp = PhoneBookList[hash];
            //while (temp != null)
            //{
            //    if (temp.Contact.Number == number)
            //        return temp.Contact.Name;
            //    temp = temp.Next;
            //}
            //return "not found";
        }

        public void Delete(int number)
        {
            PhoneBookList.Remove(number);
            //Node temp = PhoneBookList[hash];
            //if (temp != null)
            //{
            //    if (temp.Contact.Number == number)
            //    {
            //        temp = temp.Next;
            //        PhoneBookList[hash] = temp;
            //    }
            //    else
            //    {
            //        Node cur = temp;
            //        Node prev = null;
            //        while (cur != null && cur.Contact.Number != number)
            //        {
            //            prev = cur;
            //            cur = cur.Next;
            //        }
            //        if (cur != null)
            //        {
            //            prev.Next = cur.Next;
            //            PhoneBookList[hash] = prev;
            //        }
            //    }
            //}
        }

        public int Hash(int number)
        {
            int a = 20;
            int b = 20;
            int p = 10000019;
            int m = 10000;
            return ((a * number + b) % p) % m;
        }
    }
}
