using System;
using System.Collections.Generic;
using System.Text;

namespace KMP_Algorithm
{
    public class KMP
    {
        private string pattern;
        private string text;
        private int[] longestPrefixSuffix;

        public KMP(string pattern, string text)
        {
            this.pattern = pattern;
            this.text = text;
        }

        public void PrintInputs()
        {
            Console.WriteLine("Pattern: " + pattern);
            Console.WriteLine("Text: " + text);
            Console.WriteLine();
        }

        public void StartKMP()
        {
            longestPrefixSuffix = new int[pattern.Length];
            computeLongestPrefixSuffix();

            int patternIndex = 0;
            int textIndex = 0;

            while (textIndex < text.Length)
            {
                if (pattern[patternIndex] == text[textIndex])
                {
                    patternIndex++;
                    textIndex++;
                }

                if (patternIndex == pattern.Length)
                {
                    Console.WriteLine("Found pattern '" + pattern + "' at index " + (textIndex - patternIndex));
                    patternIndex = longestPrefixSuffix[patternIndex - 1];
                }
                else if (textIndex < text.Length && pattern[patternIndex] != text[textIndex])
                {
                    // Do not match longestPrefixSuffix[0..longestPrefixSuffix[patternIndex-1]] characters, they will match anyway
                    if (patternIndex != 0)
                    {
                        patternIndex = longestPrefixSuffix[patternIndex - 1];
                    }
                    else
                    {
                        textIndex = textIndex + 1;
                    }
                }
            }
        }

        private void computeLongestPrefixSuffix()
        {
            int length = 0; // Length of the previous longest prefix suffix 
            int patternIndex = 1;
            longestPrefixSuffix[0] = 0;

            while (patternIndex < pattern.Length)
            {
                if (pattern[patternIndex] == pattern[length])
                {
                    length++;
                    longestPrefixSuffix[patternIndex] = length;
                    patternIndex++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = longestPrefixSuffix[length - 1];
                    }
                    else
                    {
                        longestPrefixSuffix[patternIndex] = length;
                        patternIndex++;
                    }
                }
            }
        }
    }
}