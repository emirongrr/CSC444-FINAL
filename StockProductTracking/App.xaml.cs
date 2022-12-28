using StockProductTracking.Core;
using StockProductTracking.MVVM.View;
using StockProductTracking.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace StockProductTracking
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            new WindowService().ShowWindow<LoginView>();
        }
    }
}