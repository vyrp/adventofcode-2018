using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2018
{
    public static class Challenge11Part1
    {
        private const int N = 300;
        private const int Size = 3;
        private static int serialNum;

        public static void Solve(IEnumerable<string> lines)
        {
            serialNum = int.Parse(lines.Single());

            var q =
                from i in 1.To(N-Size+1)
                from j in 1.To(N-Size+1)
                select (i, j, power: GetSquarePower(i, j));

            Console.WriteLine(q.MaxBy(t => t.power).Single());
        }

        private static int GetSquarePower(int i, int j)
        {
            var q =
                from x in i.To(i+Size-1)
                from y in j.To(j+Size-1)
                select GetCellPower(x, y);

            return q.Sum();
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
