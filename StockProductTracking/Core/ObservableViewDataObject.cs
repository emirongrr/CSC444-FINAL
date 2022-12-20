using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.Core
{
    internal class ObservableViewDataObject : ObservableObject
    {
        private string _SearchKey;
        public string SearchKey
        {
            get { return _SearchKey; }
            set
            {
                _SearchKey = value;
                OnPropertyChanged(nameof(SearchKey));
                CollectionView.Filter = SearchFilter;
            }
        }

        private ICollectionView _CollectionView;

        public ICollectionView CollectionView
        {
            get { return _CollectionView; }
            set { _CollectionView = value; }
        }
        public virtual bool SearchFilter(object o)
        {
            return true;
        }

    }
}
