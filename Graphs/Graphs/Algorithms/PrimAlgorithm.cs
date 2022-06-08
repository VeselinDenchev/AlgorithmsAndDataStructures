namespace Graphs.Algorithms
{
	// https://www.youtube.com/watch?v=cplfcGZmX7I
	internal class PrimAlgorithm
    {
		/// <summary>
		/// <strong>Prim's algorithm</strong> is a greedy algorithm that finds a minimum spanning tree for a weighted undirected graph. 
		/// This means it finds a subset of the edges that forms a tree that includes every vertex/node, where the total weight of all the 
		/// edges in the tree is minimized. The algorithm operates by building this tree one vertex/node at a time, from an arbitrary 
		/// starting vertex/node, at each step adding the cheapest possible connection from the tree to another vertex/node.<br></br>
		///	Time complexity: <strong>O(elogv)</strong>.
		/// <br></br>
		/// e = edges count<br></br>
		/// v = e + 1 = vertex count
		/// </summary>
		/// <param name="dependencyMatrix">The dependency matrix of a graph.</param>
		public static void Prim(int[,] dependencyMatrix)
		{
			int verticesCount = dependencyMatrix.GetLength(0);

			int?[] parents = new int?[verticesCount];
			int[] distanceToVertecies = new int[verticesCount];
			bool[] areVisited = new bool[verticesCount];

			for (int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++)
			{
				distanceToVertecies[vertexIndex] = int.MaxValue;
				areVisited[vertexIndex] = false;
			}

			distanceToVertecies[0] = 0;
			parents[0] = null;

			for (int count = 0; count < verticesCount - 1; count++)
			{
				int closestUnvisitedNeighbouringVertexIndex = 
					GetClosestUnvisitedNeighbouringVertexIndex(distanceToVertecies, areVisited, verticesCount);
				areVisited[closestUnvisitedNeighbouringVertexIndex] = true;

				for (int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++)
				{
					bool thereIsDirectPathBetweenClosestUnvisitedNeighbouringVertexAndCurrentVertex =
						Convert.ToBoolean(dependencyMatrix[closestUnvisitedNeighbouringVertexIndex, vertexIndex]);
					bool directPathFromClosestUnvisitedNeighbouringVertexToCurrentVertexIsShorterThanSavedOne = 
						dependencyMatrix[closestUnvisitedNeighbouringVertexIndex, vertexIndex] < 
						distanceToVertecies[vertexIndex];

					if (thereIsDirectPathBetweenClosestUnvisitedNeighbouringVertexAndCurrentVertex && 
						!areVisited[vertexIndex] && 
						directPathFromClosestUnvisitedNeighbouringVertexToCurrentVertexIsShorterThanSavedOne)
					{
						parents[vertexIndex] = closestUnvisitedNeighbouringVertexIndex;
						distanceToVertecies[vertexIndex] = dependencyMatrix[closestUnvisitedNeighbouringVertexIndex, vertexIndex];
					}
				}
			}

			Print(parents, dependencyMatrix, verticesCount);
		}
		private static int GetClosestUnvisitedNeighbouringVertexIndex(int[] distanceToVertecies, bool[] areVisited, 
			int verticesCount)
		{
			int closestVertexDistance = int.MaxValue;
			int closestVertexIndex = 0;

			for (int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++)
			{
				if (areVisited[vertexIndex] == false && distanceToVertecies[vertexIndex] < closestVertexDistance)
				{
					closestVertexDistance = distanceToVertecies[vertexIndex];
					closestVertexIndex = vertexIndex;
				}
			}

			return closestVertexIndex;
		}

		private static void Print(int?[] parents, int[,] dependenciesMatrix, int verticesCount)
		{
			Console.WriteLine("Edge     Weight");
			for (int i = 1; i < verticesCount; ++i)
				Console.WriteLine("{0} - {1}    {2}", parents[i].Value, i, dependenciesMatrix[i, parents[i].Value]);
		}
	}
}
