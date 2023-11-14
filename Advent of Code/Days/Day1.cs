using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Tasks.Days
{
    public class Day1 : Day
    {
        // Task 1
        public int FindFloor()
        {
            string[] fileContent;
            try
            {
                fileContent = OpenFile();
                if (fileContent.Length > 1)
                {
                    throw new InvalidDataException("File contains wrong formatted data");
                }
                int floor = CountFloor(fileContent[0]);
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

        // Task 2
        public int FindBasement()
        {
            string[] fileContent;
            try
            {
                fileContent = OpenFile();
                if (fileContent.Length > 1)
                {
                    throw new Exception("Find exception for wrong read");
                }
                int floor = CountToBasement(fileContent[0]);
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
                if (currentFloor < 0) { break; }
                if (line == '(') { currentFloor++; count++; }
                else if (line == ')') { currentFloor--; count++; }
            }
            return count;
        }

        public override void Task1()
        {
            try
            {
                int floorNumber = FindFloor();
                Console.WriteLine("Task 1. The result is: " + floorNumber);
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
                int amountOfFloorChanges = FindBasement();
                Console.WriteLine("Task 2. The result is: " + amountOfFloorChanges);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
        }
    }
}
