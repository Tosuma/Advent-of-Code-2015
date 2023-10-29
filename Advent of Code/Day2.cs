using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return (Length: 1,  Width: 1, Height: 1);
        }

        private int FindSmallestArea((int Length, int Width, int Height) measurement)
        {
            return 1;
        }

        private int CalculateSurface((int Length, int Width, int Height) measurement)
        {
            return 1;
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
