using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day1Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day1();
        }
    }
}
