using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Watch3D.Core.Model;
using Watch3D.Core.Scene;

namespace Watch3D.Core.ViewModel
{
    public abstract class SceneItemViewModel
    {
        protected SceneItemViewModel(SceneItem model)
        {
            Model = model;
        }

        public SceneItem Model { get; }

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
            RaiseNameTextColorChanged();
        }

        public Brush NameTextColor => IsVisible ? Brushes.Black : Brushes.LightGray;
        public event EventHandler NameTextColorChanged;
        void RaiseNameTextColorChanged() => NameTextColorChanged?.Invoke(this, EventArgs.Empty);
    }
}