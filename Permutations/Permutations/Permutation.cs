using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    public class Permutation
    {
        int startPosition;
        int endPosition;
        int count = 0;

        List<int> numberList = new List<int>();

        public Permutation(int setStartPosition, int setEndPosition)
        {
            startPosition = setStartPosition;
            endPosition = setEndPosition;

            if (setStartPosition > setEndPosition)
            {
                int tmp = startPosition;
                startPosition = endPosition;
                endPosition = tmp;
            }

            for (int i = startPosition; i <= endPosition; i++)
            {
                numberList.Add(i);
                count++;
            }
        }

        public void StartPermute()
        {
            Permute(numberList, 0, count);
        }

        public void Permute(List<int> list, int i, int n)
        {
            if (i == n) // If i is equal to the input size, display the list
            {
                ShowList(list);
            }
            else
            {
                for (int j = i; j < n; j++)
                {
                    Swap(ref list, i, j);
                    Permute(list, i + 1, n);
                    Swap(ref list, i, j);
                }
            }
        }

        public void Swap(ref List<int> list, int a, int b)
        {
            int tmp = list[a];
            list[a] = list[b];
            list[b] = tmp;
        }

        public void ShowList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count - 1)
                {
                    Console.Write(numberList[i] + " -> ");
                }
                else
                {
                    Console.Write(numberList[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
