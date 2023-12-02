using AdventOfCode.Core;
using System;

namespace AdventOfCode.Y2021.Solutions {
    class Day01 : Day {
        protected override dynamic PrepareCommon(string[] puzzleInput)  => Utils.convertToIntArray(puzzleInput);
        protected override int GetPartOne(dynamic key) {
            int increases = 0;  // check for storing times the value increased

            for (int i = 1; i < key.Length; i++) {
                increases += (key[i] > key[i-1]) ? 1 : 0;   // add 1 to increases if current value is bigger than previous value
            }
            return increases;
        }

        protected override int GetPartTwo(dynamic key) {
            int increases = 0;  // check for storing times the value increased

            for (int i = 2; i < key.Length - 1; i++) {
                int firstWindow = key[i] + key[i - 1] + key[i - 2]; // store the sum of measurments in the first window
                int secondWindow = key[i + 1] + key[i] + key[i - 1];    // store the sum measurements in the second window

                increases += (secondWindow > firstWindow) ? 1 : 0;  // add 1 to increases if sum of second window is bigger than the sum of first window 
            }
            return increases;
        }
        public Day01() {
            day = 1;
            year = 2021;
            title = "Sonar Sweep";
        }
    }  
}   
