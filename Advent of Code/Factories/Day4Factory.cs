using System;
using Tasks.Days;

namespace Tasks.Factories
{
    class Day4Factory : IDayFactory
    {
        public Day CreateDay()
        {
            return new Day4();
        }
    }
}
