using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode.Core {
    class Utils {
        
        /// <summary> Opens a text file, reads all lines of the file, stores each line in a string and then closes the file. </summary>
        /// <param name="pathToInput"> Represents path to the file location. </param>
        /// <returns> An array of strings containing all lines of the file. </returns>
        internal static string[] getInput(string pathToInput) {
            if (!File.Exists(pathToInput)) {
                Console.WriteLine("Uh oh! File that contains puzzle input for desired solution is missing.");
                Environment.Exit(0);
            }
            if (new FileInfo( pathToInput ).Length == 0 ) {
                Console.WriteLine("Uh oh! File that contains puzzle input is empty.");
                Environment.Exit(0);
            }
            return File.ReadAllLines(pathToInput);
        }

        /// <summary> Converts an array of strings to an array of integers. </summary>
        /// <param name="stringArray"> An array of strings. </param>
        /// <returns> An array of the integers containing the converted elements from the string array. </returns>
        internal static int[] convertToIntArray(String[] stringArray) => Array.ConvertAll(stringArray, element => int.Parse(element));

        /// <summary> Converts an array of characters to an array of integers. </summary>
        /// <param name="stringArray"> An array of characteres. </param>
        /// <returns> An array of the integers containing the converted elements from the char array. </returns>
        internal static int[] convertToIntArray(char[] charArray) => Array.ConvertAll(charArray, element => (int)Char.GetNumericValue(element));

        public static int[] parsePuzzleInputToIntegerArray(String pathToInput) {
            var storage = File.ReadAllLines(pathToInput);
            int[] array = new int[storage.Count()];
            
            for (int i = 0; i < array.Length; i++) {
                array[i] = int.Parse(storage[i]);
            }
            return array;
        }

        public static int[] sliceLineToIntegerArray(String pathToInput) {
            var storage = File.ReadAllLines(pathToInput);
        
            return convertToIntArray(storage[0].Split(','));
        }
        public static string[] parsePuzzleInputToStringArray(String pathToInput) {
            var storage = File.ReadAllLines(pathToInput);
            string[] array = new string[storage.Count()];

            for (int i = 0; i < array.Length; i++) {
                array[i] = storage[i];
            }
            return array;
        }
        public static List<int> parsePuzzleInputToIntegerList(String pathToInput) {
            List<int> list = new List<int>();
            
            foreach(String line in File.ReadLines(pathToInput)) {
                list.Add(int.Parse(line));
            }
            return list;
        }
        public static List<string[]> parsePuzzleInputToArrayStringList(String pathToInput) {
            List<string[]> list = new List<string[]>();
            
            foreach (String line in System.IO.File.ReadLines(pathToInput)) {
                list.Add(line.Split(' '));
            }
            return list;
        }
        public static String invertBinaryNumber(String number) {
            return(number.Replace('0', 's').Replace('1', '0').Replace('s', '1'));
        }
    }
}
