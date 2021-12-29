using BookShop.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookShop.View
{
    /// <summary>
    /// Interaction logic for BookListPage.xaml
    /// </summary>
    public partial class BookListPage : Page, INotifyPropertyChanged
    {
        public BookListPage()
        {
            InitializeComponent();
            ((BookCatalogViewModel)this.DataContext).PropertyChanged += PropertyChanged;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Order_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrderIcon.IsManipulationEnabled = !OrderIcon.IsManipulationEnabled;
            OrderIcon.Kind = OrderIcon.Kind = OrderIcon.Kind != MaterialDesignThemes.Wpf.PackIconKind.ArrowDown ? MaterialDesignThemes.Wpf.PackIconKind.ArrowDown : MaterialDesignThemes.Wpf.PackIconKind.ArrowUp;
        }
    }
}
