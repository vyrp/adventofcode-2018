using System;
using System.Collections.Generic;
using System.Linq;

using MoreLinq;

namespace AdventOfCode2018
{
    public static class Challenge8Part1
    {
        public static void Solve(IEnumerable<string> lines)
        {
            string content = lines.Single();
            var numbers = new Queue<int>(content.Split(' ').Select(int.Parse));
            Console.WriteLine(Dfs(numbers));
        }

        private static int Dfs(Queue<int> toks)
        {
            int childCount = toks.Dequeue();
            int metaCount = toks.Dequeue();

            int sum = 0;
            for (int i = 0; i < childCount; i++)
            {
                sum += Dfs(toks);
            }

            for (int i = 0; i < metaCount; i++)
            {
                sum += toks.Dequeue();
            }

            return sum;
        }
    }
}
