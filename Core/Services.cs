using System.Collections.Generic;
using AdventOfCode.Y2022.Solutions;
using AdventOfCode.Y2021.Solutions;

namespace AdventOfCode.Core
{
    public class Services{
        public static List<Day> createDaysSolutions() {

            var solutions = new List<Day> {
                new Y2022.Solutions.Day01()
            };

            return solutions;
        }

    }
}