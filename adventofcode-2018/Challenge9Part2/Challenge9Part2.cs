using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public static class Challenge9Part2
    {
        public static void Solve(IEnumerable<string> lines)
        {
            var r = new Regex(@"(\d+) players; last marble is worth (\d+) points");

            (int players, int last) = lines
                .Select(line => r.Match(line))
                .Select(m => ToItem(m.Groups[1].Value, m.Groups[2].Value))
                .Single();
            last *= 100;

            var points = new long[players];
            var marbles = new LinkedList<int>();
            marbles.AddLast(0);
            LinkedListNode<int> current = marbles.First;
            for (int i = 1; i <= last; i++)
            {
                if (i % 23 == 0)
                {
                    current = Previous(current, 7);
                    points[i % players] += i + current.Value;

                    var next = Next(current);
                    marbles.Remove(current);
                    current = next;
                }
                else
                {
                    current = Next(current);
                    current = marbles.AddAfter(current, i);
                }
            }

            Console.WriteLine(points.Max());
        }

        private static (int x, int y) ToItem(string s1, string s2)
        {
            return (int.Parse(s1), int.Parse(s2));
        }

        private static LinkedListNode<int> Next(LinkedListNode<int> node)
        {
            return node.Next ?? node.List.First;
        }

        private static LinkedListNode<int> Previous(LinkedListNode<int> node)
        {
            return node.Previous ?? node.List.Last;
        }

        private static LinkedListNode<int> Previous(LinkedListNode<int> node, int n)
        {
            for (int i = 0; i < n; i++)
            {
                node = Previous(node);
            }

            return node;
        }
    }
}
