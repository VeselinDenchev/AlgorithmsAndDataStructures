using SearchingAlgorithms;

int[] array = { 1, 3, 6, 11, 15, 17, 21, 23, 27, 29, 32 };
int? desiredNumberIndex = SearchingAlgorithm.BinarySearch(array, 23);

string output = null;

if (desiredNumberIndex.HasValue)
{
    output = $"The number {array[desiredNumberIndex.Value]} is found on index {desiredNumberIndex.Value} " +
                $"using {nameof(SearchingAlgorithm.FibonacciSearch)}";
}
else
{
    output = "The number is not found in the array!";
}

Console.WriteLine(output);
