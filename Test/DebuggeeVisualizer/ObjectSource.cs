using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace Watch3D.Test.DebuggeeVisualizer
{
    public class ObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var mesh = target as Watch3D.Test.Debuggee.Mesh;
            if (mesh != null)
            {
                var interopMesh = InteropConverter.ConvertMesh(mesh);
                base.GetData(interopMesh, outgoingData);
                return;
            }

            var points = target as List<Watch3D.Test.Debuggee.Point>;
            if (points != null)
            {
                var interopPoints = InteropConverter.ConvertPoints(points);
                base.GetData(interopPoints, outgoingData);
                return;
            }

            var point = target as Watch3D.Test.Debuggee.Point;
            if (point != null)
            {
                var interopPoint = InteropConverter.ConvertPoint(point);
                base.GetData(interopPoint, outgoingData);
                return;
            }

            throw new ArgumentException("Unknown debuggee object type.");
        }
    }
}
