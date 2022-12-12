using System;

namespace AdventOfCode.Core {
    public abstract class Day {
        public int day {get; protected set; }
        public int year {get; protected set; }
        protected string title {get; set; }

        protected abstract dynamic prepareInput();
        protected abstract string solvePartOne(dynamic puzzleInput);
        protected abstract string solvePartTwo(dynamic puzzleInput);
        
        public void getResults() {
            var puzzleInput = prepareInput();
            Console.WriteLine( "--- Day " + this.day + ": " + this.title + " ---");
            Console.WriteLine("Part 1: " + solvePartOne(puzzleInput));
            Console.WriteLine("Part 2: " + solvePartTwo(puzzleInput));
        }
    }
}
