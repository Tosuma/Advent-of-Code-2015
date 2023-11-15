using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day21Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day21();
        }
    }
}
