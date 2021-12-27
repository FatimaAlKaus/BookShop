using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.ViewModel.VML
{
    internal class ViewModelLocator
    {
        public MainViewModel MainViewModel => Ioc.Resolve<MainViewModel>();
        public AdminPanelViewModel AdminPanelViewModel => Ioc.Resolve<AdminPanelViewModel>();

        public AddProductViewModel AddProductViewModel => Ioc.Resolve<AddProductViewModel>();

        public BookCatalogViewModel BookCatalogViewModel => Ioc.Resolve<BookCatalogViewModel>();

        public SelectCategoriesViewModel SelectCategoriesViewModel => Ioc.Resolve<SelectCategoriesViewModel>();

        public RegistrationViewModel RegistrationViewModel => Ioc.Resolve<RegistrationViewModel>();
    }
}
