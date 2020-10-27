using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    public class Program
    {
        public static void Main()
        {
            Permutation permutation = new Permutation(1, 3);
            permutation.StartPermute();

            Console.ReadKey();
        }
    }
}
