using System.Collections.Generic;
using Watch3D.Test.Debuggee.Geometry;
using Watch3D.VisualizerServices;

namespace Watch3D.Test.DebuggeeVisualizer
{
    static class InteropConverter
    {
        public static InteropMesh ConvertMesh(Mesh mesh) =>
            new InteropMesh(
                ConvertVertices(mesh.Vertices),
                ConvertTriangles(mesh.Triangles)
            );

        public static InteropPoints ConvertPoints(IReadOnlyList<Point> points) =>
            new InteropPoints(ConvertVertices(points));

        static double[] ConvertVertices(IReadOnlyList<Point> points)
        {
            var count = points.Count;
            var result = new double[3 * count];
            for (int i = 0; i != count; ++i)
                AddPoint(result, points[i], i);
            return result;
        }

        public static InteropPoint ConvertPoint(Point point) =>
            new InteropPoint(point.X, point.Y, point.Z);

        static void AddPoint(double[] vertexData, Point point, int index)
        {
            var offset = 3 * index;
            vertexData[offset] = point.X;
            vertexData[offset + 1] = point.Y;
            vertexData[offset + 2] = point.Z;
        }

        static int[] ConvertTriangles(IReadOnlyList<MeshTriangle> triangles)
        {
            var count = triangles.Count;
            var result = new int[3 * count];
            for (int i = 0; i != count; ++i)
                AddTriangle(result, triangles[i], i);
            return result;
        }

        static void AddTriangle(int[] triangleData, MeshTriangle meshTriangle, int index)
        {
            var offset = 3 * index;
            triangleData[offset] = meshTriangle.A;
            triangleData[offset + 1] = meshTriangle.B;
            triangleData[offset + 2] = meshTriangle.C;
        }
    }
}