using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using MoreLinq;

namespace AdventOfCode2018
{
    public static class Challenge5Part2
    {
        public static void Solve(IEnumerable<string> lines)
        {
            string input = lines.First();

            Console.WriteLine(
                'a'.To('z')
                    .Select(ch => input
                        .Replace(ch.ToString(), "")
                        .Replace(char.ToUpper(ch).ToString(), ""))
                    .Select(SolveForOne)
                    .Min());
        }

        private static int SolveForOne(string input)
        {
            var s = new Stack<char>();
            foreach (var ch in input)
            {
                if (s.Count > 0 && Matches(ch, s.Peek()))
                {
                    s.Pop();
                }
                else
                {
                    s.Push(ch);
                }
            }

            return s.Count;
        }

        private static bool Matches(char a, char b)
        {
            return (a ^ b) == 0b0010_0000;
        }
    }
}
