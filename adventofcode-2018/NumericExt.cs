using System.Collections.Generic;

namespace AdventOfCode2018
{
    public static class NumericExt
    {
        public static IEnumerable<char> To(this char from, char to)
        {
            for (char ch = from; ch <= to; ch++)
            {
                yield return ch;
            }
        }

        public static IEnumerable<int> To(this int from, int to)
        {
            for (int n = from; n <= to; n++)
            {
                yield return n;
            }
        }
    }
}
