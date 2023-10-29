using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class DayFactory
    {
        public IDay MakeDay(string day)
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

            throw new ArgumentException("No match found for input");
        }
    }
}
