using System;

namespace AdventOfCode.Core {
    public abstract class Day {
        public int day {get; protected set; }
        public int year {get; protected set; }
        protected string title {get; set; }
        
        protected abstract dynamic solveMain(dynamic puzzleInput);
        protected abstract int getPartOne(dynamic key);
        protected abstract int getPartTwo(dynamic key);

        protected dynamic preparePuzzleInput(string pathToInput) => Utils.getInput(pathToInput);
        
        public void getResults() {
            var key = solveMain(preparePuzzleInput(string.Format("./Y{0}/PuzzleInputs/day{1}.txt", this.year, this.day.ToString("00"))));
            Console.WriteLine( "--- Day " + this.day + ": " + this.title + " ---");
            Console.WriteLine("Part 1: " + getPartOne(key));
            Console.WriteLine("Part 2: " + getPartTwo(key));
        }
    }
}
