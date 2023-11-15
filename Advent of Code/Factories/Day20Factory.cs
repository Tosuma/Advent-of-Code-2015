using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day20Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day20();
        }
    }
}
