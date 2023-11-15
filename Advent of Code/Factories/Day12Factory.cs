using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day12Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day12();
        }
    }
}
