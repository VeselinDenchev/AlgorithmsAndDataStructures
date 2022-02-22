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

                #
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
    }
}
