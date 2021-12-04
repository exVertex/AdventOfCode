using System;

namespace AdventOfCode2021 {
    class Day01 {
        /// <summary> Calculates the number of times a depth (puzzle input) measurement increases from the previous measurement. </summary>
        /// <param name="input"> Puzzle input. </param>
        /// <returns> Sum of the increases. </returns>
        private static int calculcateMeasuermentIncreases(int[] input) {
            int prevNumber = 0;
            int increases = -1;

            foreach (int line in input) { 
                increases += (line > prevNumber) ? 1 : 0;
                prevNumber = line;
            }
            return increases;
        }
        /// <summary> Calculates the number of times the sum of measurements in this sliding window increases. </summary>
        /// <param name="input"> Puzzle input. </param>
        /// <returns> Sum of the three-measurements increases. </returns>
        private static int calculcateThreeSumMeasuermentIncreases(int[] input) {
            int increases = -1;
            int sumA, prevSum, i;
            sumA = prevSum = i = 0;
            
            while(i < input.Length-2) {
                sumA = input[i] + input[i+1] + input[i+2];
                increases += (prevSum < sumA) ? 1 : 0;
                prevSum = sumA;
                i++;
            }
            return increases;
        }
        public static void getDay01Results(){
            var puzzleInput = Helpers.parsePuzzleInputToIntegerArray("./puzzleInputs/day01.txt");

            int measurementIncreases = calculcateMeasuermentIncreases(puzzleInput); // Part 1
            int threeSumMeasurementIncreases = calculcateThreeSumMeasuermentIncreases(puzzleInput); // Part 2

            Console.WriteLine("~~~~~~~~~~~~~ Day 1 ~~~~~~~~~~~~~");
            Console.WriteLine("Part 1: " + measurementIncreases);
            Console.WriteLine("Part 2: " + threeSumMeasurementIncreases);                        
        }

    }  
}   