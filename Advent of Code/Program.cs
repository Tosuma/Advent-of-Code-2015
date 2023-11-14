using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main()
        {
            // Make DayFactory
            DayFactory factory = new DayFactory();

            // Day 1 tasks
            Day day1 = factory.MakeDay("Day1");

            day1.SetFilePath("C:/Coding-Git/Advent-of-Code-2015/Advent of Code/Task Files/Day1.txt");
            day1.Task1();
            day1.Task2();

            // Day 2 tasks
            Day day2 = factory.MakeDay("Day2");

            day2.SetFilePath("C:/Coding-Git/Advent-of-Code-2015/Advent of Code/Task Files/Day2.txt");
            day2.Task1();
            day2.Task2();

            // Day 3 tasks
            Day day3 = factory.MakeDay("Day3");

            day3.SetFilePath("C:/Coding-Git/Advent-of-Code-2015/Advent of Code/Task Files/Day3.txt");
            day3.Task1();
            day3.Task2();
        }
    }
}
