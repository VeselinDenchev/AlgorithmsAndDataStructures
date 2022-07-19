LinkedList<int> linkedList = new LinkedList<int>();
for (int i = 1; i <= 10; i++)
{
    linkedList.AddLast(i);
}

for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
{
     node.Value++;
     Console.WriteLine(node.Value);
}

Console.WriteLine();

foreach (int number in linkedList)
{
    Console.WriteLine(number);
}

Console.WriteLine();

LinkedListNode<int> currentElement = linkedList.First;
while (currentElement != null)
{
    if (currentElement is not null)
    {
        Console.WriteLine(currentElement.Value);
    }

    currentElement = currentElement.Next;
}