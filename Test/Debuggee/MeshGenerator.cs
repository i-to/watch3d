using System.Collections.Generic;

namespace Watch3D.Test.Debuggee
{
    class MeshGenerator
    {
        public static Mesh CreateSingleTriangle()
        {
            var o = new Point(0, 0, 0.5);
            var a = new Point(0.5, 0, 0.5);
            var b = new Point(0, 0.5, 0.5);
            var abc = new Triangle(0, 1, 2);
            return new Mesh
            {
                Vertices = new List<Point> { o, a, b },
                Triangles = new List<Triangle> { abc }
            };
        }
    }
}