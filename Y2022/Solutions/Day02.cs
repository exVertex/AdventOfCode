using AdventOfCode.Core;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2022.Solutions {
    public class Day02 : Day {
        protected const int Rock = 1;
        protected const int Paper = 2;
        protected const int Scissors = 3;
        protected const int Win = 6;
        protected const int Draw = 3;
        protected const int Loss = 0; 

        private static int GetPickScore(char pick) {
            if (pick == 'X') return Rock;
            else if (pick == 'Y') return Paper;
            else return Scissors;
        }
        private static int GetResultScore(char playerOne, char playerTwo) {
            if ((playerOne== 'A' && playerTwo== 'Y') || (playerOne== 'B' && playerTwo== 'Z') || (playerOne== 'C' && playerTwo== 'X')) return Win;
            if ((playerOne== 'A' && playerTwo== 'Z') || (playerOne== 'B' && playerTwo== 'X') || (playerOne== 'C' && playerTwo== 'Y')) return Loss;
            else return Draw;
        }
        private static char SetPlayerTwo(char playerOne, char playerTwo) {
            if ((playerTwo == 'X' && playerOne == 'A') || (playerTwo == 'Y' && playerOne == 'C') || (playerTwo == 'Z' && playerOne== 'B')) return 'Z';
            else if ((playerTwo == 'X' && playerOne== 'B') || (playerTwo == 'Y' && playerOne == 'A') || (playerTwo == 'Z' && playerOne == 'C')) return 'X';
            else return 'Y';
        }
        private static int GetGameScore(char playerOne, char playerTwo, bool partTwo = false) {
            playerTwo = partTwo ? SetPlayerTwo(playerOne, playerTwo) : playerTwo; // sets playerTwo to correct option in order to get the desired game outcome 
            return GetPickScore(playerTwo) + GetResultScore(playerOne, playerTwo); // return points for pick selection + points for game result
        }

        protected override int GetPartOne(dynamic key) => new List<string>(key).Sum(round => GetGameScore(round[0], round[2]));   // // calculate the sum of all scores
        protected override int GetPartTwo(dynamic key) => new List<string>(key).Sum(round => GetGameScore(round[0], round[2], true));   // calculate the sum of all scores 
        public Day02() {
            day = 2;
            year = 2022;
            title = "Rock Paper Scissors";
        }
    }
}
