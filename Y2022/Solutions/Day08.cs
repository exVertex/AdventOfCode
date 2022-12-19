using System;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day08: Day {
        protected override dynamic prepareCommon(string[] puzzleInput) {
            var treePlantation = Utils.convertToIntArray(puzzleInput);
            
            foreach (var item in puzzleInput)
            {
                var test = item.ToCharArray();
                Console.WriteLine(test[0]); 
            }

            return "";
        }

        protected override int getPartOne(dynamic key) {
            return 0;
        }

        protected override int getPartTwo(dynamic key) {
            return 0;
        }

        public Day08() {
            day = 8;
            year = 2022;
            title = "Treetop Tree House ";
        }
    }
}