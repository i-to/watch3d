using System.Windows.Input;

namespace Watch3D.Gui.Commands
{
    public class SceneCommands
    {
        public static readonly RoutedUICommand AddPoint =
            new RoutedUICommand(
                "Add Point",
                nameof(AddPoint),
                typeof(SceneCommands)/*,
                new InputGestureCollection { new KeyGesture(Key.P) }*/);
    }
}
