using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heuristic_Queens_Puzzle
{
    public class Heuristic_Queens_Puzzle
    {
        private static int chessboardSize = 60;
        private int conflictsCounter = 0;
        private int lastConflictsCounter = 0;
        private int iterationNumber = 1;

        private List<int> column = new List<int>();
        private int[,] chessboard = new int[chessboardSize, chessboardSize];

        public Heuristic_Queens_Puzzle()
        {
            InitializeChessboard();
            InitializeQueens();

            TryHeuristicQueensPuzzle();
            PrintResult();
        }

        private void InitializeChessboard()
        {
            for (int i = 0; i < chessboardSize; i++)
            {
                column.Add(0);
            }
        }

        private void InitializeQueens()
        {
            List<int> tmpPosition = new List<int>();
            for (int i = 0; i < chessboardSize; i++)
            {
                tmpPosition.Add(i);
            }
            List<int> shufflePositions = tmpPosition.OrderBy(a => Guid.NewGuid()).ToList();


            for (int i = 0; i < chessboardSize; i++)
            {
                column[i] = shufflePositions[i];
            }
        }

        private void TryHeuristicQueensPuzzle()
        {
            conflictsCounter = CountConflicts();
            Console.WriteLine("Starting queens setting contains " + conflictsCounter + " conflicts!");
            PrintResult();

            if (conflictsCounter != 0)
            {
                do
                {
                    lastConflictsCounter = conflictsCounter;
                    for (int i = 0; i < chessboardSize; i++)
                    {
                        for (int j = 0; j < chessboardSize; j++)
                        {
                            int conflictsBefore = CountConflicts();
                            
                            if (IsAttack(i) || IsAttack(j))
                            {
                                ChangeQueens(i, j);
                                conflictsCounter = CountConflicts();

                                if (conflictsBefore < CountConflicts())
                                {
                                    ChangeQueens(i, j);
                                    conflictsCounter = CountConflicts();
                                }
                            }
                        }
                    }
                    Console.WriteLine("After iteration " + iterationNumber + " found " + conflictsCounter + " conflicts!");
                    iterationNumber++;
                }
                while ((lastConflictsCounter != conflictsCounter) && conflictsCounter != 0);
            }
        }

        private void ChangeQueens(int quenn1, int quenn2)
        {
            int tmp = column[quenn1];
            column[quenn1] = column[quenn2];
            column[quenn2] = tmp;
        }

        private bool IsAttack(int queen)
        {
            for (int i = 0; i < chessboardSize; i++)
            {
                if (i - column[i] == queen - column[queen] || i + column[i] == queen + column[queen])
                {
                    if (i != queen)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int CountConflicts()
        {
            int conflicts = 0;

            for (int i = 0; i < chessboardSize; i++)
            {
                for (int j = 0; j < chessboardSize; j++)
                {
                    if (i - column[i] == j - column[j] || i + column[i] == j + column[j])
                    {
                        if (i != j)
                        {
                            conflicts++;
                        }
                    }
                }
            }

            return conflicts;
        } 

        public void PrintResult()
        {
            int queen = 1;
            ClearChessboard();

            for (int i = 0; i < column.Count; i++)
            {
                chessboard[i, column[i]] = queen;
                queen++;
            }
            PrintMatrix();
            Console.WriteLine();
        }

        public void ClearChessboard()
        {
            for (int i = 0; i < chessboardSize; i++)
            {
                for (int j = 0; j < chessboardSize; j++)
                {
                    chessboard[i, j] = 0;
                }
            }
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < chessboard.Length / chessboardSize; i++)
            {
                for (int j = 0; j < chessboard.Length / chessboardSize; j++)
                {
                    if (chessboard[i, j] < 10)
                    {
                        Console.Write(chessboard[i, j] + "  ");
                    }
                    else
                    {
                        Console.Write(chessboard[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
