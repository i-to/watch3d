using System.Windows.Media.Media3D;

namespace Watch3D.Core.Model
{
    public abstract class SceneItem
    {
        protected SceneItem(string name, ModelVisual3D visual)
        {
            Name = name;
            Visual = visual;
        }

        public string Name { get; set; }
        public ModelVisual3D Visual { get; }
        public bool IsHidden { get; set; }
    }
}