using System.Collections.Generic;
using Debuggee;
using Watch3D.Visualizer;

namespace DebuggeeVisualizer
{
    static class InteropConverter
    {
        public static InteropMesh ToVisualizer(Mesh mesh) =>
            new InteropMesh(
                ConvertPoints(mesh.Vertices),
                ConvertTriangles(mesh.Triangles)
            );

        static double[] ConvertPoints(IReadOnlyList<Point> points)
        {
            var count = points.Count;
            var result = new double[3 * count];
            for (int i = 0; i != count; ++i)
                AddPoint(result, points[i], i);
            return result;
        }

        static void AddPoint(double[] vertexData, Point point, int index)
        {
            var offset = 3 * index;
            vertexData[offset] = point.X;
            vertexData[offset + 1] = point.Y;
            vertexData[offset + 2] = point.Z;
        }

        static int[] ConvertTriangles(IReadOnlyList<Triangle> triangles)
        {
            var count = triangles.Count;
            var result = new int[3 * count];
            for (int i = 0; i != count; ++i)
                AddTriangle(result, triangles[i], i);
            return result;
        }

        static void AddTriangle(int[] triangleData, Triangle triangle, int index)
        {
            var offset = 3 * index;
            triangleData[offset] = triangle.A;
            triangleData[offset + 1] = triangle.B;
            triangleData[offset + 2] = triangle.C;
        }
    }
}