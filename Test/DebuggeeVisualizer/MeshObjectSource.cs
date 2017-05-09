using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace DebuggeeVisualizer
{
    public class MeshObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var debuggeeMesh = (Debuggee.Mesh)target;
            var meshData = InteropConverter.ToVisualizer(debuggeeMesh);
            base.GetData(meshData, outgoingData);
        }
    }
}
