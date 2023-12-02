using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AdventOfCode.Y2023.Solutions {
    public class Day03 : Day {
        protected override dynamic PrepareCommon(string[] puzzleInput) {
            foreach(var line in puzzleInput) {
                Console.WriteLine(line);
            }
            return puzzleInput;
        }
        protected override int GetPartOne(dynamic key ) {
            return 1;
        }
        protected override int GetPartTwo(dynamic key) {
            return 2;
        }
        public Day03() {
            day = 3;
            year = 2023;
            title = "";
        }
    }
}
