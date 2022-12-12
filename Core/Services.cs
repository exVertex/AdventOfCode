using System.Collections.Generic;
using System;

namespace AdventOfCode.Core
{
    public class Services{
        internal static List<Day> createDaysSolutions() => new List<Day> { 
            new Y2022.Solutions.Day01()
            };

        internal static void printInstructions() {
            Console.WriteLine("The command argument is not recognised.\n~~~~~~~~~~~~~~~");
            Console.WriteLine("Please enter date of desired solution in the following format YYYY DD.");
            Console.WriteLine("...or run the program without arguments to get the latest solution.");
        }
    }
}
