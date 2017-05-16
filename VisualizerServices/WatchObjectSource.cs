using System;
using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace Watch3D.VisualizerServices
{
    public class WatchObjectSource : VisualizerObjectSource
    {
        readonly DebuggeeObjectConverter Converter;

        public WatchObjectSource(DebuggeeObjectConverter converter)
        {
            Converter = converter;
        }

        public override void GetData(object target, Stream outgoingData)
        {
            InteropMesh mesh;
            if (Converter.TryConvert(out mesh, target))
            {
                base.GetData(mesh, outgoingData);
                return;
            }

            InteropPoints points;
            if (Converter.TryConvert(out points, target))
            {
                base.GetData(points, outgoingData);
                return;
            }

            InteropPoint point;
            if (Converter.TryConvert(out point, target))
            {
                base.GetData(point, outgoingData);
                return;
            }

            throw new ArgumentException("Unknown debuggee object type.");
        }
    }
}