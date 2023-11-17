using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Days
{
    public class Day7 : Day
    {
        private Dictionary<string, ushort> wireSignals = new Dictionary<string, ushort>();
        private Dictionary<string, string[]> instructions = new Dictionary<string, string[]>();

        public override void Task1()
        {
            string[] fileContent = OpenFile();
            LoadInstructions(fileContent);
            int result = GetSignalOnWire("a");

            AnnounceResult(1, result);
        }

        public override void Task2()
        {
            wireSignals.Clear();
            wireSignals.Add("b", 956);
            int result = GetSignalOnWire("a");

            AnnounceResult(2, result);
        }

        private void LoadInstructions(string[] fileContent)
        {
            foreach (string line in fileContent)
            {
                string[] parts = line.Split(" -> ");
                instructions[parts[1]] = parts[0].Split(' ');
            }
        }

        public ushort GetSignalOnWire(string wire)
        {
            if (!wireSignals.ContainsKey(wire))
            {
                // If the signal on the wire is not calculated yet, calculate it
                ushort signal = CalculateSignal(wire);
                wireSignals[wire] = signal;
            }

            return wireSignals[wire];
        }

        private ushort CalculateSignal(string wire)
        {
            // If the signal is already a number, parse and return it
            if (ushort.TryParse(wire, out ushort signal))
            {
                return signal;
            }

            // If the signal is not a number, recursively calculate it based on the instructions
            string[] instruction = instructions[wire];

            if (instruction.Length == 1)
            {
                // Single input case
                return GetSignalOnWire(instruction[0]);
            }
            else if (instruction.Length == 2)
            {
                // NOT gate
                return (ushort)~GetSignalOnWire(instruction[1]);
            }
            else
            {
                // Two-input gate
                ushort input1 = GetSignalOnWire(instruction[0]);
                ushort input2 = GetSignalOnWire(instruction[2]);

                switch (instruction[1])
                {
                    case "AND":
                        return (ushort)(input1 & input2);
                    case "OR":
                        return (ushort)(input1 | input2);
                    case "LSHIFT":
                        return (ushort)(input1 << int.Parse(instruction[2]));
                    case "RSHIFT":
                        return (ushort)(input1 >> int.Parse(instruction[2]));
                    default:
                        throw new InvalidOperationException("Invalid instruction");
                }
            }
        }
    }
}
