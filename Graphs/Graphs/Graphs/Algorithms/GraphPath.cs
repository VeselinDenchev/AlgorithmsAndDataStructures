using System.Text;

namespace Graphs.Algorithms
{
    internal class GraphPath
    {
        public GraphPath(int[,] dependenciesMatrix, int from, int to)
        {
            DependenciesMatrix = dependenciesMatrix;
            RowLength = dependenciesMatrix.GetLength(0);
            From = from;
            To = to;
            Path = new List<int>();
            Path.Add(from);
        }
        private int RowLength { get; }

        private int From { get; }

        private int To { get; }

        private List<int> Path { get; }

        private int[,] DependenciesMatrix { get; }

        private bool IsThereAPath(int from, int to)
        {
            if (DependenciesMatrix[from, to] != 0)
            {
                Path.Add(to);

                return true;
            }

            for (int currentVertexIndex = 0; currentVertexIndex < RowLength; currentVertexIndex++)
            {
                if (DependenciesMatrix[from, currentVertexIndex] == 0 || from == currentVertexIndex ||
                    Path.Contains(currentVertexIndex))
                {
                    continue;
                }

                Path.Add(currentVertexIndex);
                if (IsThereAPath(currentVertexIndex, to))
                {
                    return true;
                }
                else
                {
                    Path.Remove(currentVertexIndex);
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder outputStringBuilder = new StringBuilder();

            if (IsThereAPath(From, To))
            {
                outputStringBuilder.AppendLine($"There is at least one path between {From} and {To}:");
                foreach (int node in Path)
                {
                    outputStringBuilder.AppendLine(node.ToString());
                }
            }
            else
            {
                outputStringBuilder.Append($"There is no path between {From} and {To}");
            }

            string output = outputStringBuilder.ToString();

            return output;
        }
    }
}
