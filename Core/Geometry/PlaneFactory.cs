using System;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Utility;

namespace Watch3D.Core.Geometry
{
    public static class PlaneFactory
    {
        /// <summary>
        /// Creates plane from components of linear equation in the form: ax + by + cx + d = 0.
        /// </summary>
        public static Plane3D FromComponents(double a, double b, double c, double d)
        {
            var normal = new Vector3D(a, b, c);
            var point = new Point3D() + normal * d;
            var length = normal.Length;
            if (length.IsNearlyZero())
                throw new InvalidOperationException($"Bad plane equation: {a}, {b}, {c}, {d}.");
            normal /= length;
            return new Plane3D(point, normal / length);
        }

        /// <summary>
        /// Creates plane from components of linear equation, in the form: ax + by + cx - d = 0
        /// (note the minus sign before d).
        /// </summary>
        public static Plane3D FromComponentsAlt(double a, double b, double c, double d) =>
            FromComponents(a, b, c, -d);
    }
}
