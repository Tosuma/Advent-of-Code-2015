using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day19Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day19();
        }
    }
}
