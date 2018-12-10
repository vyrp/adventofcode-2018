using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowUsage();
                return 0;
            }

            var m = Regex.Match(args[0], @"^(\d+)\.([12])$");
            if (!m.Success)
            {
                Console.Error.WriteLine($"Invalid challenge name: '{args[0]}'.");
                return 1;
            }

            return ExecuteChallenge(m.Groups[1].Value, m.Groups[2].Value);
        }

        private static void ShowUsage()
        {
            const string Usage =
@"Usage:
    dotnet run <challenge_num>

Where:
    <challenge_num>: The challenge number.";

            Console.WriteLine(Usage);
        }

        private static int ExecuteChallenge(string challengeNum, string partNum)
        {
            var t = Type.GetType($"{nameof(AdventOfCode2018)}.Challenge{challengeNum}Part{partNum}");

            if (t == null)
            {
                Console.Error.WriteLine($"Challenge not found: '{challengeNum}.{partNum}'.");
                return 1;
            }

            t.GetMethod("Solve").Invoke(null, new object[] { ReadInput() });
            return 0;
        }

        private static string[] ReadInput()
        {
            return Console.In.ReadToEnd()
                .Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToArray();
        }
    }
}
