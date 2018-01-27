using System.Windows.Input;

namespace Watch3D.Gui
{
    public class UICommands
    {
        public static readonly RoutedUICommand ToggleShowHide =
            new RoutedUICommand(
                "Show/Hide",
                nameof(ToggleShowHide),
                typeof(UICommands),
                new InputGestureCollection { new KeyGesture(Key.Space) });

        public static readonly RoutedCommand StartEditingListItemByKeyGesture =
            new RoutedUICommand(
                "Rename",
                nameof(StartEditingListItemByKeyGesture),
                typeof(UICommands),
                new InputGestureCollection { new KeyGesture(Key.F2) });

        public static readonly RoutedUICommand StartEditingListItemByMouseGesture =
            new RoutedUICommand(
                "Rename",
                nameof(StartEditingListItemByMouseGesture),
                typeof(UICommands),
                new InputGestureCollection { new MouseGesture(MouseAction.LeftDoubleClick) });

        public static readonly RoutedUICommand Export =
            new RoutedUICommand(
                "Export ...",
                nameof(Export),
                typeof(UICommands));

        public static readonly RoutedUICommand ExportSTL =
            new RoutedUICommand(
                "Export STL ...",
                nameof(ExportSTL),
                typeof(UICommands));
    }
}
