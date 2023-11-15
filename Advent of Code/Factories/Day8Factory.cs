using System;
using Tasks.Days;

namespace Tasks.Factories
{
    public class Day8Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day8();
        }
    }
}
