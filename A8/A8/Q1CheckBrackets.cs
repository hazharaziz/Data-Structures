using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            BracketStack<Bracket> stack = new BracketStack<Bracket>();
            long index = -1;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '[' || str[i] == '{')
                    stack.Push(new Bracket(str[i], i));
                if (str[i] == ')' || str[i] == ']' || str[i] == '}')
                {
                    if (stack.IsEmpty())
                        return i + 1;
                    else
                    {
                        char top = stack.Pop().Character;
                        if (Match(str[i], top))
                            return i + 1;
                    }
                }
            }

            if (!stack.IsEmpty())
            {
                Bracket top = stack.Pop();
                return top.Index + 1;
            }

            return index;
        }

        /// <summary>
        /// Returns true if the characters are pairs of each other
        /// </summary>
        /// <param name="ch1"></param>
        /// <param name="ch2"></param>
        /// <returns></returns>
        private bool Match(char ch1, char ch2) =>
            (ch1 != ')' && ch2 == '(') ||
            (ch1 != ']' && ch2 == '[') ||
            (ch1 != '}' && ch2 == '{');

    }
}
