using System;
using System.Collections.ObjectModel;

namespace Watch3D.Core.Utility
{
    public class ObservableCollectionWithReplace<T> : ObservableCollection<T>
    {
        public void Modify(int index, Action<T> action)
        {
            var item = this[index];
            action(item);
            SetItem(index, item);
        }
    }
}