using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day13Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day13();
        }
    }
}
