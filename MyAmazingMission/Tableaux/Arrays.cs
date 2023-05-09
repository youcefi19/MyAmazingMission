using System.Net;
using System;

namespace MyAmazingMission.Tableaux
{
    public class Arrays
    {
        public static void TriInsertion(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                int current = tab[i];
                int index = i - 1;

                while (index >= 0 && tab[index] > current)
                {
                    tab[index + 1] = tab[index];
                    index = index - 1;
                }
                tab[index + 1] = current;
            }

            Console.WriteLine("Tableau après Tri Insertion : ");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write($"{tab[i]} | ");
            }
            Console.WriteLine(Environment.NewLine);
        }

        public static int[] TriFusion(int[] tab)
        {
            if (tab.Length > 1)
            {
                // initialize left and right arrays
                int midIndex = tab.Length / 2;
                int[] left = new int[midIndex];
                int[] right;
                if (tab.Length % 2 == 0) right = new int[midIndex];
                else right = new int[midIndex + 1];

                // populate left array
                for (int i = 0; i < midIndex; i++)
                {
                    left[i] = tab[i];
                }
                // populate right array
                int x = 0;
                for (int i = midIndex; i < tab.Length; i++)
                {
                    right[x] = tab[i];
                    x++;
                }

                TriFusion(left);
                TriFusion(right);

                int leftIndex = 0, rightIndex = 0, globalIndex = 0;

                // loop until we reach the end of the left or the right array
                while (leftIndex < left.Length && rightIndex < right.Length)
                {
                    // if the left element is smaller its should be first in the array
                    // else the right element should be first
                    // move indexes at each steps
                    if (left[leftIndex] < right[rightIndex])
                    {
                        tab[globalIndex] = left[leftIndex];
                        leftIndex++;
                    }
                    else
                    {
                        tab[globalIndex] = right[rightIndex];
                        rightIndex++;
                    }
                    globalIndex++;
                }

                // making sure that any element was not left behind during the process
                while (leftIndex < left.Length)
                {
                    tab[globalIndex] = left[leftIndex];
                    leftIndex++;
                    globalIndex++;
                }
                while (rightIndex < right.Length)
                {
                    tab[globalIndex] = right[rightIndex];
                    rightIndex++;
                    globalIndex++;
                }
            }

            return tab;
        }

        public static void JaggedArrays()
        {
            int[][] jagged = new int[3][]
            {
                new int[2] { 3, 11 },
                new int[2] { 2, 5 },
                new int[2] { 9, 4 }
            };

            Console.WriteLine($"The first element of the second inner array = {jagged[1][0]}");
        }

        public static void MultidimensionalArrays()
        {
            int[,] array2D = new int[4, 2] {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 },
                { 7, 8 }
            };

            Console.WriteLine($"The element at the second column of the third row array = {array2D[2, 1]}");

            int[,,] array3D = new int[2, 2, 3] {
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 }
                },
                {
                    { 7, 8, 9 },
                    { 10, 11, 12 }
                }
            };

            Console.WriteLine($"The element at the second height (3D) of the first column and second row = {array3D[1, 0, 1]}");
        }

        public static void MixArrays()
        {
            int[][,] jaggedArrayOfMultiDimArrays = new int[3][,] { 
                new int[,] { 
                    { 1, 3 },
                    { 5, 7 }
                }, 
                new int[,] {
                    { 0, 2 },
                    { 4, 6 },
                    { 8, 10 }
                }, 
                new int[,] {
                    { 11, 22 },
                    { 99, 88 },
                    { 0, 9 }
                } 
            };

            Console.WriteLine(
                $"The element at the second column of the first row in the third cell of the outer array = {jaggedArrayOfMultiDimArrays[2][0, 1]}");
        }
    }
}
