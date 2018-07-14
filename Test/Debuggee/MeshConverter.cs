using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Watch3D.Test.Debuggee.Geometry;

namespace Watch3D.Test.Debuggee
{
    class MeshConverter
    {
        public IEnumerable<Mesh> Convert(IEnumerable<Model3D> models) =>
            models.Select(
                model => Convert((MeshGeometry3D)((GeometryModel3D)model).Geometry));

        Mesh Convert(MeshGeometry3D geometry) =>
            new Mesh(
                vertices: Convert(geometry.Positions),
                triangles: Convert(geometry.TriangleIndices));

        List<MeshTriangle> Convert(Int32Collection triangleIndices)
        {
            int triangleCount = triangleIndices.Count / 3;
            var triangles = new List<MeshTriangle>(triangleCount);
            for (int i = 0; i != triangleCount; ++i)
                AddTriangle(triangles, triangleIndices, i);
            return triangles;
        }

        void AddTriangle(List<MeshTriangle> triangles, Int32Collection triangleIndices, int triangleIndex)
        {
            int offset = 3 * triangleIndex;
            var triangle = new MeshTriangle(
                triangleIndices[offset],
                triangleIndices[offset + 1],
                triangleIndices[offset + 2]);
            triangles.Add(triangle);
        }

        public List<Point> Convert(Point3DCollection positions) =>
            positions.Select(Convert).ToList();

        public Point Convert(Point3D point) => new Point(point.X, point.Y, point.Z);
    }
}
