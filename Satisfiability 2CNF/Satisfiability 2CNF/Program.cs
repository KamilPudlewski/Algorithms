using System;

namespace Satisfiability_2CNF
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] a = { 1, 2, 1 };
            //int[] b = { 2, -1, -2 };

            //int[] a = { 1, -1, 1, -1 };
            //int[] b = { 2, 2, -2, -2 };

            //int[] a = { 1, -1, -1, 1 };
            //int[] b = { -2, 2, -2, -3 };

            //int[] a = { 1, 1, 2, 2, 3, 1, 2, 3, 4, 5, 6, -1 };
            //int[] b = { 3, -4, -4, -5, -5, -6, -6, -6, -7, 7, 7, 7 };

            //int[] a = { 1, -1, 3, 3 };
            //int[] b = { 1, -1, -3, -2 };

            int[] a = { 1, -2, -1, 1 };
            int[] b = { 2, -3, 3, 3 };

            Satisfiability2CNF satisfiability2CNF = new Satisfiability2CNF(a, b);
            Console.ReadKey();
        }
    }
}
