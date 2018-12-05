
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public static class RegexExt
    {
        public static T Extract<T>(this Regex r, string input, Func<string, T> parser)
        {
            return parser(r.Match(input).Groups[1].Value);
        }

        public static (T1, T2) Extract<T1, T2>(
            this Regex r,
            string input,
            Func<string, T1> parser1,
            Func<string, T2> parser2)
        {
            var groups = r.Match(input).Groups;
            return (parser1(groups[1].Value), parser2(groups[2].Value));
        }

        public static (T1, T2, T3) Extract<T1, T2, T3>(
            this Regex r,
            string input,
            Func<string, T1> parser1,
            Func<string, T2> parser2,
            Func<string, T3> parser3)
        {
            var groups = r.Match(input).Groups;
            return (parser1(groups[1].Value), parser2(groups[2].Value), parser3(groups[3].Value));
        }

        public static (T1, T2, T3, T4) Extract<T1, T2, T3, T4>(
            this Regex r,
            string input,
            Func<string, T1> parser1,
            Func<string, T2> parser2,
            Func<string, T3> parser3,
            Func<string, T4> parser4)
        {
            var groups = r.Match(input).Groups;
            return (
                parser1(groups[1].Value),
                parser2(groups[2].Value),
                parser3(groups[3].Value),
                parser4(groups[4].Value));
        }

        public static (T1, T2, T3, T4, T5) Extract<T1, T2, T3, T4, T5>(
            this Regex r,
            string input,
            Func<string, T1> parser1,
            Func<string, T2> parser2,
            Func<string, T3> parser3,
            Func<string, T4> parser4,
            Func<string, T5> parser5)
        {
            var groups = r.Match(input).Groups;
            return (
                parser1(groups[1].Value),
                parser2(groups[2].Value),
                parser3(groups[3].Value),
                parser4(groups[4].Value),
                parser5(groups[5].Value));
        }
    }
}
