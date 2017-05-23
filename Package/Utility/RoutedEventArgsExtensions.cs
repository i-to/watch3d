using System.Windows;

namespace Watch3D.Package.Utility
{
    public static class RoutedEventArgsExtensions
    {
        public static T GetSource<T>(this RoutedEventArgs eventArgs) =>
            (T) eventArgs.Source;
    }
}
