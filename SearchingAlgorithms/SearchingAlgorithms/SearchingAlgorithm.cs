namespace SearchingAlgorithms
{
    internal class SearchingAlgorithm
    {
        // https://www.youtube.com/watch?v=9J5OTuk2_CI
        /// <summary>
        /// <strong>Linear search</strong> is a sequential searching algorithm where we start from one end and check every element of the
        /// list until the desired element is found.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(1);</item>
        ///         <item>Average: θ(n);</item>
        ///         <item>Worst: O(n).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        /// <param name="targetElement">The element that is searched for.</param>
        /// <returns>
        /// <list type="bullet">
        ///     <item><description>The index of the first match of the element in the array if it is found.</description></item>
        ///     <item><description>Null if the element is not present in the array.</description></item>
        /// </list>
        /// </returns>
        public static int? LinearSearch(int[] array, int targetElement)
        {
            for (int index = 0; index < array.Length; index++)
            {
                bool isFound = array[index] == targetElement;
                if (isFound)
                {
                    return index;
                }
            }

            return null;
        }

        // https://www.youtube.com/watch?v=wNOoyZ45SmQ
        /// <summary>
        /// <strong>Jump Search</strong> is a searching algorithm for sorted arrays. The basic idea is to check fewer elements 
        /// (than <see cref="LinearSearch(int[], int)"/>) by jumping ahead by fixed steps or skipping some elements in place of 
        /// searching all elements.
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(1);</item>
        ///         <item>Average: θ(√n);</item>
        ///         <item>Worst: O(√n).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="sortedArray">An ascending sorted array of integers.</param>
        /// <param name="targetElement">he element that is searched for.</param>
        /// <returns>
        ///     <list type="bullet">
        ///         <item><description>The index of the first match of the element in the array if it is found.</description></item>
        ///         <item><description>Null if the element is not present in the array.</description></item>
        ///     </list>
        /// </returns>
        public static int? JumpSearch(int[] sortedArray, int targetElement)
        {
            int stepsToJump = (int)Math.Sqrt(sortedArray.Length);
            int blockStartIndex = 0;
            int blockEndIndex = stepsToJump;

            bool blockIsFound = false;
            while (!blockIsFound)
            {
                blockStartIndex = blockEndIndex;
                blockEndIndex += stepsToJump;

                blockIsFound = sortedArray[Math.Min(blockEndIndex, sortedArray.Length) - 1] >= targetElement;

                if (blockStartIndex >= sortedArray.Length) return null;
            }

            while (sortedArray[blockStartIndex] < targetElement)
            {
                blockStartIndex++;

                bool isOutOfBlockBounds = blockStartIndex == Math.Min(blockEndIndex, sortedArray.Length);
                if (isOutOfBlockBounds) return null;
            }

            bool elementIsFound = sortedArray[blockStartIndex] == targetElement;
            if (elementIsFound) return blockStartIndex;

            return null;
        }

        // https://www.youtube.com/watch?v=B25Gu5r0xUg
        /// <summary>
        /// <strong>Binary Search</strong> is a searching algorithm used in a sorted array by repeatedly dividing the search interval in 
        /// half. The idea of binary search is to use the information that the array is sorted and reduce the time complexity.<br></br>
        /// <strong>
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(1);</item>
        ///         <item>Average: θ(logn);</item>
        ///         <item>Worst: O(logn).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="sortedArray">An ascending sorted array of integers.</param>
        /// <param name="desiredElement">The element that is searched for.</param>
        /// <returns>
        ///     <list type="bullet">
        ///         <item><description>The index of the first match of the element in the array if it is found.</description></item>
        ///         <item><description>Null if the element is not present in the array.</description></item>
        ///     </list>
        /// </returns>
        public static int? BinarySearch(int[] sortedArray, int desiredElement)
        {
            int minNumberIndex = 0;
            int maxNumberIndex = sortedArray.Length - 1;

            while (minNumberIndex <= maxNumberIndex)
            {
                int middleNumberIndex = (minNumberIndex + maxNumberIndex) / 2;

                bool isFound = desiredElement == sortedArray[middleNumberIndex];
                if (isFound) return middleNumberIndex;
                else if (desiredElement < sortedArray[middleNumberIndex])
                {
                    maxNumberIndex = middleNumberIndex - 1;
                }
                else
                {
                    minNumberIndex = middleNumberIndex + 1;
                }
            }

            return null;
        }

        /// <summary>
        /// Recursive realization of the <strong><see cref="BinarySearch(int[], int)"/><br></br>.
        /// Time complexity:<br></br>
        ///     <list type="bullet">
        ///         <item>Best: Ω(1);</item>
        ///         <item>Average: θ(logn);</item>
        ///         <item>Worst: O(logn).</item>
        ///     </list>
        /// </strong>
        /// </summary>
        /// <param name="sortedArray">An ascending sorted array of integers.</param>
        /// <param name="smallestIntegerIndex">The index of the smallest integer.</param>
        /// <param name="largestIntegerIndex">The index of the largest integer.</param>
        /// <param name="targetElement">The element that is searched for.</param>
        /// <returns>
        ///     <list type="bullet">
        ///         <item><description>The index of the first match of the element in the array if it is found.</description></item>
        ///         <item><description>Null if the element is not present in the aray.</description></item>
        ///     </list>
        /// </returns>
        public static int? BinarySearchRecursive(int[] sortedArray, int smallestIntegerIndex, int largestIntegerIndex, 
            int targetElement)
        {
            if (largestIntegerIndex >= smallestIntegerIndex)
            {
                int middleNumberIndex = smallestIntegerIndex + (largestIntegerIndex - smallestIntegerIndex) / 2;

                if (sortedArray[middleNumberIndex] == targetElement) return middleNumberIndex;

                if (sortedArray[middleNumberIndex] > targetElement)
                {
                    return BinarySearchRecursive(sortedArray, smallestIntegerIndex, middleNumberIndex - 1, targetElement);
                }

                return BinarySearchRecursive(sortedArray, middleNumberIndex + 1, largestIntegerIndex, targetElement);
            }

            return null;
        }

        // https://www.youtube.com/watch?v=K9n_mkLvRBs
        /// <summary>
        /// <strong>Fibonacci search</strong> technique is a method of searching a sorted array using a divide and conquer algorithm 
        /// that narrows down possible locations with the aid of Fibonacci numbers. Fibonacci search divides the array into two parts that have sizes that 
        /// are consecutive Fibonacci numbers as the greater one must be the smallest Fibonacci number that is greater than or equal to the 
        /// array size.
        /// </summary>
        /// <param name="sortedArray">An ascending sorted array of integers.</param>
        /// <param name="targetElement">he element that is searched for.</param>
        /// <returns>
        ///     <list type="bullet">
        ///         <item><description>The index of the first match of the element in the array if it is found.</description></item>
        ///         <item><description>Null if the element is not present in the array.</description></item>
        ///     </list>
        /// </returns>
        public static int? FibonacciSearch(int[] sortedArray, int targetElement)
        {
            /* Initialize fibonacci numbers */
            int previousOfThePreviousFibonacciNumber = 0; // (m-2)'th Fibonacci No.
            int previousFibonacciNumber = 1; // (m-1)'th Fibonacci No.
            int fibonacciNumber = previousOfThePreviousFibonacciNumber + previousFibonacciNumber; // m'th Fibonacci

            // fibonacciNumber is going to store the smallest Fibonacci number greater than or equal to the array length
            bool fibonacciNumbersAreBeingCalculated = true;
            while (fibonacciNumbersAreBeingCalculated)
            {
                previousOfThePreviousFibonacciNumber = previousFibonacciNumber;
                previousFibonacciNumber = fibonacciNumber;
                fibonacciNumber = previousOfThePreviousFibonacciNumber + previousFibonacciNumber;

                fibonacciNumbersAreBeingCalculated = fibonacciNumber < sortedArray.Length;
            }

            // Marks the eliminated range from front
            int offset = -1;

            /* while there are elements to be inspected.
            Note that we compare sortedArray[previousOfThePreviousFibonacciNumber] with x.
            When fibonacciNumber becomes 1, previousOfThePreviousFibonacciNumber becomes 0 */
            bool thereAreElementsToBeInspected = true;
            while (thereAreElementsToBeInspected)
            {
                // Check if previousOfThePreviousFibonacciNumber is a valid location
                int index = Math.Min(offset + previousOfThePreviousFibonacciNumber, sortedArray.Length - 1);

                /* If targetNumber is greater than the value at index previousOfThePreviousFibonacciNumber, cut the subarray array 
                 * from offset to i */
                if (sortedArray[index] < targetElement)
                {
                    fibonacciNumber = previousFibonacciNumber;
                    previousFibonacciNumber = previousOfThePreviousFibonacciNumber;
                    previousOfThePreviousFibonacciNumber = fibonacciNumber - previousFibonacciNumber;
                    offset = index;
                }
                // If target element is less than the value at index previousOfThePreviousFibonacciNumber, cut the subarray after i+1
                else if (sortedArray[index] > targetElement)
                {
                    fibonacciNumber = previousOfThePreviousFibonacciNumber;
                    previousFibonacciNumber = previousFibonacciNumber - previousOfThePreviousFibonacciNumber;
                    previousOfThePreviousFibonacciNumber = fibonacciNumber - previousFibonacciNumber;
                }
                else return index;

                thereAreElementsToBeInspected = fibonacciNumber > 1;
            }

            // Comparing the last element with the target element
            bool previousFibonacciNumberIsFirstFibonacciNumber = previousFibonacciNumber == 1;
            bool lastElementIsTarget = sortedArray[sortedArray.Length - 1] == targetElement;
            if (previousFibonacciNumberIsFirstFibonacciNumber && lastElementIsTarget) return sortedArray.Length - 1;

            return null;
        }
    }
}