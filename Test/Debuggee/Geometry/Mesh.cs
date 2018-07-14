using System.Collections.Generic;

namespace Watch3D.Test.Debuggee.Geometry
{
    public class Mesh
    {
        public readonly IReadOnlyList<Point> Vertices;
        public readonly IReadOnlyList<MeshTriangle> Triangles;

        public Mesh(IReadOnlyList<Point> vertices, IReadOnlyList<MeshTriangle> triangles)
        {
            Vertices = vertices;
            Triangles = triangles;
        }
    }
}