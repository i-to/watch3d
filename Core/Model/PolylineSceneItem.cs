using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Utility;

namespace Watch3D.Core.Model
{
    public class PolylineSceneItem : SceneItem
    {
        public PolylineSceneItem(string name, Point3DCollection points)
            : base(
                name,
                new TubeVisual3D { Path = points, Diameter = 0.03 })
        {
            Polyline = points;
            SurfaceColor = Colors.Green;
        }

        public Point3DCollection Polyline { get; }

        TubeVisual3D TubeVisual => Visual.Cast<TubeVisual3D>();

        SolidColorBrush SurfaceBrush
        {
            get { return TubeVisual.Fill.Cast<SolidColorBrush>(); }
            set { TubeVisual.Fill = value; }
        }

        public Color SurfaceColor
        {
            get { return SurfaceBrush.Color; }
            set { SurfaceBrush = new SolidColorBrush(value); }
        }

        public double Diameter
        {
            get { return TubeVisual.Diameter; }
            set { TubeVisual.Diameter = value; }
        }
    }
}