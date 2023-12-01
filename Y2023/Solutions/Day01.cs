using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Solutions {
    public class Day01 : Day {
        private static string ConvertWordToDigit(string text) {
            switch(text) {
                case "one": { return "1"; };
                case "two": { return "2"; };
                case "three": { return "3"; };
                case "four": { return "4"; };
                case "five": { return "5"; };
                case "six": { return "6"; };
                case "seven": { return "7"; };
                case "eight": { return "8"; };
                case "nine": { return "9"; };
                default: { return text; };
            };
        }
        protected override int GetPartOne(dynamic key) {
            var calibrationValues = new List<string> {};   // create an empty list of integers, where correct calibration values will be stored

            foreach(string line in key) {
                var first = Regex.Match(line, @"\d").ToString();   // find first digit
                var last = Regex.Match(line, @"\d", RegexOptions.RightToLeft).ToString();  // find last digit in sequence

                if (first.Length > 0) calibrationValues.Add(first + last);   // join digits to form calibration value and add it to the list
            }
            
           return calibrationValues.Sum(x => int.Parse(x));   // return the sum of calibration values
        }
        protected override int GetPartTwo(dynamic key) {
            var calibrationValues = new List<string> {};    // create an empty list of integers, where correct calibration values will be stored
            
            foreach(string line in key) {
                var pattern =  @"(\d|one|two|three|four|five|six|seven|eight|nine)";    // RegEx: find digit or any of the number words 
                var first = Regex.Match(line, pattern).ToString();   // find first occurrence of number, text or digit
                var last = Regex.Match(line, pattern, RegexOptions.RightToLeft).ToString();  // find last occurrence of number, text or digit

                if (first.Length > 1) first = ConvertWordToDigit(first);    // if found number is in text form, convert it to a digit
                if (last.Length > 1) last = ConvertWordToDigit(last);   // if found number is in text form, convert it to a digit

                if (first.Length > 0) calibrationValues.Add(first + last);   // join digits to form calibration value and add it to the list
            }

           return calibrationValues.Sum(x => int.Parse(x));    // return the sum of calibration values
        }

        public Day01() {
            day = 1;
            year = 2023;
            title = "Trebuchet?!";
        }
    }
}
