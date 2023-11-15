using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day23Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day23();
        }
    }
}