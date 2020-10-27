using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Knight_Problem
{
    public class ChessKnightProblem
    {
        private bool status = false;
        private static int chessboardSize = 6;
        private int[,] chessboard = new int[chessboardSize, chessboardSize];
        private List<int> knightMovesX = new List<int>();
        private List<int> knightMovesY = new List<int>();
        private List<int[,]> result = new List<int[,]>();

        private int startPositionX = 0;
        private int startPositionY = 0;

        public ChessKnightProblem()
        {
            for (int i = 0; i < 8; i++)
            {
                knightMovesX.Add(0);
                knightMovesY.Add(0);
            }

            // Possible Moves
            knightMovesX[0] = 2; knightMovesY[0] = 1;
            knightMovesX[1] = 1; knightMovesY[1] = 2;
            knightMovesX[2] = -1; knightMovesY[2] = 2;
            knightMovesX[3] = -2; knightMovesY[3] = 1;
            knightMovesX[4] = -2; knightMovesY[4] = -1;
            knightMovesX[5] = -1; knightMovesY[5] = -2;
            knightMovesX[6] = 1; knightMovesY[6] = -2;
            knightMovesX[7] = 2; knightMovesY[7] = -1;

            StartChessKnightProblem();
        }

        public void StartChessKnightProblem()
        {
            // Initiate Chessboard
            for (int i = 0; i < chessboardSize; i++)
            {
                for (int j = 0; j < chessboardSize; j++)
                {
                    chessboard[i, j] = 0;
                }
            }

            chessboard[startPositionX, startPositionY] = 1;

            TryNextMove(2, startPositionX, startPositionY, ref status);

            if (status)
            {
                Console.WriteLine("Result moves matrix: ");
                PrintMatrix();
            }
            else
            {
                Console.WriteLine("No solutions");
            }
        }

        private void TryNextMove(int counter, int x, int y, ref bool status)
        {
            int u, v = 0;
            int k = -1;
            do
            {
                k = k + 1;
                u = x + knightMovesX[k];
                v = y + knightMovesY[k];

                if ((0 <= u && u < chessboardSize) && (0 <= v  && v < chessboardSize) && (chessboard[u, v] == 0))
                {
                    chessboard[u, v] = counter;
                    if (counter < chessboardSize * chessboardSize)
                    {
                        TryNextMove(counter + 1, u, v, ref status);
                        if (!status)
                        {
                            chessboard[u, v] = 0;
                        }
                    }
                    else
                    {
                        status = true;
                    }
                }
            }
            while (!status && k != 7);
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