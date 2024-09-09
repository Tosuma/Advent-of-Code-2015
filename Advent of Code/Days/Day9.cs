using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tasks.Days
{
    public class Day9 : Day
    {
        public override void Task1()
        {
            Dictionary<string, int> distances = new Dictionary<string, int>
            {
                {"FaerunTristram", 65},
                {"FaerunTambi", 129},
                {"FaerunNorrath", 144},
                {"FaerunSnowdin", 71},
                {"FaerunStraylight", 137},
                {"FaerunAlphaCentauri", 3},
                {"FaerunArbre", 149},
                {"TristramTambi", 63},
                {"TristramNorrath", 4},
                {"TristramSnowdin", 105},
                {"TristramStraylight", 125},
                {"TristramAlphaCentauri", 55},
                {"TristramArbre", 14},
                {"TambiNorrath", 68},
                {"TambiSnowdin", 52},
                {"TambiStraylight", 65},
                {"TambiAlphaCentauri", 22},
                {"TambiArbre", 143},
                {"NorrathSnowdin", 8},
                {"NorrathStraylight", 23},
                {"NorrathAlphaCentauri", 136},
                {"NorrathArbre", 115},
                {"SnowdinStraylight", 101},
                {"SnowdinAlphaCentauri", 84},
                {"SnowdinArbre", 96},
                {"StraylightAlphaCentauri", 107},
                {"StraylightArbre", 14},
                {"AlphaCentauriArbre", 46}
            };

            List<string> locations = distances.Keys.SelectMany(pair => pair.Split("")).Distinct().ToList();

            List<List<string>> permutations = GetPermutations(locations);

            int shortestDistance = int.MaxValue;

            foreach (var permutation in permutations)
            {
                int totalDistance = CalculateTotalDistance(permutation, distances);
                shortestDistance = Math.Min(shortestDistance, totalDistance);
            }

            Console.WriteLine("Shortest Distance: " + shortestDistance);
        }

        static List<List<T>> GetPermutations<T>(List<T> list)
        {
            if (list.Count == 1)
                return new List<List<T>> { new List<T> { list[0] } };

            return list.SelectMany(
                (e, i) => GetPermutations(list.Take(i).Concat(list.Skip(i + 1)).ToList()),
                (e, c) => c.Prepend(e).ToList()
            ).ToList();
        }

        static int CalculateTotalDistance(List<string> permutation, Dictionary<string, int> distances)
        {
            int totalDistance = 0;

            for (int i = 0; i < permutation.Count - 1; i++)
            {
                string key = permutation[i] + permutation[i + 1];
                totalDistance += distances[key];
            }

            return totalDistance;
        }

        public override void Task2()
        {
            
        }


        /*
         *  procedure DFS(G, v) is
                label v as discovered
                for all directed edges from v to w that are in G.adjacentEdges(v) do
                    if vertex w is not labeled as discovered then
                        recursively call DFS(G, w)
        */

        private int DFS(Graph graph)
        {
            HashSet<City> visited = new HashSet<City>();
            List<City> path = new List<City>();
            List<City> shortestPath = null;
            DFSHelper(graph, new City("Faerun"), visited, path, ref shortestPath, 0);
            


            return 0;
        }

        private void DFSHelper(Graph graph, City currentCity, HashSet<City> visited, List<City> path, ref List<City>? shortestPath, int iteration)
        {
            Console.WriteLine(new string(' ', iteration*4) + $"Current city: {currentCity.Name}");
            visited.Add(currentCity);
            path.Add(currentCity);

            //if (visited.Count == graph.Cities.Count)
            //{
            //    if (shortestPath == null || SumPath(graph, path) < SumPath(graph, shortestPath))
            //    {
            //        shortestPath = path;
            //    }
            //}

            foreach (var edge in graph.Edges.Where(e => e.StartCity.Name == currentCity.Name))
            {
                Console.WriteLine(new string(' ', iteration*4) + $"Current childs: {edge.EndCity.Name}");
                City neighborCity = edge.EndCity;
                if (!visited.Contains(neighborCity))
                {
                    DFSHelper(graph, neighborCity, visited, path, ref shortestPath, iteration + 1);
                }
            }
        }

        private int SumPath(Graph graph, List<City> path)
        {
            int totalDistance = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                Edge edge = graph.Edges.FirstOrDefault(e => e.StartCity == path[i] && e.EndCity == path[i + 1]);
                if (edge != null)
                {
                    totalDistance += edge.Distance;
                }
            }
            return totalDistance;
        }

        private Graph InitializeGraph(string[] routes)
        {
            Graph graph = new Graph();

            foreach (string route in routes)
            {
                string pattern = @"(\w)+ to (\w)+ = (\d)+"; // Matches with the string containing a word followed by another word followed by a digit
                Regex regex = new Regex(pattern);
                Match match = regex.Match(route);
                City cityFrom = new City(match.Groups[1].Value);
                City cityTo = new City(match.Groups[2].Value);
                int distance = int.Parse(match.Groups[3].Value);

                graph.Cities.Add(cityFrom);
                graph.Cities.Add(cityTo);
                graph.Edges.Add(new Edge(cityFrom, cityTo, distance));
            }

            return graph;
        }

    }

    // Helper classes
    class City
    {
        public City(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    class Edge
    {
        public Edge(City startCity, City endCity, int distance)
        {
            StartCity = startCity;
            EndCity = endCity;
            Distance = distance;
        }

        public City StartCity { get; set; }
        public City EndCity { get; set; }
        public int Distance { get; set; }
    }

    class Graph
    {
        public HashSet<City> Cities { get; } = new HashSet<City>();
        public HashSet<Edge> Edges { get; } = new HashSet<Edge>();
    }
}
