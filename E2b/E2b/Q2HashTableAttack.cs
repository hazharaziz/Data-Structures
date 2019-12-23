using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2b
{
    public class Q2HashTableAttack : Processor
    {
        public Q2HashTableAttack (string testDataName) : base(testDataName) 
        {
        }

        public override string Process(string inStr)
        {
            long bucketCount = long.Parse(inStr);
            return string.Join("\n", Solve(bucketCount));
        }

        public string[] Solve(long bucketCount)
        {
            double maxLoadingFactor = 0.9;
            double p = bucketCount * maxLoadingFactor;
            List<string> result = new List<string>();
            Random random = new Random();
            string s = AllChars[random.Next(0, 60)].ToString();
            long firstHash = GetBucketNumber(s, bucketCount);
            long hash = 0;
            while (result.Count < p)
            {
                hash = GetBucketNumber(s + AllChars[random.Next(0, 60)], bucketCount);
                if (hash == firstHash)
                    result.Add(s + AllChars[random.Next(0, 60)].ToString());
                s += AllChars[random.Next(0, 60)];
            }
            return result.ToArray();
        }

        #region Chars
        static char[] LowChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('a' + n))
            .ToArray();

        static char[] CapChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('A' + n))
            .ToArray();

        static char[] Numbers = Enumerable
            .Range(0, 10)
            .Select(n => (char)('0' + n))
            .ToArray();

        static char[] AllChars = 
            LowChars.Concat(CapChars).Concat(Numbers).ToArray();
        #endregion


        // پیاده‌سازی مورد استفاده دات‌نت برای پیدا کردن شماره باکت
        // https://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,bcd13bb775d408f1
        public static long GetBucketNumber(string str, long bucketCount) =>
            (str.GetHashCode() & 0x7FFFFFFF) % bucketCount;
    }
}
