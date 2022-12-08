using System;
using System.Collections.Generic;


namespace AdventOfCode2021 {
    class Day02 {
        private static int depth, horizontalPosition, aim;

        static void move(String where, int howMuch, bool secondPart = false) {
            switch(where) {
                case "down":
                    if (secondPart) {
                        aim += howMuch;
                    } else {
                        depth += howMuch;
                    }
                    break;
                case "up":
                    if (secondPart) {
                        aim -= howMuch;
                    } else {
                        depth -= howMuch;
                    }
                    break;
                case "forward":
                    if (secondPart) {
                        depth += aim*howMuch;
                    }
                    horizontalPosition += howMuch;
                    break;
            }
        }
        public static int calculatePosition(List<string[]> input, bool secondPart = false) {
            depth = horizontalPosition = aim = 0;

            foreach(string[] entry in input) {
                move(entry[0], int.Parse(entry[1]), true);
            }
            return depth*horizontalPosition;
        }

        public static void getDay02Results() {
            /* 
            List<string[]> puzzleInput = Helpers.parsePuzzleInputToArrayStringList("./puzzleInputs/day02.txt");
            Console.WriteLine(Day02.calculatePosition(input, true));
            
            List<string[]> input = Helpers.parsePuzzleInputToArrayStringList("./puzzleInputs/testInput.txt");
            String gammaRate = Day03.getepsilonRate(input); */ 
            //String epsilonRate = Day03.getEpsilonRate(gammaRate);
            //int powerConsumption = Day03.getPowerConsumption(gammaRate, epsilonRate);
            //Console.WriteLine(Day03.getLifeSupportRatting(input));
            /* 
            int[] sean = Helpers.parsePuzzleInputToIntegerArray("./puzzleInputs/testInput.txt");
            foreach(int baby in sean) {
                Console.WriteLine(baby);
            } */    
        }
    }
}