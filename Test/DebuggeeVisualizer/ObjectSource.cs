using Watch3D.VisualizerServices;

namespace Watch3D.Test.DebuggeeVisualizer
{
    public class ObjectSource : WatchObjectSource
    {
        public ObjectSource()
            : base(new DebuggeeConverter())
        {
        }
    }
}
