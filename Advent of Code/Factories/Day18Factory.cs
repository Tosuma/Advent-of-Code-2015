using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day18Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day18();
        }
    }
}
