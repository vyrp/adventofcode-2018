using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Challenge1Part1
    {
        public static void Solve(IEnumerable<string> lines)
        {
            int sum = lines.Select(int.Parse).Sum();

            Console.WriteLine(sum);
        }
    }
}
