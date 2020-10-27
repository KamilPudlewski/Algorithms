using System;
using System.Collections.Generic;
using System.Text;

namespace Maximum_Flow_Problem
{
    public class MaximumFlow
    {
        private int maximumFlow = 0;
        private GraphMatrix result;

        public MaximumFlow()
        {

        }

        public void Run(int size, GraphMatrix graph, int source, int destination)
        {
            maximumFlow = 0;
            result = new GraphMatrix(size);
            int[] ancestors = new int[size];
            int[] cfp = new int[size];
            Stack<int> queue = new Stack<int>();

            while(true)
            {
                for (int i = 0; i < size; i++)
                {
                    ancestors[i] = -1;
                }
                ancestors[source] = -2;
                cfp[source] = int.MaxValue;
                while (queue.Count != 0)
                {
                    queue.Pop();
                }
                queue.Push(source);
                bool finishFlag = false;
                while (queue.Count != 0)
                {
                    int vertice = queue.Pop();
                    for (int i = 0; i < size; i++)
                    {
                        int cost = graph.GetValue(vertice, i) - result.GetValue(vertice, i);
                        if (cost.Equals(0) || !ancestors[i].Equals(-1))
                            continue;

                        ancestors[i] = vertice;
                        cfp[i] = Math.Min(cfp[vertice], cost);
                        if (i == destination)
                        {
                            maximumFlow += cfp[destination];
                            int tmp = destination;
                            while (!tmp.Equals(source))
                            {
                                int w = ancestors[tmp];
                                result.AddEdge(w, tmp, result.GetValue(w, tmp) + cfp[destination]);
                                result.AddEdge(tmp, w, result.GetValue(tmp, w) - cfp[destination]);
                                tmp = w;
                            }
                            finishFlag = true;
                        }
                        queue.Push(i);
                    }
                    if (finishFlag)
                    {
                        break;
                    }
                }
                if (!finishFlag)
                {
                    break;
                }
            }
        }

        public void PrintResult()
        {
            Console.WriteLine("Maximum flow is: " + maximumFlow);
            Console.WriteLine(result.Print());
        }

        public void PrintAdvenced()
        {
            List<Tuple<int, int>> tmp = new List<Tuple<int, int>>();

            for (int i = 0; i < result.size; i++)
            {
                for (int j = 0; j < result.size; j++)
                {
                    if (result.graph[i, j] != 0)
                    {
                        tmp.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

        }
    }
}
