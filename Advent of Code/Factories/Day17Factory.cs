using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day17Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day17();
        }
    }
}
