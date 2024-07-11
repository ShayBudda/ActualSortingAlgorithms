using System;

namespace ActualSortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 45, 56, 34, 65, 87, 12, 89 };
            PrintArray(arr1);
            BubbleSort(arr1);
            PrintArray(arr1);
        }
        public static void PrintArray(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        
        }
        public static Array BubbleSort(int[] arraytosort)
        {
            int temp;
            //Overall O(n^2) runtime - Big O
            //
            for (int i = 0; i < arraytosort.Length - 1; i++) //O(n)how many times it goes through the unsorted array
            {
                int swaps = 0;
                for (int j = 0; j < arraytosort.Length - 1 - i; j++)//O(n)
                {
                    if (arraytosort[j] > arraytosort[j + 1])
                    {
                        swaps++;
                        temp = arraytosort[j];
                        arraytosort[j] = arraytosort[j + 1];
                        arraytosort[j + 1] = temp;
                    }
                }
                if (swaps == 0) break; // break out of the loop if there are no swaps
            }
            return arraytosort;
        }

    }
}
