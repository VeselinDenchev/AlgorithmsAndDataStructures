using SearchingAlgorithms;

int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int? desiredNumberIndex = SearchingAlgorithm.FibonacciSearch(array, 5);

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
