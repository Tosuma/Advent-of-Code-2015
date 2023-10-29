using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Day_1
{
    public class Day1 : IDay
    {
        private string _filePath;
        public Day1(string filePath)
        {

            _filePath = filePath;

        }
        // Task 1
        public int FindFloor()
        {
            string fileContent;
            try
            {
                fileContent = OpenFile();
                int floor = CountFloor(fileContent);
                return floor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Task 1
        private int CountFloor(string fileContent)
        {
            int count = 0;
            foreach (char line in fileContent)
            {
                if (line == '(') { count++; }
                else if (line == ')') { count--; }
            }
            return count;
        }

        // Task 1 & 2
        private string OpenFile()
        {
            if (_filePath == null || _filePath == string.Empty)
            {
                throw new ArgumentException("Invalid file path");
            }
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("File not found");
            }
            return File.ReadAllText(_filePath);       
        }

        // Task 2
        public int FindBasement()
        {
            string fileContent;
            try
            {
                fileContent = OpenFile();
                int floor = CountToBasement(fileContent);
                return floor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Task 2
        private int CountToBasement(string fileContent)
        {
            int count = 0;
            int currentFloor = 0;
            foreach (char line in fileContent)
            {
                if (currentFloor < 0) { break ; }
                if (line == '(') { currentFloor++; count++; }
                else if (line == ')') { currentFloor--; count++; }
            }
            return count;
        }

        public void Task1()
        {
            try
            {
                int floorNumber = FindFloor();
                Console.WriteLine("Task 1. The result is: " + floorNumber);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void Task2()
        {
            try
            {
                int amountOfFloorChanges = FindBasement();
                Console.WriteLine("Task 2. The result is: " + amountOfFloorChanges);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
