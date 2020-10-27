using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Hashing
{
    public class Hashing
    {
        private object[] hash;
        private int startHashSize = 10;
        private object infinity = "-inf";
        private int size = 0;
        private bool debug = false;
              
        public Hashing()
        {
            InitializeHash();
        }

        public Hashing(int size)
        {
            startHashSize = size;
            InitializeHash();
        }

        private void InitializeHash()
        {
            hash = new object[startHashSize];
        }

        private int OpenHashFunction(object obj, int counter)
        {
            if (obj.GetType() == typeof(string))
            {
                return (HashFunction((string)obj) + counter * HashFunction((string)obj)) % hash.Length;
            }
            else if (obj.GetType() == typeof(char))
            {
                return (HashFunction((string)obj) + counter * HashFunction((string)obj)) % hash.Length;
            }
            else if (obj.GetType() == typeof(int))
            {
                return (HashFuntionNumber((int)obj) + counter * HashFuntionNumber((int)obj)) % hash.Length;
            }
            else if (obj.GetType() == typeof(short))
            {
                return Math.Abs((int)obj * 265443576) % hash.Length;
            }
            else if (obj.GetType() == typeof(long))
            {
                return Math.Abs((int)obj * 265443576) % hash.Length;
            }
            else if (obj.GetType() == typeof(float))
            {
                return Math.Abs((int)obj * 265443576) % hash.Length;
            }
            else if (obj.GetType() == typeof(double))
            {
                return Math.Abs((int)obj * 265443576) % hash.Length;
            }
            else if (obj.GetType() == typeof(byte))
            {
                return Math.Abs((int)obj * 265443576) % hash.Length;
            }          
            else
            {
                int sum = 0;
                Type objType = obj.GetType();
                IList<PropertyInfo> properties = new List<PropertyInfo>(objType.GetProperties());

                foreach (PropertyInfo prop in properties)
                {
                    object propValue = prop.GetValue(obj, null);
                    sum += OpenHashFunction(propValue, counter);
                }

                return (HashFuntionNumber((int)sum) + counter * HashFuntionNumber((int)sum)) % hash.Length;
            }
        }

        private int HashFunction(string str)
        {
            int sumAscii = 0;
            for (int i = 0; i < str.Length; i++)
            {
                sumAscii += (sumAscii << 5 + sumAscii) + (int)str[i];
            }
            int result = (int) (hash.Length * (Math.Abs(sumAscii) * B() % 1));

            return result;
        }

        private int HashFuntionNumber(int number)
        {
            int result = (int)(hash.Length * (number * B() % 1));

            return result;
        }

        private double B()
        {
            return (Math.Sqrt(5) - 1) / 2;
        }

        public int Insert(object obj)
        {
            int counter = 0;

            if (size > hash.Length * 0.8)
            {
                Console.WriteLine("Hash overflow, size increase!");
                IncreaseHashSize();
            }

            while (counter != hash.Length)
            {
                int tableIndex = OpenHashFunction(obj, counter * counter);
                if (hash[tableIndex] == null || hash[tableIndex] == infinity)
                {
                    hash[tableIndex] = obj;
                    size++;
                    if (debug)
                    {
                        Console.WriteLine("Insert " + obj + " conflicts: " + counter);
                    }
                    return counter;
                }
                else
                {
                    counter++;
                }
            }

            return -1;
        }

        public void IncreaseHashSize()
        {
            object[] tmpHash = hash;

            object[] newHash = new object[2*hash.Length];
            hash = newHash;
            size = 0;

            for (int i = 0; i < tmpHash.Length; i++)
            {
                if (tmpHash[i] != null && tmpHash[i] != infinity)
                {
                    Insert(tmpHash[i]);
                }
            }
        }

        public void DecreaseHashSize()
        {
            object[] tmpHash = hash;

            object[] newHash = new object[(int)(0.5 * hash.Length)];
            hash = newHash;
            size = 0;

            for (int i = 0; i < tmpHash.Length; i++)
            {
                if (tmpHash[i] != null && tmpHash[i] != infinity)
                {
                    Insert(tmpHash[i]);
                }
            }
        }

        private void CheckReduce()
        {
            if ( 2 * size < hash.Length && 2 * size > startHashSize)
            {
                Console.WriteLine("Not enough elements, decrease stash size!");
                DecreaseHashSize();
            }
        }

        public Tuple<int, int> HashSearchFirst(object obj)
        {
            int counter = 0;
            while (counter != hash.Length)
            {
                int tableIndex = OpenHashFunction(obj, counter * counter);

                if (hash[tableIndex] == infinity || hash[tableIndex] == null)
                {
                    Console.WriteLine("Element " + obj + " not found");
                    return Tuple.Create(-1, counter);
                }

                if (hash[tableIndex].Equals(obj))
                {
                    Console.WriteLine("First element " + obj + " found under the index " + tableIndex + " confilict count: " + counter);
                    return Tuple.Create(tableIndex, counter);
                }
                else
                {
                    counter++;
                }
            }

            return Tuple.Create(0, counter);
        }

        public Tuple<int, int> HashSearchLast(object obj)
        {
            int counter = 0;
            while (counter != hash.Length)
            {
                int tableIndex = OpenHashFunction(obj, counter * counter);

                if (hash[tableIndex] == infinity || hash[tableIndex] == null)
                {
                    Console.WriteLine("Element " + obj + " not found");
                    return Tuple.Create(-1, counter);
                }

                if (hash[tableIndex].Equals(obj))
                {
                    int tmpTableIndex = OpenHashFunction(obj, counter * counter);
                    counter++;
                    tableIndex = OpenHashFunction(obj, counter * counter);

                    if (hash[tableIndex].Equals(obj))
                    {
                        continue;
                    }
                    else
                    {
                        counter--;
                        Console.WriteLine("Last element " + obj + " found under the index " + tmpTableIndex + " confilict count: " + counter);
                        return Tuple.Create(tableIndex, counter);
                    }
                }
                else
                {
                    counter++;
                }
            }

            return Tuple.Create(0, counter);
        }

        public int Delete(object obj)
        {
            int counter = 0;

            while (counter != hash.Length)
            {
                int tableIndex = OpenHashFunction(obj, counter * counter);

                if (hash[tableIndex] == null)
                {
                    Console.WriteLine("Delete failed! Element " + obj + " does not exist");
                    return -1;
                }

                if (hash[tableIndex].Equals(obj))
                {
                    int tmpTableIndex = OpenHashFunction(obj, counter);
                    counter++;
                    tableIndex = OpenHashFunction(obj, counter * counter);

                    if (hash[tableIndex] == obj)
                    {
                        continue;
                    }
                    else
                    {
                        counter--;
                        Console.WriteLine("Delete element " + obj + " found under the index " + tmpTableIndex + " confilict count: " + counter);
                        hash[tmpTableIndex] = infinity;
                        size--;
                        CheckReduce();
                        return tmpTableIndex;
                    }
                }
                else
                {
                    counter++;
                }
            }

            return 0;
        }

        public int GetHashSize()
        {
            return hash.Length;
        }

        public void PrintHash()
        {
            for (int i = 0; i < hash.Length; i++)
            {
                Console.WriteLine("Hash " + i + " : " + hash[i]);
            }
            Console.WriteLine();
        }
    }
}
