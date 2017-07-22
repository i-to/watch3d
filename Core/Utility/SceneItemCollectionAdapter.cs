using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media.Media3D;
using Watch3D.Core.Model;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Utility
{
    public class SceneItemCollectionAdapter
    {
        readonly ObservableCollection<SceneItemViewModel> Source;

        public SceneItemCollectionAdapter(ObservableCollection<SceneItemViewModel> source)
        {
            Source = source;
            source.CollectionChanged += OnCollectionChanged;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => RaiseVisualsChanged();
        void RaiseVisualsChanged() => VisualsChanged?.Invoke(this, EventArgs.Empty);

        public IEnumerable<Visual3D> Visuals => Source.Where(item => item.IsVisible).Select(item => item.Visual);
        public event EventHandler VisualsChanged;
    }
}