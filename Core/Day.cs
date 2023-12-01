using System;
using System.Diagnostics;

namespace AdventOfCode.Core {
    public abstract class Day {
        public int day { get; protected set; }
        public int year { get; protected set; }
        protected string title { get; set; }
        
        protected virtual dynamic prepareCommon(string[] puzzleInput) => puzzleInput;
        protected abstract int getPartOne(dynamic key);
        protected abstract int getPartTwo(dynamic key);

        protected string[] preparePuzzleInput(string pathToInput) => Utils.getInput(pathToInput);
        
        public void getResults() {
            var key = prepareCommon(preparePuzzleInput(string.Format("./Y{0}/PuzzleInputs/day{1}.txt", this.year, this.day.ToString("00"))));

            var watch = new Stopwatch();

            Console.WriteLine( "--- Day " + this.day + ": " + this.title + " ---");
            
            watch.Start();
            var partOne = getPartOne(key);
            watch.Stop();
            Console.WriteLine("Part 1: " + partOne + " (" + watch.ElapsedMilliseconds + " ms)");
            
            watch.Start();
            var partTwo = getPartTwo(key);
            watch.Stop();
            Console.WriteLine("Part 2: " + partTwo + " (" + watch.ElapsedMilliseconds + " ms)");
        }
    }
}
