using System.Text;

namespace SortingAlgorithms
{
    // https://github.com/ivandobrinovv/AlgorithmsAndDataStructures/blob/main/SortAlgorithmsExamples/Sort.Buisiness/Helpers/SortHelper.cs
    internal static class SortingAlgorithm
    {
        // https://www.youtube.com/watch?v=g-PGLbMth_g
        /// <summary>
        /// The <strong>selection sort</strong> algorithm sorts an array by repeatedly finding the minimum element (considering ascending order) 
        /// from unsorted part and putting it at the beginning. The algorithm maintains two subarrays in a given array:
        ///     <list type="bullet">
        ///         <item>The subarray which is already sorted.</item>
        ///         <item>Remaining subarray which is unsorted.</item>
        ///     </list>
        /// In every iteration of selection sort, the minimum element (considering ascending order) from the unsorted subarray is 
        /// picked and moved to the sorted subarray.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(n^2);</item>
        ///         <item>Average: θ(n^2);</item>
        ///         <item>Worst: O(n^2).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                ref int initialElement = ref array[i];
                int currentElement = initialElement;
                int currentMinElement = currentElement;
                int currentMinElementIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    currentElement = array[j];

                    if (currentElement < currentMinElement)
                    {
                        currentMinElement = currentElement;
                        currentMinElementIndex = j;
                    }
                }

