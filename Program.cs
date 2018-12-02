using System;

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
                    case "1":
                        Challenge1.Solve();
                        break;
                    case "2":
                        Challenge2.Solve();
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
    }
}
