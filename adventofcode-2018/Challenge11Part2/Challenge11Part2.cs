using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2018
{
    public static class Challenge11Part2
    {
        private const int N = 300;
        private static int serialNum;
        private static int[,] sums;

        public static void Solve(IEnumerable<string> lines)
        {
            serialNum = int.Parse(lines.Single());

            int[][] power = 0.To(N).Select(j => 0.To(N).Select(i => GetCellPower(j, i)).ToArray()).ToArray();

            sums = new int[N+1, N+1];

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    sums[i, j] = sums[i, j-1] + sums[i-1, j] + power[i][j] - sums[i-1, j-1];
                }
            }

            var r = 1.To(N).Select(BestWith).MaxBy(t => t.power).First();
            Console.WriteLine(r);
        }

        public static (int x, int y, int size, int power) BestWith(int size)
        {
            Console.Write(size + ": ");
            var q =
                from i in 1.To(N - size + 1)
                from j in 1.To(N - size + 1)
                select (i, j, power: GetSquarePower(i, j, size));

            var r = q.MaxBy(t => t.power).First();
            Console.WriteLine(r);
            return (r.i, r.j, size, r.power);
        }

        private static int GetSquarePower(int i, int j, int size)
        {
            return sums[i+size-1, j+size-1] - sums[i-1, j+size-1] - sums[i+size-1, j-1] + sums[i-1, j-1];
        }

        private static int GetCellPower(int x, int y)
        {
            long rackID = x + 10;
            long tmp = ((rackID * y) + serialNum) * rackID;

            if (tmp < 100)
            {
                return 0;
            }

            int hundredsDigit = (int)((tmp / 100) % 10);
            return hundredsDigit - 5;
        }
    }
}
