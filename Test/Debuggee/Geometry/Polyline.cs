using System.Collections.Generic;

namespace Watch3D.Test.Debuggee.Geometry
{
    public class Polyline
    {
        public readonly IReadOnlyList<Point> Points;

        public Polyline(IReadOnlyList<Point> points)
        {
            Points = points;
        }
    }
}
