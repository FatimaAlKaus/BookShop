using Application.DTO;
using Application.Interfaces;
using DevExpress.Mvvm;
using Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShop.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private readonly IDbContext _context;

        public AuthorDto Author => _context.Authors.FirstOrDefault().Adapt<AuthorDto>();

        public decimal Price { get; set; } = 1212;
        public string Title { get; set; } = "Titiless";

        public ICommand Buy => new DelegateCommand(() => { Title = Title + "1"; });

        public MainViewModel(IDbContext context)
        {
            _context = context;
        }
    }
}
