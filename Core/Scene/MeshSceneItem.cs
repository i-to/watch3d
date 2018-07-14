using System.Windows.Media;
using System.Windows.Media.Media3D;
using Watch3D.Core.Utility;

namespace Watch3D.Core.Scene
{
    public class MeshSceneItem : SceneItem
    {
        public MeshSceneItem(string name, MeshGeometry3D geometry)
            : base(
                name,
                new ModelVisual3D {
                    Content = new GeometryModel3D {
                        Geometry = geometry,
                        Material = new DiffuseMaterial(new SolidColorBrush()),
                        BackMaterial = new DiffuseMaterial(new SolidColorBrush())
                    }
                })
        {
            Mesh = geometry;
            FrontSurfaceColor = Colors.LightGray;
            BackSurfaceColor = Colors.Red;
        }

        public MeshGeometry3D Mesh { get; }

        GeometryModel3D GeometryModel => Visual.Content.Cast<GeometryModel3D>();
        DiffuseMaterial FrontMaterial => GeometryModel.Material.Cast<DiffuseMaterial>();
        DiffuseMaterial BackMaterial => GeometryModel.BackMaterial.Cast<DiffuseMaterial>();
        SolidColorBrush FrontSurfaceBrush => FrontMaterial.Brush.Cast<SolidColorBrush>();
        SolidColorBrush BackSurfaceBrush => BackMaterial.Brush.Cast<SolidColorBrush>();

        public Color FrontSurfaceColor
        {
            get => FrontSurfaceBrush.Color;
            set => FrontSurfaceBrush.Color = value;
        }

        public Color BackSurfaceColor
        {
            get => BackSurfaceBrush.Color;
            set => BackSurfaceBrush.Color = value;
        }
    }
}