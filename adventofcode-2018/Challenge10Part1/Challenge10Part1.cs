using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public static class Challenge10Part1
    {
        public static void Solve(IEnumerable<string> lines)
        {
            var r = new Regex(@"position=<([ 0-9-]+),([ 0-9-]+)> velocity=<([ 0-9-]+),([ 0-9-]+)>");

            (int x, int y, int vx, int vy)[] items = lines
                .Select(line => r.Match(line))
                .Select(m => ToItem(
                    m.Groups[1].Value,
                    m.Groups[2].Value,
                    m.Groups[3].Value,
                    m.Groups[4].Value))
                .ToArray();

            // Idea: stop when the area starts increasing.
            long idx = 0;
            long area = long.MaxValue;
            while (true)
            {
                Update(items);

                long currentArea = GetArea(items);
                if (currentArea < area)
                {
                    idx++;
                    if (idx % 100 == 0) Console.WriteLine(idx);
                    area = currentArea;
                }
                else if (currentArea > area)
                {
                    Console.WriteLine(idx);
                    UnUpdate(items);
                    Show(items);
                    Update(items);
                    Console.ReadLine();
                }
            }
        }

        private static long GetArea((int x, int y, int vx, int vy)[] items)
        {
            var minX = items.Min(p => p.x);
            var maxX = items.Max(p => p.x);
            var minY = items.Min(p => p.y);
            var maxY = items.Max(p => p.y);

            return ((long)(maxX - minX)) * (maxY - minY);
        }

        private static void Show((int x, int y, int vx, int vy)[] items)
        {
            var minX = items.Min(p => p.x);
            var maxX = items.Max(p => p.x);
            var minY = items.Min(p => p.y);
            var maxY = items.Max(p => p.y);

            var map = new bool[maxY - minY + 1, maxX - minX + 1];

            foreach (var p in items)
            {
                map[p.y - minY, p.x - minX] = true;
            }

            for (int j = 0; j < map.GetLength(0); j++)
            {
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    Console.Write(map[j, i] ? "#" : ".");
                }
                Console.WriteLine();
            }
        }

        private static void Update((int x, int y, int vx, int vy)[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].x += items[i].vx;
                items[i].y += items[i].vy;
            }
        }

        private static void UnUpdate((int x, int y, int vx, int vy)[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].x -= items[i].vx;
                items[i].y -= items[i].vy;
            }
        }

        private static (int x, int y, int vx, int vy) ToItem(string s1, string s2, string s3, string s4)
        {
            return (int.Parse(s1), int.Parse(s2), int.Parse(s3), int.Parse(s4));
        }
    }
}
