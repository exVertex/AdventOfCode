using System.Collections.Generic;
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
            var treePlantation = (int[][])key;
            var coordinatesOfVisibleTrees = new HashSet<(int, int)>();

            for (int y = 0; y < treePlantation.Length; y++) {
                int x = 0;
                int highestSoFar = -1;

                while (x < treePlantation[y].Length && highestSoFar < 9) {
                    if (treePlantation[y][x] > highestSoFar) {
                        highestSoFar = treePlantation[y][x];
                        coordinatesOfVisibleTrees.Add((y, x));
                    }
                    x++;
                }

                x = treePlantation[y].Length-1;
                highestSoFar = -1;

                while(x >= 0 && highestSoFar < 9) {
                    if (treePlantation[y][x] > highestSoFar) {
                        highestSoFar = treePlantation[y][x];
                        coordinatesOfVisibleTrees.Add((y, x));
                    }
                    x--;
                }
            }

            for (int x = 0; x < treePlantation[0].Length; x++) {
                int y = 0;
                int highestSoFar = -1;

                while (y < treePlantation.Length && highestSoFar < 9) {
                    if (treePlantation[y][x] > highestSoFar) {
                        highestSoFar = treePlantation[y][x];
                        coordinatesOfVisibleTrees.Add((y, x));
                    }
                    y++;
                }
                
                y = treePlantation.Length-1;
                highestSoFar = -1;

                while(y >= 0 && highestSoFar < 9) {
                    if (treePlantation[y][x] > highestSoFar) {
                        highestSoFar = treePlantation[y][x];
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
