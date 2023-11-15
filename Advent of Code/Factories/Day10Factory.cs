using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day10Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day10();
        }
    }
}
