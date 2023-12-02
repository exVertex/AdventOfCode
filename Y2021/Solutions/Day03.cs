using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AdventOfCode.Y2021.Solutions {
    public class Day03 : Day {
        private static string GetMoreCommonBit(List<int> bits, bool isInverted = false ) {
            int zero = bits.Where(x => x == 0).Count(); // get amount of times 0 occurs
            int one = bits.Where(x => x == 1).Count();  // get amount of times 1 occurs

            return isInverted ? (zero < one ? "0" : "1") : (zero < one ? "1" : "0");    // return bit that occurs most (ifInverted - occurs least)
        }

        protected override dynamic PrepareCommon(string[] puzzleInput) {
            var bits = new List<List<int>> {new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>()};
            
            foreach (var line in puzzleInput) {
                for (int i = 0; i <bits.Count; i++) {
                    bits[i].Add(int.Parse(line[i].ToString()));
                }
            }
            return bits;
        }
        protected override int GetPartOne(dynamic key ) {
            // get gamma rate by joining most common bits in every position
            var gammaRate = GetMoreCommonBit(key[0]) + GetMoreCommonBit(key[1]) + GetMoreCommonBit(key[2]) + GetMoreCommonBit(key[3]) + GetMoreCommonBit(key[4]);
            var epsilonRate = GetMoreCommonBit(key[0], isInverted: true)  // get epsilon rate by joining least common bits in every position
                                + GetMoreCommonBit(key[1], isInverted: true)
                                + GetMoreCommonBit(key[2], isInverted: true)
                                + GetMoreCommonBit(key[3], isInverted: true)
                                + GetMoreCommonBit(key[4], isInverted: true);

            return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2); // return power consumption
        }
        protected override int GetPartTwo(dynamic key) {

            

            return 2;
        }
        public Day03() {
            day = 3;
            year = 2021;
            title = "Binary Diagnostic";
        }
    }
}

//         private static List<string[]> filterOut(List<string[]> input, int index, bool inverted = false) {
//             List<string[]> filteredList = new List<string[]>();
//             int beat = getMoreCommonBit(input, index, inverted);

//             foreach(String[] entry in input) {
//                 if(int.Parse(entry[0][index].ToString()) == beat) {
//                     filteredList.Add(entry);
//                 }
//             }
//             if(filteredList.Count > 1) {
//                 return (filterOut(filteredList, index + 1, inverted));
//             } else {
//                 return filteredList;
//             }       
//         }
//         public static int getOxygenGneratorRating(List<string[]> input) {
//             return (Convert.ToInt32(filterOut(input, 0)[0][0], 2));
//         }
//         public static int getCO2ScrubberRating(List<string[]> input) {
//             return (Convert.ToInt32(filterOut(input, 0, true)[0][0], 2));
//         }
//         public static int getLifeSupportRating(List<string[]> input) {
//             return getOxygenGneratorRating(input) * getCO2ScrubberRating(input);
//         }
//     }
// }
