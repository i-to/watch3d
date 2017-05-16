using System.Collections.Generic;
using Watch3D.VisualizerServices;

namespace Watch3D.Test.DebuggeeVisualizer
{
    public class DebuggeeConverter : DebuggeeObjectConverter
    {
        public bool TryConvert(out InteropMesh interopMesh, object obj)
        {
            var mesh = obj as Watch3D.Test.Debuggee.Mesh;
            if (mesh != null)
            {
                interopMesh = InteropConverter.ConvertMesh(mesh);
                return true;
            }
            interopMesh = new InteropMesh();
            return false;
        }

        public bool TryConvert(out InteropPoints interopPoints, object obj)
        {
            var points = obj as List<Watch3D.Test.Debuggee.Point>;
            if (points != null)
            {
                interopPoints = InteropConverter.ConvertPoints(points);
                return true;
            }
            interopPoints = new InteropPoints();
            return false;
        }

        public bool TryConvert(out InteropPoint interopPoint, object obj)
        {
            var point = obj as Watch3D.Test.Debuggee.Point;
            if (point != null)
            {
                interopPoint = InteropConverter.ConvertPoint(point);
                return true;
            }
            interopPoint = new InteropPoint();
            return false;
        }
    }
}