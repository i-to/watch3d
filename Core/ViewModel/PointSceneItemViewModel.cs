using System;
using System.Windows.Media;
using Watch3D.Core.Model;
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

        public Color Color
        {
            get { return Model.SurfaceColor; }
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
            get { return Model.Radius; }
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