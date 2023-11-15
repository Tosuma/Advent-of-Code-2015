using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day1Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day1();
        }
    }
}
