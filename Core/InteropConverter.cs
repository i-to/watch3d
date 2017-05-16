using System.Windows.Media;
using System.Windows.Media.Media3D;
using Watch3D.VisualizerServices;

namespace Watch3D.Core
{
    public class InteropConverter
    {
        public static MeshGeometry3D ConvertMesh(InteropMesh interopMesh) =>
            new MeshGeometry3D
            {
                Positions = ConvertPositions(interopMesh.VertexData),
                TriangleIndices = ConvertIndices(interopMesh.TrianglesData)
            };

        public static Point3DCollection ConvertPoints(InteropPoints points) =>
            ConvertPositions(points.PointsData);

        public static Point3D ConvertPoint(InteropPoint point) =>
            new Point3D(point.X, point.Y, point.Z);

        static Point3DCollection ConvertPositions(double[] vertexData)
        {
            int count = vertexData.Length / 3;
            var result = new Point3DCollection(count);
            for (int i = 0; i != count; ++i)
                AddVertex(result, vertexData, i);
            return result;
        }

        static void AddVertex(Point3DCollection result, double[] vertexData, int vertexIndex)
        {
            int offset = vertexIndex * 3;
            var point = new Point3D
            {
                X = vertexData[offset],
                Y = vertexData[offset + 1],
                Z = vertexData[offset + 2]
            };
            result.Add(point);
        }

        static Int32Collection ConvertIndices(int[] trianglesData)
        {
            var count = trianglesData.Length;
            var result = new Int32Collection(count);
            for (int i = 0; i != count; ++i)
                result.Add(trianglesData[i]);
            return result;
        }
    }
}