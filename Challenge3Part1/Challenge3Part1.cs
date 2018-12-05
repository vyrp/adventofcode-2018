using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public static class Challenge3Part1
    {
        private static Regex inputRegex = new Regex(@"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)");

        public static void Solve(string[] words)
        {
            var dict = words
                .Select(line => inputRegex.Extract(line, int.Parse, int.Parse, int.Parse, int.Parse, int.Parse))
                .SelectMany(PointsInRectangle)
                .GroupBy(t => (t.x, t.y), t => t.id)
                .ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine(dict.Values.Count(count => count >= 2));
        }

        private static IEnumerable<(int id, int x, int y)> PointsInRectangle((int id, int left, int top, int w, int h) t)
        {
            for (int i = t.left; i < t.left + t.w; i++)
            {
                for (int j = t.top; j < t.top + t.h; j++)
                {
                    yield return (t.id, i, j);
                }
            }
        }
    }
}
