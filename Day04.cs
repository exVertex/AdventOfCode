using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021 {
    class BingoBoard {
        ///<value> 2D array represended in list of dictionaries stored in an Array.
        ///Each dictionary contains key (number in the board) and value (whether it has been crossed off or not). </value>
        private Dictionary<int, bool>[] board = new Dictionary<int, bool>[5];
        ///<value> Marked true if the scored a bingo. </value>
        protected bool alreadyWon = false;
        ///<value> Returns the value of <see cref="alreadyWon"/>. </value>
        public bool didBoardWin() { return alreadyWon; }
        ///<value> Set the value of <see cref="alreadyWon"/> to true. </value>
        public void itWon() { alreadyWon = true; }
        /// <summary> If <see cref="drawnNumber"/> is on the board, it will cross it off (set dict value to true). </summary>
        /// <param name="drawnNumber"> Numbers in the order of how they were drawn. </param>
        public void crossNumber(int drawnNumber) {
            foreach(Dictionary<int, bool> boardLine in board) {
                if (boardLine.ContainsKey(drawnNumber)) {
                    boardLine[drawnNumber] = true;
                    break;
                }
            }
        }
        /// <summary> Checks if there is bingo combination present on <see cref="board"/> horizontally or vertically. </summary>
        /// <param name="bingoNumbers"> Numbers in the order of how they were drawn. </param>
        /// <returns> List of the winning bingo values. In case of no winning combination, it returns an empty list. </returns>
        public List<int> checkForBingo() {
            List<int> matchX = new List<int>();
            List<int> matchY = new List<int>();
            
            for(int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Count; j++) {
                    KeyValuePair<int, bool> numberRow = board[i].ElementAt(j); // Row values
                    KeyValuePair<int, bool> numberColumn = board[j].ElementAt(i); // Column values
                    if(numberRow.Value) {
                        matchX.Add(numberRow.Key);
                        if(matchX.Count == 5) {
                            return matchX;
                        }
                    }
                    if(numberColumn.Value) {
                        matchY.Add(numberColumn.Key);
                            if(matchY.Count == 5) {
                            return matchY;
                        }
                    }
                }
                matchX.Clear();
                matchY.Clear();   
            }
            return matchX;
        }
        /// <summary> Prints 2D representation of the <see cref="board"/>. </summary>
        public void printTheBoard() {
            foreach(Dictionary<int, bool> boardline in board) {
                foreach(KeyValuePair<int, bool> number in boardline){
                    if(number.Value) {
                        Console.Write("x ");
                    } else {
                        Console.Write(number.Key  + " ");
                    }
                }
                Console.WriteLine();  
            }
        }
        /// <summary> Iterates through the <see cref="board"/> and looks for numbers whose values are set to false. </summary>
        /// <returns> Sum of all unmarked board Numbers. </returns>
        public int getSumOfUnmarkedNumbers() {
            int sum = 0;
            foreach(Dictionary<int, bool> boardline in board) {
                foreach(KeyValuePair<int, bool> number in boardline){
                    if(!number.Value) {
                        sum += number.Key;
                    }
                }
            }
            return sum;
        }
        /// <summary> 2D array created from an array of dictionaries. </summary>
        public BingoBoard(Dictionary<int, bool>[] board) {
            this.board = board;
        }
    }
    class Day04 {
            /// <summary> Packs the puzzleInput into <see cref="BingoBoard"/>. </summary>
            /// <returns> List of <see cref="BingoBoard"/>. </returns>
        private static List<BingoBoard> setupBingoBoards(string pathToInput) {
            List<BingoBoard> bingoBoards = new List<BingoBoard>();
            var storage = File.ReadAllLines(pathToInput);
            int i = 2;

            while (i < storage.Length-1) {
                Dictionary<int, bool>[] board = new Dictionary<int, bool>[5]; // Creates an empty bingo board 
                for(int s = 0; s < board.Length; s++) {
                    board[s] = new Dictionary<int, bool>(); // Creates an empty line

                    string line = storage[i].Replace("  ", " "); // Parses input
                    if (line[0] == ' ') {
                        line = line.Remove(0, 1);
                    }
                    string[] storedLine = line.Split(' ');
                    foreach(string number in storedLine) {
                        board[s].Add(int.Parse(number), false); // Add keys (bingo numbers) and values (if marked) to the board
                    }  
                    i++; 
                }
                bingoBoards.Add(new BingoBoard(board));
                i++;
            }
            return bingoBoards;
        }
        /// <summary> Takes drawn bingoNumber, iterates through all BingoBoards,
        /// checks if drawn bingoNumber is on the board and marks it accordingly. </summary>
        /// <param name="bingoNumbers"> Numbers in the order of how they were drawn. </param>
        /// <param name="boards"> List of BingoBoards. </param>
        /// <param name="firstPart"> When set to false it find the last winning board and produce sum based on it. </param>
        /// <returns> Sum of left-over unmarked numbers on the winning bingoBoard and last drawn number. </returns>
        private static int getSumMultipliedByWinningNumber(int[] bingoNumbers, List<BingoBoard> boards, bool firstPart = true) {
            int numberOfBoardsThatWon = 0;

            foreach(int number in bingoNumbers) {
                foreach(BingoBoard board in boards) {
                    if(firstPart || !board.didBoardWin()) { // If firstPart set to false, it will look for last winning board
                        board.crossNumber(number);
                        List<int> bingo = board.checkForBingo();
                        if (bingo.Count == 5) {
                            if(firstPart) {
                                return board.getSumOfUnmarkedNumbers() * number;
                            } else {
                                board.itWon();
                                numberOfBoardsThatWon++;
                            }
                        };
                        if(!firstPart && numberOfBoardsThatWon == boards.Count) {
                            return board.getSumOfUnmarkedNumbers() * number;
                        }
                    }
                }
            }
            return 0;
        }
        public static void getDay04Results() {
            var bingoNumbers = Helpers.sliceLineToIntegerArray("./puzzleInputs/day04.txt");
            var boards = setupBingoBoards("./puzzleInputs/day04.txt");           

            Console.WriteLine("~~~~~~~~~~~~~ Day 4 ~~~~~~~~~~~~~");
            Console.WriteLine("Part 1: " + getSumMultipliedByWinningNumber(bingoNumbers, boards));
            Console.WriteLine("Part 1: " + getSumMultipliedByWinningNumber(bingoNumbers, boards, false));

        }
    }
}