using System;
using System.Diagnostics;

namespace ActualSortingAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*int[] arr1 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
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
            Console.WriteLine("4: Merge sort");

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
                case "4":
                    // call merge sort method
                    MergeSort(arr1);
                    break;
                default:
                    // the case did not match
                    break;

                


            }
            PrintArray(students);

            int[] mergeArray = { 3, 2, 5, 6, 7, 4, 1, 0 };
            MergeSort(mergeArray);*/
            int[] mergeArray = { 3, 2, 5, 6, 7, 4, 1, 0 };
            MergeSort(mergeArray);
            QuickSort(arr1);
            Console.WriteLine(mergeArray);

        }

        /// <summary>
        /// Utilizes a quicksort algorithm to sort a passed in array
        /// </summary>
        /// <param name="arr">the array which should be sorted</param>
        /// <param name="low">the smallwer index of the (sub)array</param>
        /// <param name="high">the larger index of the (sub)array</param>
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                //partition return pivot to us
                int pivotIndex = Partition(arr, low, high);
                //call quicksort again on the new subarrays passed on pivots position
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; //setting pivot as the last value
            int i = low - 1;
            
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    //swap - could also move this into a helper method
                    Swap(arr, i, j);
                    
                }
            }
            Swap(arr, ++i, high);
            return i;
      
        }

        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
        // Responsible for spling the array and merging into togther
        // Recursive function
        public static void MergeSort(int[] arr)
        {
            // Base case: if the array has 1 or no elements, it's already sorted
            if (arr.Length <= 1) return;

            // Find the middle index of the array
            int mid = arr.Length / 2;

            // Create subarrays for the left and right halves of the original array
            int[] leftSubArray = new int[mid];
            int[] rightSubArray = new int[arr.Length - mid];

            // Copy elements to the left subarray
            for (int i = 0; i < mid; i++)
            {
                leftSubArray[i] = arr[i];
            }

            // Copy elements to the right subarray
            for (int i = mid; i < arr.Length; i++)
            {
                rightSubArray[i - mid] = arr[i];
            }

            // Recursively sort the left and right subarrays
            MergeSort(leftSubArray);
            MergeSort(rightSubArray);

            // Merge the sorted subarrays back into the original array
            Merge(arr, leftSubArray, rightSubArray);
        }

        public static void Merge(int[] arr, int[] leftSubArray, int[] rightSubArray)
        {
            int left = 0, right = 0, merged = 0;

            // Merge elements from left and right subarrays in sorted order
            while (left < leftSubArray.Length && right < rightSubArray.Length)
            {
                if (leftSubArray[left] <= rightSubArray[right])
                {
                    arr[merged++] = leftSubArray[left++];
                }
                else
                {
                    arr[merged++] = rightSubArray[right++];
                }
            }

            // Copy any remaining elements from the left subarray
            // while the left sub arr and right sub arr has vakues
            // we will eval which value is less and make assessments
            while (left < leftSubArray.Length)
            {
                arr[merged++] = leftSubArray[left++];
            }

            // Copy any remaining elements from the right subarray
            while (right < rightSubArray.Length)
            {
                arr[merged++] = rightSubArray[right++];
            }
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
