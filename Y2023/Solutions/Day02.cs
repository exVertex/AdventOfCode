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
                var cubes = Regex.Matches(line, @"\d+\s(red|green|blue)");

                GameRounds.Add(new() {
                    Id = int.Parse(line.Replace(":", "").Split(" ")[1]),
                    RedMaxCubes = cubes.Select(cubes => cubes.ToString().Split(" ")).Where(cubes => cubes[1] == "red").Select(cubes => int.Parse(cubes[0])).Max(),
                    GreenMaxCubes = cubes.Select(cubes => cubes.ToString().Split(" ")).Where(cubes => cubes[1] == "green").Select(cubes => int.Parse(cubes[0])).Max(),
                    BlueMaxCubes = cubes.Select(cubes => cubes.ToString().Split(" ")).Where(cubes => cubes[1] == "blue").Select(cubes => int.Parse(cubes[0])).Max()
                });
            }
            

            return GameRounds;
        }
        protected override int GetPartOne(dynamic key ) {

            List<Game> gameRounds = key;

            return gameRounds.Where(game => game.RedMaxCubes <= RedCubes && game.GreenMaxCubes <= GreenCubes && game.BlueMaxCubes <= BlueCubes).Sum(game => game.Id);
        }

        protected override int GetPartTwo(dynamic key) {
            List<Game> gameRounds = key;
            return gameRounds.Sum(game => game.RedMaxCubes * game.GreenMaxCubes * game.BlueMaxCubes);
        }

        public Day02() {
            day = 2;
            year = 2023;
            title = "Cube Conundrum";
        }
    }
}