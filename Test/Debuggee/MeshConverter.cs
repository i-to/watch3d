using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Debuggee
{
    class MeshConverter
    {
        public IEnumerable<Mesh> Convert(IEnumerable<Model3D> models) =>
            models.Select(
                model => Convert((MeshGeometry3D)((GeometryModel3D)model).Geometry));

        Mesh Convert(MeshGeometry3D geometry) =>
            new Mesh
            {
                Vertices = Convert(geometry.Positions),
                Triangles = Convert(geometry.TriangleIndices)
            };

        List<Triangle> Convert(Int32Collection triangleIndices)
        {
            int triangleCount = triangleIndices.Count / 3;
            var triangles = new List<Triangle>(triangleCount);
            for (int i = 0; i != triangleCount; ++i)
                AddTriangle(triangles, triangleIndices, i);
            return triangles;
        }

        void AddTriangle(List<Triangle> triangles, Int32Collection triangleIndices, int triangleIndex)
        {
            int offset = 3 * triangleIndex;
            var triangle = new Triangle
            {
                A = triangleIndices[offset],
                B = triangleIndices[offset + 1],
                C = triangleIndices[offset + 2]
            };
            triangles.Add(triangle);
        }

        List<Point> Convert(Point3DCollection positions) =>
            positions.Select(Convert).ToList();

        Point Convert(Point3D point) => new Point(point.X, point.Y, point.Z);
    }
}
