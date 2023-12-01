using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;
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
                if (digits.Length > 0) {
                    calibrationValues.Add(int.Parse(digits[0] + "" + digits[digits.Length -1]));
                }
            };

           return(calibrationValues.Sum(x => x));
        }

        protected override int getPartTwo(dynamic key) {

            var calibrationValues = new List<int> {};

            for (int i = 0; i <key.Length; i++) {
                if (key[i].Contains("eightwo")) {
                    key[i] = key[i].Replace("eightwo", "82");
                }
                if (key[i].Contains("eighthree")) {
                    key[i] = key[i].Replace("eightree", "83");
                }
                if (key[i].Contains("oneight")) {
                    key[i] = key[i].Replace("oneight", "18");
                }
                if (key[i].Contains("twone")) {
                    key[i] = key[i].Replace("twone", "21");
                }
                if (key[i].Contains("twone")) {
                    key[i] = key[i].Replace("twone", "21");
                }
                if (key[i].Contains("threeight")) {
                    key[i] = key[i].Replace("threeight", "38");
                }
                if (key[i].Contains("fiveight")) {
                    key[i] = key[i].Replace("fiveight", "58");
                }
                if (key[i].Contains("sevenine")) {
                    key[i] = key[i].Replace("sevenine", "79");
                }
                if (key[i].Contains("eighthree")) {
                    key[i] = key[i].Replace("eightree", "83");
                }
                if (key[i].Contains("nineight")) {
                    key[i] = key[i].Replace("nineight", "98");
                }
                if (key[i].Contains("zerone")) {
                    key[i] = key[i].Replace("zerone", "01");
                }
                if (key[i].Contains("one")) {
                    key[i] = key[i].Replace("one", "1");
                }
                if (key[i].Contains("two")) {
                    key[i] = key[i].Replace("two", "2");
                }
                if (key[i].Contains("three")) {
                    key[i] = key[i].Replace("three", "3");
                }
                if (key[i].Contains("four")) {
                    key[i] = key[i].Replace("four", "4");
                }
                if (key[i].Contains("five")) {
                    key[i] = key[i].Replace("five", "5");
                }
                if (key[i].Contains("six")) {
                    key[i] = key[i].Replace("six", "6");
                }
                if (key[i].Contains("seven")) {
                    key[i] = key[i].Replace("seven", "7");
                }
                if (key[i].Contains("eight")) {
                    key[i] = key[i].Replace("eight", "8");
                }
                if (key[i].Contains("nine")) {
                    key[i] = key[i].Replace("nine", "9");
                }
                if (key[i].Contains("zero")) {
                    key[i] = key[i].Replace("zero", "0");
                }

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