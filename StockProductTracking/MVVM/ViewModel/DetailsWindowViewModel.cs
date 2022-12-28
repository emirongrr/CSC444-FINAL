using StockProductTracking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class DetailsWindowViewModel : ObservableObject
    {
        private string _details;
        public string Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
                OnPropertyChanged(nameof(Details));
            }
        }
        public ICommand CopyContents { get; set; }
        public DetailsWindowViewModel()
        {
            CopyContents = new RelayCommand(o =>
            {
                try
                {
                    Clipboard.SetText(Details);
                }
                catch{}
            });
        }
    }
}
