using System;

namespace AdventOfCode.Core
{
    public abstract class Day
    {
        int year;
        int day;
        string title;

        public void getResults() {
            Console.WriteLine("I am a result.");
        }

        public Day() {
        }
    }
}