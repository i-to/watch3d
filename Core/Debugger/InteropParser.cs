using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Watch3D.Core.Debugger
{
    public class InteropParser
    {
        public int ParseInt(string str) =>
            int.Parse(str);

        public double ParseDouble(string str) =>
            double.Parse(str);

        public Point3DCollection ParsePoint3DCollection(string str) =>
            Point3DCollection.Parse(str);

        public Int32Collection ParseInt32Collection(string str) =>
            Int32Collection.Parse(str);

        public Point3D ParsePoint3D(string str)
        {
            var points = Point3DCollection.Parse(str);
            if (points.Count != 1)
                throw new FormatException($"Failed to parse single point from string: {str}");
            return points[0];
        }
    }
}
