using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges_And_Articulation_Points
{
    public class GraphMatrix
    {
        public int[,] graph;
        public int size;

        public GraphMatrix(int size)
        {
            this.size = size;
            graph = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    graph[i, j] = 0;
                }
            }
        }

        public void AddEdge(int source, int destination)
        {
            graph[source, destination] = 1;
        }

        public void AddEdge(int source, int destination, int weight)
        {
            graph[source, destination] = weight;
        }

        public void AddEdgeN(int source, int destination)
        {
            graph[source, destination] = 1;
            graph[destination, source] = 1;
        }

        public void AddEdgeN(int source, int destination, int weight)
        {
            graph[source, destination] = weight;
            graph[destination, source] = weight;
        }

        public int GetValue(int source, int destination)
        {
            return graph[source, destination];
        }

        public List<int> GetNeighbours(int vertice)
        {
            List<int> neighours = new List<int>();
            for (int i = 0; i < size; i++)
            {
                if (!graph[vertice, i].Equals(0))
                {
                    neighours.Add(i);
                }
            }
            return neighours;
        }

        public bool HasNeighbours(int vertice, int neighbour)
        {
            return graph[vertice, neighbour].Equals(1);
        }

        public void Transpose()
        {
            int[,] tmp = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tmp[i, j] = graph[j, i];
                }
            }
            graph = tmp;
        }

        public void CreateImplicationGraph(int[] a, int[] b, int offset)
        {
            if (a.Length != b.Length)
            {
                Console.WriteLine("Error! Array must be the same dimensions!");
                return;
            }

            for (int i = 0; i < a.Length; i++)
            {
                int x = a[i];
                int y = b[i];
                int negativeX = x + offset;
                int negativeY = y + offset;

                if (x < 0)
                {
                    negativeX = -x;
                    x = -x + offset;
                }
                if (y < 0)
                {
                    negativeY = -y;
                    y = -y + offset;
                }
                x--;
                y--;
                negativeX--;
                negativeY--;
                graph[negativeX, y] = 1;
                graph[negativeY, x] = 1;
            }
        }

        public string Print()
        {
            string result = "";
            for (int i = 0; i < size; i++)
            {
                result += i + ": [";
                for (int j = 0; j < size; j++)
                {
                    result += " " + graph[i, j] + " ";
                }
                result += "]\n";
            }
            return result;
        }
    }
}