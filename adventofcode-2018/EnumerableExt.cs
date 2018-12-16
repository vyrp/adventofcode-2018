using System;
using System.Collections.Generic;

namespace AdventOfCode2018
{
    public static class EnumerableExt
    {
        public static int ArgMax<T>(this IEnumerable<T> source, IComparer<T> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            bool any = false;
            int idx = 0;
            int maxIdx = 0;
            T max = default;
            foreach (var item in source)
            {
                if (!any)
                {
                    any = true;
                    max = item;
                }
                else if (comparer.Compare(item, max) > 0)
                {
                    max = item;
                    maxIdx = idx;
                }

                idx++;
            }

            return any ? maxIdx : throw new ArgumentException(message: "Input sequence is empty.", paramName: nameof(source));
        }

        public static int ArgMax<T>(this IEnumerable<T> source)
        {
            return ArgMax(source, null);
        }
    }
}
