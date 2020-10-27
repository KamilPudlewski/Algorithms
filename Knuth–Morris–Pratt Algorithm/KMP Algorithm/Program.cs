using System;

namespace KMP_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "oko";
            string text = "aaaaokoaaaaokaokobsako";

            KMP kmp = new KMP(pattern, text);
            kmp.PrintInputs();
            kmp.StartKMP();
            Console.ReadKey();
        }
    }
}
