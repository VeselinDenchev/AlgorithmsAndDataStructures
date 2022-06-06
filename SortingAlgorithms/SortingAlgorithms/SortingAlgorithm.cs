﻿using System.Text;

namespace SortingAlgorithms
{
    // https://github.com/ivandobrinovv/AlgorithmsAndDataStructures/blob/main/SortAlgorithmsExamples/Sort.Buisiness/Helpers/SortHelper.cs
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

        // https://www.youtube.com/watch?v=Hoixgm4-P4M
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

        // https://www.youtube.com/watch?v=2DmK_H7IdTo
        public static void HeapSort(int[] array)
        {
            // Call the Sift method for each parent element starting from the last one
            // to form a pyramid
            for (int i = array.Length / 2; i > 0; i--)
            {
                Heapify(array, i - 1, array.Length - 1);
            }

            // Create a sorted array from the pyramid by taking the biggest element from the
            // non-sorted part (index 0 because it is a pyramid) and placing it at the end
            // of the non sorted part. Then call the Sift method for the non-sorted part to
            // set the biggest element at index 0 (create a pyramid) and repeat for the whole array.
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

        // Quick sort
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

        // Heap sort
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

                // Check if the value of the the start item is bigger than both children's
                // values (if this is the correct place for it) and if it is break
                if (itemValue >= array[childIndex])
                {
                    break;
                }

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
    }
}
