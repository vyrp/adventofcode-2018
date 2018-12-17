using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public static class Challenge9Part1
    {
        public static void Solve(IEnumerable<string> lines)
        {
            var r = new Regex(@"(\d+) players; last marble is worth (\d+) points");

            (int players, int last) = lines
                .Select(line => r.Match(line))
                .Select(m => ToItem(m.Groups[1].Value, m.Groups[2].Value))
                .Single();

            var marbles = new List<int> { 0 };
            var points = new int[players];

            int current = 0;
            for (int i = 1; i <= last; i++)
            {
                if (i % 23 == 0)
                {
                    points[i % players] += i;

                    current = (current - 7 + marbles.Count) % marbles.Count;
                    var v = marbles[current];
                    marbles.RemoveAt(current);
                    points[i % players] += v;
                }
                else
                {
                    current = (current + 2) % marbles.Count;
                    marbles.Insert(current, i);
                }
            }

            Console.WriteLine(points.Max());
        }

        private static (int x, int y) ToItem(string s1, string s2)
        {
            return (int.Parse(s1), int.Parse(s2));
        }
    }
}
