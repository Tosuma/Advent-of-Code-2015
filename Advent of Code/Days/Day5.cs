using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Tasks.Days
{
    public class Day5 : Day
    {
        public override void Task1()
        {
            string[] fileContent = OpenFile();
            int numberOfNice = 0;

            foreach (string s in fileContent)
            {
                numberOfNice += FindConsecutiveChars(s) &&
                    FindVowels(s) &&
                    FindIllegal(s) ? 1 : 0;
            }

            AnnounceResult(1, numberOfNice);
        }

        public override void Task2()
        {
            string[] fileContent = OpenFile();
            int numberOfNice = 0;

            foreach (string s in fileContent)
            {
                numberOfNice += FindSeparatedChars(s) &&
                    FindConsecutivePair(s) ? 1 : 0;
            }

            AnnounceResult(2, numberOfNice);
        }

        private static bool FindConsecutivePair(string input)
        {
            string pattern = @"(\w\w)\w*\1";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            return match.Success;
        }

        private static bool FindSeparatedChars(string input)
        {
            string pattern = @"(\w)\w\1";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            return match.Success;
        }

        private bool FindIllegal(string input)
        {
            string pattern = @"^(?:(?!ab|cd|pq|xy)\w)*$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            return match.Success;
        }

        private bool FindVowels(string input)
        {
            string pattern = @"([aeiou]\w*){3}";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            return match.Success;
        }

        private bool FindConsecutiveChars(string input)
        {
            string pattern = @"(\w)\1";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            return match.Success;
        }
    }
}
