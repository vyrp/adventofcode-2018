using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using MoreLinq;

namespace AdventOfCode2018
{
    public static class Challenge4Part1
    {
        private static Regex fullInputRegex = new Regex(@"\[\d+-\d+-\d+ \d+:(\d+)\] (.+)");
        private static Regex guardIdRegex = new Regex(@"Guard #(\d+) begins shift");

        public static void Solve(IEnumerable<string> lines)
        {
            var items = lines
                .OrderBy(line => line)
                .Select(line => fullInputRegex.Match(line))
                .Select(m => (minute: int.Parse(m.Groups[1].Value), text: m.Groups[2].Value));

            var minutesByGuard = new Dictionary<string, int[]>();
            string currentGuard = default;
            int lastTime = default;
            foreach (var item in items)
            {
                if (item.text == "falls asleep")
                {
                    lastTime = item.minute;
                }
                else if (item.text == "wakes up")
                {
                    var minutes = minutesByGuard[currentGuard];
                    for (int m = lastTime; m < item.minute; m++)
                    {
                        minutes[m]++;
                    }
                }
                else
                {
                    currentGuard = guardIdRegex.Match(item.text).Groups[1].Value;
                    if (!minutesByGuard.ContainsKey(currentGuard))
                    {
                        minutesByGuard[currentGuard] = new int[60]; // Starts 0-filled.
                    }
                }
            }

            (string mostAsleepGuard, int[] hisMinutes) = minutesByGuard.MaxBy(kvp => kvp.Value.Sum()).Single();

            Console.WriteLine(hisMinutes.ArgMax() * int.Parse(mostAsleepGuard));
        }
    }
}
