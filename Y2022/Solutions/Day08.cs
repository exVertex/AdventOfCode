using System.Collections.Generic;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day08: Day {

        protected override dynamic prepareCommon(string[] puzzleInput) {
            var treePlantation = new int[puzzleInput.Length][]; // new jagged int[] to store tree heights

            for (int i = 0; i < puzzleInput.Length; i++) {  // fill key array with array of converted integers
                treePlantation[i] = Utils.convertToIntArray(puzzleInput[i].ToCharArray());
            }

            return treePlantation;
        }

        protected override int getPartOne(dynamic key) {
            var coordinatesOfVisibleTrees = new HashSet<(int, int)>();  // hashset where coordinates of every visible tree will be stored

            for (int y = 0; y < key.Length; y++) {
                int x = 0;
                int highestSoFar = -1;

                while (x < key[y].Length && highestSoFar < 9) { // scar for visible trees: left -> right
                    if (key[y][x] > highestSoFar) {
                        highestSoFar = key[y][x];
                        coordinatesOfVisibleTrees.Add((y, x));
                    }
                    x++;
                }

                x = key[y].Length-1;
                highestSoFar = -1;

                while(x >= 0 && highestSoFar < 9) { // scan for visible trees: right -> left
                    if (key[y][x] > highestSoFar) {
                        highestSoFar = key[y][x];
                        coordinatesOfVisibleTrees.Add((y, x));
                    }
                    x--;
                }
            }

            for (int x = 0; x < key[0].Length; x++) {
                int y = 0;
                int highestSoFar = -1;

                while (y < key.Length && highestSoFar < 9) {    // scan for visible trees: top -> bottom
                    if (key[y][x] > highestSoFar) {
                        highestSoFar = key[y][x];
                        coordinatesOfVisibleTrees.Add((y, x));
                    }
                    y++;
                }
                
                y = key.Length-1;
                highestSoFar = -1;

                while(y >= 0 && highestSoFar < 9) { // scan for visible trees: bottom -> top
                    if (key[y][x] > highestSoFar) {
                        highestSoFar = key[y][x];
                        coordinatesOfVisibleTrees.Add((y, x));
                    }
                    y--;
                }
            }

            return coordinatesOfVisibleTrees.Count;
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
