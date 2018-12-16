using System;
using System.Collections.Generic;
using System.Linq;

using MoreLinq;

namespace AdventOfCode2018
{
    public static class Challenge5Part1
    {
        public static void Solve(IEnumerable<string> lines)
        {
            string input = lines.First();

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

            Console.WriteLine(s.Count);
        }

        private static bool Matches(char a, char b)
        {
            return (a ^ b) == 0b0010_0000;
        }
    }
}
