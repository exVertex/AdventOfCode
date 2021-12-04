using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021 {
    class Helpers {
        public static int[] parsePuzzleInputToIntegerArray(String pathToInput) {
            var storage = File.ReadAllLines(pathToInput);
            int[] array = new int[storage.Count()];
            
            for (int i = 0; i < array.Length; i++) {
                array[i] = int.Parse(storage[i]);
            }
            return array;
        }
        public static int[] stringToIntArray(String[] stringArray) {
            return Array.ConvertAll(stringArray, element => int.Parse(element));
        }
        public static int[] sliceLineToIntegerArray(String pathToInput) {
            var storage = File.ReadAllLines(pathToInput);
            
            return stringToIntArray(storage[0].Split(','));
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
