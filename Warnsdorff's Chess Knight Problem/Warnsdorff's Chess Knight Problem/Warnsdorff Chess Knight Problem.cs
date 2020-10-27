using System;
using System.Collections.Generic;
using System.Text;

namespace Warnsdorff_s_Chess_Knight_Problem
{
    public class Warnsdorff_Chess_Knight_Problem
    {
        private static int chessboardSize = 10;
        private List<int> knightMovesX = new List<int>{ 1, 1, 2, 2, -1, -1, -2, -2 };
        private List<int> knightMovesY = new List<int> { 2, -2, 1, -1, 2, -2, 1, -1 };
        private int[,] chessboard = new int[chessboardSize, chessboardSize];
        private int[,] availableMoves = new int[chessboardSize, chessboardSize];
        private bool backwardStatus = false;
        List<int> movesIndicator = new List<int>();

        private int startPositionX = 0;
        private int startPositionY = 0;
        private int newPointsCounter = 0;

        // Choose method true = True Wansdorff Random Moves else Sorted Moves
        private bool trueWarnsdorffMethod = false;

        public Warnsdorff_Chess_Knight_Problem()
        {
            if (chessboardSize < 5)
            {
                Console.WriteLine("No solutions.");
                return;
            }

            PrepareData();
            StartWarnsdorffMethod();
            PrintMatrix(chessboard);
        }

        private void PrepareData()
        {
            InitiateChessboard();
            InitiateAvailableMoves();
        }

        private void InitiateChessboard()
        {
            // Inside Value
            for (int i = 0; i < chessboardSize; i++)
            {
                for (int j = 0; j < chessboardSize; j++)
                {
                    chessboard[i, j] = 0;
                }
            }
        }

        private void InitiateAvailableMoves()
        {
            for (int i = 0; i < chessboardSize; i++)
            {
                for (int j = 0; j < chessboardSize; j++)
                {
                    // Value 2
                    if ((i == 0 || i == chessboardSize - 1) && (j == 0 || j == chessboardSize - 1))
                    {
                        availableMoves[i, j] = 2;
                    }

                    // Value 3
                    else if ((i == 0 || i == chessboardSize - 1) && (j == 1 || j == chessboardSize - 2))
                    {
                        availableMoves[i, j] = 3;
                    }
                    else if ((j == 0 || j == chessboardSize - 1) && (i == 1 || i == chessboardSize - 2))
                    {
                        availableMoves[i, j] = 3;
                    }

                    // Value 4
                    else if ((i == 0 || i == chessboardSize - 1) && (j > 1 && j < chessboardSize - 2))
                    {
                        availableMoves[i, j] = 4;
                    }
                    else if ((j == 0 || j == chessboardSize - 1) && (i > 1 && i < chessboardSize - 2))
                    {
                        availableMoves[i, j] = 4;
                    }
                    else if ((i == 1 || i == chessboardSize - 2) && (j == 1 || j == chessboardSize - 2))
                    {
                        availableMoves[i, j] = 4;
                    }

                    // Value 6
                    else if ((i == 1 || i == chessboardSize - 2) && (j > 1 && j < chessboardSize - 2))
                    {
                        availableMoves[i, j] = 6;
                    }
                    else if ((j == 1 || j == chessboardSize - 2) && (i > 1 && i < chessboardSize - 2))
                    {
                        availableMoves[i, j] = 6;
                    }

                    //Value 8
                    else
                    {
                        availableMoves[i, j] = 8;
                    }
                }
            }
        }

        private void StartWarnsdorffMethod()
        {
            int moveNumber = 1;
            SetKnight(startPositionX, startPositionY, ref moveNumber);
            int x = startPositionX;
            int y = startPositionY;
            
            do
            {
                if (!backwardStatus)
                {
                    TryBestNextMove(ref x, ref y, ref moveNumber);
                }
                else
                {
                    newPointsCounter++;
                    PrepareData();
                    backwardStatus = false;
                    moveNumber = 1;
                    Random random = new Random();
                    x = random.Next(0, chessboardSize);
                    y = random.Next(0, chessboardSize);
                    SetKnight(x, y, ref moveNumber);
                }
            }
            while (moveNumber <= chessboardSize * chessboardSize);
        }

