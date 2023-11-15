using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day21Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day21();
        }
    }
}
