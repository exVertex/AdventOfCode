using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;
using System;

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
            elfCalorieStorage.Sort();

            return elfCalorieStorage;
        }

        protected override string getPartOne(dynamic key) {
            
            List<int> elfStorage = (List<int>)key;
            return elfStorage.Last().ToString();
        }

        protected override string getPartTwo(dynamic key) {

            return "";
        }

        public Day01() {
            day = 1;
            year = 2022;
            title = "Calorie counting";
        }
    }
}
