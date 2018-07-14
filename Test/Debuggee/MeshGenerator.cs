using System.Collections.Generic;
using Watch3D.Test.Debuggee.Geometry;

namespace Watch3D.Test.Debuggee
{
    class MeshGenerator
    {
        public Mesh CreateSingleTriangle()
        {
            var o = new Point(0, 0, 0.5);
            var a = new Point(0.5, 0, 0.5);
            var b = new Point(0, 0.5, 0.5);
            var abc = new MeshTriangle(0, 1, 2);
            return new Mesh(
                vertices: new List<Point> { o, a, b },
                triangles: new List<MeshTriangle> { abc });
        }
    }
}