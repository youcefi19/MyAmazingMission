using MyAmazingMission.Arbres;
using MyAmazingMission.ListeChainee;
using MyAmazingMission.Tableaux;

namespace MyAmazingMission
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //TestListChainee();

            //TestTableau();

            Console.ReadKey();
        }

        public static void TestListChainee()
        {
            ListeChainee.Node node5 = new ListeChainee.Node(9, null);
            ListeChainee.Node node4 = new ListeChainee.Node(3, node5);
            ListeChainee.Node node3 = new ListeChainee.Node(12, node4);
            ListeChainee.Node node2 = new ListeChainee.Node(8, node3);
            ListeChainee.Node node1 = new ListeChainee.Node(10, node2);
            LinkedList liste = new LinkedList();
            liste.Root = node1;

            Console.WriteLine("Initial list : ");
            liste.ViewList();

            ListeChainee.Node? middle = liste.FindMiddle();
            if (middle != null)
            {
                Console.WriteLine($"the element at the middle of the list is {middle.Value}");
            }

            ListeChainee.Node? previous12 = liste.Previous(node1);
            if (previous12 != null)
            {
                Console.WriteLine($"the element preceding {node1.Value} is {previous12.Value}");
            }
            else
            {
                Console.WriteLine($"no element preceds {node1.Value}");
            }

            liste.Remove(node1);
            Console.WriteLine($"This is the new list after removing the node with value = {node1.Value} : ");
            liste.ViewList();

            liste.Invert();
            Console.WriteLine("This is the inverted list : ");
            liste.ViewList();

            ListeChainee.Node node6 = new ListeChainee.Node(4, null);
            liste.InsertRoot(node6);
            Console.WriteLine($"This is the list after adding {node6.Value} at the beginning : ");
            liste.ViewList();

            ListeChainee.Node node7 = new ListeChainee.Node(5, null);
            liste.InsertAfter(node2, node7);
            Console.WriteLine($"This is the list after adding {node7.Value} after {node2.Value} : ");
            liste.ViewList();

            ListeChainee.Node node8 = new ListeChainee.Node(1, null);
            liste.InsertBefore(node5, node8);
            Console.WriteLine($"This is the list after adding {node8.Value} before {node5.Value} : ");
            liste.ViewList();
        }

        public static void TestTableau()
        {
            int[] tab = new int[] { 5, 16, 11, -2, 0, -5, 3, 7, 1, 8 };

            Console.WriteLine("Tableau état initial : ");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write($"{tab[i]} | ");
            }
            Console.WriteLine(Environment.NewLine);

            tab = Arrays.TriFusion(tab);
            Console.WriteLine("Tableau après tri fusion : ");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write($"{tab[i]} | ");
            }
            Console.WriteLine(Environment.NewLine);

            Arrays.JaggedArrays();
            Arrays.MultidimensionalArrays();
            Arrays.MixArrays();

            //Tri.TriInsertion(tab);
        }

        public static void TestArbre()
        {
            Arbres.Node TestTree = new(
                5,
                new Arbres.Node(2, new Arbres.Node(1), new Arbres.Node(4, new Arbres.Node(3))),
                new Arbres.Node(8, new Arbres.Node(6), new Arbres.Node(10))
                );

             BinaryTreeOperations.PrintAllNodes(TestTree);

            Console.WriteLine(string.Format("Depth of the tree = {0}", BinaryTreeOperations.Depth(TestTree)));

            BinaryTreeOperations.PrintCurrentLevel(TestTree.LeftChild, 3);

            BinaryTreeOperations.PrintLevelOrder(TestTree);

            BinaryTreeOperations.PrintLevelOrderUsingQueue(TestTree);

            BinaryTreeOperations.Preorder(TestTree);
            Console.WriteLine();
            BinaryTreeOperations.IterativePreorder(TestTree);
            Console.WriteLine();
            BinaryTreeOperations.Inorder(TestTree);
            Console.WriteLine();
            BinaryTreeOperations.IterativeInorder(TestTree);
            Console.WriteLine();
            BinaryTreeOperations.IterativePostOrder(TestTree);

            Console.WriteLine("Nombre de feuilles = " + BinaryTreeOperations.CalculateLeaves(TestTree));
        }
    }
}