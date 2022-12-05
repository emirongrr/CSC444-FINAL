using StockProductTracking.MVVM.CustomControls;
using StockProductTracking.Utils;
using System.Security;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StockProductTracking.CustomControls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBoxString.xaml
    /// </summary>
    public partial class BindablePasswordBoxString : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
                DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBoxString));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBoxString()
        {
            InitializeComponent();
            passwordBox.PasswordChanged += OnPasswordChanged;

        }

        
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = SHA256Helper.ComputeSha256Hash(passwordBox.Password);
        }
    }
}
