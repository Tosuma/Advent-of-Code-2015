using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Day_1
{
    public class Task
    {
        // Task 1
        public int FindFloor(string filePath)
        {
            string fileContent;
            try
            {
                fileContent = OpenFile(filePath);
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
        private string OpenFile(string filePath)
        {
            if (filePath == null || filePath == string.Empty)
            {
                throw new ArgumentException("Invalid file path");
            }
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found");
            }
            return File.ReadAllText(filePath);       
        }

        // Task 2
        public int FindBasement(string filePath)
        {
            string fileContent;
            try
            {
                fileContent = OpenFile(filePath);
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

        public static void Main(string[] args)
        {
            string filePath = "C:\\Coding-Git\\Advent-of-Code-2015\\Advent of Code\\Task1Input.txt";
            Task task = new Task();
            try
            {
                int floorNumber = task.FindFloor(filePath);
                int amountOfFloorChanges = task.FindBasement(filePath);
                Console.WriteLine("Task 1. The result is: " + floorNumber);
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
