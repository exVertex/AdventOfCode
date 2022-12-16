using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day08: Day {
        protected override dynamic prepareCommon(string[] puzzleInput) {
            var treePlantation = new int[puzzleInput.Length][]; // new jagged int[] to store tree heights

            for (int i = 0; i < puzzleInput.Length; i++) {  // fill treePlantation array with array of converted integers
                treePlantation[i] = Utils.convertToIntArray(puzzleInput[i].ToCharArray());
            }

            return treePlantation;
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
            title = "Treetop Tree House";
        }
    }
}
