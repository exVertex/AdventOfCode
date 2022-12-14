using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day03 : Day {

        protected int getPriorityValue(int item) => (item > 91) ? item - 96 : item - 38;    // get value of the priority through char ascii values
        
        protected override dynamic solveMain(string[] puzzleInput) {
            List<char> commonItems = new List<char>();
            
            Array.ForEach(puzzleInput, rucksack => commonItems.Add( // fill commonItems with letters contained in both substrings
                rucksack.Substring(0, rucksack.Length/2).Intersect(rucksack.Substring(rucksack.Length/2)).FirstOrDefault()));

            return commonItems;
        }

        protected override int getPartOne(dynamic key) => ((List<char>)key).Sum(item => getPriorityValue((int)item));   // return sum of all priorities

        protected override int getPartTwo(dynamic key) {
            return 0;
        }

        public Day03() {
            day = 3;
            year = 2022;
            title = "Rucksack Reorganization";
        }
    }
}
