using System.Text;

namespace Graphs.Algorithms
{
    internal class GraphPath
    {
        public GraphPath(int[,] dependenciesMatrix, int fromVertexIndex, int toVertexIndex)
        {
            DependenciesMatrix = dependenciesMatrix;
            RowLength = dependenciesMatrix.GetLength(0);
            FromVertexIndex = fromVertexIndex;
            ToVertexIndex = toVertexIndex;
            Path = new List<int>();
            Path.Add(fromVertexIndex);
        }
        private int RowLength { get; }

        private int FromVertexIndex { get; }

        private int ToVertexIndex { get; }

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

            if (IsThereAPath(FromVertexIndex, ToVertexIndex))
            {
                outputStringBuilder.AppendLine($"There is at least one path between {FromVertexIndex} and {ToVertexIndex}:");
                foreach (int node in Path)
                {
                    outputStringBuilder.AppendLine(node.ToString());
                }
            }
            else
            {
                outputStringBuilder.Append($"There is no path between {FromVertexIndex} and {ToVertexIndex}");
            }

            string output = outputStringBuilder.ToString();

            return output;
        }
    }
}
