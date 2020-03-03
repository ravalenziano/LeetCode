using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy.FindAllNumbersDisappearedInanArray
{
    class Solution
    {
        /// <summary>
        /// Use boolean Array. O(n) runtime, O(n) space, smaller constant than hashset
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            bool[] numSet = new bool[nums.Length];

            for(int i = 0; i < nums.Length; i++)
            {
                numSet[nums[i] - 1] = true;
            }

            List<int> disappearedNumbers = new List<int>();
            
            for(int i =0; i< nums.Length; i++)
            {
                if (!numSet[i])
                {
                    disappearedNumbers.Add(i + 1);
                }
            }

            return disappearedNumbers;
        }

        /// <summary>
        /// Use HashSet. O(n) runtime, O(n) space
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbersHashSet(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>();
            for (int i = 1; i <= nums.Length; i++)
            {
                numSet.Add(i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                numSet.Remove(nums[i]);
            }

            List<int> disappearedNumbers = new List<int>(numSet.Count);

            foreach (var num in numSet)
            {
                disappearedNumbers.Add(num);
            }

            return disappearedNumbers;
        }

    }
}
