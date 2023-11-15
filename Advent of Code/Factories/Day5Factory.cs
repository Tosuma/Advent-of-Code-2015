using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day5Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day5();
        }
    }
}
