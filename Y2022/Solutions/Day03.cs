using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day03 : Day {

        protected int getPriorityValue(int item) => (item > 91) ? item - 96 : item - 38;    // get value of the priority through char ascii values
        
        protected override int getPartOne(dynamic key) {
            var commonItems = new List<char>();  // list to store items common in both compartments

            Array.ForEach((string[])key, rucksack => commonItems.Add( // fill commonItems with letters contained in both substrings
                rucksack.Substring(0, rucksack.Length/2).Intersect(rucksack.Substring(rucksack.Length/2)).FirstOrDefault()));

            return commonItems.Sum(item => getPriorityValue((int)item));   // return sum of all priorities
        }

        protected override int getPartTwo(dynamic key) {
            var rucksacks = new List<string>(key); // store puzzle input in list of strings
            var commonItems = new List<char>(); // list to store items common in both compartments

            for (int i = 0; i < rucksacks.Count; i += 3) {
                commonItems.Add(rucksacks[i].Intersect(rucksacks[i+1].Intersect(rucksacks[i+2])).FirstOrDefault());
            }

            return commonItems.Sum(item => getPriorityValue((int)item));
        }

        public Day03() {
            day = 3;
            year = 2022;
            title = "Rucksack Reorganization";
        }
    }
}
