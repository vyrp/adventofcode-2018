using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Challenge2Part1
    {
        public static void Solve(string[] words)
        {
            int twos = 0;
            int threes = 0;
            foreach (string word in words)
            {
                var letterToCount = new Dictionary<char, int>();
                foreach (char ch in word)
                {
                    Increment(letterToCount, ch);
                }

                if (letterToCount.Values.Any(count => count == 2))
                {
                    twos++;
                }

                if (letterToCount.Values.Any(count => count == 3))
                {
                    threes++;
                }
            }

            Console.WriteLine(twos * threes);
        }

        private static void Increment(Dictionary<char, int> dict, char key)
        {
            if (!dict.TryGetValue(key, out int value))
            {
                value = 0;
            }

            dict[key] = value + 1;
        }
    }
}
