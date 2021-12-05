using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("C:/Users/Woute/Documents/GitHub/AdventOfCode/AdventOfCode/Day3/input.txt")
                .ToList();

            part1(inputs);
        }

        static void part1(List<string> inputs)
        {
            var gamma = "";
            var epsilon = "";

            for (var i = 0; i < 12; i++)
            {
                var zero = 0;
                var one = 0;

                foreach (var input in inputs)
                {
                    if (input[i] == '1')
                        one++;
                    else
                        zero++;
                }

                if (one > zero)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            var gammaDecimal = Convert.ToInt32(gamma, 2);
            var epsilonDecimal = Convert.ToInt32(epsilon, 2);

            var answer = gammaDecimal * epsilonDecimal;
            
            Console.WriteLine("part1 answer: ");
            Console.WriteLine(answer);

            part2(inputs, gamma);
        }

        static void part2(List<string> inputs, string gamma)
        {
            var oxygen = Convert.ToInt32(getOxygen(new List<string>(inputs)), 2);
            var co2 = Convert.ToInt32(getCo2(new List<string>(inputs)), 2);

            
            Console.WriteLine("Part2 answer: ");
            Console.WriteLine(oxygen * co2);
        }

        static string getOxygen(List<string> inputs)
        {
            for (var i = 0; i < 12; i++)
            {
                var zero = 0;
                var one = 0;

                foreach (var input in inputs)
                {
                    if (input[i] == '1')
                        one++;
                    else
                        zero++;
                }

                if (inputs.Count <= 1) continue;
                if (one >= zero)
                    inputs.RemoveAll(x => x[i] == '0');

                if (zero > one)
                    inputs.RemoveAll(x => x[i] == '1');
            }

            return inputs[0];
        }
        
        static string getCo2(List<string> inputs)
        {
            for (var i = 0; i < 12; i++)
            {
                var zero = 0;
                var one = 0;

                foreach (var input in inputs)
                {
                    if (input[i] == '1')
                        one++;
                    else
                        zero++;
                }

                if (inputs.Count <= 1) continue;
                if (one >= zero)
                    inputs.RemoveAll(x => x[i] == '1');

                if (zero > one)
                    inputs.RemoveAll(x => x[i] == '0');
            }

            return inputs[0];
        }
    }
}