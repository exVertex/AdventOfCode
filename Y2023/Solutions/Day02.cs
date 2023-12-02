using System;
using AdventOfCode.Core;

namespace AdventOfCode.Y2023.Solutions {
    public class Day02 : Day {
        protected const int RedCubes = 12;
        protected const int GreenCubes = 13;
        protected const int BlueCubes = 14;
        protected override int GetPartOne(dynamic key) {

            int sum = 0;

            foreach(var line in key) {

                string[] info = line.Replace(";", "").Replace(",", "").Split(" ");
                int[] game = [0, 0];

                game[0] = int.Parse(info[1].Replace(":", ""));  // game id

                for (int i = 3; i < info.Length; i += 2) {

                    if(info[i] == "red") {
                        if(!(int.Parse(info[i - 1]) <= RedCubes)) {
                            goto LoopEnd;
                        }
                    }

                    if(info[i] == "green") {
                        if(!(int.Parse(info[i - 1]) <= GreenCubes)) {
                            goto LoopEnd;
                        }
                    }

                    if(info[i] == "blue") {
                        if(!(int.Parse(info[i - 1]) <= BlueCubes)) {
                            goto LoopEnd;
                        }
                    }
    
                }
                sum += int.Parse(info[1].Replace(":", ""));
                LoopEnd: continue;
            }

            return sum;
        }

        protected override int GetPartTwo(dynamic key) {

            int superSum = 0;
            foreach(var line in key) {

                string[] info = line.Replace(";", "").Replace(",", "").Split(" ");
                int[] game = [0, 0, 0, 0];

                game[0] = int.Parse(info[1].Replace(":", ""));  // game id

                for (int i = 3; i < info.Length; i += 2) {

                    if(info[i] == "red") {
                        if(int.Parse(info[i - 1]) > game[1]) {
                            game[1] = int.Parse(info[i - 1]);
                        }
                    }
                    if(info[i] == "green") {
                        if(int.Parse(info[i - 1]) > game[2]) {
                            game[2] = int.Parse(info[i - 1]);
                        }
                    }
                    if(info[i] == "blue") {
                        if(int.Parse(info[i - 1]) > game[3]) {
                            game[3] = int.Parse(info[i - 1]);
                        }
                    }
                }
                superSum += game[1] * game[2] * game[3];
            }

            return superSum;

        }

        public Day02() {
            day = 2;
            year = 2023;
            title = "";
        }
    }
}