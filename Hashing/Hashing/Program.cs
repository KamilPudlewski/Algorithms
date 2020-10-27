using System;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######################### TEST 1: 250 HASH SIZE #########################");
            HashTest hashTest = new HashTest(250);
            hashTest.TestHashAdd(200);
            //hashTest.PrintHash();
            hashTest.HashFind(100);

            Console.WriteLine("######################### TEST 2: 500 HASH SIZE #########################");
            hashTest = new HashTest(500);
            hashTest.TestHashAdd(200);
            //hashTest.PrintHash();
            hashTest.HashFind(100);

            Console.WriteLine("######################### TEST 3: 1000 HASH SIZE #########################");
            hashTest = new HashTest(1000);
            hashTest.TestHashAdd(200);
            //hashTest.PrintHash();
            hashTest.HashFind(100);

            Console.WriteLine("######################### TEST 4: 1000 HASH SIZE #########################");
            hashTest = new HashTest(10000);
            hashTest.TestHashAdd(200);
            //hashTest.PrintHash();
            hashTest.HashFind(100);

            //Hashing hashing = new Hashing();
            //hashing.Insert(321);
            //hashing.Insert(512);
            //hashing.Insert("Napis");
            //hashing.Insert("Ala ma kota");

            //Person andrzej = new Person("Andrzej K", 28);
            //hashing.Insert(andrzej);

            //Person janusz = new Person("Janusz K", 28);
            //hashing.Insert(janusz);

            //hashing.PrintHash();

            //Random random = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    hashing.Insert(i);
            //}
            //hashing.PrintHash();


            //hashing.HashSearchFirst("Napis");
            //hashing.HashSearchFirst(321);
            //hashing.HashSearchLast(321);
            //hashing.Delete(321);
            //hashing.HashSearchFirst(8);
            //hashing.PrintHash();

            //for (int i = 0; i < 10; i++)
            //{
            //    hashing.Delete(i);
            //}
            //hashing.PrintHash();

            ////hashing.HashSearchLast("a");
            ////hashing.Delete("a");
            ////hashing.Delete("a");
            ////hashing.Delete("a");
            ////hashing.Delete("a");
            ////hashing.Delete("a");
            ////hashing.Delete("a");
            ////hashing.Delete("a");
            ////hashing.Delete("a");
            ////hashing.Delete("a");

            ////hashing.PrintHash();
            ////hashing.HashSearchLast("a");

            //hashing.Insert("It works!");
            //hashing.PrintHash();

            Console.ReadKey();
        }
    }
}
