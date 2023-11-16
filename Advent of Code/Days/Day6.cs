using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tasks.Days
{
    public class Day6 : Day
    {
        public override void Task1()
        {
            string[] fileContent = OpenFile();
            bool[,] area = new bool[1000, 1000];
            int numberOfTurnedOn;
            foreach (string s in fileContent)
            {
                var info = ExtractInfo(s);
                for (int i = info.x.start; i <= info.x.end; i++)
                {
                    for (int j = info.y.start; j <= info.y.end; j++)
                    {
                        if (info.command == "toggle") area[i, j] = !area[i, j];
                        else if (info.command == "turn on") area[i, j] = true;
                        else area[i, j] = false;
                    }
                }

            }

            numberOfTurnedOn = CountTurnedOn(area);
            AnnounceResult(1, numberOfTurnedOn);
        }

        public override void Task2()
        {
            string[] fileContent = OpenFile();
            int[,] area = new int[1000, 1000];
            int totalBrightness;
            foreach (string s in fileContent)
            {
                var info = ExtractInfo(s);
                for (int i = info.x.start; i <= info.x.end; i++)
                {
                    for (int j = info.y.start; j <= info.y.end; j++)
                    {
                        if (info.command == "toggle") area[i, j] += 2;
                        else if (info.command == "turn on") area[i, j] += 1;
                        else
                        {
                            area[i, j] -= (area[i, j] != 0) ? 1 : 0;
                        }
                    }
                }
            }

            totalBrightness = area.Cast<int>().Sum();
            AnnounceResult(2, totalBrightness);
        }

        private static int CountTurnedOn(bool[,] area)
        {
            int count = 0;
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    count += area[i, j] ? 1 : 0;
                }
            }
            // This is way to do it using Linq
            //int test = area.Cast<bool>().Count(value => value);
            return count;
        }

        private static (string command, (int start, int end) x, (int start, int end ) y) ExtractInfo(string input)
        {
            string pattern = @"(turn on|turn off|toggle) (\d+),(\d+) through (\d+),(\d+)";
            Match match = Regex.Match(input, pattern);
            string command = match.Groups[1].Value;

            int xStart = int.Parse(match.Groups[2].Value);
            int yStart = int.Parse(match.Groups[3].Value);
            int xEnd = int.Parse(match.Groups[4].Value);
            int yEnd = int.Parse(match.Groups[5].Value);

            var x = (start: xStart, end: xEnd);
            var y = (start: yStart, end: yEnd);

            return (command, x, y);
        }
    }
}
