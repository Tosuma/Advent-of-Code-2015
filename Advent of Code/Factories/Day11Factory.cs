using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day11Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day11();
        }
    }
}
