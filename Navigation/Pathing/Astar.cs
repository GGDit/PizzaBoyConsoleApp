using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation.Pathing.Intarfaces;
using Navigation.Mapping;

namespace Navigation.Pathing
{
    public class Astar : IPathingAlg
    {
        private List<LocationNode> ReconstructPath(LocationNode finish)
        {
            List<LocationNode> pathMap = new List<LocationNode>();

            LocationNode current = finish;
            while (current != null)
            {
                pathMap.Insert(0, current);
                current = current.Parent;
            }

            return pathMap;
        }

        private double GetHeuristiCost(LocationNode a, LocationNode b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public List<LocationNode> Run(LocationNode start, LocationNode finish)
        {
            List<LocationNode> closedSet = new List<LocationNode>(); //множество обработанных

            List<LocationNode> openSet = new List<LocationNode>();   //множ-во ожидающих обработки
                 

            Double tentative_g_score; //Примерное оценка для соседей
            bool tentative_is_better = false; //Флаг для предпочитаемого соседа

            start.G = 0;
            start.H = GetHeuristiCost(start, finish);
            start.F = start.G + start.H;
            openSet.Add(start);

            LocationNode current, nearest;

            while (openSet.Count != 0)
            {
                current = (LocationNode)openSet.Find(x => x.F == openSet.Min(x => x.F)); //!!!!!!!

                if (LocationNode.IsSameLocation(current, finish)) //Проверка на финиш
                {
                    return ReconstructPath(current);
                }

                openSet.Remove(current);

                closedSet.Add(current);

                for (int i = 0; i < Directions.fourWays.Length / 2; i++) 
                {
                    nearest = new LocationNode(current.X, current.Y);
                    nearest.X = current.X + Directions.fourWays[i, 0];
                    nearest.Y = current.Y + Directions.fourWays[i, 1];

                    if ( closedSet.Exists(a => (a.X == nearest.X && a.Y == nearest.Y))) //Содержится ли сосед в множ-ве обработанных
                    {
                        continue;
                    }

                    tentative_g_score = current.G + GetHeuristiCost(current, nearest);

                    if ( !openSet.Exists(a => (a.X == nearest.X && a.Y == nearest.Y)) )    //Новый ли сосед
                    {
                        openSet.Add(nearest);
                        tentative_is_better = true;
                    }
                    else
                    {
                        if (tentative_g_score < nearest.G) //
                        {
                            tentative_is_better = true;
                        }
                        else
                        {
                            tentative_is_better = false;
                        }
                    }
                    if (tentative_is_better == true)
                    {
                        nearest.Parent = current;
                        current.Child = nearest;

                        nearest.G = tentative_g_score;
                        nearest.H = GetHeuristiCost(current, nearest);
                        nearest.F = nearest.G + nearest.H;

                    }
                }
            }

            return null;
        }
    }
}
