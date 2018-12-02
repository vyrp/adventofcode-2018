using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Challenge2
    {
        public static void Solve()
        {
            int[] numbers = Console.In.ReadToEnd()
                .Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(int.Parse)
                .ToArray();

            int sum = 0;
            int idx = 0;
            var set = new HashSet<int>();
            while (set.Add(sum))
            {
                sum += numbers[idx];
                idx = (idx + 1) % numbers.Length;
            }

            Console.WriteLine(sum);
        }
    }
}
