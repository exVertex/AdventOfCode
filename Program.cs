using System;
using System.Collections.Generic;
using AdventOfCode.Core;
using AdventOfCode.Y2022.Solutions;

namespace AdventOfCode {
    class Program {
        static void Main(string[] args) {

            var days = new List<Day> {
                new Day01()
            };

            days[0].getResults();

            foreach (var day in days) {
                day.getResults();
            }
        }    
    }
}
