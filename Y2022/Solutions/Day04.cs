using System;
using System.Linq;
using System.Collections.Generic;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day04 : Day {

        private int checkIfContains (int[] top, int[] bottom) => (top[1] >= bottom[1] && bottom[0] >= top[0]) ? 1 : 0; // checks if one task range contains the other
        private int checkIfOverlaps (int[] top, int[] bottom) => (bottom[1] >= top[0]) ? 1 : 0; // checks if task ranges overlap

        protected override dynamic PrepareCommon(string[] puzzleInput) {
            var elfGroups = new List<int[][]>();

            foreach (string line in puzzleInput) {
                string[] elfGroup = line.Split(",");    // split the line into left and rigt assignment parts
                string[] leftElf = elfGroup[0].Split("-");  // get task range of the first elf
                string[] rightElf = elfGroup[1].Split("-"); // get task range of the second elf

                elfGroups.Add(new int[] [] {
                    new int[] {int.Parse(leftElf[0]), int.Parse(leftElf[1])},
                    new int[] {int.Parse(rightElf[0]), int.Parse(rightElf[1])}
                });
            }

            return elfGroups;   // returns puzzle input in the form of list of jagged arrays
        }

        protected override int GetPartOne(dynamic key) => (new List<int[][]>(key)).Sum(
            elfGroup => (elfGroup[0][1] > elfGroup[1][1] || (elfGroup[0][1] == elfGroup[1][1] && elfGroup[0][0] < elfGroup[1][0])) ?
            checkIfContains(elfGroup[0], elfGroup[1]) : checkIfContains(elfGroup[1], elfGroup[0]));
        
        protected override int GetPartTwo(dynamic key) => (new List<int[][]>(key)).Sum(
            elfGroup => (elfGroup[0][1] > elfGroup[1][1] || (elfGroup[0][1] == elfGroup[1][1] && elfGroup[0][0] < elfGroup[1][0])) ?
            checkIfOverlaps(elfGroup[0], elfGroup[1]) : checkIfOverlaps(elfGroup[1], elfGroup[0]));

        public Day04() {
            day = 4;
            year = 2022;
            title = "Camp Cleanup";
        }
    }
}
