using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Days
{
    public abstract class Day
    {
        private string _filePath = "";
        public abstract void Task1();
        public abstract void Task2();
        public string[] OpenFile()
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

        protected void AnnounceResult(int taskNumber, int result)
        {
            Console.WriteLine($"Task {taskNumber}. The result is: {result}");
        }
        protected void AnnounceResult(int taskNumber, string result)
        {
            Console.WriteLine($"Task {taskNumber}. The result is: {result}");
        }

        public void Execute()
        {
            string dayName = GetType().Name;
            _filePath = $"C:\\Coding-Git\\Advent-of-Code-2015\\Advent of Code\\Task Files\\{dayName}.txt";

            Console.WriteLine($"+------ {dayName} is beginning ------+");
            Task1();
            Task2();
            Console.WriteLine();
        }
    }
}
