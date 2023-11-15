using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Days;

namespace Tasks.Factories
{
    interface IDayFactory
    {
        Day CreateDay();
    }
}
