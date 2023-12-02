using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode.Y2023.Solutions {
    public class Day02 : Day {
        protected const int RedCubes = 12;
        protected const int GreenCubes = 13;
        protected const int BlueCubes = 14;

        private class Game {
            public int Id { get; set; }
            public int RedMaxCubes { get; set; }
            public int GreenMaxCubes { get; set; }
            public int BlueMaxCubes { get; set; }
        }

        protected override dynamic PrepareCommon(string[] puzzleInput) {
            var GameRounds = new List<Game> {};

            foreach (var line in puzzleInput) {
                var pattern = @"\d+\s(red|green|blue)"; // Match any digit followed by words red, green or blue
                var cubes = Regex.Matches(line, pattern);   // get array of matches that contain number of cubes and its color

                GameRounds.Add(new() {
                    Id = int.Parse(line.Replace(":", "").Split(" ")[1]),    // set game id
                    RedMaxCubes = cubes.Select(cubes => cubes.ToString().Split(" "))    // split search result by spaces
                        .Where(cubes => cubes[1] == "red")  // filter those that contain red
                        .Select(cubes => int.Parse(cubes[0])).Max(),    // from all red cubes, get the highest occurrence
                    GreenMaxCubes = cubes.Select(cubes => cubes.ToString().Split(" ")) // split search result by spaces ex.["8", "green"]
                        .Where(cubes => cubes[1] == "green")    // filter those that contain green
                        .Select(cubes => int.Parse(cubes[0])).Max(),    // from all green cubes, get the highest occurrence
                    BlueMaxCubes = cubes.Select(cubes => cubes.ToString().Split(" "))    // split search result by spaces ex.["8", "green"]
                        .Where(cubes => cubes[1] == "blue") // filter those that contain blue
                        .Select(cubes => int.Parse(cubes[0])).Max() // from all ble cubes, get the highest occurrence
                });
            }
            return GameRounds;
        }
        protected override int GetPartOne(dynamic key ) {
            List<Game> gameRounds = key;
            return gameRounds.Where(game => game.RedMaxCubes <= RedCubes && game.GreenMaxCubes <= GreenCubes && game.BlueMaxCubes <= BlueCubes)
                .Sum(game => game.Id);  // return sum of game ids
        }
        protected override int GetPartTwo(dynamic key) {
            List<Game> gameRounds = key;
            return gameRounds.Sum(game => game.RedMaxCubes * game.GreenMaxCubes * game.BlueMaxCubes);   // retun sum of the power of minimal requirement sets
        }
        public Day02() {
            day = 2;
            year = 2023;
            title = "Cube Conundrum";
        }
    }
}