        private void SetKnight(int x, int y, ref int moveNumber)
        {
            chessboard[x, y] = moveNumber;
            moveNumber++;
            UpdateNeighbors(x, y);
        }

        private void TryBestNextMove(ref int x, ref int y, ref int moveNumber)
        {
            List<Tuple<int, int>> neighbors = GetNeighbors(x, y);

            if (neighbors.Count == 0)
            {
                backwardStatus = true;
            }
            else if (neighbors.Count == 1)
            {
                x = neighbors[0].Item1;
                y = neighbors[0].Item2;
                SetKnight(x, y, ref moveNumber);
                backwardStatus = false;
            }
            else
            {
                Tuple<int, int> result;
                if (trueWarnsdorffMethod)
                {
                    result = GetBestRandomNeighbors(neighbors);
                }
                else
                {
                    result = GetBestNeighbors(neighbors);
                }
                x = result.Item1;
                y = result.Item2;
                SetKnight(x, y, ref moveNumber);
                backwardStatus = false;
            }
        }

        private List<Tuple<int, int>> GetNeighbors(int x, int y)
        {
            List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();

            for (int i = 0; i < 8; i++)
            {
                int positionX = x + knightMovesX[i];
                int positionY = y + knightMovesY[i];

                if ((positionX >= 0 && positionX < chessboardSize) && (positionY >= 0 && positionY < chessboardSize))
                {
                    if (chessboard[positionX, positionY] == 0)
                    {
                        neighbors.Add(new Tuple<int, int>(positionX, positionY));
                    }
                }
            }
            return neighbors;
        }

        private Tuple<int, int> GetBestNeighbors(List<Tuple<int, int>> neighbors)
        {
            int bestIndex = 0;
            int lowerAvailableMoves = availableMoves[neighbors[0].Item1, neighbors[0].Item2];

            for (int i = 0; i < neighbors.Count; i++)
            {
                if (availableMoves[neighbors[i].Item1, neighbors[i].Item2] < lowerAvailableMoves)
                {
                    lowerAvailableMoves = availableMoves[neighbors[i].Item1, neighbors[i].Item2];
                    bestIndex = i;
                }
            }
            return neighbors[bestIndex];
        }

        private Tuple<int, int> GetBestRandomNeighbors(List<Tuple<int, int>> neighbors)
        {
            int bestIndex = 0;
            int lowerAvailableMoves = availableMoves[neighbors[0].Item1, neighbors[0].Item2];
            List<int> bestIndexes = new List<int>();

            for (int i = 0; i < neighbors.Count; i++)
            {
                if (availableMoves[neighbors[i].Item1, neighbors[i].Item2] <= lowerAvailableMoves)
                {
                    lowerAvailableMoves = availableMoves[neighbors[i].Item1, neighbors[i].Item2];
                    bestIndex = i;
                }
            }

            for (int i = 0; i < neighbors.Count; i++)
            {
                if (availableMoves[neighbors[i].Item1, neighbors[i].Item2] == lowerAvailableMoves)
                {
                    bestIndexes.Add(i);
                }
            }

            Random random = new Random();
            int randomBestindex = random.Next(bestIndexes.Count);

            return neighbors[bestIndexes[randomBestindex]];
        }

        private void UpdateNeighbors(int x, int y)
        {
            for (int i = 0; i < 8; i++)
            {
                int positionX = x + knightMovesX[i];
                int positionY = y + knightMovesY[i];

                if ((positionX >= 0 && positionX < chessboardSize) && (positionY >= 0 && positionY < chessboardSize))
                {
                    availableMoves[positionX, positionY]--;
                }
            }
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] < 10)
                    {
                        Console.Write(matrix[i, j] + "   ");
                    }
                    else if (matrix[i, j] < 100)
                    {
                        Console.Write(matrix[i, j] + "  ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("New point selected: " + newPointsCounter + " times.");
        }
    }
}