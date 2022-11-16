using FontAwesome.Sharp;
using System.Windows;
using System.Windows.Controls;


namespace StockProductTracking.MVVM.View
{
    
    public partial class LastOrdersSection : UserControl
    {
        public LastOrdersSection()
        {
            InitializeComponent();
        }



        public string Title     
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); } 
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string),typeof(LastOrdersSection));


        public string Desc
        {
            get { return (string)GetValue(DescProperty); }
            set { SetValue(DescProperty, value); }
        }

        public static readonly DependencyProperty DescProperty = DependencyProperty.Register("Desc", typeof(string), typeof(LastOrdersSection));


        public FontAwesome.Sharp.IconChar Icon
        {
            get { return (FontAwesome.Sharp.IconChar)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.Sharp.IconChar), typeof(LastOrdersSection));






    }
}
