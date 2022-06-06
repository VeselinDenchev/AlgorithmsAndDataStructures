namespace SearchingAlgorithms
{
    internal class SearchingAlgorithm
    {
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

        public static int? BinarySearchRecursive(int[] sortedArray, int minNumberIndex, int maxNumberIndex, int desiredNumber)
        {
            if (maxNumberIndex >= minNumberIndex)
            {
                int middleNumberIndex = minNumberIndex + (maxNumberIndex - minNumberIndex) / 2;

                if (sortedArray[middleNumberIndex] == desiredNumber)
                {
                    return middleNumberIndex;
                }

                if (sortedArray[middleNumberIndex] > desiredNumber)
                {
                    return BinarySearchRecursive(sortedArray, minNumberIndex, middleNumberIndex - 1, desiredNumber);
                }

                return BinarySearchRecursive(sortedArray, middleNumberIndex + 1, maxNumberIndex, desiredNumber);
            }

            return null;
        }
    }
}
