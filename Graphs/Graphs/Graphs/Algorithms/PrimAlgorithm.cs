namespace Graphs.Algorithms
{
    internal class PrimAlgorithm
    {
		public static void Prim(int[,] dependenciesMatrix)
		{
			int verticesCount = dependenciesMatrix.GetLength(0);

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
						Convert.ToBoolean(dependenciesMatrix[closestUnvisitedNeighbouringVertexIndex, vertexIndex]);
					bool directPathFromClosestUnvisitedNeighbouringVertexToCurrentVertexIsShorterThanSavedOne = 
						dependenciesMatrix[closestUnvisitedNeighbouringVertexIndex, vertexIndex] < 
						distanceToVertecies[vertexIndex];

					if (thereIsDirectPathBetweenClosestUnvisitedNeighbouringVertexAndCurrentVertex && 
						!areVisited[vertexIndex] && 
						directPathFromClosestUnvisitedNeighbouringVertexToCurrentVertexIsShorterThanSavedOne)
					{
						parents[vertexIndex] = closestUnvisitedNeighbouringVertexIndex;
						distanceToVertecies[vertexIndex] = dependenciesMatrix[closestUnvisitedNeighbouringVertexIndex, vertexIndex];
					}
				}
			}

			Print(parents, dependenciesMatrix, verticesCount);
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
