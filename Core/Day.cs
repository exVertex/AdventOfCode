using System;

namespace AdventOfCode.Core {
    public abstract class Day {
        public int day {get; protected set; }
        public int year {get; protected set; }
        protected string title {get; set; }

        protected abstract dynamic preparePuzzleInput();
        protected abstract dynamic solveMain(dynamic puzzleInput);
        protected abstract string getPartOne(dynamic blob);
        protected abstract string getPartTwo(dynamic blob);
        
        public void getResults() {
            var blob = solveMain(preparePuzzleInput());
            Console.WriteLine( "--- Day " + this.day + ": " + this.title + " ---");
            Console.WriteLine("Part 1: " + getPartOne(blob));
            Console.WriteLine("Part 2: " + getPartTwo(blob));
        }
    }
}
