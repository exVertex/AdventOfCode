using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2022.Solutions {
    public class Day01 : Day {
       
        protected override dynamic PrepareCommon(string[] puzzleInput) {
            var elfCalorieStorage = new List<int> {};

            foreach (var line in puzzleInput) {
                int elf = 0;
                if (string.IsNullOrWhiteSpace(line)) {
                    elf += int.Parse(line);
                } else {
                    elfCalorieStorage.Add(elf);
                }
            };
            
            return elfCalorieStorage.OrderByDescending(x => x).ToList();
        }

        protected override int GetPartOne(dynamic key) => ((List<int>)key).First();
        protected override int GetPartTwo(dynamic key) => key[0] + key[1] + key[2];

        public Day01() {
            day = 1;
            year = 2022;
            title = "Calorie Counting";
        }
    }
}
