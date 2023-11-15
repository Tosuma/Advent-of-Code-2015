using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day7Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day7();
        }
    }
}
