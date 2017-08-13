using System;
using System.Windows.Media;
using Watch3D.Core.Model;
using Watch3D.Core.Utility;

namespace Watch3D.Core.ViewModel
{
    public class PolylineSceneItemViewModel : SceneItemViewModel
    {
        public PolylineSceneItemViewModel(PolylineSceneItem model)
            : base(model)
        {
        }

        new PolylineSceneItem Model => base.Model.Cast<PolylineSceneItem>();

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

        public double Diameter
        {
            get { return Model.Diameter; }
            set
            {
                Model.Diameter = value;
                RaiseDiameterChanged();
            }
        }
        public event EventHandler DiameterChanged;
        void RaiseDiameterChanged() => DiameterChanged?.Invoke(this, EventArgs.Empty);
    }
}