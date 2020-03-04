using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy.DiameterofBinaryTree
{
    //https://leetcode.com/problems/diameter-of-binary-tree/
    class DiameterOfBinaryTreeAns
    {
        /// <summary>
        /// Recursive solution O(n) time, O(n) space
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }
            NodeStats stats = diameterOfBinaryTree(root);

            return stats.Diameter;
        }

        private struct NodeStats
        {
            public int Depth { get; set; }
            public int Diameter { get; set; }
        }

        private NodeStats diameterOfBinaryTree(TreeNode node)
        {
            if (node.left == null && node.right == null)
            {
                return new NodeStats { Depth = 1, Diameter = 0 };
            }
            NodeStats leftPath = new NodeStats(), rightPath = new NodeStats();

            if (node.left != null)
            {
                leftPath = diameterOfBinaryTree(node.left);
            }

            if (node.right != null)
            {
                rightPath = diameterOfBinaryTree(node.right);
            }

            NodeStats stats = new NodeStats();
            stats.Depth = Math.Max(leftPath.Depth, rightPath.Depth) + 1;
            stats.Diameter = Math.Max(
                                       Math.Max(leftPath.Diameter, rightPath.Diameter), 
                                       leftPath.Depth + rightPath.Depth);

            return stats;
        }


    }

    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
}
