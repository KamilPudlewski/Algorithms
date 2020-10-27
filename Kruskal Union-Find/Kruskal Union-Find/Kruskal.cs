using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kruskal_Union_Find
{
    public class Kruskal
    {
        private Graph graph;

        private int[] count;
        private int[] name;
        private int[] parent;
        private int[] root;

        private List<Edge> result = new List<Edge>();

        public Kruskal(Graph graph)
        {
            this.graph = graph;

            var sortedEdges = graph.edges.OrderBy(edge => edge.weight).ToList();
            graph.edges = sortedEdges;

            Initialize(graph.VerticesCount());

            foreach (var edge in graph.edges)
            {
                int vertice1 = edge.source;
                int vertice2 = edge.destination;

                if (Find(vertice1) != Find(vertice2))
                {
                    result.Add(new Edge(vertice1, vertice2, edge.weight));
                    Union(vertice1, vertice2);
                }
            }
        }

        private void Initialize(int size)
        {
            count = new int[size];
            name = new int[size];
            parent = new int[size];
            root = new int[size];

            for (int i = 0; i < size; i++)
            {
                count[i] = 1;
                name[i] = i;
                parent[i] = -1;
                root[i] = i;
            }
        }

        private int Find(int i)
        {
            int v = i;
            List<int> list = new List<int>();
            while (parent[v] != -1)
            {
                list.Add(v);
                v = parent[v];
            }
            foreach (int w in list)
            {
                parent[w] = v;
            }
            return name[v];
        }

        private void Union(int i, int j)
        {
            int large = root[j];
            int small = root[i];
            if (count[root[i]] > count[root[j]])
            {
                large = root[i];
                small = root[j];
            }
            parent[small] = large;
            count[large] += count[small];
            name[small] = large;
            root[small] = large;
        }

        public void PrintResult()
        {
            int sum = 0;
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i].source + " -> " + result[i].destination + " == " + result[i].weight);
                sum += result[i].weight;
            }
            Console.WriteLine("Total weights: " + sum);
        }
    }
}