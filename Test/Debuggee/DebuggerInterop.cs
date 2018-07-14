using System.Collections.Generic;
using System.Text;
using Watch3D.Test.Debuggee.Geometry;

namespace Watch3D.Test.Debuggee
{
    static class DebuggerInterop
    {
        public static readonly string Separator = "|";

        public static string EvaluateObject(object obj)
        {
            if (obj is Mesh mesh)
                return CreateMesh(mesh);
            if (obj is Polyline polyline)
                return CreatePolyline(polyline);
            if (obj is Point point)
                return CreatePoint(point);
            return $"Unrecognized object of type: {obj.GetType()}";
        }

        static string CreatePoint(Point point)
        {
            var result = new StringBuilder();
            result.Append("point");
            result.Append(Separator);
            AppendPoint(result, point);
            return result.ToString();
        }

        static string CreatePolyline(Polyline polyline)
        {
            var result = new StringBuilder();
            result.Append("polyline");
            result.Append(Separator);
            AppendPoints(result, polyline.Points);
            return result.ToString();
        }

        static string CreateMesh(Mesh mesh)
        {
            var result = new StringBuilder();
            result.Append("mesh");
            result.Append(Separator);
            AppendPoints(result, mesh.Vertices);
            result.Append(Separator);
            AppendIndices(result, mesh.Triangles);
            return result.ToString();
        }

        static void AppendPoints(StringBuilder builder, IReadOnlyList<Point> vertices)
        {
            for (int i = 0; i != vertices.Count; ++i)
            {
                var vertex = vertices[i];
                if (i != 0)
                    builder.Append(" ");
                AppendPoint(builder, vertex);
            }
        }

        static void AppendPoint(StringBuilder builder, Point point) => 
            builder.Append($"{point.X},{point.Y},{point.Z}");

        static void AppendIndices(StringBuilder builder, IReadOnlyList<MeshTriangle> triangles)
        {
            for (int i = 0; i != triangles.Count; ++i)
            {
                var triangle = triangles[i];
                if (i != 0)
                    builder.Append(" ");
                builder.Append($"{triangle.A},{triangle.B},{triangle.C} ");
            }
        }
    }
}