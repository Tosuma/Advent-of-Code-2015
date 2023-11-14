using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Days
{
    public class Day3 : Day
    {
        private int CountVisitedHouses(string directions)
        {
            HashSet<(int, int)> visitedHouses = new HashSet<(int, int)>();

            int x = 0; // Santa's starting x-coordinate
            int y = 0; // Santa's starting y-coordinate

            visitedHouses.Add((x, y)); // Santa always visits the starting house

            foreach (char direction in directions)
            {
                // Update Santa's position based on the current direction
                var movement = DecodeMovement(direction);

                x += movement.x;
                y += movement.y;

                // Mark the current house as visited
                visitedHouses.Add((x, y));
            }

            return visitedHouses.Count;

        }

        private (int x, int y) DecodeMovement(char direction)
        {
            switch (direction)
            {
                case '^':
                    return (x: 0, y: 1);
                case 'v':
                    return (x: 0, y: -1);
                case '>':
                    return (x: 1, y: 0);
                case '<':
                    return (x: -1, y: 0);
                default:
                    throw new ArgumentException("A sign was given which is not correct");
            }
        }

        private int RoboSantaCountVisitedHouses(string directions)
        {
            HashSet<(int, int)> visitedHouses = new HashSet<(int, int)>();

            var santa = (x: 0, y: 0);
            var roboSanta = (x: 0, y: 0);

            visitedHouses.Add(santa);
            visitedHouses.Add(roboSanta);

            for (int i = 0; i < directions.Length; i += 2)
            {
                char santaDirection = directions[i];

                // Ensure that we are not going beyond the length of the string
                char roboSantaDirection = i + 1 < directions.Length ? directions[i + 1] : '\0';

                var santaMovement = DecodeMovement(santaDirection);
                santa.x += santaMovement.x;
                santa.y += santaMovement.y;
                visitedHouses.Add(santa);

                var roboSantaMovement = DecodeMovement(roboSantaDirection);
                roboSanta.x += roboSantaMovement.x;
                roboSanta.y += roboSantaMovement.y;
                visitedHouses.Add(roboSanta);
            }

            return visitedHouses.Count;

        }
        public override void Task1()
        {
            try
            {
                string fileContent = OpenFile()[0]; // only one line
                int gotAPresent = CountVisitedHouses(fileContent);
                Console.WriteLine($"Task 1. The result is: {gotAPresent}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
        }

        public override void Task2()
        {
            try
            {
                string fileContent = OpenFile()[0]; // only one line
                int gotAPresent = RoboSantaCountVisitedHouses(fileContent);
                Console.WriteLine($"Task 2. The result is: {gotAPresent}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
        }
    }
}