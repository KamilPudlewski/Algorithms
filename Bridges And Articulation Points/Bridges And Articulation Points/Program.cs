using System;

namespace Bridges_And_Articulation_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            //GraphMatrix graph = new GraphMatrix(6);
            //graph.AddEdgeN(0, 1);
            //graph.AddEdgeN(3, 0);
            //graph.AddEdgeN(1, 2);
            //graph.AddEdgeN(2, 3);
            //graph.AddEdgeN(3, 4);
            //graph.AddEdgeN(1, 5);

            GraphMatrix graph = new GraphMatrix(15);
            graph.AddEdgeN(0, 1);
            graph.AddEdgeN(1, 3);
            graph.AddEdgeN(1, 4);
            graph.AddEdgeN(2, 4);
            graph.AddEdgeN(2, 5);
            graph.AddEdgeN(3, 4);
            graph.AddEdgeN(3, 7);
            graph.AddEdgeN(4, 6);
            graph.AddEdgeN(5, 6);
            graph.AddEdgeN(7, 8);
            graph.AddEdgeN(7, 9);
            graph.AddEdgeN(7, 10);
            graph.AddEdgeN(9, 10);
            graph.AddEdgeN(9, 11);
            graph.AddEdgeN(10, 13);
            graph.AddEdgeN(11, 12);
            graph.AddEdgeN(12, 13);

            //GraphMatrix graph = new GraphMatrix(7);
            //graph.AddEdgeN(0, 1);
            //graph.AddEdgeN(0, 3);
            //graph.AddEdgeN(0, 5);
            //graph.AddEdgeN(0, 6);
            //graph.AddEdgeN(1, 4);
            //graph.AddEdgeN(1, 5);
            //graph.AddEdgeN(4, 5);
            //graph.AddEdgeN(2, 3);
            //graph.AddEdgeN(2, 6);
            //graph.AddEdgeN(3, 6);

            Bridges bridges = new Bridges(graph);
            bridges.FindBridges();
            bridges.PrintBridges();

            ArticulationPoints articulationPoints = new ArticulationPoints(graph);
            articulationPoints.FindArticulationPoints();
            articulationPoints.PrintArticulationPoints();

            Console.ReadKey();
        }
    }
}
