using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021 {
    class Day14 {
        private static int processPolymers(int numberOfRounds, string masterline, Dictionary<string, string> rules) {
            
            for (int i = 0; i < numberOfRounds; i++) {
                int igor = 0;
                while (igor < masterline.Length-1) {
                    var substring = masterline.Substring(igor, 2);
                    var petra = rules[substring];
                    masterline = masterline.Insert(igor+1, petra);
                    igor+= 2;
                }
            }

            int max = masterline.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Count();
            int min = masterline.GroupBy(x => x).OrderByDescending(x => x.Count()).Last().Count();

            return max - min;
        }

        public static void getDay14Results() {
            Dictionary<string, string> rules = new Dictionary<string, string>();

            var storage = File.ReadAllLines("./puzzleInputs/day14.txt");
            string masterLine = storage[0];

            for(int i = 2; i < storage.Length; i++) {
                var line = storage[i].Split(" -> ");
                rules[line[0]] = line[1];
            }

            Console.WriteLine(processPolymers(40, masterLine, rules));
        }
    }
}