using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Utility;

namespace Watch3D.Core.Scene
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

        SphereVisual3D SphereVisual => Visual.Cast<SphereVisual3D>();

        public Point3D Location
        {
            get => SphereVisual.Center;
            set => SphereVisual.Center = value;
        }

        public double X
        {
            get => Location.X;
            set => Location = new Point3D(value, Y, Z);
        }

        public double Y
        {
            get => Location.Y;
            set => Location = new Point3D(X, value, Z);
        }

        public double Z
        {
            get => Location.Z;
            set => Location = new Point3D(X, Y, value);
        }

        SolidColorBrush SurfaceBrush
        {
            get => SphereVisual.Fill.Cast<SolidColorBrush>();
            set => SphereVisual.Fill = value;
        }

        public Color SurfaceColor
        {
            get => SurfaceBrush.Color;
            set => SurfaceBrush = new SolidColorBrush(value);
        }

        public double Radius
        {
            get => SphereVisual.Radius;
            set => SphereVisual.Radius = value;
        }
    }
}