using AdventOfCode.Core;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Y2021.Solutions {

    class Point {
        private int x;
        public int getX() {
            return this.x;
        }
        private int y;
        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
        public override int GetHashCode(){
            return 17 * x + 11 * y;
        }
        public override bool Equals(object obj) {
            return obj is Point && Equals((Point) obj);
        }
        public bool Equals(Point that) {
            return this.x == that.x && y == that.y;
        }
    }

    class Day05 {

        public static void getDay05Results() {
            var puzzleInput = Utils.parsePuzzleInputToStringArray("./puzzleInputs/day05.txt"); 
            HashSet<Point> points = new HashSet<Point>();
            HashSet<int> ints = new HashSet<int>();

            ints.Add(1);
            ints.Add(1);

            Point sean = new Point(17, 11);
            Point petra = new Point(17, 11);

            points.Add(sean);
            points.Add(petra);
            if (sean.Equals(petra)) {
                Console.WriteLine(points.Count);
            }

            Console.WriteLine("~~~~~~~~~~~~~ Day 5 ~~~~~~~~~~~~~");
            Console.WriteLine("Part 1: " + sean);
            Console.WriteLine("Part 2: ");
        }
    }
    class Day05TerribleSolution {
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
                int[] ex = Utils.convertToIntArray(modded[0].Split(','));
                int[] ey = Utils.convertToIntArray(modded[1].Split(','));
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
            var puzzleInput = Utils.parsePuzzleInputToStringArray("./puzzleInputs/day05.txt");
            var diagram = fillTheDiagram(puzzleInput);
            var diagramWithHorizontals = fillTheDiagram(puzzleInput, true);

            Console.WriteLine("~~~~~~~~~~~~~ Day 5 ~~~~~~~~~~~~~");
            Console.WriteLine("Part 1: " + numberOfDangerAreas(diagram));
            Console.WriteLine("Part 2: " + numberOfDangerAreas(diagramWithHorizontals));
        }
    }
}
