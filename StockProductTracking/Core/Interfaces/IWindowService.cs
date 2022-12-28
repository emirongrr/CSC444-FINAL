using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockProductTracking.Core.Interfaces
{
    interface IWindowService
    {
         void CloseWindow<T>() where T : Window;
         void ShowWindow<T>(object DataContext) where T: Window, new();
        void CloseWindowByReference(Window window);
    }
}
