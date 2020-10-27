using System;

namespace Kruskal_Union_Find
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            //graph.AddEdge(0, 1);
            //graph.AddEdge(0, 2);
            //graph.AddEdge(0, 3);
            //graph.AddEdge(1, 3);
            //graph.AddEdge(2, 3);

            graph.AddEdge(0, 1, 13);
            graph.AddEdge(0, 2, 8);
            graph.AddEdge(0, 3, 1);
            graph.AddEdge(1, 2, 15);
            graph.AddEdge(2, 3, 5);
            graph.AddEdge(2, 4, 3);
            graph.AddEdge(3, 4, 4);
            graph.AddEdge(3, 5, 5);
            graph.AddEdge(4, 5, 2);

            Kruskal kruskal = new Kruskal(graph);
            kruskal.PrintResult();
            Console.ReadKey();
        }
    }
}
