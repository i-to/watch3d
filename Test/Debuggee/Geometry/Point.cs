namespace Watch3D.Test.Debuggee.Geometry
{
    public class Point
    {
        public static Point Zero = new Point(0, 0, 0);

        public readonly double X, Y, Z;

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
