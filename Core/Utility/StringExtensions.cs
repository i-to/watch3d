using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Watch3D.Core.Utility
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str) => str == string.Empty;
        public static int ParseInt32(this string str) => int.Parse(str);
        public static double ParseDouble(this string str) => double.Parse(str);
        public static Point3DCollection ParsePoint3DCollection(this string str) => Point3DCollection.Parse(str);
        public static Int32Collection ParseInt32Collection(this string str) => Int32Collection.Parse(str);

        public static Point3D ParsePoint3D(this string str)
        {
            var points = Point3DCollection.Parse(str);
            if (points.Count != 1)
                throw new FormatException($"Failed to parse single point from string: {str}");
            return points[0];
        }
    }
}