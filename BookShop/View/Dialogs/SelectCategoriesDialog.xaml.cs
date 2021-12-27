using BookShop.ViewModel;
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

namespace BookShop.View.Dialogs
{
    /// <summary>
    /// Interaction logic for SelectCategoriesDialog.xaml
    /// </summary>
    public partial class SelectCategoriesDialog : Window
    {
        public SelectCategoriesDialog(SelectCategoriesViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
