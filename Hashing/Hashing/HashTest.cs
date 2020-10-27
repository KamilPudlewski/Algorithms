using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hashing
{
    public class HashTest
    {
        public Hashing hashing;
        private string[] persons;
        private string[] usedDataset;
        private string[] unusedDataset;
        private int startHashSize = 100;

        public HashTest()
        {
            hashing = new Hashing(startHashSize);
            LoadPersonsData();
            Prepare2Datasets();
        }

        public HashTest(int startHashSize)
        {
            this.startHashSize = startHashSize;
            hashing = new Hashing(startHashSize);
            LoadPersonsData();
            Prepare2Datasets();
        }

        private void LoadPersonsData()
        {
            string[] loadedPersons = System.IO.File.ReadAllLines(@"..\..\..\..\Data\Persons.txt");
            persons = loadedPersons;
        }

        private void Prepare2Datasets()
        {
            int totalRows = persons.Length;
            int halfway = totalRows / 2;
            usedDataset = persons.Select(x => x).Take(halfway).ToArray();
            unusedDataset = persons.AsEnumerable().Skip(halfway).Take(totalRows - halfway).ToArray();
        }

        public int TestHashAdd(int elements)
        {
            if (usedDataset.Length - elements < 0)
            {
                Console.WriteLine("Error! Try insert too many elements");
                return -1;
            }

            int sum = 0;
            int maximalConflicts = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < elements; i++)
            {
                int result = hashing.Insert(usedDataset[i]);
                CheckMaxConflicts(ref maximalConflicts, result);

                sum += result;
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Added " + elements + " elements successfully to " + hashing.GetHashSize() + " hash table!");
            Console.WriteLine("Adding time: " + elapsedMs + " milliseconds");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Confilicts count: " + sum);
            Console.WriteLine("Maximal confilicts: " + maximalConflicts);
            Console.ResetColor();
            Console.WriteLine();

            return 0;
        }

        public void HashFind(int elements)
        {
            int foundElements = 0;
            int notFoundElements = 0;
            int sumConflictsFoundElements = 0;
            int sumConflictsNotFoundElements = 0;
            int maximalConflicts = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < elements; i++)
            {
                Tuple<int, int> result;
                if (i < elements/2)
                {
                    result = hashing.HashSearchFirst(usedDataset[i]);

                    if (result.Item1 > 0)
                    {
                        sumConflictsFoundElements += result.Item2;
                        CheckMaxConflicts(ref maximalConflicts, result.Item2);
                    }
                    else
                    {
                        sumConflictsNotFoundElements += result.Item2;
                        CheckMaxConflicts(ref maximalConflicts, result.Item2);
                    }
                }
                else
                {
                    result = hashing.HashSearchFirst(unusedDataset[i - elements / 2]);
                    if (result.Item1 > 0)
                    {
                        sumConflictsFoundElements += result.Item2;
                        CheckMaxConflicts(ref maximalConflicts, result.Item2);
                    }
                    else
                    {
                        sumConflictsNotFoundElements += result.Item2;
                        CheckMaxConflicts(ref maximalConflicts, result.Item2);
                    }
                }

                if (result.Item1 > 0)
                {
                    foundElements++;
                }
                else
                {
                    notFoundElements++;
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            if (foundElements == elements/2 && notFoundElements == elements / 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hash Find Test Correct Passed");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hash Find Test Failed");
            }
            Console.WriteLine("Found elements: " + foundElements + "/" + elements/2 + " , not founds elements: " + notFoundElements + "/" + elements/2);
            Console.ResetColor();

            Console.WriteLine("Time: " + elapsedMs + " milliseconds");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Confilicts count found elements: " + sumConflictsFoundElements);
            Console.WriteLine("Confilicts count not found elements: " + sumConflictsNotFoundElements);
            int totalConflicts = sumConflictsFoundElements + sumConflictsNotFoundElements;
            Console.WriteLine("Total confilicts count: " + totalConflicts);
            Console.WriteLine("Average confilicts: " + (double)totalConflicts/elements);
            Console.WriteLine("Maximal confilicts: " + maximalConflicts);
            Console.ResetColor();
            Console.WriteLine();
        }

        private void CheckMaxConflicts(ref int maximalConflicts, int newConflicts)
        {
            if (maximalConflicts < newConflicts)
            {
                maximalConflicts = newConflicts;
            }
        }

        public void PrintHash()
        {
            hashing.PrintHash();
        }
    }
}
