using System;
using System.Windows.Media.Media3D;
using Watch3D.Core.Utility;

namespace Watch3D.Core.Geometry
{
    public static class Vector3DExtensions
    {
        public static Vector3D CreateOrthogonalVector(this Vector3D vector)
        {
            var ex = new Vector3D(1, 0, 0);
            var n = Vector3D.CrossProduct(vector, ex);
            if (!n.Length.IsNearlyZero())
                return n;

            var ey = new Vector3D(0, 1, 0);
            n = Vector3D.CrossProduct(vector, ey);
            if (!n.Length.IsNearlyZero())
                return n;

            throw new ArgumentOutOfRangeException($"Expected non-zero vector, got: '{vector}'.");
        }
    }
}
