﻿using System.Text;

namespace KruskalAlgorithm
{
    internal static class KruskalHelper
    {
		public static Graph CreateGraph(int verticesCount, int edgesCount)
		{
			Graph graph = new Graph();
			graph.VerticesCount = verticesCount;
			graph.EdgesCount = edgesCount;
			graph.edge = new Edge[graph.EdgesCount];

			return graph;
		}

		private static int FindVertexParent(Subset[] subsets, int vertexIndex)
		{
			if (subsets[vertexIndex].Parent != vertexIndex)
				subsets[vertexIndex].Parent = FindVertexParent(subsets, subsets[vertexIndex].Parent);

			return subsets[vertexIndex].Parent;
		}

		private static void Union(Subset[] subsets, int sourceIndex, int destinationIndex)
		{
			int sourceRootIndex = FindVertexParent(subsets, sourceIndex);
			int destinationRootIndex = FindVertexParent(subsets, destinationIndex);

			if (subsets[sourceRootIndex].Rank < subsets[destinationRootIndex].Rank)
			{
				AdjustVerteciesRanks(subsets);
				subsets[sourceRootIndex].Parent = destinationRootIndex;
			}
			else if (subsets[sourceRootIndex].Rank > subsets[destinationRootIndex].Rank)
			{
				AdjustVerteciesRanks(subsets);
				subsets[destinationRootIndex].Parent = sourceRootIndex;				
			}
			else
			{
				subsets[destinationRootIndex].Parent = sourceRootIndex;
				++subsets[sourceRootIndex].Rank;
			}
		}

		private static void Print(Edge[] result, int verticesCount, Subset[] subsets)
		{
			Array.Reverse(subsets);

			for (int i = 0; i < verticesCount; ++i)
            {
				Console.WriteLine("{0} -- {1} == {2}", result[i].Source, result[i].Destination, result[i].Weight);
                Console.WriteLine(subsets[i + 1].Rank);
                Console.WriteLine();
			}
		}

		private static void AdjustVerteciesRanks(Subset[] subsets)
        {
            for (int i = 0; i < subsets.Length; i++)
            {
				List<Subset> predecessors = subsets.Where(s => s.Parent == i).ToList();
				for (int j = 0; j < predecessors.Count; j++)
				{
					Subset predecessor = predecessors[j];
					predecessor.Rank++;
					predecessors[j] = predecessor;

					if ((predecessor.Parent == subsets[i].Parent) && (predecessor.Rank == subsets[i].Rank + 1))
					{
						subsets[i] = predecessor;
					}
				}
			}
        }

		public static void Kruskal(Graph graph)
		{
			int verticesCount = graph.VerticesCount;
			Edge[] result = new Edge[verticesCount];
			int currentEdgeIndex = 0;
			int resultEdgeIndex = 0;

			// Sort edges by weight
			Array.Sort(graph.edge, delegate (Edge firstEdge, Edge secondEdge)
			{
				return firstEdge.Weight.CompareTo(secondEdge.Weight);
			});

			Subset[] subsets = new Subset[verticesCount];

			// Set every vertex's parent to be itself and its rank to 0
			for (int vertexIndex = 0; vertexIndex < verticesCount; ++vertexIndex)
			{
				subsets[vertexIndex].Parent = vertexIndex;
				subsets[vertexIndex].Rank = 0;
			}

			while (resultEdgeIndex < verticesCount - 1)
			{
				Edge nextEdge = graph.edge[currentEdgeIndex++];
				int sourceIndex = FindVertexParent(subsets, nextEdge.Source);
				int destinationIndex = FindVertexParent(subsets, nextEdge.Destination);

				if (sourceIndex != destinationIndex)
				{
					result[resultEdgeIndex++] = nextEdge;
					Union(subsets, sourceIndex, destinationIndex);
				}
			}

			Print(result, resultEdgeIndex, subsets);
		}
	}
}