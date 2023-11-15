using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day2Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day2();
        }
    }
}
