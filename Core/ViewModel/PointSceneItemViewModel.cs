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
                RaiseColorChanged();
                Model.SurfaceColor = value;
            }
        }
        public event EventHandler ColorChanged;
        void RaiseColorChanged() => ColorChanged?.Invoke(this, EventArgs.Empty);
    }
}