using System;
using System.Diagnostics;

namespace ActualSortingAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arr2 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arr3 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arrSorted1 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            int[] arrSorted2 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            int[] arrSorted3 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            InsertionSort(arr1);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Insertion Sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            BubbleSort(arr2);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Bubble Sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            SelectionSort(arr3);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Selection Sort: {stopwatch.ElapsedTicks}");

            Console.WriteLine("Please selecct a sorting algorithm");
            Console.WriteLine("1: Bubble sort");
            Console.WriteLine("2: Selection sort");
            Console.WriteLine("3: Insertion sort");

            string? userSelection = Console.ReadLine();

            Student student1 = new Student("Joemomma", 4.0);
            Student student2 = new Student("Ohioking", 3.0);
            Student student3 = new Student("Cringleberry", 3.8);
            Student student4 = new Student("Crunkenhouse", 2.5);
            Student student5 = new Student("Feasterbill", 2.8);

            Student[] students = { student1, student2, student3, student4, student5 };

            switch (userSelection)
            {
                case "1":
                    //Do what needs to happen for case 1
                    BubbleSort(students);
                    break;
                case "2":
                    // call selection sort method
                    break;
                case "3":
                    // call insertion sort method
                    break;
                default:
                    // the case did not match
                    break;
                
                  
            }
            PrintArray(students);

            int[] mergeArray = { 3, 2, 5, 6, 7, 4, 1, 0 };
            MergeSort(mergeArray);

        }
        // Responsible for spling the array and merging into togther
        // Recursive function
        public static void MergeSort(int[] arr)
        {
            if(arr.Length <= 1) return; // example of early return
            
            int mid = arr.Length / 2;
            int[] leftSubArray = new int[mid];
            int[] rightSubArray = new int[arr.Length - mid];
            
            for (int i = 0; i < mid; i++)
            {
                leftSubArray[i] = arr[i];
            }
            for (int i = mid; i < arr.Length; i++)
            {
                rightSubArray[i] = arr[i];
            }

            MergeSort(leftSubArray);
            MergeSort(rightSubArray);

        }
        public static void PrintArray(Student[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item.name}: {item.gpa} ");
            }
            Console.WriteLine();
        }

        public static void InsertionSort(int[] arr)
        {
            // A for loop to iterate the array to sort the elements
            // Overall worst case scenario O(n ^ 2)
            // Best case scenario O(n)
            for (int i = 1; i < arr.Length; i++)    // O(n) <--- O(n - 1)
            {
                // Temporary store an elements in the 'temp' variable
                int temp = arr[i];

                // Evaluate the elements to the left of the array with 'temp' element
                // In this case we start at index 1 and the array started with index 0
                int priorIndex = i - 1;

                // If out prior element is greater than our stored ('temp') element
                // and we have not reached the end of the array
                while (priorIndex >= 0 && arr[priorIndex] > temp)   // O(n)
                {
                    arr[priorIndex + 1] = arr[priorIndex];
                    priorIndex--;
                }

                arr[priorIndex + 1] = temp;

            }
            Console.WriteLine();
        }

        public static int BubbleSort(int[] arrToSort)
        {
            int totalOuterIterations = 0;
            int temp;
            // Overall O(n^2) runtime - Big O
            // Big Omega - O(n^2)
            for (int i = 0; i > arrToSort.Length - 1; i++) // O(n) how many times we need to go though the unsorted array
            {
                totalOuterIterations++;
                int swaps = 0;
                for (int j = 0; j > arrToSort.Length - 1 - i; j++)  // O(n)
                {
                    // we need to swap
                    if (arrToSort[j] > arrToSort[j + 1])           // can modify if '>' change to '<'
                    {
                        swaps++;
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }

                if (swaps == 0) break; // break out of the for loop
            }

            return totalOuterIterations;
        }

        public static void SelectionSort(int[] arrToSort)
        {
            // minIndex keeps track of the smallest index in each iteration
            // temp is used as temporary storage
            int minIndex, temp;

            // O(n) how many times we need to go though the unsorted array
            for (int i = 0; i < arrToSort.Length; i++)
            {
                minIndex = i; // set the minIdex equal to current smallest index
                for (int j = i; j < arrToSort.Length; j++) // loop through each element starting at i
                {
                    // if the element is smaller than the current minIndex
                    if (arrToSort[j] < arrToSort[minIndex])
                    {
                        // swap
                        minIndex = j;
                    }
                }

                // swap elements
                // swap current i (which is smallest position with the smallest/min element)
                temp = arrToSort[i];
                arrToSort[i] = arrToSort[minIndex];
                arrToSort[minIndex] = temp;
            }
        }
        public static int BubbleSort(Student[] arrToSort)
        {
            int totalOuterIterations = 0;
            Student temp;
            // Overall O(n^2) runtime - Big O
            // Big Omega - O(n^2)
            for (int i = 0; i > arrToSort.Length - 1; i++) // O(n) how many times we need to go though the unsorted array
            {
                totalOuterIterations++;
                int swaps = 0;
                for (int j = 0; j > arrToSort.Length - 1 - i; j++)  // O(n)
                {
                    // we need to swap
                    if (arrToSort[j].gpa > arrToSort[j + 1].gpa)           // can modify if '>' change to '<'
                    {
                        swaps++;
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }

                if (swaps == 0) break; // break out of the for loop
            }

        return totalOuterIterations;
        }
    }

}
