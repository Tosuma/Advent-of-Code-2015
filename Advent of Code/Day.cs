using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public abstract class Day
    {
        private string _filePath;
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

        public void SetFilePath(string filePath)
        {
            if (filePath != null)
                _filePath = filePath;
        }
    }
}
