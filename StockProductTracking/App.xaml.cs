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
        LoginView loginView;
        MainWindow mainWindow;
        private void LogOff(object o, DependencyPropertyChangedEventArgs args)
        {
            if(mainWindow.IsVisible == false && mainWindow.IsLoaded)
            {
                InitLogIn();
                mainWindow.Close();
            }

        }

        private void InitLogIn()
        {
            loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (o, args) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    mainWindow = new MainWindow();
                    mainWindow.IsVisibleChanged += new DependencyPropertyChangedEventHandler(LogOff);
                    mainWindow.Show();
                    loginView.Close();

                }
            };
        }
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            InitLogIn();
        }
    }
}