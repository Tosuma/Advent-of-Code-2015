using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day3Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day3();
        }
    }
}
