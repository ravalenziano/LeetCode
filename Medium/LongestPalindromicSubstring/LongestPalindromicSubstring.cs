using System;
using System.Collections.Generic;
using System.Text;

//https://leetcode.com/problems/longest-palindromic-substring/solution/
namespace LeetCode.Medium.LongestPalindromicSubstring
{
    class LongestPalindromicSubstringSol
    {
        public string LongestPalindrome(string s)
        {
            if(s.Length == 0)
            {
                return "";
            }
            if(s.Length == 1)
            {
                return s;
            }
            int maxPalindrome = 1;
            int maxStart = 0;
            
            for (int i = 0; i < s.Length - 1; i++)
            {
                for(int j = i + 1; j < s.Length; j++)
                {
                    int mid = i + (j - i - 1) / 2;

                    bool isPalindrome = true;
                    for(int k = i; k <= mid; k++)
                    {
                        if(s[k] != s[j - (k - i)])
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

        /// <summary>
        /// O(N^3) - This gives time limited exceeded
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
