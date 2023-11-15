using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Days;

namespace Tasks
{
    public class DayFactory
    {
        public Day MakeDay(string day)
        {
            if (day == null)
                throw new ArgumentNullException("No input was given");
            if (day.Equals("DAY1", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("+------ Day  1 is beginning ------+");
                return new Day1();
            }
            if (day.Equals("DAY2", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("+------ Day  2 is beginning ------+");
                return new Day2();
            }
            if (day.Equals("DAY3", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("+------ Day  3 is beginning ------+");
                return new Day3();
            }
            if (day.Equals("DAY4", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("+------ Day  4 is beginning ------+");
                return new Day4();
            }
            if (day.Equals("DAY5", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("+------ Day  5 is beginning ------+");
                //return new Day5();
            }
            if (day.Equals("DAY6", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("+------ Day  6 is beginning ------+");
                //return new Day6();
            }

            throw new ArgumentException("No match found for input");
        }
    }
}
