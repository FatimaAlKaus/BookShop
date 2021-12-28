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
    /// Interaction logic for AuthorizeWindow.xaml
    /// </summary>
    public partial class AuthorizeWindow : Window
    {
        public AuthorizeWindow()
        {
            InitializeComponent();
            ((AuthorizationViewModel)this.DataContext).OnClosed += Close;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
