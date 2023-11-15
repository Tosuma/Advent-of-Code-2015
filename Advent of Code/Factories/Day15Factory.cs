using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day15Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day15();
        }
    }
}