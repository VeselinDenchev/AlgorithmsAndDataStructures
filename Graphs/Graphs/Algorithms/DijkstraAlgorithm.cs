namespace Graphs.Algorithms
{
    // https://www.youtube.com/watch?v=GazC3A4OQTE
    internal class DijkstraAlgorithm
    {
        /// <summary>
        /// <strong>Dijkstra's algorithm</strong> is an algorithm for finding the shortest paths between vertecies/nodes in a graph.
        /// </summary>
        /// <param name="dependencyMatrix">The dependency matrix of a graph.</param>
        /// <param name="sourceIndex">The index of the start vertex/node of the path.</param>
        public static void Dijkstra(int[,] dependencyMatrix, int sourceIndex)
        {
            int verticesCount = dependencyMatrix.GetLength(0);

            int[] distances = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++)
            {
                distances[vertexIndex] = int.MaxValue;
                shortestPathTreeSet[vertexIndex] = false;
            }

            distances[sourceIndex] = 0;

            for (int count = 0; count < verticesCount - 1; count++)
            {
                int closestNeighbouringVertexIndex = GetClosestNeighbouringVertexIndex(distances, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[closestNeighbouringVertexIndex] = true;

                for (int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++)
                {
                    bool isShortestPathToVertex = shortestPathTreeSet[vertexIndex];
                    bool thereIsDirectPathBetweenClosestNeighbouringVertexAndCurrentVertex = 
                        Convert.ToBoolean(dependencyMatrix[closestNeighbouringVertexIndex, vertexIndex]);
                    bool distanceToClosestNeighbouringVertexHasBeenSet = distances[closestNeighbouringVertexIndex] != int.MaxValue;
                    bool isPathShorterThanDirectPath = distances[closestNeighbouringVertexIndex] 
                        + dependencyMatrix[closestNeighbouringVertexIndex, vertexIndex] < distances[vertexIndex];

                    if (!isShortestPathToVertex && thereIsDirectPathBetweenClosestNeighbouringVertexAndCurrentVertex && 
                        distanceToClosestNeighbouringVertexHasBeenSet && isPathShorterThanDirectPath)
                    {
                        distances[vertexIndex] = distances[closestNeighbouringVertexIndex] + dependencyMatrix[closestNeighbouringVertexIndex, vertexIndex];
                    }
                }        
            }

            Print(distances, verticesCount);
        }

        private static int GetClosestNeighbouringVertexIndex(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int minDistance = int.MaxValue;
            int minDistanceToVertexIndex = 0;

            for (int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++)
            {
                if (shortestPathTreeSet[vertexIndex] == false && distance[vertexIndex] <= minDistance)
                {
                    minDistance = distance[vertexIndex];
                    minDistanceToVertexIndex = vertexIndex;
                }
            }

            return minDistanceToVertexIndex;
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }
    }
}
