using System.Text;

namespace Debuggee
{
    static class MeshStringBuilder
    {
        public static string GetVerticesString(Mesh mesh)
        {
            var vertices = mesh.Vertices;
            var builder = new StringBuilder();
            for (int i = 0; i != vertices.Count; ++i)
            {
                var vertex = vertices[i];
                if (i != 0)
                    builder.Append(" ");
                builder.Append($"{vertex.X},{vertex.Y},{vertex.Z}");
            }
            return builder.ToString();
        }

        public static string GetIndicesString(Mesh mesh)
        {
            var triangles = mesh.Triangles;
            var builder = new StringBuilder();
            for (int i = 0; i != triangles.Count; ++i)
            {
                var triangle = triangles[i];
                if (i != 0)
                    builder.Append(" ");
                builder.Append($"{triangle.A},{triangle.B},{triangle.C} ");
            }
            return builder.ToString();
        }
    }
}