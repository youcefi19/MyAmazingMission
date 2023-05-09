using MyAmazingMission.ListeChainee;
using MyAmazingMission.Tableaux;
using System;

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
            Node node5 = new Node(9, null);
            Node node4 = new Node(3, node5);
            Node node3 = new Node(12, node4);
            Node node2 = new Node(8, node3);
            Node node1 = new Node(10, node2);
            LinkedList liste = new LinkedList();
            liste.Root = node1;

            Console.WriteLine("Initial list : ");
            liste.ViewList();

            Node? middle = liste.FindMiddle();
            if (middle != null)
            {
                Console.WriteLine($"the element at the middle of the list is {middle.Value}");
            }

            Node? previous12 = liste.Previous(node1);
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

            Node node6 = new Node(4, null);
            liste.InsertRoot(node6);
            Console.WriteLine($"This is the list after adding {node6.Value} at the beginning : ");
            liste.ViewList();

            Node node7 = new Node(5, null);
            liste.InsertAfter(node2, node7);
            Console.WriteLine($"This is the list after adding {node7.Value} after {node2.Value} : ");
            liste.ViewList();

            Node node8 = new Node(1, null);
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
    }
}