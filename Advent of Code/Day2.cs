using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tasks
{
    public class Day2 : IDay
    {
        private string _filePath;

        public void SetFilePath(string filePath)
        {
            if (filePath != null)
                _filePath = filePath;
        }

        private string[] OpenFile()
        {
            if (_filePath == null || _filePath == string.Empty)
            {
                throw new ArgumentException("Invalid file path");
            }
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("File not found");
            }
            return File.ReadAllLines(_filePath);
        }

        private (int Length, int Width, int Height) ExtractInfo(string line)
        {
            string matchPattern = @"^\d+x\d+x\d+$";
            if (line == string.Empty)
            {
                throw new ArgumentException("No input was given");
            }
            if (!Regex.IsMatch(line, matchPattern))
            {
                throw new ArgumentException("Invalid string given. Only 2 'x' allowed");
            }

            int[] data = line.Split('x')
                .Select(int.Parse)
                .ToArray();
            return (data[0], data[1], data[2]);
        }

        private int FindSmallestArea((int Length, int Width, int Height) measurement)
        {
            int length = measurement.Length;
            int width = measurement.Width;
            int height = measurement.Height;
            
            int smallest = Math.Min(length, Math.Max(width, height));
            int nextSmallest = 0;

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
            return smallest * nextSmallest;
        }

        private int CalculateSurface((int Length, int Width, int Height) measurement)
        {
            int length = measurement.Length;
            int width = measurement.Width;
            int height = measurement.Height;
            return (2 * length * width) + (2 * width * height) + (2 * height * length);
        }

        public void Task1()
        {
            try
            {
                int sum = 0;
                string[] fileContent = OpenFile();
                foreach (string line in fileContent)
                {
                    var measurement = ExtractInfo(line);
                    int surface = CalculateSurface(measurement);
                    int smallestArea = FindSmallestArea(measurement);
                    sum += surface + smallestArea;
                }
                Console.WriteLine("Task 1. The result is: " + sum);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }

        }

        public void Task2()
        {
            throw new NotImplementedException();
        }
    }
}
