using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Challenge1Part1
    {
        public static void Solve(string[] lines)
        {
            int sum = lines.Select(int.Parse).Sum();

            Console.WriteLine(sum);
        }
    }
}
