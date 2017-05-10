using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace Watch3D.Test.DebuggeeVisualizer
{
    public class MeshObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var debuggeeMesh = (Watch3D.Test.Debuggee.Mesh)target;
            var meshData = InteropConverter.ToVisualizer(debuggeeMesh);
            base.GetData(meshData, outgoingData);
        }
    }
}
