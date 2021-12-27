using Application.DTO;
using Application.Interfaces;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookShop.ViewModel
{
    public class RegistrationViewModel : BindableBase
    {
        private readonly IUserService _userService;

        public RegistrationViewModel(IUserService userService)
        {
            this._userService = userService;
            RegisteredUser = new UserDto() { UserName = "", Password = "" };
        }
        public UserDto RegisteredUser { get; set; }

        public ICommand SaveUser => new DelegateCommand<string>((password) =>
        {
            RegisteredUser.Password = password;
            var currentUser = _userService.RegisterUser(RegisteredUser);
            CurrentUser.SetUser(currentUser.UserName, currentUser.Role);
        }, (password) => { return RegisteredUser.IsValid; });
    }
}
