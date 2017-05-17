using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Watch3D.Package.Utility
{
    static class ListBoxExtensions
    {
        public static IEnumerable<int> SelectedItemIndices(this ListBox listBox) =>
            listBox.SelectedItems.Cast<object>().Select(o => listBox.Items.IndexOf(o));
    }
}
