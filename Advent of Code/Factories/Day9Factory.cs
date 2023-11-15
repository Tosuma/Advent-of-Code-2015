using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day9Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day9();
        }
    }
}
