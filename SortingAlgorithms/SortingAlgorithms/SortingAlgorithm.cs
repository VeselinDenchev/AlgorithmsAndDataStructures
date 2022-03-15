using System.Text;

namespace SortingAlgorithms
{
    internal static class SortingAlgorithm
    {
        // https://www.youtube.com/watch?v=g-PGLbMth_g
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                ref int initialElement = ref array[i];
                int currentElement = initialElement;
                int currentMin = currentElement;
                int currentMinIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    currentElement = array[j];

                    if (currentMin > currentElement)
                    {
                        currentMin = currentElement;
                        currentMinIndex = j;
                    }
                }

                SwapElements(ref initialElement, ref array[currentMinIndex]);
            }
        }

        // https://www.youtube.com/watch?v=JU767SDMDvA
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

        // https://www.youtube.com/watch?v=xli_FI7CuzA
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

                if (!isChanged)
                {
                    break;
                }
            }
        }

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

        public static void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivot = Partition(array, leftIndex, rightIndex);

                if (pivot > 1)
                {
                    QuickSort(array, leftIndex, pivot - 1);
                }
                if (pivot + 1 < rightIndex)
                {
                    QuickSort(array, pivot + 1, rightIndex);
                }
            }
        }

        public static void PrintArray(int[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (int element in array)
            {
                stringBuilder.Append(element.ToString() + ' ');
            }

            string arrayString = stringBuilder.ToString();
            Console.WriteLine(arrayString);
        }

        private static void SwapElements(ref int firstNumber, ref int secondNumber)
        {
            int tempValue = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempValue;
        }

        private static int Partition(int[] array, int leftIndex, int rightIndex)
        {
            int pivot = array[leftIndex];

            while (true)
            {

                while (array[leftIndex] < pivot)
                {
                    leftIndex++;
                }

                while (array[rightIndex] > pivot)
                {
                    rightIndex--;
                }

                if (leftIndex < rightIndex)
                {
                    if (array[leftIndex] == array[rightIndex])
                    {
                        return rightIndex;
                    }

                    SwapElements(ref array[leftIndex], ref array[rightIndex]);
                }
                else
                {
                    return rightIndex;
                }
            }
        }
    }
}
