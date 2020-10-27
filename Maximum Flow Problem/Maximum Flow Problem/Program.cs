using System;

namespace Maximum_Flow_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            //int size = 7;
            //GraphMatrix graph = new GraphMatrix(size);
            //int source = 0;
            //int destination = size - 1;
            //graph.AddEdge(source, 1, 9);
            //graph.AddEdge(source, 4, 9);
            //graph.AddEdge(1, 2, 7);
            //graph.AddEdge(1, 3, 3);
            //graph.AddEdge(2, 3, 4);
            //graph.AddEdge(2, destination, 6);
            //graph.AddEdge(3, destination, 9);
            //graph.AddEdge(3, 5, 2);
            //graph.AddEdge(4, 3, 3);
            //graph.AddEdge(4, 5, 6);
            //graph.AddEdge(5, destination, 8);

            int size = 7;
            GraphMatrix graph = new GraphMatrix(size);
            int source = 0;
            int destination = size - 1;
            graph.AddEdge(source, 1, 4);
            graph.AddEdge(source, 2, 3);
            graph.AddEdge(1, 3, 4);
            graph.AddEdge(3, destination, 2);
            graph.AddEdge(2, 4, 6);
            graph.AddEdge(4, destination, 6);
            graph.AddEdge(3, 2, 3);
 

            MaximumFlow maximumFlow = new MaximumFlow();
            maximumFlow.Run(size, graph, source, destination);
            maximumFlow.PrintResult();
            maximumFlow.PrintAdvenced();
            Console.ReadKey();
        }
    }
}