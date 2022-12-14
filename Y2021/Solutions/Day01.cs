using AdventOfCode.Core;
using System;

namespace AdventOfCode.Y2021.Solutions {
    class Day01 : Day {
        private static int calculcateMeasuermentIncreases(int[] input) {
            int prevNumber = 0;
            int increases = -1;

            foreach (int line in input) { 
                increases += (line > prevNumber) ? 1 : 0;
                prevNumber = line;
            }
            return increases;
        }

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
        protected override dynamic solveMain(string[] puzzleInput) {
            throw new NotImplementedException();
        }

        protected override int getPartOne(dynamic key) {
            throw new NotImplementedException();
        }

        protected override int getPartTwo(dynamic key) {
            throw new NotImplementedException();
        }
    }  
}   
