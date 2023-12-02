using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AdventOfCode.Y2020.Solutions {
    public class Day01 : Day {
        protected override dynamic PrepareCommon(string[] puzzleInput)  => Utils.convertToIntArray(puzzleInput);
        protected override int GetPartOne(dynamic key) {
            int[] expenses = key;

            foreach(int expense in expenses) {
                int match = 2020 - expense;

                if(expenses.Contains(match)) {
                    return expense * match;
                }
            }
            return 0;
        }
        protected override int GetPartTwo(dynamic key) {
            int[] expenses = key;

            foreach(int expenseOne in expenses) {
                foreach (int expenseTwo in expenses) {
                    int match = 2020 - expenseOne - expenseTwo;
                    
                    if(expenses.Contains(match) && expenseOne != expenseTwo) {
                        return expenseOne * expenseTwo * match;
                    }
                }
            }
            return 0;
            }

        public Day01() {
            day = 1;
            year = 2020;
            title = "Report Repair";
        }
    }
}
