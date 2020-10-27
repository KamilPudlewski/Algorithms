using System;
using System.Collections.Generic;
using System.Linq;

namespace Tarjan_Algorithm
{
    public class Tree
    {
        public List<Node> nodes = new List<Node>();
        public int root = 0;

        public Tree()
        {

        }

        public void AddNode(Node node)
        {
            if (!NodeExist(node.id))
            {
                nodes.Add(node);
            }
        }

        public void AddNode(int node)
        {
            if (!NodeExist(node))
            {
                nodes.Add(new Node(node));
            }
        }

        public void AddNode(int node, int root)
        {
            if (!NodeExist(node))
            {
                nodes.Add(new Node(node, root));
            }
            if (!NodeExist(root))
            {
                nodes.Add(new Node(root));
            }

            FindNodeById(root).children.Add(node);
        }

        public int NodeCount()
        {
            return nodes.Count;
        }

        public bool NodeExist(int id)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (id == nodes[i].id)
                {
                    return true;
                }
            }
            return false;
        }

        public Node FindNodeById(int id)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (id == nodes[i].id)
                {
                    return nodes[i];
                }
            }

            Console.WriteLine("Node not found!");
            return new Node(-1);
        }

        public void OrderById()
        {
            nodes = nodes.OrderBy(node => node.id).ToList();
        }

        public void PrintAllChildren()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.Write("Node " + nodes[i].id + " childerens: ");
                for (int j = 0; j < nodes[i].children.Count; j++)
                {
                    if (j != nodes[i].children.Count - 1)
                    {
                        Console.Write(nodes[i].children[j] + ", ");
                    }
                    else
                    {
                        Console.Write(nodes[i].children[j]);
                    }           
                }
                Console.WriteLine();
            }
        }

        public List<List<int>> ReturnChildren()
        {
            List<List<int>> children = new List<List<int>>();
            for (int i = 0; i < nodes.Count; i++)
            {
                children.Add(new List<int>());
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes[i].children.Count; j++)
                {
                    children[i].Add(nodes[i].children[j]);
                }
            }

            return children;
        }
    }

    public class Node
    {
        public int id = 0;
        public int root = 0;
        public bool visited = false;
        public List<int> children = new List<int>();

        public Node(int node)
        {
            id = node;
            root = node;
        }

        public Node(int node, int root)
        {
            id = node;
            this.root = root;
        }
    }

    public class NodeLink
    {
        public int node1;
        public int node2;

        public NodeLink(int node1, int node2)
        {
            this.node1 = node1;
            this.node2 = node2;
        }
    }

    public class NodeLinkRequests
    {
        public List<NodeLink> nodeLinks = new List<NodeLink>();

        public NodeLinkRequests()
        {

        }

        public void AddRequest(NodeLink nodeLink)
        {
            nodeLinks.Add(nodeLink);
        }

        public void AddRequest(int node1, int node2)
        {
            nodeLinks.Add(new NodeLink(node1, node2));
        }

        public int CheckRequest(int node)
        {
            

            for (int i = 0; i < nodeLinks.Count; i++)
            {
                if (node == nodeLinks[i].node1)
                {
                    return nodeLinks[i].node2;
                }
                else if (node == nodeLinks[i].node2)
                {
                    return nodeLinks[i].node1;
                }
            }
            return -1;
        }
    }
}
