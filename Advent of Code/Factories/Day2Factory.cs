using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day2Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day2();
        }
    }
}
