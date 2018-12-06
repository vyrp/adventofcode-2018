using System;
using System.Linq;

namespace AdventOfCode2018
{
    public partial class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowUsage();
                return 0;
            }
            else
            {
                switch (args[0])
                {
                    case "1.1":
                        Challenge1Part1.Solve(ReadInput());
                        break;
                    case "1.2":
                        Challenge1Part2.Solve(ReadInput());
                        break;
                    case "2.1":
                        Challenge2Part1.Solve(ReadInput());
                        break;
                    case "2.2":
                        Challenge2Part2.Solve(ReadInput());
                        break;
                    case "3.1":
                        Challenge3Part1.Solve(ReadInput());
                        break;
                    case "3.2":
                        Challenge3Part2.Solve(ReadInput());
                        break;
                    case "4.1":
                        Challenge4Part1.Solve(ReadInput());
                        break;
                    case "4.2":
                        Challenge4Part2.Solve(ReadInput());
                        break;
                    case "5.1":
                        Challenge5Part1.Solve(ReadInput());
                        break;
                    case "5.2":
                        Challenge5Part2.Solve(ReadInput());
                        break;
                    default:
                        Console.Error.WriteLine($"Challenge not supported: '{args[0]}'.");
                        return 1;
                }
            }

            return 0;
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
