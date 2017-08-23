using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Utility;

namespace Watch3D.Core.Model
{
    public class PolylineSceneItem : SceneItem
    {
        public PolylineSceneItem(string name, Point3DCollection points)
            : base(name, new ModelVisual3D())
        {
            Polyline = points;
            TubeVisual = new TubeVisual3D { Path = points, Diameter = 0.03 };
            PointVisuals = points.Select(point => new SphereVisual3D {Center = point, Radius = 0.03}).ToArray();
            SetupChildren(true, false);
            SurfaceColor = Colors.Green;
        }

        public Point3DCollection Polyline { get; }

        Visual3DCollection VisualChildren => Visual.Children;
        TubeVisual3D TubeVisual { get; }
        IReadOnlyList<SphereVisual3D> PointVisuals { get; }


        void SetupChildren(bool tubeVisible, bool pointsVisible)
        {
            VisualChildren.Clear();
            if (tubeVisible)
                VisualChildren.Add(TubeVisual);
            if (pointsVisible)
                PointVisuals.ForEach(VisualChildren.Add);
        }

        SolidColorBrush SurfaceBrush
        {
            get { return TubeVisual.Fill.Cast<SolidColorBrush>(); }
            set
            {
                TubeVisual.Fill = value;
                PointVisuals.ForEach(point => point.Fill = value);
            }
        }

        public bool TubeVisualEnabled
        {
            get { return VisualChildren.FirstOrDefault() is TubeVisual3D; }
            set { SetupChildren(value, PointVisualsEnabled);}
        }

        public bool PointVisualsEnabled
        {
            get { return VisualChildren.LastOrDefault() is SphereVisual3D; }
            set { SetupChildren(TubeVisualEnabled, value); }
        }

        public Color SurfaceColor
        {
            get { return SurfaceBrush.Color; }
            set { SurfaceBrush = new SolidColorBrush(value); }
        }

        public double Diameter
        {
            get { return TubeVisual.Diameter; }
            set
            {
                TubeVisual.Diameter = value;
                PointVisuals.ForEach(point => point.Radius = value);
            }
        }
    }
}