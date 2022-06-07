using Graphs.Algorithms;
using Graphs.Algorithms.KruskalAlgorithmHelpers;

// Is there a path in a graph BEGIN
// Можете да промените матрицата на зависимостите, за да тествате с различни данни
int[,] dependenciesMatrix = new int[,]
{
    { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
    { 0, 0, 4, 0, 10, 0, 2, 0, 0 },
    { 0, 0, 0, 14, 0, 2, 0, 1, 6 },
    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
    { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
};

Console.WriteLine("From where should the path start?");
int from = int.Parse(Console.ReadLine());

Console.WriteLine("Where should the path end?");
int to = int.Parse(Console.ReadLine());

GraphPath graphPath = new GraphPath(dependenciesMatrix, from, to);
Console.WriteLine(graphPath);
// Is there a path in a graph END
Console.WriteLine();
Console.WriteLine("============================================================================================================");
Console.WriteLine();

// Kruskal (Minimum spanning tree) algorithm BEGIN
int verticesCount = 4;
int edgesCount = 5;
Graph graph = KruskalAlgorithm.CreateGraph(verticesCount, edgesCount);

// Edge 0-1
graph.edge[0].Source = 0;
graph.edge[0].Destination = 1;
graph.edge[0].Weight = 10;

// Edge 0-2
graph.edge[1].Source = 0;
graph.edge[1].Destination = 2;
graph.edge[1].Weight = 6;

// Edge 0-3
graph.edge[2].Source = 0;
graph.edge[2].Destination = 3;
graph.edge[2].Weight = 5;

// Edge 1-3
graph.edge[3].Source = 1;
graph.edge[3].Destination = 3;
graph.edge[3].Weight = 15;

// Edge 2-3
graph.edge[4].Source = 2;
graph.edge[4].Destination = 3;
graph.edge[4].Weight = 4;

KruskalAlgorithm.Kruskal(graph);
// Kruskal (Minimum spanning tree) algorithm END

Console.WriteLine();
Console.WriteLine("============================================================================================================");
Console.WriteLine();

DijkstraAlgorithm.Dijkstra(dependenciesMatrix, 0);

Console.WriteLine();
Console.WriteLine("============================================================================================================");
Console.WriteLine();

PrimAlgorithm.Prim(dependenciesMatrix);
