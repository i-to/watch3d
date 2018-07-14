using System;
using System.Windows.Media;
using Watch3D.Core.Scene;
using Watch3D.Core.Utility;

namespace Watch3D.Core.ViewModel
{
    public class PointSceneItemViewModel : SceneItemViewModel
    {
        public PointSceneItemViewModel(PointSceneItem model)
            : base(model)
        {
        }

        new PointSceneItem Model => base.Model.Cast<PointSceneItem>();

        public double X
        {
            get => Model.X;
            set
            {
                Model.X = value;
                RaiseXChanged();
            }
        }
        public event EventHandler XChanged;
        void RaiseXChanged() => XChanged?.Invoke(this, EventArgs.Empty);

        public double Y
        {
            get => Model.Y;
            set
            {
                Model.Y = value;
                RaiseYChanged();
            }
        }
        public event EventHandler YChanged;
        void RaiseYChanged() => YChanged?.Invoke(this, EventArgs.Empty);

        public double Z
        {
            get => Model.Z;
            set
            {
                Model.Z = value;
                RaiseZChanged();
            }
        }
        public event EventHandler ZChanged;
        void RaiseZChanged() => ZChanged?.Invoke(this, EventArgs.Empty);

        public Color Color
        {
            get => Model.SurfaceColor;
            set
            {
                Model.SurfaceColor = value;
                RaiseColorChanged();
            }
        }
        public event EventHandler ColorChanged;
        void RaiseColorChanged() => ColorChanged?.Invoke(this, EventArgs.Empty);

        public double Radius
        {
            get => Model.Radius;
            set
            {
                Model.Radius = value;
                RaiseRadiusChanged();
            }
        }
        public event EventHandler RadiusChanged;
        void RaiseRadiusChanged() => RadiusChanged?.Invoke(this, EventArgs.Empty);
    }
}