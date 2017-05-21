using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public class SceneItem
    {
        public SceneItem(ModelVisual3D visual, string name)
        {
            Visual = visual;
            Name = name;
        }

        public ModelVisual3D Visual { get; }
        public string Name { get; set; }
        public bool IsHidden { get; set; }
    }
}