using System;
using System.Windows;

namespace Watch3D.Test.GuiStandalone
{
    public static class EntryPoint
    {
        [STAThread]
        public static void Main()
        {
            var application = new Application();
            var root = new Root();
            root.InitializeTestScene();
            application.Run(root.Window);
        }
    }
}
