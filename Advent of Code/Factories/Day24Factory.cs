using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day24Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day24();
        }
    }
}
