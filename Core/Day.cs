using System;

namespace AdventOfCode.Core {
    public abstract class Day {
        public int day {get; protected set; }
        public int year {get; protected set; }
        protected string title {get; set; }

        protected abstract dynamic preparePuzzleInput();
        protected abstract dynamic solveMain(dynamic puzzleInput);
        protected abstract int getPartOne(dynamic key);
        protected abstract int getPartTwo(dynamic key);
        
        public void getResults() {
            var key = solveMain(preparePuzzleInput());
            Console.WriteLine( "--- Day " + this.day + ": " + this.title + " ---");
            Console.WriteLine("Part 1: " + getPartOne(key));
            Console.WriteLine("Part 2: " + getPartTwo(key));
        }
    }
}
