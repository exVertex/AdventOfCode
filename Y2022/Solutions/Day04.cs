using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day04 : Day {

        private int checkIfOverlapping (int[] top, int[] bottom) => (top[1] >= bottom[1] && bottom[0] >= top[0]) ? 1 : 0;

        protected override dynamic solveMain(string[] puzzleInput) {
            int overlappingAssigmentPairs = 0;

            foreach(var line in puzzleInput) {
                string[] elfGroup = line.Split(",");
                string[] leftPart = elfGroup[0].Split("-");
                string[] rightPart = elfGroup[1].Split("-");
                int[] leftElf = new int[] {int.Parse(leftPart[0]), int.Parse(leftPart[1])};
                int[] rightElf = new int[] {int.Parse(rightPart[0]), int.Parse(rightPart[1])};

                overlappingAssigmentPairs += (leftElf[1] > rightElf[1] || (leftElf[1] == rightElf[1] && leftElf[0] < rightElf[0])) ?
                checkIfOverlapping(leftElf, rightElf) : checkIfOverlapping(rightElf, leftElf);
            }

            return overlappingAssigmentPairs;
        }

        protected override int getPartOne(dynamic key) {
            return key;
        }

        protected override int getPartTwo(dynamic key) {

            
            return 0;
        }

        public Day04() {
            day = 4;
            year = 2022;
            title = "Camp Cleanup";
        }
    }
}
