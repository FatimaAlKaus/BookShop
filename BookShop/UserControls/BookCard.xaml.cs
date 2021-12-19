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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookShop.UserControls
{
    /// <summary>
    /// Interaction logic for BookCard.xaml
    /// </summary>
    public partial class BookCard : UserControl
    {

        public ICommand Expand
        {
            get { return (ICommand)GetValue(ExpandProperty); }
            set { SetValue(ExpandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpandProperty =
            DependencyProperty.Register("Expand", typeof(ICommand), typeof(BookCard), new PropertyMetadata(null));


        public ICommand Buy
        {
            get { return (ICommand)GetValue(BuyProperty); }
            set { SetValue(BuyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Buy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BuyProperty =
            DependencyProperty.Register("Buy", typeof(ICommand), typeof(BookCard), new PropertyMetadata(null));



        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(BookCard));





        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Price.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(int), typeof(BookCard), new PropertyMetadata(0));




        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Author.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AuthorProperty =
            DependencyProperty.Register("Author", typeof(string), typeof(BookCard), new PropertyMetadata(""));



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(BookCard), new PropertyMetadata(""));

        public BookCard()
        {
            InitializeComponent();
        }
    }
}
