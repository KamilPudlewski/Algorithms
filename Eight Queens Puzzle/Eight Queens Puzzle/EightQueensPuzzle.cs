using System;
using System.Collections.Generic;
using System.Text;

namespace Eight_Queens_Puzzle
{
    public class EightQueensPuzzle
    {
        private static int n = 8;
        private bool status = false;

        private List<int> column = new List<int>();
        private List<bool> row = new List<bool>();
        private List<bool> firstDiagonal = new List<bool>();
        private List<bool> secondDiagonal = new List<bool>();

        private int[,] result = new int[n,n];

        public EightQueensPuzzle()
        {
            for (int i = 0; i < n; i++)
            {
                column.Add(0);
                row.Add(true);
            }

            for (int i = 0; i < 2 * n - 1; i++)
            {
                firstDiagonal.Add(true);
                secondDiagonal.Add(true);
            }

            Try8Q(0, ref status);
            Console.WriteLine("Queens position matrix:");
            PrintResult();
        }

        private void Try8Q(int i, ref bool status)
        {
            int j = -1;
            do
            {
                j = j + 1;
                status = false;

                if (row[j] && firstDiagonal[i + j] && secondDiagonal[i - j + n - 1])
                {
                    column[i] = j;
                    row[j] = false;
                    firstDiagonal[i + j] = false;
                    secondDiagonal[i - j + n - 1] = false;

                    if (i < n - 1)
                    {
                        Try8Q(i + 1, ref status);
                        if (!status)
                        {
                            row[j] = true;
                            firstDiagonal[i + j] = true;
                            secondDiagonal[i - j + n - 1] = true;
                        }
                    }
                    else
                    {
                        status = true;
                    }
                }
            }
            while (!status && j != n - 1);
        }

        public void PrintResult()
        {
            int queen = 1;

            for (int i = 0; i < column.Count; i++)
            {
                result[i, column[i]] = queen;
                queen++;
            }
            PrintMatrix();
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < result.Length / n; i++)
            {
                for (int j = 0; j < result.Length / n; j++)
                {
                    if (result[i, j] < 10)
                    {
                        Console.Write(result[i, j] + "  ");
                    }
                    else
                    {
                        Console.Write(result[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
