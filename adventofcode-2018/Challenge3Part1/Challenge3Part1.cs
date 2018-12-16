using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public static class Challenge3Part1
    {
        private static Regex inputRegex = new Regex(@"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)");

        public static void Solve(IEnumerable<string> words)
        {
            var dict = words
                .Select(line => inputRegex.Match(line))
                .SelectMany(m => PointsInRectangle(
                    int.Parse(m.Groups[1].Value),
                    int.Parse(m.Groups[2].Value),
                    int.Parse(m.Groups[3].Value),
                    int.Parse(m.Groups[4].Value),
                    int.Parse(m.Groups[5].Value)))
                .GroupBy(t => (t.x, t.y), t => t.id)
                .ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine(dict.Values.Count(count => count >= 2));
        }

        private static IEnumerable<(int id, int x, int y)> PointsInRectangle(int id, int left, int top, int w, int h)
        {
            for (int i = left; i < left + w; i++)
            {
                for (int j = top; j < top + h; j++)
                {
                    yield return (id, i, j);
                }
            }
        }
    }
}
