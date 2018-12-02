using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Challenge2Part2
    {
        public static void Solve()
        {
            string[] words = Console.In.ReadToEnd()
                .Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToArray();

            Console.WriteLine("TODO");
        }
    }
}
