using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Utility;

namespace Watch3D.Core
{
    public class SceneViewModel : Scene
    {
        public ObservableCollectionWithReplace<SceneItemViewModel> SceneItems { get; }
        public SceneItemCollectionAdapter SceneItemsViewportAdapter { get; }

        public SceneViewModel(
            ObservableCollectionWithReplace<SceneItemViewModel> sceneItems,
            SceneItemCollectionAdapter sceneItemsViewportAdapter)
        {
            SceneItems = sceneItems;
            SceneItemsViewportAdapter = sceneItemsViewportAdapter;
        }

        public void InitializeScene()
        {
            AddItem(new DirectionalHeadLight(), "Directional Head Light");
            AddItem(new GridLinesVisual3D {Width = 8, Length = 8, MinorDistance = 1, Thickness = 0.01}, "Grid");
        }

        void AddItem(ModelVisual3D visual, string name)
        {
            var sceneItem = new SceneItem(visual, name);
            var sceneItemViewModel = new SceneItemViewModel(sceneItem);
            SceneItems.Add(sceneItemViewModel);
        }

        public void AddMesh(MeshGeometry3D mesh)
        {
            var geometry = CreateModel(mesh);
            var visual = new ModelVisual3D {Content = geometry};
            AddItem(visual, "Mesh");
        }

        public void AddPolyline(Point3DCollection points)
        {
            var visual = new TubeVisual3D {Path = new Point3DCollection(points), Diameter = 0.03, Fill = Brushes.Green};
            AddItem(visual, "Polyline");
        }

        public void AddPoint(Point3D point)
        {
            var visual = new SphereVisual3D {Center = point, Radius = 0.03, Fill = Brushes.Yellow};
            AddItem(visual, "Point");
        }

        GeometryModel3D CreateModel(MeshGeometry3D mesh) =>
            new GeometryModel3D
            {
                Geometry = mesh,
                Material = new DiffuseMaterial(Brushes.LightGray),
                BackMaterial = new DiffuseMaterial(Brushes.Red)
            };
    }
}