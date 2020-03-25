using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode.Hard.LongestValidParentheses
{
    //https://leetcode.com/problems/longest-valid-parentheses/
    public class LongestValidParenthesesSol
    {
        public int LongestValidParentheses(string s)
        {
            Dictionary<int, int> levelMap = new Dictionary<int, int>();

            levelMap[0] = -1;

            int level = 0;
            int maxParen = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '(')
                {
                    level++;
                    levelMap[level] = i;
                }
                else
                {
                    if(level > 0)
                    {
                        level--;
                        maxParen = Math.Max(maxParen, i - levelMap[level]);
                    }
                    else
                    {
                        levelMap.Clear();
                        levelMap[0] = i;
                    }
                }
            }
            return maxParen;
        }
    }
}
