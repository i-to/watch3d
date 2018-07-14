using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Scene;

namespace Watch3D.Core.ViewModel
{
    public class SceneItemFactory
    {
        public MeshSceneItemViewModel CreateMesh(string name, MeshGeometry3D mesh)
        {
            var model = new MeshSceneItem(name, mesh);
            return new MeshSceneItemViewModel(model);
        }

        public LightSceneItemViewModel CreateLight()
        {
            var model = new LightSceneItem();
            return new LightSceneItemViewModel(model);
        }

        public GridSceneItemViewModel CreateGrid()
        {
            var model = new GridSceneItem();
            return new GridSceneItemViewModel(model);
        }

        public PolylineSceneItemViewModel CreatePolyline(string name, Point3DCollection points)
        {
            var model = new PolylineSceneItem(name, points);
            return new PolylineSceneItemViewModel(model);
        }

        public PointSceneItemViewModel CreatePoint(string name, Point3D point)
        {
            var model = new PointSceneItem(name, point);
            return new PointSceneItemViewModel(model);
        }

        public SceneItemViewModel CreatePlane(string name, Plane3D plane)
        {
            var model = new PlaneSceneItem(name, plane);
            return new PlaneSceneItemViewModel(model);
        }
    }
}