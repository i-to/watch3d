using System.Collections.Generic;
using Watch3D.Test.Debuggee.Geometry;
using Watch3D.VisualizerServices;

namespace Watch3D.Test.DebuggeeVisualizer
{
    public class DebuggeeConverter : DebuggeeObjectConverter
    {
        public bool TryConvert(out InteropMesh interopMesh, object obj)
        {
            if (obj is Mesh mesh)
            {
                interopMesh = InteropConverter.ConvertMesh(mesh);
                return true;
            }
            interopMesh = new InteropMesh();
            return false;
        }

        public bool TryConvert(out InteropPoints interopPoints, object obj)
        {
            if (obj is IReadOnlyList<Point> points)
            {
                interopPoints = InteropConverter.ConvertPoints(points);
                return true;
            }
            interopPoints = new InteropPoints();
            return false;
        }

        public bool TryConvert(out InteropPoint interopPoint, object obj)
        {
            if (obj is Point point)
            {
                interopPoint = InteropConverter.ConvertPoint(point);
                return true;
            }
            interopPoint = new InteropPoint();
            return false;
        }
    }
}