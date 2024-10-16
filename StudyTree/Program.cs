namespace StudyTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
          // BST();
           BT();

            Console.ReadKey();
        }
        public static void BT()
        {
            BinaryTree tree = new BinaryTree(50);
            tree.Insert(30);                            //      50
            tree.Insert(70);                            //    /    \
            tree.Insert(20);                            //  30      70
            tree.Insert(40);                            // /  \    /  \
            tree.Insert(60);                           // 20   40 60   82
            tree.Insert(82);                           //              /
            tree.Insert(80);                           //             80
            tree.Insert(81);                           //              \
                                                       //               81
            Console.WriteLine("In-Order Traversal:");
            tree.InOrderTraversal(tree.Root);
            Console.WriteLine("\n");

            Console.WriteLine(tree.IsSymmetric(tree.Root) ? "Tree is Symmetric" : "Tree is not Symmetric");

            if (tree.BalancedTree(tree.Root))
            {
                Console.WriteLine("\nTree is balanced\n");
            }
            else
            {
                Console.WriteLine("\nTree is not balanced\n");
            }
            //////////////////////////Same Function////////////////////////////
            if (tree.isBalanced(tree.Root) > 0)
            {
                Console.WriteLine("\nBalanced\n");
            }
            else
            {
                Console.WriteLine("\nNot Balanced\n");
            }
            int maxDepth = tree.FindMaximumDepth(tree.Root);
            Console.WriteLine("Maximum depth of the BST: " + maxDepth);
            int minDepth = tree.MinimumDepth(tree.Root);
            Console.WriteLine("Minimum Depth of the BST: " + minDepth);
            int pathsum =tree.PathSum(tree.Root);
            Console.WriteLine("path sum : " + pathsum);
            Console.WriteLine("\n-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            int[] sortedArray = { 20, 30, 40, 50, 60, 70, 80 };

            BinaryTree bst = new BinaryTree(50);
            Node root = bst.ConvertSortedArrayToBST(sortedArray);

            Console.WriteLine("In-Order Traversal of the constructed BST:");
            bst.InOrderTraversal(root);

            Console.WriteLine("\n-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("In-Order Traversal before Inversion:");
            tree.InOrderTraversal(root);

            // Invert the binary tree
            tree.MirrorTree(root);

            Console.WriteLine("\nIn-Order Traversal after Inversion:");
            tree.InOrderTraversal(root);
            Console.WriteLine("\n-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Diameter of the tree: " + tree.GetDiameter(root));

            Console.WriteLine("\n-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            BinaryTree tree2 = new BinaryTree(50);
            tree2.Insert(30);
            tree2.Insert(70);
            tree2.Insert(20);
            tree2.Insert(40);
            tree2.Insert(60);
            tree2.Insert(80);

            bool areSame = tree.IsSameTree(tree.Root, tree2.Root);
            Console.WriteLine("Are the two trees identical? " + areSame);
            Console.WriteLine("\n-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            BinaryTree mergedTree = new BinaryTree(0); // Dummy root
            mergedTree.Root = mergedTree.MergeTrees(tree.Root, tree2.Root);

            // Print the merged tree using in-order traversal
            Console.WriteLine("In-order traversal of merged tree:");
            mergedTree.InOrderTraversal(mergedTree.Root);
            Console.WriteLine("\n-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            int targetSum = 100; 

            bool hasPath = tree.PathEqualSum(tree.Root, targetSum);
            Console.WriteLine("Does the tree have a root-to-leaf path with the sum " + targetSum + "? " + hasPath);
            Console.WriteLine("\n-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////


        }
        public static void BST()
        {
            BinarySearchTree bst = new BinarySearchTree();

            // Insert some values into the BST
            bst.Insert(50);                    //      50
            bst.Insert(30);                    //     /  \
            bst.Insert(70);                    //   30    70
            bst.Insert(20);                    //  /  \   /  \
            bst.Insert(40);                    // 20   40 60  82
            bst.Insert(60);                    //             /
            bst.Insert(82);                    //            80
            bst.Insert(80);                    //             \
            bst.Insert(81);                    //              81
            Console.WriteLine("In-Order Traversal:");
            bst.InOrderPrint(bst.Root);  // Prints: 20 30 40 50 60 70 81
            Console.WriteLine("\n-----------------------------\n");

            BinarySearchTree Btree = new BinarySearchTree();
            Btree.Root = new Node(50);
            Btree.Root.Lift = new Node(30);
            Btree.Root.Right = new Node(70);
            Btree.Root.Lift.Lift = new Node(20);
            Btree.Root.Lift.Right = new Node(40);
            Btree.Root.Right.Lift = new Node(60);
            Btree.Root.Right.Right = new Node(82);
            Console.WriteLine("IsValidate :" + Btree.IsValidate(Btree.Root));
           
            Console.WriteLine("\n-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////
            // Test the Contains method
            Console.WriteLine("If Contains : ");
            Console.WriteLine("Contains 40: " + bst.Contains(40)); // Should return true
            Console.WriteLine("Contains 25: " + bst.Contains(25)); // Should return false
            Console.WriteLine("Contains 80: " + bst.Contains(80)); // Should return true
            Console.WriteLine("Contains 100: " + bst.Contains(100)); // Should return false
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////
            Node maxNode = bst.FindMax(bst.Root);

            if (maxNode != null)
            {
                Console.WriteLine("Maximum value in the tree: " + maxNode.Data);
            }
            else
            {
                Console.WriteLine("The tree is empty.");
            }
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////
            Node secondMaxNode = bst.FindSecondMax(bst.Root);

            if (secondMaxNode != null)
            {
                Console.WriteLine("Second maximum value in the tree: " + secondMaxNode.Data);  // Should print 70
            }
            else
            {
                Console.WriteLine("The tree does not have a second maximum value.");
            }
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            int leafSum = bst.LeafSum(bst.Root);
            Console.WriteLine("Sum of leaf nodes: " + leafSum);
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Inorder Traversal before Mirroring:");
            bst.InOrderPrint(bst.Root);
            Console.WriteLine();

            // Mirror the tree
            // bst.MirrorTree(bst.Root);

            Console.WriteLine("Inorder Traversal after Mirroring:");
            bst.InOrderPrint(bst.Root);
            Console.WriteLine();
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Print Right Path");
            bst.PrintRightPath(bst.Root);
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Print Right View");
            bst.PrintRightView(bst.Root);
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            int minDepth = bst.FindMinimumDepth(bst.Root);
            Console.WriteLine("Minimum depth of the BST: " + minDepth);
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            int minLiftDepth = bst.FindMinimumLeftDepth(bst.Root);
            Console.WriteLine("Minimum Lift Depth of the BST: " + minLiftDepth);
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            List<int> largestValues = bst.LargestLevelValue();

            Console.WriteLine("Largest values at each level:");
            foreach (var value in largestValues)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            Node minNode = bst.FindMin(bst.Root);

            if (minNode != null)
            {
                Console.WriteLine("Minimum value in the tree: " + minNode.Data);
            }
            else
            {
                Console.WriteLine("The tree is empty.");
            }
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            int totalSum = bst.SumOfNodes();

            Console.WriteLine($"The sum of all nodes is: {totalSum}");
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            List<int> oddNodes = bst.ListOfOddNodes();
            Console.WriteLine("Odd Nodes: " + string.Join(", ", oddNodes));
            Console.WriteLine("-----------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////////////

            List<int> evenNodes = bst.ListOfEvenNodes();
            Console.WriteLine("Even Nodes: " + string.Join(", ", evenNodes));

        }
    }
}
