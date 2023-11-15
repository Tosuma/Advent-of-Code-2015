using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day23Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day23();
        }
    }
}
