using Application.DTO;
using Application.Interfaces;
using DevExpress.Mvvm;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShop.ViewModel
{
    public class SpecialOffersViewModel : BindableBase
    {
        private readonly IDbContext _context;
        private readonly IUserService _userService;

        public SpecialOffersViewModel(IDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public List<DiscountBookDto> Books
        {
            get
            {
                return _userService.OfferBooks(EntireUser.Id, 3);

            }
        }
    }
}
