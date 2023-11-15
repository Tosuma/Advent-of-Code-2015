using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day22Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day22();
        }
    }
}
