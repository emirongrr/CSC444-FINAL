using MySqlX.XDevAPI.Relational;
using Prism.Commands;
using StockProductTracking.MVVM.View;
using StockProductTracking.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

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
        public ICommand ShowDetails
        {
            get
            {
                return _ShowDetails;
            }
        }
        private ICommand _ShowDetails = new DelegateCommand<ModelObject>(o =>
        {
            if (o is null)
                return;

            new WindowService().ShowWindow<DetailsWindow>(new DetailsWindowViewModel()
            {
                Details = o.Dump()
            });
        });
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

        private ModelObject _SelectedItem;
        public ModelObject SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                if(value != null)
                {
                    _SelectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

    }
}
