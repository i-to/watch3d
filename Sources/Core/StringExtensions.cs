using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public static class StringExtensions
    {
        public static int ParseInt32(this string str) => int.Parse(str);
        public static double ParseDouble(this string str) => double.Parse(str);
        public static Point3DCollection ParsePoint3DCollection(this string str) => Point3DCollection.Parse(str);
        public static Int32Collection ParseInt32Collection(this string str) => Int32Collection.Parse(str);
    }
}