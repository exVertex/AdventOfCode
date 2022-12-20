using System;
using System.Collections.Generic;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day08: Day {

        private int getScenicScore(int[][] treePlantation, int x, int y) {
            
            int leftScore, rightScore, topScore, bottomScore, treeHeight, floatX, floatY;
            leftScore = rightScore = topScore = bottomScore = 0;

            // right
            floatX = 1;
            do {
                rightScore++;
                floatX++;
            } while (floatX < treePlantation[y].Length && (treePlantation[y][floatX] > treePlantation[y][x]) && (treePlantation[y][floatX] != treePlantation[y][x]));

            /* 
            treeHeight = 0;

            floatX = x+1;
            while (floatX < treePlantation[y].Length && treeHeight <= treePlantation[y][x]) { // count trees visible from the main tree - right 
                if (treePlantation[y][floatX] >= treeHeight) {
                    treeHeight = treePlantation[y][floatX];
                    rightScore++;
                }
                floatX++;
            }

            treeHeight = 0;

            floatX = x-1;
            while (floatX >= 0 && treeHeight <= treePlantation[y][x]) {    // count trees visible from the main tree - left
                if (treePlantation[y][floatX] >= treeHeight) {
                    treeHeight = treePlantation[y][floatX];
                    leftScore++;
                }
                floatX--;
            }

            treeHeight = 0;

            floatY = y+1;
            while (floatY < treePlantation.Length && treeHeight <= treePlantation[y][x]) {    // count trees visible from the main tree - bottom
                if (treePlantation[floatY][x] >= treeHeight) {
                    treeHeight = treePlantation[floatY][x];
                    bottomScore++;
                }
                floatY++;
            }

            treeHeight = 0;

            floatY = y-1;
            while (floatY >= 0 && treeHeight <= treePlantation[y][x]) {    // count trees visible from the main tree - top
                if (treePlantation[floatY][x] >= treeHeight) {
                    treeHeight = treePlantation[floatY][x];
                    topScore++;
                }
                floatY--;
            } */ 

            return rightScore;
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

            // highestScenicScore = getScenicScore(treePlantation, 1, 2);
            
            for (int y = 1; y < key.Length-1; y++) {
                for (int x = 1; x <key[y].Length-1; x++) {
                    Console.Write(key[y][x] + " [" + getScenicScore(treePlantation, x, y) + "] ");
                    int scenicScore = getScenicScore(treePlantation, x, y);
                    highestScenicScore = (scenicScore > highestScenicScore) ? scenicScore : highestScenicScore;
                }
                Console.WriteLine(" ");
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
