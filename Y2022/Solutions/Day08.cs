using System;
using System.Collections.Generic;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day08: Day {

        private int getScenicScore(int[][] treePlantation, int x, int y) {
            
            int leftScore, rightScore, upScore, downScore, index;
            leftScore = rightScore = upScore = downScore = 0;

            index = x; // count trees visible from the main tree - right
            do {
                rightScore++;
                index++;
            } while (index < treePlantation[y].Length-1 && treePlantation[y][index] < treePlantation[y][x]);

            index = x; // count trees visible from the main tree - left
            do {
                leftScore++;
                index--;
            } while (index > 0 && treePlantation[y][index] < treePlantation[y][x]);

            index = y; // count trees visible from the main tree - down
            do {
                downScore++;
                index++;
            } while (index < treePlantation[y].Length-1 && treePlantation[index][x] < treePlantation[y][x]);

            index = y; // count trees visible from the main tree - up
            do {
                upScore++;
                index--;
            } while (index > 0 && treePlantation[index][x] < treePlantation[y][x]);

            return rightScore * leftScore * upScore * downScore;
        }

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
                int highestTreeHeightSoFar = -1;

                while (x < key[y].Length && highestTreeHeightSoFar < 9) { // scar for visible trees: left -> right

                    if (key[y][x] > highestTreeHeightSoFar) {
                        highestTreeHeightSoFar = key[y][x];
                        coordinatesOfVisibleTrees.Add((y, x));
                    }
                    x++;
                }

                x = key[y].Length-1;
                highestTreeHeightSoFar = -1;

                while (x >= 0 && highestTreeHeightSoFar < 9) { // scan for visible trees: right -> left

                    if (key[y][x] > highestTreeHeightSoFar) {
                        highestTreeHeightSoFar = key[y][x];
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

                while (y >= 0 && highestSoFar < 9) { // scan for visible trees: bottom -> top
                
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
            var treePlantation = (int[][])key;
            int highestScenicScore = 0;
            
            for (int y = 1; y < key.Length-1; y++) {
                for (int x = 1; x <key[y].Length-1; x++) {
                    int scenicScore = getScenicScore(treePlantation, x, y);
                    highestScenicScore = (scenicScore > highestScenicScore) ? scenicScore : highestScenicScore;
                }
            } 
            return highestScenicScore;
        }

        public Day08() {
            day = 8;
            year = 2022;
            title = "Treetop Tree House";
        }
    }
}
