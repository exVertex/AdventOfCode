using System;

namespace AdventOfCode2021 {
    class Day05 {
        /// <summary> Creates a blank diagram. </summary>
        /// <param name="input"> Puzzle input. </param>
        /// <returns> 2D array. </returns>
        private static int[,] createDiagram(string[] input) {
            string decimals = input[0].Split(',')[0];
            int arraySize = int.Parse("1" + ((decimals.Length-1).ToString()));

            return new int[arraySize,arraySize];
        }
        private static int[,] fillTheDiagram(string[] input, bool diagonal = false) {
            int[,] diagram = new int[1000,1000];
            int x1, x2, y1, y2;
            x1 = x2 = y1 = y2 = 0;

            foreach(string line in input) {
                string[] modded = line.Split(" -> ");
                int[] ex = Helpers.stringToIntArray(modded[0].Split(','));
                int[] ey = Helpers.stringToIntArray(modded[1].Split(','));
                x1 = ex[0];
                x2 = ey[0];
                y1 = ex[1];
                y2 = ey[1];

                if(x1 == x2) {
                    int s1, s2; 
                    s2 = ( y2 > y1) ? y2 : y1;
                    s1 = ( y2 < y1) ? y2 : y1;
                    while( s2 >= s1) {
                        diagram[s2, x1] = diagram[s2, x1] + 1; 
                        s2--;
                    }
                }
                if(y1 == y2) {
                    int s1, s2; 
                    s2 = ( x2 > x1) ? x2 : x1;
                    s1 = ( x2 < x1) ? x2 : x1;
                    while( s2 >= s1) {
                        diagram[y1, s2] = diagram[y1, s2] + 1; 
                        s2--;
                    }
                }

                if (diagonal && (Math.Abs(x1 - x2)  == Math.Abs(y1 - y2))) {
                    int ey1, ey2, ex1, ex2;

                    if (x2 > x1) {
                        ex2 = x2;
                        ex1 = x1;
                        ey2 = y2;
                        ey1 = y1;
                    } else {
                        ex2 = x1;
                        ex1 = x2;
                        ey2 = y1;
                        ey1 = y2;
                    }
                    //goes up
                    if (ey1 > ey2) {
                        while (ex1 <= ex2) {
                        diagram[ey1, ex1] = diagram[ey1, ex1] + 1; 
                        ex1++;
                        ey1--;
                        }
                    } else {
                        while (ex1 <= ex2) {
                        diagram[ey1, ex1] = diagram[ey1, ex1] + 1; 
                        ex1++;
                        ey1++;
                        }
                    }
                }
            }
            return diagram;
        }
        /// <summary> Loops through the diagram and checks for values greather than 1. </summary>
        /// <param name="diagram"> Two-dimensional array of marked diagram. </param>
        /// <returns> Number of danger areas. </returns>
        private static int numberOfDangerAreas(int[,] diagram) {
            int howMany = 0;
            for (int i = 0; i < Math.Sqrt(diagram.Length); i++) {   
                for (int j = 0; j < Math.Sqrt(diagram.Length); j++) {
                    howMany += (diagram[i, j] >= 2) ? 1 : 0;           
                }
            }
            return howMany;
        }
        /// <summary> Graphically represent the diagram. </summary>
        /// <param name="diagram"> Two-dimensional array of marked diagram. </param>
        private void printDiagram(int[,] diagram) {
            for (int i = 0; i < Math.Sqrt(diagram.Length); i++) {   
                for (int j = 0; j < Math.Sqrt(diagram.Length); j++) {
                    if (diagram[i, j] == 0) {
                        Console.Write(".");
                    } else {
                        Console.Write(diagram[i, j]);
                    }
                }  
                Console.WriteLine();       
            }
        }
        /// <summary> Calls the Day05 methods in the correct order and prints the result. </summary>
        public static void getDay05Results() {
            var puzzleInput = Helpers.parsePuzzleInputToStringArray("./puzzleInputs/day05.txt");
            var diagram = fillTheDiagram(puzzleInput);
            var diagramWithHorizontals = fillTheDiagram(puzzleInput, true);

            Console.WriteLine("~~~~~~~~~~~~~ Day 5 ~~~~~~~~~~~~~");
            Console.WriteLine("Part 1: " + numberOfDangerAreas(diagram));
            Console.WriteLine("Part 2: " + numberOfDangerAreas(diagramWithHorizontals));
        }
    }
}