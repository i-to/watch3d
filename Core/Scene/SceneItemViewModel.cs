using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Watch3D.Core.Scene
{
    public class SceneItemViewModel
    {
        readonly SceneItem Model;

        public SceneItemViewModel(SceneItem model)
        {
            Model = model;
        }

        public Visual3D Visual => Model.Visual;
        public string Name
        {
            get { return Model.Name; }
            set { Model.Name = value; }
        }

        public bool IsVisible => !Model.IsHidden;

        public void ToggleVisibility()
        {
            Model.IsHidden = !Model.IsHidden;
            RaiseForegroundChanged();
        }

        public Brush Foreground => IsVisible ? Brushes.Black : Brushes.LightGray;
        public event EventHandler ForegroundChanged;

        void RaiseForegroundChanged() => ForegroundChanged?.Invoke(this, EventArgs.Empty);
    }
}