using Watch3D.Core.Model;
using Watch3D.VisualizerServices;

namespace Watch3D.Core
{
    public class WatchVisualizerService : VisualizerService
    {
        readonly VisualizerAddGeometry Scene;

        public WatchVisualizerService(VisualizerAddGeometry scene)
        {
            Scene = scene;
        }

        public void ShowMesh(InteropMesh interopMesh)
        {
            var mesh = InteropConverter.ConvertMesh(interopMesh);
            Scene.AddMesh(mesh);
        }

        public void ShowPoints(InteropPoints interopPoints)
        {
            var points = InteropConverter.ConvertPoints(interopPoints);
            Scene.AddPolyline(points);
        }

        public void ShowPoint(InteropPoint interopPoint)
        {
            var point = InteropConverter.ConvertPoint(interopPoint);
            Scene.AddPoint(point);
        }
    }
}