﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyTree
{
    public class BinaryTree
    {
        public Node Root { get; set; }

        public BinaryTree(int rootValue)
        {
            Root = new Node(rootValue);
        }
        // 1.
        public void Insert(int data)
        {
            Insert(Root, data);
        }
        public void Insert(Node node, int data)
        {
            if (data < node.Data)
            {
                if (node.Lift == null)
                {
                    node.Lift = new Node(data);
                }
                else
                {
                    Insert(node.Lift, data);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node(data);
                }
                else
                {
                    Insert(node.Right, data);
                }
            }
        }
        //*****************************************************************************************************
        // 2.
        public bool IsSymmetric(Node root)
        {
            if (root == null) return true;                                   //    1
                                                                             //   / \
           // Use a helper function to compare the left and right subtrees   //  2   2
                                                                             // / \ / \
            return IsMirror(root.Lift, root.Right);                          //3  4 4  3
        }
        private bool IsMirror(Node left, Node right)
        {
            // If both nodes are null, they are symmetric
            if (left == null && right == null) return true;

            // If only one of the nodes is null, the tree is not symmetric
            if (left == null || right == null) return false;

            // Check if the current nodes have the same value and 
            // their children are mirrors of each other
            return (left.Data == right.Data) &&
                   IsMirror(left.Lift, right.Right) &&
                   IsMirror(left.Right, right.Lift);
        }
        //*****************************************************************************************************
        // 3.
        public int FindMaximumDepth(Node node)
        {
            if (node == null) { return 0; }

            if (node.Lift == null && node.Right == null) { return 1; }

            if (node.Lift == null) { return FindMaximumDepth(node.Right) + 1; }
            if (node.Right == null) return FindMaximumDepth(node.Lift) + 1;

            return Math.Max(FindMaximumDepth(node.Lift), FindMaximumDepth(node.Right)) + 1;
        }
        //*****************************************************************************************************
        // 4.
        public Node ConvertSortedArrayToBST(int[] nums)
        {
            return ConvertToBST(nums, 0, nums.Length - 1);
        }
        private Node ConvertToBST(int[] nums, int left, int right)
        {
            if (left > right) return null;

            int mid = (left + right) / 2;
            Node node = new Node(nums[mid]);

            node.Lift = ConvertToBST(nums, left, mid - 1);
            node.Right = ConvertToBST(nums, mid + 1, right);

            return node;
        }
        //*****************************************************************************************************
        // 5.
        public void MirrorTree(Node node)
        {
            if (node == null) { return; }

            MirrorTree(node.Lift);
            MirrorTree(node.Right);

            Node temp = node.Lift;
            node.Lift = node.Right;
            node.Right = temp;
        }
        //*****************************************************************************************************
        // 6.
        private int maxDiameter = 0;
        public int Diameter(Node node)
        {
            if (node == null) return 0;

            // Recursively calculate the height of the left and right subtrees
            int leftHeight = Diameter(node.Lift);
            int rightHeight = Diameter(node.Right);

            // Calculate the diameter through the current node (sum of left and right heights)
            int currentDiameter = leftHeight + rightHeight;

            // Update the maximum diameter if the current one is greater
            maxDiameter = Math.Max(maxDiameter, currentDiameter);

            // Return the height of the current node
            return 1 + Math.Max(leftHeight, rightHeight);
        }
        public int GetDiameter(Node root)
        {
            Diameter(root);
            return maxDiameter;
        }
        //*****************************************************************************************************
        // 7.
        public bool IsSameTree(Node node, Node node2)
        {
            if (node == null && node2 == null) return true;
            if (node == null || node2 == null) return false;
            if (node.Data != node2.Data) return false;

            return IsSameTree(node.Lift, node2.Lift) && IsSameTree(node.Right, node2.Right);
        }
        //*****************************************************************************************************
        // 8.
        public Node MergeTrees(Node node, Node node2)
        {
            if(node == null && node2 == null) return null;
            if (node == null) return node2;
            if (node2 == null) return node;

            Node merged = new Node(node.Data + node2.Data);

            merged.Lift = MergeTrees(node.Lift, node2.Lift);
            merged.Right = MergeTrees(node.Right, node2.Right);

            return merged;
        }
        //*****************************************************************************************************
        // 9.
        public virtual int height(Node node)
        {
            /* base case tree is empty */
            if (node == null)
            {
                return 0;
            }
            /* If tree is not empty then height = 1 + max of
            left height and right heights */
            return 1
                + Math.Max(height(node.Lift),
                           height(node.Right));
        }
        public bool BalancedTree(Node node)
        {
            int lh;   // for height of left subtree
            int rh;   // for height of right subtree

            if (node == null) return true;

            lh = height(node.Lift);
            rh = height(node.Right);

            if (Math.Abs(lh - rh) <= 1 && BalancedTree(node.Lift)
            && BalancedTree(node.Right))
            {
                return true;
            }

            return false;
        }
        //Another Way To Solve it 
        public virtual int isBalanced(Node root)
        {
            if (root == null) return 0;

            int lh = isBalanced(root.Lift);
            if (lh == -1)
                return -1;
            int rh = isBalanced(root.Right);
            if (rh == -1)
                return -1;

            if (lh > rh + 1 || rh > lh + 1)
                return -1;
            else
                return Math.Max(lh, rh) + 1;
        }
        //*****************************************************************************************************
        // 10.
        public int MinimumDepth(Node node)
        {
            if (node == null) { return 0; }

            if (node.Lift == null && node.Right == null) { return 1; }

            if (node.Lift == null) { return MinimumDepth(node.Right) + 1; }
            if (node.Right == null) return MinimumDepth(node.Lift) + 1;

            return Math.Min(MinimumDepth(node.Lift), MinimumDepth(node.Right)) + 1;
        }
        //*****************************************************************************************************
        // 11.
        public int PathSum(Node node)
        {
            if (node == null) return 0; // Base case: if the node is null, return 0

            // Calculate the sum for the right subtree first
            int rightSum = PathSum(node.Right);

            // If no right child, calculate the left path sum
            if (node.Right == null)
            {
                return node.Data + PathSum(node.Lift); // Path sum on the left side
            }

            // If both children exist or no left child, return the right path sum
            return node.Data + rightSum;
        }
        //*****************************************************************************************************
        // 12.
        public bool PathEqualSum(Node node, int s)
        {
            if(node == null) return false;

            if (node.Lift == null && node.Right == null)
            {
                return s == node.Data; 
            }
            s -= node.Data;

            return PathEqualSum(node.Lift, s) || PathEqualSum(node.Right, s);

        }
        //*****************************************************************************************************
        // 13.
        public int MaximumPathSum(Node node)
        {
            if (node == null) return 0;

            // Recursively calculate the maximum path sum for left and right subtrees
            int leftSum = MaximumPathSum(node.Lift);
            int rightSum = MaximumPathSum(node.Right);

            // Calculate the maximum path through the current node
            // If either left or right is negative, we can ignore it
            return node.Data + Math.Max(0, Math.Max(leftSum, rightSum));
        }



        // ( Root - Left - Right )
        public void PreOrderTraversal(Node node)
        {
            if (node == null) return; // Base case if node null then return

            Console.Write(node.Data + "  ");
            PreOrderTraversal(node.Lift);
            PreOrderTraversal(node.Right);

        }

        // ( Left - Root - right )
        public void InOrderTraversal(Node node)
        {
            if (node == null) return;

            InOrderTraversal(node.Lift);
            Console.Write(node.Data + "  ");
            InOrderTraversal(node.Right);
        }

        // ( Left - Right - Root )
        public void PostOrderTraversal(Node node)
        {
            if (node == null) return;

            PostOrderTraversal(node.Lift);
            PostOrderTraversal(node.Right);
            Console.Write(node.Data + "  ");
        }
    }
}
