using SortingAlgorithms;

int[] array = null;
while (array is null)
{
    Console.Write("Enter a lower bound of array integers: ");
    int arrayLowerBound = int.Parse(Console.ReadLine());

    Console.Write("Enter an upper bound of array integers: ");
    int arrayUpperBound = int.Parse(Console.ReadLine());

    Console.Write("Enter the array's length: ");
    int arrayLength = int.Parse(Console.ReadLine());

    array = SortingAlgorithm.GenerateArrayWithRandomIntegers(arrayLowerBound, arrayUpperBound, arrayLength);

    Console.WriteLine();
}

Console.WriteLine("Unsorted array: " + SortingAlgorithm.ArrayToString(array));

SortingAlgorithm.MergeSort(array, 0, array.Length - 1);
Console.WriteLine($"Sorted array using {nameof(SortingAlgorithm.MergeSort)}: {SortingAlgorithm.ArrayToString(array)}");