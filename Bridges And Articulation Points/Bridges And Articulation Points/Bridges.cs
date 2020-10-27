using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges_And_Articulation_Points
{
    public class Bridges
    {
        private GraphMatrix graph;
        private List<Tuple<int, int>> bridges = new List<Tuple<int, int>>();

        public Bridges(GraphMatrix graph)
        {
            this.graph = graph;
        }

        public void FindBridges()
        {
            bridges.Clear();
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
                DFS(vertice, -1, verticeNumbers, verticeNumber);
            }
        }

        private int DFS(int vertice, int parent, int[] verticeNumbers, int verticeNumber)
        {
            verticeNumbers[vertice] = verticeNumber;
            int low = verticeNumber;
            verticeNumber++;

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
                }
            }

            if (parent > -1 && low.Equals(verticeNumbers[vertice]))
            {
                bridges.Add(new Tuple<int, int>(parent, vertice));
            }

            return low;
        }

        public void PrintBridges()
        {
            for (int i = 0; i < bridges.Count; i++)
            {
                Console.WriteLine("Bridge: ( " + bridges[i].Item1 + ", " + bridges[i].Item2 + " )");
            }
            Console.WriteLine();
        }
    }
}
