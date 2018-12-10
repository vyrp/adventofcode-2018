using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using MoreLinq;

namespace AdventOfCode2018
{
    public static class Challenge6Part1
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

            var map = new int[maxX + 1, maxY + 1];

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    List<int> closest = new List<int>();
                    int closestDist = int.MaxValue;
                    for (int pi = 0; pi < points.Length; pi++)
                    {
                        int dist = Dist(x, y, points[pi].x, points[pi].y);
                        if (dist < closestDist)
                        {
                            closestDist = dist;
                            closest = new List<int> { pi };
                        }
                        else if (dist == closestDist)
                        {
                            closest.Add(pi);
                        }
                    }

                    map[x, y] = closest.Count == 1 ? closest[0] : -1;
                }
            }

            var counts = (-1).To(points.Length).ToDictionary(n => n, _ => 0);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    counts[map[x, y]]++;
                }
            }

            // Remove points that are in the border, because they are infinite.
            for (int x = minX; x <= maxX; x++)
            {
                counts.Remove(map[x, minY]);
                counts.Remove(map[x, maxY]);
            }

            for (int y = minY; y <= maxY; y++)
            {
                counts.Remove(map[minX, y]);
                counts.Remove(map[maxX, y]);
            }

            Console.WriteLine(counts.MaxBy(kvp => kvp.Value).First().Value);
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
