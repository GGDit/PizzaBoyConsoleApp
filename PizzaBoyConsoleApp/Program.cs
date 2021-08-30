using System;
using Navigation;
using Navigation.Pathing;
using Navigation.Mapping;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace PizzaBoyConsoleApp
{
    class Program
    {
        static List<LocationNode> InputInterpretation(string input)
        {
            Regex regex = new Regex(@"[(]+\d+[,]+\d+[)]");
            MatchCollection matches = regex.Matches(input);

           

            List<string> strings = matches.Cast<Match>().Select(match => match.Value).ToList();

            List<LocationNode> nodes = new List<LocationNode>();

            foreach (string s in strings)
            {
                Match[] matches1 = Regex.Matches(s, @"\d+").Cast<Match>().ToArray();

                List<string> strings1 = matches1.Cast<Match>().Select(match => match.Value).ToList();

                string[] array = new string[2];

                array = strings1.ToArray();

                nodes.Add(new LocationNode(int.Parse(array[0]), int.Parse(array[1])));
            }

            return nodes;
            
        }

        static string OutputInterpretation(List<LocationNode> nodes)
        {
            int i, j; string output = "";

            LocationNode[] locations = nodes.ToArray();

            for (i=0; i<locations.Length-1; i++)
            {
                j = 0;

                while ((j < Directions.fourWays.Length / 2) &&
                    ((locations[i + 1].X - locations[i].X) != Directions.fourWays[j, 0] ||
                    (locations[i + 1].Y - locations[i].Y) != Directions.fourWays[j, 1])) ++j;

                if (j<= Directions.fourWays.Length / 2)
                {
                    if (j == Directions.fourWays.Length / 2) output = output + "D";
                    else output = output + Directions.fourWaysNames[j];
                }
            }

            return output;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Введите последовательность точек в формате: (0,0) (1,3) (4,4) (4,2) (4,2) (0,1) (3,2) (2,3) (4,1)");

            string input = Console.ReadLine();

            List<LocationNode> checkpoints = InputInterpretation(input);

            Astar astar = new();

            LocationNode[] nodes = new LocationNode[checkpoints.Count];
            int i = -1;
            foreach (LocationNode checkpoint in checkpoints)
            {
                ++i;
                nodes[i] = checkpoint;
            }

            List<LocationNode> path = new List<LocationNode>();

            for (i=0; i<nodes.Length-1; i++)
            {
                path.AddRange(astar.Run(nodes[i], nodes[i + 1]));
            }

            Console.WriteLine(OutputInterpretation(path));

            Console.ReadLine();
        }
    }
}
