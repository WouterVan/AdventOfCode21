using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs =
                File.ReadAllLines("C:/Users/Woute/Documents/GitHub/AdventOfCode/AdventOfCode21/Day4/input.txt")[0]
                    .ToString().Split(",");

            var board = File.ReadAllLines("C:/Users/Woute/Documents/GitHub/AdventOfCode/AdventOfCode21/Day4/boards.txt")
                .ToList();

            var allBoards = GenerateCells(board);
            var boards = GenerateBoard(board);
            var result1 = part1(inputs.ToList(), allBoards);
            if (result1 != 0)
            {
                Console.WriteLine("Bingo!");
                Console.WriteLine(result1);
            }

            var result2 = par2(inputs.ToList(), boards);
            if (result2 != 0)
            {
                Console.WriteLine("You where the worst loser");
                Console.WriteLine(result2);
            }
        }

        static int part1(List<string> inputs, List<Cell[,]> boards)
        {
            foreach (var input in inputs)
            {
                foreach (var board in boards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (board[i, j].Number == input)
                            {
                                board[i, j].HasOccured = true;
                            }

                            if (CheckBingo(board))
                            {
                                var numbersToMultiply = new List<string>();
                                for (int k = 0; k < 5; k++)
                                {
                                    for (int l = 0; l < 5; l++)
                                    {
                                        if (!board[k, l].HasOccured)
                                        {
                                            numbersToMultiply.Add(board[k, l].Number);
                                        }
                                    }
                                }

                                int value = 0;
                                foreach (var number in numbersToMultiply)
                                {
                                    value += Convert.ToInt32(number);
                                }

                                return value * Convert.ToInt32(board[i, j].Number);
                            }
                        }
                    }
                }
            }

            return 0;
        }

        static int par2(List<string> inputs, List<Board> boards)
        {
            foreach (var input in inputs)
            {
                foreach (var board in boards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (board.Cells[i, j].Number == input)
                            {
                                board.Cells[i, j].HasOccured = true;
                            }

                            if (CheckBingo(board.Cells))
                            {
                                board.HasWon = true;
                                if (boards.Count(x => x.HasWon == true) == boards.Count)
                                {
                                    var lastBoard = board;
                                    var numbersToMultiply = new List<string>();
                                    for (int k = 0; k < 5; k++)
                                    {
                                        for (int l = 0; l < 5; l++)
                                        {
                                            if (!lastBoard.Cells[k, l].HasOccured)
                                            {
                                                numbersToMultiply.Add(lastBoard.Cells[k, l].Number);
                                            }
                                        }
                                    }

                                    int value = 0;
                                    foreach (var number in numbersToMultiply)
                                    {
                                        value += Convert.ToInt32(number);
                                    }

                                    return value * Convert.ToInt32(board.Cells[i, j].Number);
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        static bool CheckBingo(Cell[,] board)
        {
            var count = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j].HasOccured)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                }

                if (count == 5)
                {
                    return true;
                }

                count = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[j, i].HasOccured)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                }

                if (count == 5)
                {
                    return true;
                }

                count = 0;
            }

            return false;
        }

        static List<Cell[,]> GenerateCells(List<string> inputs)
        {
            var cells = new List<Cell[,]>();
            var board = new Cell[5, 5];
            var index = 0;
            foreach (var input in inputs)
            {
                if (input == "")
                {
                    cells.Add(board);
                    board = new Cell[5, 5];
                    continue;
                }

                var row = input.Replace("  ", " ");
                if (row[0] == ' ')
                {
                    row = row.TrimStart();
                }

                var numbers = row.Split(" ");
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine(numbers[j]);
                    board[index, j] = new Cell() {Number = numbers[j], HasOccured = false};
                }

                index++;
                if (input == inputs.Last())
                {
                    cells.Add(board);
                }

                if (index == 5)
                {
                    index = 0;
                }
            }

            return cells;
        }

        static List<Board> GenerateBoard(List<string> inputs)
        {
            var boards = new List<Board>();
            var cells = new List<Cell[,]>();
            var board = new Cell[5, 5];
            var index = 0;
            foreach (var input in inputs)
            {
                if (input == "")
                {
                    boards.Add(new Board()
                    {
                        Cells = board,
                        HasWon = false
                    });
                    board = new Cell[5, 5];
                    continue;
                }

                var row = input.Replace("  ", " ");
                if (row[0] == ' ')
                {
                    row = row.TrimStart();
                }

                var numbers = row.Split(" ");
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine(numbers[j]);
                    board[index, j] = new Cell() {Number = numbers[j], HasOccured = false};
                }

                index++;
                if (input == inputs.Last())
                {
                    boards.Add(new Board()
                    {
                        Cells = board,
                        HasWon = false
                    });
                }

                if (index == 5)
                {
                    index = 0;
                }
            }

            return boards;
        }

        private class Board
        {
            public bool HasWon { get; set; }
            public Cell[,] Cells { get; set; }
        }

        private class Cell
        {
            public string Number { get; set; }
            public bool HasOccured { get; set; }
        }
    }
}