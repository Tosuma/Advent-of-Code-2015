using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Days
{
    public class Day8 : Day
    {
        public override void Task1()
        {
            string[] fileContent = OpenFile();
            int totalChars;
            int inMemoryChars;
            int result;

            totalChars = CountTotalChars(fileContent);
            inMemoryChars = CountInMemoryChars(fileContent);

            result = totalChars - inMemoryChars;
            AnnounceResult(1, result);
        }


        public override void Task2()
        {
            string[] fileContent = OpenFile();
            int totalChars = CountTotalChars(fileContent);
            int encodedSize;
            int result;
            encodedSize = CountEncodedChars(fileContent);

            result = encodedSize - totalChars;
            AnnounceResult(2, result);
        }

        private static int CountEncodedChars(string[] fileContent)
        {
            int sum = 0;
            foreach (string line in fileContent)
            {
                sum += line.Count(c => c == '\"');
                sum += line.Count(c => c == '\\');
                sum += line.Length;
                sum += 2;
            }
            return sum;
        }

        private static int CountInMemoryChars(string[] fileContent)
        {
            int inMemoryChars = 0;
            foreach (string line in fileContent)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '\\')
                    {
                        inMemoryChars++;
                        if (line[i + 1] == 'x') i += 3;
                        else i++;
                    }
                    else if (line[i] == '\"')
                    {
                        continue;
                    }
                    else
                    {
                        inMemoryChars++;
                    }
                }
            }

            return inMemoryChars;
        }

        private static int CountTotalChars(string[] fileContent)
        {
            int totalChars = 0;
            
            foreach (string line in fileContent)
            {
                totalChars += line.Length;
            }

            return totalChars;
        }
    }
}
