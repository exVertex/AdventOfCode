using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2022.Solutions {
    public class Day01 : Day {
        protected override dynamic PrepareCommon(string[] puzzleInput) {
            var elfCalorieStorage = new List<int> {};
            int elfCalories = 0;

            for (int i = 0; i < puzzleInput.Length; i++) {
                if(!string.IsNullOrWhiteSpace(puzzleInput[i])) {
                    elfCalories += int.Parse(puzzleInput[i]);
                } else {
                    elfCalorieStorage.Add(elfCalories);
                    elfCalories = 0;
                }
                if (i == puzzleInput.Length -1) elfCalorieStorage.Add(elfCalories);
            }

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
