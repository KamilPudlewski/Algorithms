using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kruskal_Algorithm
{
    public class Graph
    {
        public List<Edge> edges = new List<Edge>();
        public List<int> vertices = new List<int>();

        public Graph()
        {

        }

        public void AddEdge(Edge edge)
        {
            edges.Add(edge);
            AddVertice(edge.source);
            AddVertice(edge.destination);
        }

        public void AddEdge(int source, int destination)
        {
            edges.Add(new Edge(source, destination));
            AddVertice(source);
            AddVertice(destination);
        }

        public void AddEdge(int source, int destination, int weight)
        {
            edges.Add(new Edge(source, destination, weight));
            AddVertice(source);
            AddVertice(destination);
        }

        public bool EdgeExist(Edge edge)
        {
            return edges.Contains(edge);
        }

        public bool VerticeExist(int vertice)
        {
            return vertices.Contains(vertice);
        }

        public int EdgesCount()
        {
            return edges.Count;
        }

        public int VerticesCount()
        {
            return vertices.Count;
        }

        public void AddVertice(int vertice)
        {
            if (!VerticeExist(vertice))
            {
                vertices.Add(vertice);
            }
        }
    }

    public class Edge
    {
        public int source;
        public int destination;
        public int weight;

        public Edge(int source, int destination)
        {
            this.source = source;
            this.destination = destination;
            weight = 0;
        }

        public Edge(int source, int destination, int weight)
        {
            this.source = source;
            this.destination = destination;
            this.weight = weight;
        }
    }

    public class Subset
    {
        public int parent;
        public int rank;

        public Subset()
        {

        }

        public Subset(int parent, int rank)
        {
            this.parent = parent;
            this.rank = rank;
        }
    }
}
