using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day16Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day16();
        }
    }
}
