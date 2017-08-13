using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Utility;

namespace Watch3D.Core.Model
{
    public class PointSceneItem : SceneItem
    {
        public PointSceneItem(string name, Point3D point)
            : base(
                name,
                new SphereVisual3D { Center = point, Radius = 0.03 })
        {
            Location = point;
            SurfaceColor = Colors.Yellow;
        }

        public Point3D Location { get; }

        SphereVisual3D SphereVisual => Visual.Cast<SphereVisual3D>();

        SolidColorBrush SurfaceBrush
        {
            get { return SphereVisual.Fill.Cast<SolidColorBrush>(); }
            set { SphereVisual.Fill = value; }
        }

        public Color SurfaceColor
        {
            get { return SurfaceBrush.Color; }
            set { SurfaceBrush = new SolidColorBrush(value); }
        }

        public double Radius
        {
            get { return SphereVisual.Radius; }
            set { SphereVisual.Radius = value; }
        }
    }
}