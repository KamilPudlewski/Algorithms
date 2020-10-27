using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kruskal_Algorithm
{
    public class Kruskal
    {
        private Graph graph;
        private List<Edge> result = new List<Edge>();

        public Kruskal(Graph graph)
        {
            this.graph = graph;
            int verticesCount = graph.VerticesCount();

            var sortedEdges = graph.edges.OrderBy(edge => edge.weight).ToList();
            graph.edges = sortedEdges;
            
            Subset[] subsets = new Subset[verticesCount];
            for (int i = 0; i < subsets.Length; i++)
            {
                subsets[i] = new Subset();
            }

            for (int v = 0; v < verticesCount; v++)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            int actualEdgeCounter = 0;
            while (result.Count < verticesCount - 1)
            {
                Edge nextEdge = graph.edges[actualEdgeCounter++];
                int x = Find(subsets, nextEdge.source);
                int y = Find(subsets, nextEdge.destination);

                if (x != y)
                {
                    result.Add(nextEdge);
                    Union(subsets, x, y);
                }
            }
        }

        private int Find(Subset[] subsets, int i)
        {
            if (subsets[i].parent != i)
            {
                subsets[i].parent = Find(subsets, subsets[i].parent);
            }
            return subsets[i].parent;
        }   

        private void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            // Attach smaller rank tree under root of high rank tree (Union by Rank) 
            if (subsets[xroot].rank < subsets[yroot].rank)
            {
                subsets[xroot].parent = yroot;
            }
            else if (subsets[xroot].rank > subsets[yroot].rank)
            {
                subsets[yroot].parent = xroot;
            }
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
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