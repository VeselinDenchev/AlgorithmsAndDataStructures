namespace SearchingAlgorithms
{
    internal class SearchingAlgorithm
    {
        /// <summary>
        /// <strong>Linear search</strong> is a sequential searching algorithm where we start from one end and check every element of the
        /// list until the desired element is found.<br></br>
        /// Time complexity: <strong>O(n)</strong>
        /// </summary>
        /// <param name="array">An array of integers.</param>
        /// <param name="desiredElement">The element that is searched for.</param>
        /// <returns>
        /// <list type="bullet">
        ///     <item><description>The index of the first match of the element in the array if it is found.</description></item>
        ///     <item><description>Null if the element is not present in the aray.</description></item>
        /// </list>
        /// </returns>
        public static int? LinearSearch(int[] array, int desiredElement)
        {
            for (int index = 0; index < array.Length; index++)
            {
                bool isFound = array[index] == desiredElement;
                if (isFound)
                {
                    return index;
                }
            }

            return null;
        }

        /// <summary>
        /// <strong>Binary Search</strong> is a searching algorithm used in a sorted array by repeatedly dividing the search interval in 
        /// half. The idea of binary search is to use the information that the array is sorted and reduce the time complexity.<br></br>
        /// Time complexity: <strong>O(logn)</strong>
        /// </summary>
        /// <param name="sortedArray">An ascending sorted array of integers.</param>
        /// <param name="desiredElement">The element that is searched for.</param>
        /// <returns>
        ///     <list type="bullet">
        ///         <item><description>The index of the first match of the element in the array if it is found.</description></item>
        ///         <item><description>Null if the element is not present in the aray.</description></item>
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
                if (isFound)
                {
                    return middleNumberIndex;
                }
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
        /// Recursive realization of the <strong><see cref="BinarySearch(int[], int)"/></strong>.
        /// </summary>
        /// <param name="sortedArray">An ascending sorted array of integers.</param>
        /// <param name="smallestIntegerIndex">The index of the smallest integer.</param>
        /// <param name="largestNumberIndex">The index of the largest integer.</param>
        /// <param name="desiredNumber">The element that is searched for.</param>
        /// <returns>
        ///     <list type="bullet">
        ///         <item><description>The index of the first match of the element in the array if it is found.</description></item>
        ///         <item><description>Null if the element is not present in the aray.</description></item>
        ///     </list>
        /// </returns>
        public static int? BinarySearchRecursive(int[] sortedArray, int smallestIntegerIndex, int largestNumberIndex, int desiredNumber)
        {
            if (largestNumberIndex >= smallestIntegerIndex)
            {
                int middleNumberIndex = smallestIntegerIndex + (largestNumberIndex - smallestIntegerIndex) / 2;

                if (sortedArray[middleNumberIndex] == desiredNumber)
                {
                    return middleNumberIndex;
                }

                if (sortedArray[middleNumberIndex] > desiredNumber)
                {
                    return BinarySearchRecursive(sortedArray, smallestIntegerIndex, middleNumberIndex - 1, desiredNumber);
                }

                return BinarySearchRecursive(sortedArray, middleNumberIndex + 1, largestNumberIndex, desiredNumber);
            }

            return null;
        }
    }
}