                SwapElements(ref initialElement, ref array[currentMinElementIndex]);
            }
        }

        // https://www.youtube.com/watch?v=xli_FI7CuzA
        /// <summary>
        /// <strong>Bubble Sort</strong> works by repeatedly swapping the neighbouring elements if they are in the wrong order.
        /// The highest number will "bubble" itself to the right with each itteration. A sorted partition will form at the end
        /// of the array.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(n);</item>
        ///         <item>Average: θ(n^2);</item>
        ///         <item>Worst: O(n^2).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        public static void BubbleSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                bool isChanged = false;

                for (int j = 0; j < array.Length - 1; j++)
                {
                    ref int currentElement = ref array[j];
                    ref int nextElement = ref array[j + 1];

                    if (currentElement > nextElement)
                    {
                        SwapElements(ref currentElement, ref nextElement);
                        isChanged = true;
                    }
                }

                if (!isChanged) break;
            }
        }

        /// <summary>
        /// <strong>Reverse Bubble Sort</strong> works by repeatedly swapping the neighbouring elements if they are in the wrong 
        /// order. The lowest number will "sink" to the left with each itteration. A sorted partition will form at the begining
        /// of the array.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(n);</item>
        ///         <item>Average: θ(n^2);</item>
        ///         <item>Worst: O(n^2).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        public static void ReverseBubbleSort(int[] array)
        {
            for (int i = array.Length - 2; i >= 0; i--)
            {
                bool isChanged = false;

                for (int j = array.Length - 1; j >= 1; j--)
                {
                    ref int currentElement = ref array[j];
                    ref int previousElement = ref array[j - 1];

                    if (currentElement < previousElement)
                    {
                        SwapElements(ref currentElement, ref previousElement);
                        isChanged = true;
                    }
                }

                if (!isChanged)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// <strong>Cocktail Shaker Sort</strong> is a variation of <see cref="BubbleSort"/>. Cocktail Shaker Sort traverses 
        /// through a given array in both directions alternatively. Basically it is combination of <see cref="BubbleSort(int[])"/> 
        /// and <see cref="ReverseBubbleSort(int[])"/>.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(n);</item>
        ///         <item>Average: θ(n^2);</item>
        ///         <item>Worst: O(n^2).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        // https://www.youtube.com/watch?v=njClLBoEbfI
        public static void CocktailShakerSort(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool isChanged = false;

                for (int j = 0; j < array.Length - 1; j++)
                {
                    ref int currentElement = ref array[j];
                    ref int nextElement = ref array[j + 1];

                    if (currentElement > nextElement)
                    {
                        SwapElements(ref currentElement, ref nextElement);
                        isChanged = true;
                    }
                }

                if (!isChanged)
                {
                    break;
                }

                for (int j = array.Length - 1; j >= 1; j--)
                {
                    ref int currentElement = ref array[j];
                    ref int previousElement = ref array[j - 1];

                    if (currentElement < previousElement)
                    {
                        SwapElements(ref currentElement, ref previousElement);
                        isChanged = true;
                    }
                }

                if (!isChanged)
                {
                    break;
                }
            }
        }

        // https://www.youtube.com/watch?v=JU767SDMDvA
        /// <summary>
        /// <strong>Insertion sort</strong> is a simple sorting algorithm that works similar to the way you sort playing cards in your hands. 
        /// The array is virtually split into a sorted and an unsorted part. Values from the unsorted part are picked and placed at 
        /// the correct position in the sorted part.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(n);</item>
        ///         <item>Average: θ(n^2);</item>
        ///         <item>Worst: O(n^2).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;

                ref int previousElement = ref array[j - 1];
                ref int currentElement = ref array[j];

                while (previousElement > currentElement)
                {
                    SwapElements(ref currentElement, ref previousElement);
                    j--;

                    if (j <= 0)
                    {
                        break;
                    }

                    previousElement = ref array[j - 1];
                    currentElement = ref array[j];
                }
            }
        }

        // https://www.youtube.com/watch?v=Hoixgm4-P4M
        /// <summary>
        /// <strong>Quick Sort</strong> is a Divide and Conquer algorithm. It picks an element as pivot and partitions the given 
        /// array around the picked pivot.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(nlogn);</item>
        ///         <item>Average: θ(nlogn);</item>
        ///         <item>Worst: O(n^2).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        /// <param name="leftmostElementIndex">The index of the leftmost element of the array to sort</param>
        /// <param name="rightmostElementIndex">The index of the rightmost element of the array to sort</param>
        public static void QuickSort(int[] array, int leftmostElementIndex, int rightmostElementIndex)
        {
            if (leftmostElementIndex < rightmostElementIndex)
            {
                int pivotIndex = Partition(array, leftmostElementIndex, rightmostElementIndex);

                if (pivotIndex > 1)
                {
                    QuickSort(array, leftmostElementIndex, pivotIndex - 1);
                }

                if (pivotIndex + 1 < rightmostElementIndex)
                {
                    QuickSort(array, pivotIndex + 1, rightmostElementIndex);
                }
            }
        }

        // https://www.youtube.com/watch?v=2DmK_H7IdTo
        /// <summary>
        /// <strong>Heap Sort</strong> is a comparison-based sorting algorithm. Heap Sort can be thought of as an improved 
        /// <see cref="SelectionSort(int[])"/>: like Selection Sort, Heap Sort divides its input into a sorted and an unsorted 
        /// region, and it iteratively shrinks the unsorted region by extracting the largest element from it and inserting it 
        /// into the sorted region. Unlike Selection Sort, heapsort does not waste time with a linear-time scan of the unsorted 
        /// region; rather, Heap Sort maintains the unsorted region in a heap data structure to more quickly find the largest 
        /// element in each step.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(nlogn);</item>
        ///         <item>Average: θ(nlogn);</item>
        ///         <item>Worst: O(nlogn).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers</param>
        public static void HeapSort(int[] array)
        {
            // Call the Heapify method for each parent element starting from the last one to form a pyramid
            for (int i = array.Length / 2; i > 0; i--)
            {
                Heapify(array, i - 1, array.Length - 1);
            }

            int firstElementIndex = 0;
            ref int firstElement = ref array[firstElementIndex];
            for (int i = array.Length - 1; i > 0; i--)
            {
                ref int currentElement = ref array[i];
                SwapElements(ref firstElement, ref currentElement);

                int previousElementIndex = i - 1;
                Heapify(array, firstElementIndex, previousElementIndex);
            }
        }

        // https://www.youtube.com/watch?v=4VqmGXwpLqc
        /// <summary>
        /// Like <see cref="QuickSort(int[], int, int)"/>, <strong>Merge Sort</strong> is a Divide and Conquer algorithm. It 
        /// divides the input array into two halves, calls itself for the two halves, and then it merges the two sorted 
        /// halves.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(nlogn);</item>
        ///         <item>Average: θ(nlogn);</item>
        ///         <item>Worst: O(nlogn).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        /// <param name="leftmostElementIndex">The index of the leftmost element of the array to sort</param>
        /// <param name="rightmostElementIndex">The index of the rightmost element of the array to sort</param>
        public static void MergeSort(int[] array, int leftmostElementIndex, int rightmostElementIndex)
        {
            if (leftmostElementIndex < rightmostElementIndex)
            {
                int middleElementIndex = (leftmostElementIndex + rightmostElementIndex) / 2;
                MergeSort(array, leftmostElementIndex, middleElementIndex);
                MergeSort(array, middleElementIndex + 1, rightmostElementIndex);
                MergeSubarrays(array, leftmostElementIndex, middleElementIndex, rightmostElementIndex);
            }
        }

        public static int[] GenerateArrayWithRandomIntegers(int lowerBound, int upperBound, int integersCount)
        {
            try
            {
                if (lowerBound >= upperBound)
                {
                    throw new ArgumentException("Upper bound must be greater than lower bound!");
                }

                int[] array = new int[integersCount];

                Random random = new Random();

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(lowerBound, upperBound);
                }

                return array;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            return null;
        }

        public static string ArrayToString(int[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (int element in array)
            {
                stringBuilder.Append(element.ToString() + ' ');
            }

            string arrayString = stringBuilder.ToString().TrimEnd();

            return arrayString;
        }

        // Quick sort
        /// <summary>
        /// Given an array and an element of array as pivot, put the element at its correct position in sorted array and put all 
        /// smaller elements than it before it, and put all greater than it elements after it.
        /// </summary>
        /// <param name="array">An array of integers.</param>
        /// <param name="leftmostIndex">The leftmost index of the subarray to get pivot from.</param>
        /// <param name="rightmostIndex">The rightmost index of the subarray to get pivot from.</param>
        /// <returns>New pivot index.</returns>
        private static int Partition(int[] array, int leftmostIndex, int rightmostIndex)
        {
            int pivot = array[leftmostIndex];
            int pivotIndex;

            while (true)
            {
                while (array[leftmostIndex] < pivot)
                {
                    leftmostIndex++;
                }

                while (array[rightmostIndex] > pivot)
                {
                    rightmostIndex--;
                }

                if (leftmostIndex < rightmostIndex)
                {
                    if (array[leftmostIndex] == array[rightmostIndex])
                    {
                        pivotIndex = rightmostIndex;
                        break;
                    }

                    SwapElements(ref array[leftmostIndex], ref array[rightmostIndex]);
                }
                else
                {
                    pivotIndex = rightmostIndex;
                    break;
                }
            }

            return pivotIndex;
        }

        // Heap sort
        /// <summary>
        /// Reshaping a binary tree into a Heap data structure is known as <strong>‘heapify’</strong>. A binary tree is a tree 
        /// data structure that has two child nodes at max. If a node’s children nodes are ‘heapified’, then only ‘heapify’ 
        /// process can be applied over that node. A heap should always be a complete binary tree. 
        /// </summary>
        /// <param name="array">An array of integers.</param>
        /// <param name="startIndex">The start index of the subarray to get 'heapified'.</param>
        /// <param name="endIndex">The end index of the subarray to get 'heapified'.</param>
        private static void Heapify(int[] array, int startIndex, int endIndex)
        {
            int parentIndex = startIndex;
            int childIndex = parentIndex * 2 + 1;
            int itemValue = array[parentIndex];

            while (childIndex <= endIndex)
            {
                // Take the index of the child with bigger value
                if (childIndex < endIndex && array[childIndex] < array[childIndex + 1])
                {
                    childIndex++;
                }

                /* Check if the value of the the start item is bigger than both children's values (if this is the correct place for
                 * it) and if it is break */
                if (itemValue >= array[childIndex]) break;

                // Set the value of the bigger child as parent value
                array[parentIndex] = array[childIndex];

                // Take the index of the bigger child as a parent index
                parentIndex = childIndex;

                // Take the index of the first child of the new parent index
                childIndex *= 2;
                childIndex++;
            }

            // Set the value of the start item on the correct place (as found from the logic above)
            array[parentIndex] = itemValue;
        }

        // Merge sort
        /// <summary>
        /// It is used for merging two half-arrays. The merge is a key process that assumes that both subarrays are sorted and merges 
        /// them into one.
        /// </summary>
        /// <param name="array">The array of integers to get its both halves sorted (therefore the whole array) and merged</param>
        /// <param name="leftmostElementIndex">The index of the leftmost element of the array to get sorted.</param>
        /// <param name="middleElementIndex">The index of the middle element of the array (seperating the both half-arrays)
        /// to get sorted.</param>
        /// <param name="rightmostElementIndex">The index of the rightmost element of the left array to get sorted.</param>
        private static void MergeSubarrays(int[] array, int leftmostElementIndex, int middleElementIndex, 
            int rightmostElementIndex)
        {
            rightmostElementIndex++;
            middleElementIndex++;
            int leftSubarrayRightmostElementIndex = middleElementIndex;
            int rightSubarrayLeftmostElementIndex = middleElementIndex;
            int leftSubarrayLeftmostElementIndex = leftmostElementIndex;

            int arrayLength = rightmostElementIndex - leftmostElementIndex;
            int[] tempArray = new int[arrayLength];
            int i;

            // Stop when all of the elements from one of the subarrays are used
            for (i = 0; i < arrayLength && leftmostElementIndex != leftSubarrayRightmostElementIndex && 
                rightSubarrayLeftmostElementIndex != rightmostElementIndex; i++)
            {
                if (array[leftmostElementIndex] < array[rightSubarrayLeftmostElementIndex])
                {
                    tempArray[i] = array[leftmostElementIndex++];
                }
                else
                {
                    tempArray[i] = array[rightSubarrayLeftmostElementIndex++];
                }
            }

            // Set the elements left from the right subarray at the end of the tempArray if there are any
            if (leftmostElementIndex == leftSubarrayRightmostElementIndex)
            {
                while (i < arrayLength)
                {
                    tempArray[i++] = array[rightSubarrayLeftmostElementIndex++];
                }
            }

            // Set the elements left from the left subarray at the end of the tempArray if there are any
            if (rightSubarrayLeftmostElementIndex == rightmostElementIndex)
            {
                while (i < arrayLength)
                {
                    tempArray[i++] = array[leftmostElementIndex++];
                }
            }

            // Set the sorted subarray's values as values in the original array
            for (i = 0; i < arrayLength; i++)
            {
                array[leftSubarrayLeftmostElementIndex++] = tempArray[i];
            }
        }

        /// <summary>
        /// Method for swapping two integers in an array.
        /// </summary>
        private static void SwapElements(ref int firstInteger, ref int secondInteger)
        {
            int tempValue = firstInteger;
            firstInteger = secondInteger;
            secondInteger = tempValue;
        }
    }
}