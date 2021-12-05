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
            var inputs = File.ReadAllLines("C:/Users/Woute/Documents/GitHub/AdventOfCode/AdventOfCode/Day4/input.txt")
                .ToList();
            var board = File.ReadAllLines("C:/Users/Woute/Documents/GitHub/AdventOfCode/AdventOfCode/Day4/boards.txt")
                .ToList();

            Console.WriteLine(board[0]);
        }


        static void part1(List<string> inputs, List<string> board)
        {
            foreach (var input in inputs)
            {
                
            }
        }
    }
}