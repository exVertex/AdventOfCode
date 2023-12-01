using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace AdventOfCode.Y2023.Solutions {
    public class Day01 : Day {
        protected override int getPartOne(dynamic key) {

            var calibrationValues = new List<int> {};

            foreach (var line in key ) {
                string digits = "";
                foreach(var character in line) {
                    bool isDigit = int.TryParse(character + "", out int n);
                    if(isDigit) {
                        digits += character;
                    }
                }
                calibrationValues.Add(int.Parse(digits[0] + "" + digits[digits.Length -1]));
            };

           return(calibrationValues.Sum(x => x));
        }

        protected override int getPartTwo(dynamic key) {

            var calibrationValues = new List<int> {};

            for (int i = 0; i <key.Length; i++) {
                key[i] = key[i].Replace("one", "o1e");
                key[i] = key[i].Replace("two", "t2o");
                key[i] = key[i].Replace("three", "t3e");
                key[i] = key[i].Replace("four", "f4r");
                key[i] = key[i].Replace("five", "f5e");
                key[i] = key[i].Replace("six", "s6x");
                key[i] = key[i].Replace("seven", "s7n");
                key[i] = key[i].Replace("eight", "e8t");
                key[i] = key[i].Replace("nine", "n9e");
                key[i] = key[i].Replace("zero", "z0o");
            }

            foreach (var line in key ) {
                string digits = "";
                foreach(var character in line) {
                    bool isDigit = int.TryParse(character + "", out int n);
                    if(isDigit) {
                        digits += character;
                    }
                }
                calibrationValues.Add(int.Parse(digits[0] + "" + digits[digits.Length -1]));
            };

           return(calibrationValues.Sum(x => x));
        }

        public Day01() {
            day = 1;
            year = 2023;
            title = "";
        }
    }
}
