using System.Windows.Media.Media3D;
using Watch3D.Core.Model;

namespace Watch3D.Core.ViewModel
{
    public class SceneItemFactory
    {
        public MeshSceneItemViewModel CreateMesh(MeshGeometry3D mesh)
        {
            var model = new MeshSceneItem("Mesh", mesh);
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

        public PolylineSceneItemViewModel CreatePolyline(Point3DCollection points)
        {
            var model = new PolylineSceneItem("Polyline", points);
            return new PolylineSceneItemViewModel(model);
        }

        public PointSceneItemViewModel CreatePoint(Point3D point)
        {
            var model = new PointSceneItem("Point", point);
            return new PointSceneItemViewModel(model);
        }
    }
}