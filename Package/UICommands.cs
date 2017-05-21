using System.Windows.Input;

namespace Watch3D.Package
{
    public class UICommands
    {
        public static readonly RoutedUICommand ToggleShowHide;

        static UICommands()
        {
            var gesture = new InputGestureCollection {new KeyGesture(Key.Space)};
            ToggleShowHide = new RoutedUICommand(
                "Show/Hide", nameof(ToggleShowHide), typeof(UICommands), gesture);
        }
    }
}
