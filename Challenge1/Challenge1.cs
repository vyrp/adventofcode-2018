using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Challenge1
    {
        public static void Solve()
        {
            int sum = Console.In.ReadToEnd()
                .Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(int.Parse)
                .Sum();

            Console.WriteLine(sum);
        }
    }
}
