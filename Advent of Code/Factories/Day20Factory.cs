using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day20Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day20();
        }
    }
}
