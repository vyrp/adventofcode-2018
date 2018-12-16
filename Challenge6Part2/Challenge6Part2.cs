using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using MoreLinq;

namespace AdventOfCode2018
{
    public static class Challenge6Part2
    {
        public static void Solve(IEnumerable<string> lines)
        {
            var r = new Regex(@"(\d+), (\d+)");

            var points = lines
                .Select(line => r.Match(line))
                .Select(m => ToPoint(m.Groups[1].Value, m.Groups[2].Value))
                .ToArray();

            var minX = points.Min(p => p.x);
            var maxX = points.Max(p => p.x);
            var minY = points.Min(p => p.y);
            var maxY = points.Max(p => p.y);

            var sums =
                from x in minX.To(maxX)
                from y in minY.To(maxY)
                select points.Select(p => Dist(x, y, p.x, p.y)).Sum();

            Console.WriteLine(sums.Count(s => s < 10000));
        }

        private static int Dist(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private static (int x, int y) ToPoint(string s1, string s2)
        {
            return (int.Parse(s1), int.Parse(s2));
        }
    }
}
