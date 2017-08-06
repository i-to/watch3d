using System.Collections.Generic;
using System.Text;

namespace Watch3D.Test.Debuggee
{
    static class DebugInteropStringBuilder
    {
        public static string CreateMeshVerticesString(Mesh mesh) =>
            CreatePointsString(mesh.Vertices);

        static string CreatePointsString(IReadOnlyList<Point> vertices)
        {
            var builder = new StringBuilder();
            for (int i = 0; i != vertices.Count; ++i)
            {
                var vertex = vertices[i];
                if (i != 0)
                    builder.Append(" ");
                var pointString = CreatePointString(vertex);
                builder.Append(pointString);
            }
            return builder.ToString();
        }

        public static string CreatePointString(Point point) => 
            $"{point.X},{point.Y},{point.Z}";

        public static string CreateMeshIndicesString(Mesh mesh)
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

        public static string CreatePolylinePointsString(Polyline polyline) => 
            CreatePointsString(polyline.Points);
    }
}