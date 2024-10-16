using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyTree
{
    public class BinarySearchTree
    {
        public Node Root;

        public BinarySearchTree()
        {
            Root = null;
        }
        // 1. Write a function to insert a value into a Binary Search Tree (BST) while maintaining the BST properties using recursion.
        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }
        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Data)
            {
                node.Lift = Insert(node.Lift, value);
            }
            else if (value > node.Data)
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        //*****************************************************************************************************
        // 2. Write a function to check if a given value exists in a Binary Search Tree (BST) using recursion.
        public bool Contains(int value)
        {
            return Contains(Root, value);
        }
        public bool Contains(Node node, int data)
        {
            if (node == null)
            {
                return false;
            }

            if (data == node.Data)
            {
                return true;
            }
            else if (data < node.Data)
            {
                return Contains(node.Lift, data);
            }
            else
            {
                return Contains(node.Right, data);
            }
        }

        //*****************************************************************************************************
        // 3. Write a function to find and return the node with the maximum value in a Binary Search Tree (BST)
        public Node FindMax(Node node)
        {
            if (node == null)
            {
                return null;  // Return null if the node is null (tree is empty)
            }
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node;
        }

        //*****************************************************************************************************
        // 4. Write a function to find and return the node with the second maximum value in a Binary Search Tree (BST).
        public Node FindSecondMax(Node node)
        {
            if (node == null || (node.Lift == null && node.Right == null))
            {
                return null;  // Return null if the tree has less than 2 nodes
            }

            Node parent = null;

            while (node.Right != null)
            {
                parent = node;
                node = node.Right;
            }
            if(node.Lift != null)
            {
                return FindMax(node.Lift);
            }
            return parent;
        }

        //*****************************************************************************************************
        // 5. Write a function to calculate and return the sum of all leaf node values in a Binary Search Tree (BST).
        public int LeafSum(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            if(node.Lift == null && node.Right == null)
            {
                return node.Data;
            }
            int Lift = LeafSum(node.Lift);
            int Right = LeafSum(node.Right);

            return Lift + Right;
        }

        //*****************************************************************************************************
        // 6. Write a function to create a mirror image of a Binary Search Tree (BST) by swapping the left and right children of all nodes.
        public void MirrorTree(Node node)
        {
            if(node == null) { return; }

            MirrorTree(node.Lift);
            MirrorTree(node.Right);

            // Swap the left and right children
            Node temp = node.Lift;
            node.Lift = node.Right;
            node.Right = temp;
        }

        //*****************************************************************************************************
        // 7. Write a function to print all the values in the rightmost path of a Binary Search Tree (BST).
        public void PrintRightPath(Node node)
        {
            if (node == null) return;

            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Right;
            }
        }

        //*****************************************************************************************************
        // 8. Write a function to print the right view of a Binary Search Tree (BST), displaying the nodes that are visible when the tree is viewed from the right side.
        public void PrintRightView(Node node)
        {
            if (node == null) { return; }
            Node current = node.Lift;
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Right;
                if (node != null)
                {
                    if (node.Lift != null && node.Lift.Right != null)
                    {
                        Console.WriteLine(node.Lift.Right.Data);
                    }
                }
            }
            while (current != null)
            {
                Node temp = current;
                current = current.Right;
                if (current == null && temp.Lift != null)
                {
                    current = temp.Lift;
                }
                if (current != null)
                {
                    Console.WriteLine(current.Data);
                }
            }
        }


        //*****************************************************************************************************
        // 9. Write a function to print all the values in the leftmost path of a Binary Search Tree (BST).
        public void PrintLeftPath(Node node)
        {
            if (node == null) { return; }
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Lift;
            }
        }

        //*****************************************************************************************************
        // 10. Write a function to find and return the minimum depth of a Binary Search Tree (BST), where the minimum depth is defined as the shortest path from the root node to any leaf node.
        public int FindMinimumDepth(Node node)
        {
            if(node == null) { return 0; }

            if(node.Lift == null && node.Right == null) { return 1; }
            
            if(node.Lift == null) {return FindMinimumDepth(node.Right) + 1; }
            if (node.Right == null)  return FindMinimumDepth(node.Lift) + 1;

            return Math.Min(FindMinimumDepth(node.Lift), FindMinimumDepth(node.Right))+1;
        }

        //*****************************************************************************************************
        // 11. Write a function to find and return the minimum depth of a Binary Search Tree (BST) specifically focusing on the left subtree, where the minimum depth is defined as the shortest path from the root node to any leaf node in the left subtree.
        public int FindMinimumLeftDepth(Node node)
        { //calculate the minimum depth , specifically focusing on the left subtree
            if (node == null) { return 0; }                                            //       50
                                                                                       //      /   
            if (node.Lift == null && node.Right == null) { return 1; }                 //    30
                                                                                       //    /
            if (node.Right == null) return FindMinimumLeftDepth(node.Lift) + 1;        //  20

            return FindMinimumLeftDepth(node.Lift) + 1;
        }

        //*****************************************************************************************************
        // 12. Write a function to find and return a list of the largest values at each level of a Binary Search Tree (BST).
        public List<int> LargestLevelValue()
        {
            List<int> largestValues = new List<int>();
            LargestLevelValue(Root, 0, largestValues);
            return largestValues;
        }
        public void LargestLevelValue(Node node, int Level, List<int> largestValues)
        {
            if(node == null) { return; }

            if(Level == largestValues.Count)
            {
                largestValues.Add(node.Data);
            }
            else
            {
                largestValues[Level] = Math.Max(largestValues[Level], node.Data);
            }

            LargestLevelValue(node.Lift, Level + 1, largestValues);
            LargestLevelValue(node.Right, Level + 1, largestValues);
        }

        //*****************************************************************************************************
        // 13. Write a function to find and return the node with the minimum value in a Binary Search Tree (BST).
        public Node FindMin(Node node)
        {
            if (node == null) { return null; }

            while(node.Lift != null)
            {
                node = node.Lift;
            }
            return node;
        }

        //*****************************************************************************************************
        // 14. Write a function to calculate and return the sum of all node values in a Binary Search Tree (BST).
        public int SumOfNodes()
        {
            return SumOfNodes(Root);
        }
        public int SumOfNodes(Node node)
        {
            if (node == null) { return 0; }

            return node.Data + SumOfNodes(node.Lift) + SumOfNodes(node.Right);
        }

        //*****************************************************************************************************
        // 15. Write a function to return a list of all odd-valued nodes in a Binary Search Tree (BST).
        public List<int> ListOfOddNodes()
        {
            return ListOfOddNodes(Root);
        }
        public List<int> ListOfOddNodes(Node node)
        {
            List<int> oddNodes = new List<int>();

            if (node == null) return oddNodes;

            if (node.Data % 2 != 0)
            {
                oddNodes.Add(node.Data);
            }

            oddNodes.AddRange(ListOfOddNodes(node.Lift));
            oddNodes.AddRange(ListOfOddNodes(node.Right));

            return oddNodes;
        }

        //*****************************************************************************************************
        // 16. Write a function to return a list of all even-valued nodes in a Binary Search Tree (BST).
        public List<int> ListOfEvenNodes()
        {
            return ListOfEvenNodes(Root);
        }
        public List<int> ListOfEvenNodes(Node node)
        {
            List<int> evenNodes = new List<int>();

            if (node == null) { return evenNodes; }

            if(node.Data %2 == 0)
            {
                evenNodes.Add(node.Data);
            }

            evenNodes.AddRange(ListOfEvenNodes(node.Lift));
            evenNodes.AddRange(ListOfEvenNodes(node.Right));

            return evenNodes;
        }

        //*****************************************************************************************************
        // 17. Write a function to determine whether a Binary Search Tree (BST) is valid by checking if each node's left child is less than the node and its right child is greater than the node.
        public bool IsValidate(Node node)
        {
            if (node == null) return false;
            if(node.Lift.Data < node.Data && node.Right.Data > node.Data) return true;

            IsValidate(node.Lift);
            IsValidate(node.Right);
            return false;
        }




        public void InOrderPrint(Node node)
        {
            if (node != null)
            {
                InOrderPrint(node.Lift);  // Visit left subtree
                Console.Write(node.Data + " ");  // Print the current node
                InOrderPrint(node.Right);  // Visit right subtree
            }
        }
        public void PreOrderPrint(Node node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");  // Print the current node
                PreOrderPrint(node.Lift);  // Visit left subtree
                PreOrderPrint(node.Right);  // Visit right subtree
            }
        }
        public void PostOrderPrint(Node node)
        {
            if (node != null)
            {
                PostOrderPrint(node.Lift);  // Visit left subtree
                PostOrderPrint(node.Right);  // Visit right subtree
                Console.Write(node.Data + " ");  // Print the current node
            }
        }




    }
}
