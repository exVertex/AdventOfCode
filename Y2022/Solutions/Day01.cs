using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2022.Solutions
{
    public class Day01 : Day {

        protected override dynamic preparePuzzleInput() => Utils.getArrayInput("./Y2022/PuzzleInputs/day01.txt");
        
        protected override dynamic solveMain(dynamic puzzleInput) {
            int elf = 0;
            List<int> elfCalorieStorage = new List<int> {};

            foreach (var line in puzzleInput) {
                if (line != "") {
                    elf += int.Parse(line);
                } else {
                    elfCalorieStorage.Add(elf);
                    elf = 0;
                }
            };

            return elfCalorieStorage.OrderByDescending(x => x).ToList();
        }

        protected override int getPartOne(dynamic key) {
            List<int> elfCalorieStorage = (List<int>)key;
            return elfCalorieStorage.First();
        }

        protected override int getPartTwo(dynamic key) {
            List<int> elfCalorieStorage = (List<int>)key;
            return (elfCalorieStorage[0] + elfCalorieStorage[1] + elfCalorieStorage[2]);
        }

        public Day01() {
            day = 1;
            year = 2022;
            title = "Calorie counting";
        }
    }
}
