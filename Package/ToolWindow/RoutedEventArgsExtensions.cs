using System.Windows;

namespace Watch3D.Package.ToolWindow
{
    public static class RoutedEventArgsExtensions
    {
        public static T GetSource<T>(this RoutedEventArgs eventArgs) =>
            (T) eventArgs.Source;
    }
}
