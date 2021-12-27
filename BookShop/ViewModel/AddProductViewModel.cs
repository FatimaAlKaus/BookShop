using Application.DTO;
using Application.Interfaces;
using BookShop.View.Dialogs;
using DevExpress.Mvvm;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookShop.ViewModel
{
    public class AddProductViewModel : BindableBase
    {
        public AddProductViewModel(IConfiguration configuration, SelectCategoriesViewModel selectCategoriesViewModel, IBookService bookService)
        {
            CreatableBook = new BookDto() { Title = "", Authors = "" };

            this._configuration = configuration;
            this.selectCategoriesViewModel = selectCategoriesViewModel;
            this._bookService = bookService;
        }
        private readonly IConfiguration _configuration;
        private readonly SelectCategoriesViewModel selectCategoriesViewModel;
        private readonly IBookService _bookService;

        public bool HasPhoto => string.IsNullOrEmpty(CreatableBook.ImagePath);
        public string Genres => string.Join(", ", selectCategoriesViewModel.Genres.Where(x => x.IsSelected));
        public BookDto CreatableBook { get; set; }
        public ICommand AddCategories => new DelegateCommand(() =>
        {
            var categoriesDialog = new SelectCategoriesDialog(selectCategoriesViewModel);
            categoriesDialog.ShowDialog();
            CreatableBook.GenresDto = selectCategoriesViewModel.Genres.Where(x => x.IsSelected).ToList() ?? new List<GenreDto>();
            RaisePropertyChanged("Genres");
        });
        public ICommand AddPhoto => new DelegateCommand(() =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                var file = openFileDialog.FileName;
                var fileName = Guid.NewGuid().ToString() + file.Substring(file.LastIndexOf("."));
                var newName = _configuration["Resources"] + fileName;
                File.Copy(file, newName, true);
                CreatableBook.ImagePath = newName;
                RaisePropertyChanged("HasPhoto");
                RaisePropertyChanged("CreatableBook");
            }
        });
        public ICommand Accept => new DelegateCommand<Window>((w) =>
        {
            _bookService.AddBook(CreatableBook);
            w.Close();
        }, (w) => CreatableBook.IsValid);
    }
}
