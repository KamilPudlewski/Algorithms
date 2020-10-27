using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfiability_2CNF
{
    public class Satisfiability2CNF
    {
        private GraphMatrix graphMatrix;
        private List<List<int>> stronglyConsistentComponents = new List<List<int>>();
        private int size;

        bool[] visited;
        Stack<int> stack = new Stack<int>();
        int[] logicalValues;

        public Satisfiability2CNF(int[] a, int[] b)
        {
            size = CountSize(a, b);
            graphMatrix = new GraphMatrix(size * 2);
            graphMatrix.CreateImplicationGraph(a, b, size);
            Initialize();
            IsSatisfiability();
        }

        private int CountSize(int[] a, int[] b)
        {
            List<int> numbers = new List<int>();
            
            for (int i = 0; i < a.Length; i++)
            {
                if (!numbers.Contains(Math.Abs(a[i])))
                {
                    numbers.Add((Math.Abs(a[i])));
                }

                if (!numbers.Contains(Math.Abs(b[i])))
                {
                    numbers.Add((Math.Abs(b[i])));
                }
            }
            return numbers.Count;
        }

        private void Initialize()
        {
            visited = new bool[graphMatrix.size];
            for (int i = 0; i < graphMatrix.size; i++)
            {
                stronglyConsistentComponents.Add(new List<int>());
                visited[i] = false;
            }
        }

        private void IsSatisfiability()
        {
            StronglyConsistentComponents();

            for (int i = 0; i < size; i++)
            {
                int negativeI = i + size;
                for (int v = 0; v < stronglyConsistentComponents.Count; v++)
                {
                    if (stronglyConsistentComponents[v].Contains(i) && stronglyConsistentComponents[v].Contains(negativeI))
                    {
                        Console.WriteLine("The given expression is unsatisfiable");
                        return;
                    }
                }
            }
            Console.WriteLine("The given expression is satisfiable");
            Console.WriteLine();

            TestSatisfiability();
        }

        private void StronglyConsistentComponents()
        {
            for (int v = 0; v < graphMatrix.size; v++)
            {
                if (visited[v] == false)
                {
                    DFSStack(v);
                }
            }

            graphMatrix.Transpose();
            FillVisitedFalse();
            int counter = 0;

            while (stack.Count != 0)
            {
                int v = stack.Peek();
                stack.Pop();

                if (visited[v])
                    continue;

                Console.WriteLine("SCC " + counter + " : ");
                DFSSprint(v, counter);
                counter++;
            }
        }

        private void FillVisitedFalse()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
        }

        private void DFSStack(int v)
        {
            visited[v] = true;
            foreach (int u in graphMatrix.GetNeighbours(v))
            {
                if (visited[u] == false)
                {
                    DFSStack(u);
                }
            }
            stack.Push(v);
        }

        private void DFSSprint(int v, int counter)
        {
            visited[v] = true;
            Console.WriteLine(v);

           stronglyConsistentComponents[FindIndex(counter)].Add(v);
           foreach (int u in graphMatrix.GetNeighbours(v))
           {
                if (visited[u] == false)
                {
                    DFSSprint(u, counter);
                }
           }
        }

        private int FindIndex(int value)
        {
            for(int i = 0; i < stronglyConsistentComponents.Count; i++)
            {
                if (i == value)
                {
                    return i;
                }
            }
            Console.WriteLine("Error! Bad Index!");
            return -1;
        }

        private void TestSatisfiability()
        {
            int[] logicalValues = CalculateLogicalValues();

            for (int i = 0; i < logicalValues.Length; i++)
            {
                if (i < size)
                {
                    Console.WriteLine("Value for " + (i + 1) + " = " + logicalValues[i]);
                }
                else
                {
                    int tmp = i - size;
                    Console.WriteLine("Value for !" + (tmp + 1) + " = " + logicalValues[i]);
                }
            }
        }

        private int[] CalculateLogicalValues()
        {
            logicalValues = new int[size * 2];
            
            for (int i = 0; i < (size * 2); i++)
            {
                logicalValues[i] = 0;
            }
            int offset = size;
            foreach (var component in stronglyConsistentComponents)
            {
                if (CheckAssignment(component))
                {
                    int anyValue = AnyValueV(component);
                    foreach (int variable in component)
                    {
                        if (logicalValues[variable].Equals(0))
                        {
                            logicalValues[variable] = anyValue;
                        }
                    }
                }
                else
                {
                    foreach (int variable in component)
                    {
                        logicalValues[variable] = -1;
                        // Nagation
                        if (variable >= offset)
                        {
                            logicalValues[variable - offset] = 1;
                        }
                        else
                        {
                            logicalValues[variable + offset] = 1;
                        }
                    }
                }
            }
            return logicalValues;
        }

        private bool CheckAssignment(List<int> component)
        {
            foreach (var element in component)
            {
                if (!logicalValues[element].Equals(0))
                {
                    return true;
                }
            }
            return false;
        }

        private int AnyValueV(List<int> component)
        {
            int result = 0;
            foreach (var element in component)
            {
                if (!logicalValues[element].Equals(0))
                {
                    result = logicalValues[element];
                    return result;
                }
            }
            return result;
        }
    }
}
