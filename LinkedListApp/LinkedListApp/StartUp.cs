LinkedList<int> linkedList = new LinkedList<int>();
for (int i = 1; i <= 10; i++)
{
    linkedList.AddLast(i);
}

for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
{
     node.Value++;
}

foreach (int number in linkedList)
{
    Console.WriteLine(number);
}