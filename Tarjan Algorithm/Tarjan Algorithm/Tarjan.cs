using System;
using System.Collections.Generic;
using System.Text;

namespace Tarjan_Algorithm
{
    public class Tarjan
    {
        private Tree tree;
        private List<int> ancestor = new List<int>(); // Node root
        private List<List<int>> children; // Children nodes
        private List<bool> visited = new List<bool>();
        private NodeLinkRequests nodeLinkRequests;

        private int[] count;
        private int[] name;
        private int[] parent;
        private int[] root;

        public Tarjan(Tree tree, NodeLinkRequests nodeLinkRequests)
        {
            this.tree = tree;
            this.nodeLinkRequests = nodeLinkRequests;
            Initialize();
            TarjanStart(tree.root);
        }

        void TarjanStart(int u)
        {
            MakeSet(u);
            ancestor[u] = u;
            for (int i = 0; i < children[u].Count; i++)
            {
                int v = children[u][i];
                TarjanStart(v);
                Union(u, v);
                ancestor[Find(u)] = u;
            }
            visited[u] = true;

            // Check if v is on request list
            for (int i = 0; i < nodeLinkRequests.nodeLinks.Count; i++)
            {
                int v = -1;
                if (nodeLinkRequests.nodeLinks[i].node1 == u)
                {
                    v = nodeLinkRequests.nodeLinks[i].node2;
                }
                else if (nodeLinkRequests.nodeLinks[i].node2 == u)
                {
                    v = nodeLinkRequests.nodeLinks[i].node1;
                }

                if (v == -1)
                {
                    continue;
                }
                else if (visited[v] == true)
                {
                    Console.WriteLine("Common ancestor " + u + " and " + v + " is: " + ancestor[Find(v)]);
                }
            }
        }

        void Initialize()
        {
            for (int i = 0; i < tree.NodeCount(); i++)
            {
                ancestor.Add(0);
                children = tree.ReturnChildren();
                visited.Add(false);
            }

            // Union-Find Init
            count = new int[tree.NodeCount()];
            name = new int[tree.NodeCount()];
            parent = new int[tree.NodeCount()];
            root = new int[tree.NodeCount()];
            for (int i = 0; i < tree.NodeCount(); i++)
            {
                count[i] = 1;
                name[i] = i;
                parent[i] = -1;
                root[i] = i;
            }
        }

        void MakeSet(int x)
        {
            parent[x] = -1;
            count[x] = 1;
        }

        void Union(int i, int j)
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

        int Find(int i)
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
    }
}