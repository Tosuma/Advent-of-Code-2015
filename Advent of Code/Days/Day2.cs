using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tasks.Days
{
    public class Day2 : Day
    {
        private (int Length, int Width, int Height) ExtractInfo(string line)
        {
            string matchPattern = @"^\d+x\d+x\d+$";
            if (line == string.Empty)
            {
                throw new ArgumentException("No input was given");
            }
            if (!Regex.IsMatch(line, matchPattern))
            {
                throw new ArgumentException("Invalid string given");
            }

            int[] data = line.Split('x')
                .Select(int.Parse)
                .ToArray();
            return (data[0], data[1], data[2]);
        }

        private (int smallest, int nextSmallest) FindSmallestSides((int Length, int Width, int Height) measurement)
        {
            int length = measurement.Length;
            int width = measurement.Width;
            int height = measurement.Height;

            int smallest = Math.Min(length, Math.Max(width, height));
            int nextSmallest;
            if (smallest == length)
            {
                nextSmallest = Math.Min(width, height);
            }
            else if (smallest == width)
            {
                nextSmallest = Math.Min(length, height);
            }
            else
            {
                nextSmallest = Math.Min(length, width);
            }
            return (smallest, nextSmallest);
        }

        private int CalculateSurface((int Length, int Width, int Height) measurement)
        {
            int length = measurement.Length;
            int width = measurement.Width;
            int height = measurement.Height;
            return 2 * length * width + 2 * width * height + 2 * height * length;
        }


        public override void Task1()
        {
            try
            {
                int sum = 0;
                string[] fileContent = OpenFile();
                foreach (string line in fileContent)
                {
                    var measurement = ExtractInfo(line);
                    int surface = CalculateSurface(measurement);
                    var side = FindSmallestSides(measurement);
                    int smallestArea = side.smallest * side.nextSmallest;
                    sum += surface + smallestArea;
                }
                AnnounceResult(1, sum);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }

        }

        public override void Task2()
        {
            try
            {
                int sum = 0;
                string[] fileContent = OpenFile();
                foreach (string line in fileContent)
                {
                    var measurement = ExtractInfo(line);
                    var side = FindSmallestSides(measurement);
                    sum += 2 * side.smallest + 2 * side.nextSmallest;
                    sum += measurement.Length * measurement.Height * measurement.Width;
                }
                AnnounceResult(1, sum);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
        }
    }
}
