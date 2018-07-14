using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Geometry;

namespace Watch3D.Core.Scene
{
    public class PlaneSceneItem : MeshSceneItem
    {
        public PlaneSceneItem(string name, Plane3D plane)
            : base(name, CreateGeometry(plane, 10.0))
        {
        }

        public static MeshGeometry3D CreateGeometry(Plane3D plane, double scale)
        {
            var origin = plane.Position;
            var basis = plane.OrthonormalBasis();
            var u = basis.Item1;
            var v = basis.Item2;
            var vertices = 
                new[] {u + v, -u + v, -u - v, u - v}
                .Select(p => origin + p * scale);
            var indices = new[] {0, 1, 2, 0, 2, 3};
            return new MeshGeometry3D
            {
                Positions = new Point3DCollection(vertices),
                TriangleIndices = new Int32Collection(indices)
            };
        }
    }
}
