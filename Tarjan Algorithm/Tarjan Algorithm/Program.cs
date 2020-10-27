using System;

namespace Tarjan_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            tree.AddNode(1, 0);
            tree.AddNode(6, 1);
            tree.AddNode(4, 1);
            tree.AddNode (2, 0);
            tree.AddNode(5, 2);
            tree.AddNode(3, 0);
            tree.AddNode(7, 6);
            tree.AddNode(8, 7);
            tree.OrderById();
            tree.PrintAllChildren();
            Console.WriteLine();

            NodeLinkRequests nodeLinkRequests = new NodeLinkRequests();
            nodeLinkRequests.AddRequest(6, 3);
            nodeLinkRequests.AddRequest(6, 4);
            nodeLinkRequests.AddRequest(7, 8);

            Tarjan tarjan = new Tarjan(tree, nodeLinkRequests);

            Console.ReadKey();
        }
    }
}
