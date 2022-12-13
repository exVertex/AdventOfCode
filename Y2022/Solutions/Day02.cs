using System;
using System.Collections.Generic;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day02 : Day {

        protected const int Rock = 1;
        protected const int Paper = 2;
        protected const int Scissors = 3;
        protected const int Win = 6;
        protected const int Draw = 3;
        protected const int Loss = 0; 

        protected int getPickScore(char pick) {
            if (pick == 'X') return Rock;
            else if (pick == 'Y') return Paper;
            else return Scissors;
        }

        protected int getResultScore(char playerOne, char playerTwo) {
            if ((playerOne== 'A' && playerTwo== 'Y') || (playerOne== 'B' && playerTwo== 'Z') || (playerOne== 'C' && playerTwo== 'X')) return Win;
            if ((playerOne== 'A' && playerTwo== 'Z') || (playerOne== 'B' && playerTwo== 'X') || (playerOne== 'C' && playerTwo== 'Y')) return Loss;
            else return Draw;
        }

        protected char setPlayerTwo(char playerOne, char playerTwo) {
            if ((playerTwo == 'X' && playerOne == 'A') || (playerTwo == 'Y' && playerOne == 'C') || (playerTwo == 'Z' && playerOne== 'B')) return 'Z';
            else if ((playerTwo == 'X' && playerOne== 'B') || (playerTwo == 'Y' && playerOne == 'A') || (playerTwo == 'Z' && playerOne == 'C')) return 'X';
            else return 'Y';
        }

        protected int getGameScore(char playerOne, char playerTwo, bool partTwo = false) {
            int roundScore = 0;

            playerTwo = (partTwo) ? setPlayerTwo(playerOne, playerTwo) : playerTwo; // sets playerTwo to correct option in order to get the desired game outcome 
            roundScore += getPickScore(playerTwo);  // add points for pick selection
            roundScore += getResultScore(playerOne, playerTwo); // add points for game result

            return roundScore;
        }

        protected override dynamic solveMain(dynamic puzzleInput) => puzzleInput;   // no main part to solve

        protected override int getPartOne(dynamic key) {
            int score = 0;
            List<string> rounds = new List<string>(key);    // store puzzle input to list of strings

            rounds.ForEach(round => score += getGameScore(round[0], round[2]));    // calculate the sum of all scores 

            return score;
        }

        protected override int getPartTwo(dynamic key) {
            int score = 0;
            List<string> rounds = new List<string>(key);    // store puzzle input to list of strings

            rounds.ForEach(round => score += getGameScore(round[0], round[2], true));    // calculate the sum of all scores 

            return score;
        }

        public Day02() {
            day = 2;
            year = 2022;
            title = "Rock Paper Scissors";
        }
    }
}
