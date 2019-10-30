using System;

namespace A5
{
    public class Number
    {
        public long Num { get; set; }
        public string State { get; set; }

        public Number(long number, string state)
        {
            Num = number;
            State = state;
        }
    }
}