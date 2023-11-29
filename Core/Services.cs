using System;
using System.Collections.Generic;

namespace AdventOfCode.Core {
    public class Services{
        internal static List<Day> createDaysSolutions() => new List<Day> { 
            new Y2022.Solutions.Day01(),
            new Y2022.Solutions.Day02(),
            new Y2022.Solutions.Day03(),
            new Y2022.Solutions.Day04(),
            new Y2022.Solutions.Day05(),
            new Y2022.Solutions.Day06(),
            new Y2022.Solutions.Day07(),
            new Y2022.Solutions.Day08(),
            new Y2022.Solutions.Day09(),
            new Y2022.Solutions.Day10(),
            new Y2022.Solutions.Day11(),
            new Y2022.Solutions.Day12(),
            new Y2023.Solutions.Day01()
            };

        internal static void printInstructions() {
            Console.WriteLine("The command argument is not recognised.\n~~~~~~~~~~~~~~~");
            Console.WriteLine("Please enter date of desired solution in the following format YYYY DD.");
            Console.WriteLine("...or run the program without arguments to get the latest solution.");
        }
    }
}
