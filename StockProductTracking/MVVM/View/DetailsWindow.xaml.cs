using StockProductTracking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StockProductTracking.MVVM.View
{
    /// <summary>
    /// Interaction logic for Details_Page.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow()
        {
            InitializeComponent();
            Deactivated += new EventHandler((sender, args) =>
            {
                try
                {
                    new WindowService().CloseWindowByReference(this);
                }
                catch{}
            });
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            new WindowService().CloseWindowByReference(this);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
