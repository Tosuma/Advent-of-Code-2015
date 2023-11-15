using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day11Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day11();
        }
    }
}
