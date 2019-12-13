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
            
        public Dictionary<int, string> PhoneBookList;

        public string[] Solve(string[] commands)
        {
            PhoneBookList = new Dictionary<int, string>();
            List<string> result = new List<string>();
            bool hasKey = false;
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                string find = Find(number);
                hasKey = (find != "not found") ? true : false; 
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number, hasKey);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(find);
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
        }

        public string Find(int number)
        {
            if (!PhoneBookList.ContainsKey(number))
                return "not found";
            else
                return PhoneBookList[number];
        }

        public void Delete(int number)
        {
            PhoneBookList.Remove(number);
        }
    }
}
