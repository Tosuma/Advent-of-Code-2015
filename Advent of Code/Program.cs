using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Tasks.Days;
using Tasks.Factories;

namespace Tasks
{
    class Program
    {
        static void Main()
        {
            // Make DayFactories
            List<IDayFactory> dayFactories = new List<IDayFactory>();
            for (int i = 1; i <= 24; i++)
            {
                string factoryName = $"Tasks.Factories.Day{i}Factory";
                Type factoryType = Type.GetType(factoryName);

                if (factoryType != null && typeof(IDayFactory).IsAssignableFrom(factoryType))
                {
                    IDayFactory factory = (IDayFactory)Activator.CreateInstance(factoryType);
                    dayFactories.Add(factory);
                };
            }

            foreach (IDayFactory dayFactory in dayFactories)
            {
                Day day = dayFactory.CreateDay();
                day.Execute();
            }
        }
    }
}
