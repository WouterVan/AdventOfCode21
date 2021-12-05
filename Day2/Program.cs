using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        enum Movement
        {
            forward = 0,
            up,
            down
        }

        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("C:/Users/Woute/Documents/GitHub/AdventOfCode/AdventOfCode/Day2/input.txt")
                .ToList();

            part1(inputs);
            part2(inputs);
        }

        static void part1(List<string> inputs)
        {
            var depth = 0;
            var forward = 0;

            foreach (var input in inputs)
            {
                var instructions = input.Split(' ');
                var direction = (Movement) Enum.Parse(typeof(Movement), instructions[0].ToString());
                switch (direction)
                {
                    case Movement.down:
                        depth += Convert.ToInt32(instructions[1]);
                        break;
                    case Movement.forward:
                        forward += Convert.ToInt32(instructions[1]);
                        break;
                    case Movement.up:
                        depth -= Convert.ToInt32(instructions[1]);
                        break;
                }
            }

            Console.WriteLine("depth : " + depth);
            Console.WriteLine("forward : " + forward);
            Console.WriteLine("sum: " + forward*depth);
        }

        static void part2(List<string> inputs)
        {
            var depth = 0;
            var forward = 0;
            var aim = 0;

            foreach (var input in inputs)
            {
                var instructions = input.Split(' ');
                var direction = (Movement) Enum.Parse(typeof(Movement), instructions[0].ToString());
                switch (direction)
                {
                    case Movement.down:
                        aim += Convert.ToInt32(instructions[1]);
                        break;
                    case Movement.forward:
                        forward += Convert.ToInt32(instructions[1]);
                        depth += aim * Convert.ToInt32(instructions[1]);
                        break;
                    case Movement.up:
                        aim -= Convert.ToInt32(instructions[1]);
                        break;
                }
            }

            Console.WriteLine("depth : " + depth);
            Console.WriteLine("forward : " + forward);
            Console.WriteLine("aim: " + aim);
            Console.WriteLine("sum: " + forward*depth);
        }
    }
}