using System;
namespace AdventOfCode2021 {
    class Day08 {


        public static void getDay08Results() {
            var puzzleInput = Helpers.parsePuzzleInputToArrayStringList("./puzzleInputs/testInput.txt");

            int numb = 0;

            foreach (var line in puzzleInput) {
                for (int i = 0; i < line.Length; i++) {
                    Console.WriteLine(line[i].Length);
                    Console.ReadKey();
                    if(line[i].Length == 2 || line[i].Length == 4 || line[i].Length == 7 || line[i].Length == 3) {
                        numb++;
                    }
                }
            }
            Console.WriteLine(numb);
        }
    }
}