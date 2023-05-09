using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAmazingMission.Arbres
{
    public class BinaryTreeOperations
    {
        // Classic print all nodes
        public static void PrintAllNodes(Node? node)
        {
            if (node != null)
            {
                Console.WriteLine(string.Format(" {0} ", node.Value));
                PrintAllNodes(node.LeftChild);
                PrintAllNodes(node.RightChild);
            }
        }

        // Print nodes at certain level
        public static void PrintCurrentLevel(Node? root, int level)
        {
            if (root == null)
            {
                //Console.WriteLine(string.Format("No values at level {0}", level));
                return;
            }
            if (level == 1)
            {
                Console.Write(string.Format(" {0} ", root.Value));
            }
            else if (level > 1)
            {
                PrintCurrentLevel(root.LeftChild, level - 1);
                PrintCurrentLevel(root.RightChild, level - 1);
            }
        }

        // Calculate depth of tree
        public static int Depth(Node? root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int ldepth = Depth(root.LeftChild);
                int rdepth = Depth(root.RightChild);

                if (ldepth > rdepth)
                {
                    return (ldepth + 1);
                }
                else
                {
                    return (rdepth + 1);
                }
            }
        }

        // Print nodes level by level
        public static void PrintLevelOrder(Node? root)
        {
            int h = Depth(root);
            int i;
            for (i = 1; i <= h; i++)
            {
                PrintCurrentLevel(root, i);
            }
        }

        // Print nodes level by level using a queue
        public static void PrintLevelOrderUsingQueue(Node? root)
        {
            if (root != null)
            {
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                while (queue.Count != 0)
                {

                    Node tempNode = queue.Dequeue();
                    Console.Write(tempNode.Value + " ");

                    if (tempNode.LeftChild != null)
                    {
                        queue.Enqueue(tempNode.LeftChild);
                    }

                    if (tempNode.RightChild != null)
                    {
                        queue.Enqueue(tempNode.RightChild);
                    }
                }
            }
        }

        // Parcours préfixe
        public static void Preorder(Node? root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                Console.Write(root.Value + " ");
                Preorder(root.LeftChild);
                Preorder(root.RightChild);
            }
        }

        // Parcours préfixe itératif
        public static void IterativePreorder(Node? node)
        {
            if (node == null)
            {
                return;
            }
            else
            {
                Stack<Node> stack = new Stack<Node>();
                stack.Push(node);
                while (stack.Count != 0)
                {
                    Node tempNpde = stack.Pop();
                    Console.Write(tempNpde.Value + " ");
                    if (tempNpde.RightChild != null) stack.Push(tempNpde.RightChild);
                    if (tempNpde.LeftChild != null) stack.Push(tempNpde.LeftChild);
                }

            }
        }

        // Parcours infixe
        public static void Inorder(Node? root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                Inorder(root.LeftChild);
                Console.Write(root.Value + " ");
                Inorder(root.RightChild);
            }
        }

        // Parcours infixe itératif
        public static void IterativeInorder(Node? node)
        {
            Stack<Node> stack = new Stack<Node>();
            while (stack.Count != 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.LeftChild;
                }
                else
                {
                    node = stack.Pop();
                    Console.Write(node.Value + " ");
                    node = node.RightChild;
                }
            }
        }

        // Parcours postfixe itératif
        public static void IterativePostOrder(Node? node)
        {
            Stack<Node> stack = new Stack<Node>();
            Node? last = null;
            while (stack.Count != 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.LeftChild;
                }
                else
                {
                    var peekNode = stack.Peek();
                    // if right child exists and traversing node from left child, then move right
                    if (peekNode.RightChild != null && last != peekNode.RightChild)
                    {
                        node = peekNode.RightChild;
                    }
                    else
                    {
                        Console.Write(peekNode.Value + " ");
                        last = stack.Pop();
                    }

                }
            }
        }

        public static bool FindValue(Node? node, int target)
        {
            if (node == null) return false;
            else
            {
                if (node.Value == target) return true;
                else
                {
                    if (node.Value > target)
                    {
                        return FindValue(node.LeftChild, target);
                    }
                    else
                    {
                        return FindValue(node.RightChild, target);
                    }
                }
            }
        }

        public static int CalculateLeaves(Node? node)
        {
            if (node == null) return 0;
            else
            {
                if (node.LeftChild == null && node.RightChild == null) return 1;
                else
                {
                    return CalculateLeaves(node.LeftChild) + CalculateLeaves(node.RightChild);
                }
            }
        }
    }
}
