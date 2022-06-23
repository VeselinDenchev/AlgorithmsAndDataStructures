using BinarySearchTreeHelpers;

int[] randomIntegersArray = IntegersHelper.GenerateArrayWithRandomIntegers(1, 100, 10, true);
BinarySearchTree binarySearchTree = new BinarySearchTree(randomIntegersArray);

if (binarySearchTree.HasLeftSubtree)
{
    Console.WriteLine($"Left subtree sum = {binarySearchTree.leftSubtreeSum}");

    int digitsSumOfLeftSubtreeSum = IntegersHelper.CalculateSumOfIntegerDigits(binarySearchTree.leftSubtreeSum.Value);
    Console.WriteLine($"Sum of digits = {digitsSumOfLeftSubtreeSum}");

    /*binarySearchTree.CheckDivisibility(binarySearchTree.root, digitsSumOfLeftSubtreeSum);
    binarySearchTree.Traverse(binarySearchTree.root);*/
    binarySearchTree.TraverseNodeLeftRight(binarySearchTree.root);
}
else
{
    Console.WriteLine("The binary tree doesn't have left subtree!");
    return;
}

