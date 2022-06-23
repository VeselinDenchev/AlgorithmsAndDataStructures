using ExamTask;
using ExamTask.BinarySearchTreeHelpers;

int[] nodes = IntegersHelper.GenerateArrayWithRandomIntegersThatAreNotDivisibleBySumOfTheirDigits(100, 999, 30);

BinarySearchTree binarySearchTree = new BinarySearchTree(nodes);
BinaryTreeNode root = binarySearchTree.root;
Console.Write("Traverse tree left-node-right: ");
binarySearchTree.TraverseLeftNodeRight(root);

Console.WriteLine();

int greatestElementInLeftSubtree = binarySearchTree.FindMaxValue(root.leftChild);
int lowestElementInRightSubtree = binarySearchTree.FindMinValue(root.rightChild);
double averageOfGreatestElementAndLowestElement = (greatestElementInLeftSubtree + lowestElementInRightSubtree) / 2;
Console.WriteLine("The average of greatest element in the left subtree and the lowest element in right subtree is " +
                    $"{averageOfGreatestElementAndLowestElement}");

LinkedList<int> nodesInRange = new LinkedList<int>();
foreach (int node in nodes)
{
    if (node >= 250 && node <= 750)
    {
        nodesInRange.AddLast(node);
    }
}

string nodesInRangeString = "Nodes in the range [250, 750]: " + string.Join(' ', nodesInRange);
Console.WriteLine(nodesInRangeString);
