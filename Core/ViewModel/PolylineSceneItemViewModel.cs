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
                RaiseColorChanged();
                Model.SurfaceColor = value;
            }
        }
        public event EventHandler ColorChanged;
        void RaiseColorChanged() => ColorChanged?.Invoke(this, EventArgs.Empty);
    }
}