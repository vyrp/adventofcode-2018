using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Challenge2Part2
    {
        public static void Solve(IEnumerable<string> lines)
        {
            string[] words = lines.ToArray();
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (Difference(words[i], words[j]) == 1)
                    {
                        Console.WriteLine(OnlySameLetters(words[i], words[j]));
                    }
                }
            }
        }

        private static int Difference(string word1, string word2)
        {
            return word1.Zip(word2, (ch1, ch2) => ch1 != ch2).Count(b => b);
        }

        private static string OnlySameLetters(string word1, string word2)
        {
            return new string(
                word1.Zip(word2, (ch1, ch2) => (ch1, ch2))
                .Where(pair => pair.ch1 == pair.ch2)
                .Select(pair => pair.ch1)
                .ToArray());
        }
    }
}
