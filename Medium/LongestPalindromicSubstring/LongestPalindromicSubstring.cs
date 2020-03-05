using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium.LongestPalindromicSubstring
{
    class LongestPalindromicSubstringSol
    {
        /// <summary>
        /// O(n^2) Expand around center approach from solutions
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if(s == "")
            {
                return "";
            }

            int maxStart = 0;
            int maxLength = 1;

            
            for(int i = 0; i < s.Length; i++)
            {
                int j = i - 1;
                int k = i + 1;

                //Odd palindromes
                expandAroundCenter(s, j, k, ref maxStart, ref maxLength);

                //Event Palindromes
                j = i;
                k = i + 1;

                //Note -- duplicate code could be refactored
                expandAroundCenter(s, j, k, ref maxStart, ref maxLength);

            }

            return s.Substring(maxStart, maxLength);
        }

        private void expandAroundCenter(string s, int j, int k, ref int maxStart, ref int maxLength)
        {
            while (j >= 0 && k < s.Length)
            {
                if (s[j] != s[k])
                {
                    break;
                }
                int nextLength = k - j + 1;
                if (nextLength > maxLength)
                {
                    maxStart = j;
                    maxLength = nextLength;
                }
                j--;
                k++;
            }
        }

        /// <summary>
        /// O(N^3) Time limit exceeded. My solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindromeBruteForce(string s)
        {
            if (s.Length == 0)
            {
                return "";
            }
            if (s.Length == 1)
            {
                return s;
            }

            int maxPalindrome = 1;
            int maxStart = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {

                for (int j = i + 1; j < s.Length; j++)
                {
                    int mid = i + (j - i - 1) / 2;

                    bool isPalindrome = true;
                    for (int k = i; k <= mid; k++)
                    {
                        if (s[k] != s[j - (k - i)])
                        {
                            isPalindrome = false;
                        }
                    }

                    if (isPalindrome && maxPalindrome < j - i + 1)
                    {
                        maxStart = i;
                        maxPalindrome = j - i + 1;
                    }
                }
            }

            return s.Substring(maxStart, maxPalindrome);
        }
    }
}
