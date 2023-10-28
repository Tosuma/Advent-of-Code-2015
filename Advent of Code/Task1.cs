using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Day_1
{
    public class Task1
    {
        public int FindFloor(String filePath)
        {
            string fileContent;
            int floor = 0;
            try
            {
                fileContent = OpenFile(filePath);
                floor = CountFloor(fileContent);
                return floor;
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        private string OpenFile(String filePath)
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

        public static void Main(string[] args)
        {
            string filePath = "C:\\Coding-Git\\Advent-of-Code-2015\\Advent of Code\\Task1Input.txt";
            Task1 task = new Task1();
            try
            {
                int floorNumber = task.FindFloor(filePath);
                Console.WriteLine("The result is: " + floorNumber);
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
