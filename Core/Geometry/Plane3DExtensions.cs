using System;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace Watch3D.Core.Geometry
{
    public static class Plane3DExtensions
    {
        /// <summary>
        /// Constructs two vectors (u, v) within the plane, such that (u, v, n) forms an right-handed orthonormal basis,
        /// where n is plane normal.
        /// </summary>
        /// <param name="plane"></param>
        /// <returns>Tuple of (u, v).</returns>
        public static Tuple<Vector3D, Vector3D> OrthonormalBasis(this Plane3D plane)
        {
            var n = plane.Normal;
            var u = n.CreateOrthogonalVector();
            u.Normalize();
            var v = Vector3D.CrossProduct(n, u);
            return Tuple.Create(u, v);
        }
    }
}