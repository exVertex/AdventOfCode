using System;

namespace AdventOfCode.Core {
    public abstract class Day {
        public int day {get; protected set; }
        public int year {get; protected set; }
        protected string title {get; set; }

        protected abstract string solvePartOne();
        protected abstract string solvePartTwo();
        
        public void getResults() {
            Console.WriteLine( "--- Day " + this.day + ": " + this.title + " ---");
            Console.WriteLine("Part 1: " + solvePartOne());
            Console.WriteLine("Part 2: " + solvePartTwo());
        }
    }
}
