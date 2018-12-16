using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using MoreLinq;
using AdventOfCode2018.Challenge7;

namespace AdventOfCode2018
{
    public static class Challenge7Part2
    {
        private const int N = 5;

        public static void Solve(IEnumerable<string> lines)
        {
            var r = new Regex(@"Step (\w) must be finished before step (\w) can begin.");

            (char start, char end)[] edges = lines
                .Select(line => r.Match(line))
                .Select(m => ToItem(m.Groups[1].Value, m.Groups[2].Value))
                .ToArray();

            Dictionary<char, char[]> forwardDict = edges
                .GroupBy(e => e.start, e => e.end)
                .ToDictionary(g => g.Key, g => g.ToArray());

            Dictionary<char, HashSet<char>> backwardsDict = edges
                .GroupBy(e => e.end, e => e.start)
                .ToDictionary(g => g.Key, g => new HashSet<char>(g));

            // Start with the steps that don't have requirements.
            var q = new SortedSet<char>(forwardDict.Keys.Except(backwardsDict.Keys));
            var workers = 1.To(N).Select(_ => new Worker()).ToArray();
            int iter = 0;
            while (q.Count > 0 || workers.Any(w => w.IsWorking))
            {
                foreach (var w in workers)
                {
                    char? maybeJob = w.Tick();

                    if (maybeJob.HasValue)
                    {
                        OnCompleted(maybeJob.Value);
                    }
                }

                foreach (var w in workers)
                {
                    if (q.Count == 0)
                    {
                        break;
                    }

                    if (!w.IsWorking)
                    {
                        var step = q.First();
                        q.Remove(step);
                        w.WorkOn(step);
                    }
                }

                iter++;
            }

            Console.WriteLine(iter - 1);

            // Local function
            void OnCompleted(char step)
            {
                if (forwardDict.TryGetValue(step, out char[] nextSteps))
                {
                    foreach (char end in nextSteps)
                    {
                        HashSet<char> stepsStillToDo = backwardsDict[end];
                        stepsStillToDo.Remove(step);

                        if (stepsStillToDo.Count == 0)
                        {
                            q.Add(end);
                        }
                    }
                }
            }
        }

        private static (char x, char y) ToItem(string s1, string s2)
        {
            return (s1[0], s2[0]);
        }
    }
}
