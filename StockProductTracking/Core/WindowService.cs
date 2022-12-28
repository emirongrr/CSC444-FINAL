using StockProductTracking.Core.Interfaces;
using StockProductTracking.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockProductTracking.Core
{
    internal class WindowService : IWindowService
    {
        public static List<Window> CurrentWindows = new List<Window>();
        public void ShowWindow<T>(object DataContext = null) where T : Window, new()
        {
            Window window = new T();
            if(DataContext != null)
            {
                window.DataContext = DataContext;
            }
            CurrentWindows.Add(window);
            window.Show();
        }
        public void CloseWindow<T>() where T : Window
        {
            foreach (Window w in CurrentWindows)
            {
                if(w is T)
                {
                    CurrentWindows.Remove(w);
                    w.Close();
                    return;
                }
            }
        }
        public void CloseWindowByReference(Window window)
        {
            CurrentWindows.Remove(window);
            window.Close();
        }
    }
}
