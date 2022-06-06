using KruskalAlgorithm;

int verticesCount = 4;
int edgesCount = 5;
Graph graph = KruskalHelper.CreateGraph(verticesCount, edgesCount);

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

KruskalHelper.Kruskal(graph);