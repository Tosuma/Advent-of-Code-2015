using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day7Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day7();
        }
    }
}
