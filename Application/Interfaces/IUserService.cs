using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        UserDto RegisterUser(UserDto user);
        UserDto SignIn(string userName, string password);
        bool CheckUserName(string userName);
        List<GenreDto> GetFavoriteGenres(int userId);

        UserDto GetUserById(int id);
        List<DiscountBookDto> OfferBooks(int userId, int take);
    }
}
