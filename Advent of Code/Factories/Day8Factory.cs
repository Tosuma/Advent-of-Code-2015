using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day8Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day8();
        }
    }
}
