using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges_And_Articulation_Points
{
    public class ArticulationPoints
    {
        private GraphMatrix graph;
        private List<int> articulationPoints = new List<int>();

        public ArticulationPoints(GraphMatrix graph)
        {
            this.graph = graph;
        }

        public void FindArticulationPoints()
        {
            articulationPoints.Clear();
            int[] verticeNumbers = new int[graph.size];
            for (int i = 0; i < graph.size; i++)
            {
                verticeNumbers[i] = 0;
            }

            for (int vertice = 0; vertice < graph.size; vertice++)
            {
                if (verticeNumbers[vertice] > 0)
                    continue;

                int verticeNumber = 1;
                verticeNumbers[vertice] = verticeNumber;
                verticeNumber++;
                int childCounter = 0;
                foreach (int neighbor in graph.GetNeighbours(vertice))
                {
                    if (verticeNumbers[neighbor] > 0)
                        continue;

                    childCounter++;
                    DFS(neighbor, vertice, verticeNumbers, verticeNumber);
                }
                if (childCounter > 1)
                {
                    articulationPoints.Add(vertice);
                }
            }
        }

        private int DFS(int vertice, int parent, int[] verticeNumbers, int verticeNumber)
        {
            verticeNumbers[vertice] = verticeNumber;
            int low = verticeNumber;
            verticeNumber++;
            bool test = false;

            foreach (int neighbor in graph.GetNeighbours(vertice))
            {
                if (neighbor.Equals(parent))
                    continue;

                if (!verticeNumbers[neighbor].Equals(0))
                {
                    if (verticeNumbers[neighbor] < low)
                    {
                        low = verticeNumbers[neighbor];
                    }
                }
                else
                {
                    int tmp = DFS(neighbor, vertice, verticeNumbers, verticeNumber);
                    if (tmp < low)
                    {
                        low = tmp;
                    }
                    if (tmp.Equals(verticeNumbers[vertice]))
                    {
                        test = true;
                    }
                }
            }

            if (test)
            {
                articulationPoints.Add(vertice);
            }
            return low;
        }

        public void PrintArticulationPoints()
        {
            Console.WriteLine("Articulation Points: ");
            for (int i = 0; i < articulationPoints.Count; i++)
            {
                if (i == articulationPoints.Count - 1)
                {
                    Console.Write(articulationPoints[i]);
                }
                else
                {
                    Console.Write(articulationPoints[i] + ", ");
                } 
            }
            Console.WriteLine();
        }
    }
}
