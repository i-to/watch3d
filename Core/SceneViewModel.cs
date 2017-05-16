using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace Watch3D.Core
{
    public class SceneViewModel : Scene
    {
        public ObservableCollection<Visual3D> SceneItems { get; }

        public SceneViewModel()
        {
            SceneItems = new ObservableCollection<Visual3D>();
        }

        public void InitializeScene()
        {
            SceneItems.Add(new DirectionalHeadLight());
            SceneItems.Add(new GridLinesVisual3D {Width = 8, Length = 8, MinorDistance = 1, Thickness = 0.01});
        }

        public void AddMesh(MeshGeometry3D mesh)
        {
            var model = CreateModel(mesh);
            var visual = new SceneItemVisual
            {
                Content = model,
                SceneItemName = "Mesh"
            };
            SceneItems.Add(visual);
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