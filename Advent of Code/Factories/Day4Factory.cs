using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day4Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day4();
        }
    }
}
