using Application.DTO;
using Application.Interfaces;
using DevExpress.Mvvm;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookShop.ViewModel
{
    public class SelectCategoriesViewModel : BindableBase
    {
        public List<GenreDto> Genres { get; set; }
        public event Action<List<GenreDto>> GenresChanged;
        public SelectCategoriesViewModel(IDbContext dbContext)
        {
            Genres = dbContext.Genres.Select(x => x.Adapt<GenreDto>()).ToList();
        }
        public ICommand Accept => new DelegateCommand<Window>((window) =>
        {
            GenresChanged?.Invoke(Genres.Where(x => x.IsSelected).ToList());
            window.Close();
        });
    }
}
