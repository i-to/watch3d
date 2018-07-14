using System.Windows.Input;

namespace Watch3D.Gui.Commands
{
    public class SceneItemCommands
    {
        public static readonly RoutedUICommand ToggleShowHide =
            new RoutedUICommand(
                "Show/Hide",
                nameof(ToggleShowHide),
                typeof(SceneItemCommands),
                new InputGestureCollection { new KeyGesture(Key.Space) });

        public static readonly RoutedCommand StartEditingListItemByKeyGesture =
            new RoutedUICommand(
                "Rename",
                nameof(StartEditingListItemByKeyGesture),
                typeof(SceneItemCommands),
                new InputGestureCollection { new KeyGesture(Key.F2) });

        public static readonly RoutedUICommand StartEditingListItemByMouseGesture =
            new RoutedUICommand(
                "Rename",
                nameof(StartEditingListItemByMouseGesture),
                typeof(SceneItemCommands),
                new InputGestureCollection { new MouseGesture(MouseAction.LeftDoubleClick) });

        public static readonly RoutedUICommand ExportItem =
            new RoutedUICommand(
                "Export ...",
                nameof(ExportItem),
                typeof(SceneItemCommands));

        public static readonly RoutedUICommand ExportItemAsSTL =
            new RoutedUICommand(
                "Export STL ...",
                nameof(ExportItemAsSTL),
                typeof(SceneItemCommands));
    }
}
