using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day14Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day14();
        }
    }
}
