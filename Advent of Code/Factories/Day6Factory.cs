using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day6Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day6();
        }
    }
}