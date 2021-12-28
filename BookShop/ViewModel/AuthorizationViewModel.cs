using Application.DTO;
using Application.Interfaces;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookShop.ViewModel
{
    public class AuthorizationViewModel : BindableBase
    {
        private readonly IUserService _userService;
        public event Action? OnClosed;
        public AuthorizationViewModel(IUserService userService)
        {
            _userService = userService;
            User = new UserDto() { UserName = "", Password = "" };
        }
        public UserDto User { get; set; }

        public ICommand SignIn => new DelegateCommand<object>((password) =>
        {
            var pass = (PasswordBox)password;
            User.Password = pass.Password;
            var currentUser = _userService.SignIn(User.UserName, User.Password);
            if (currentUser != null)
            {
                CurrentUser.SetUser(currentUser.UserName, currentUser.Role,currentUser.Balance);
                OnClosed?.Invoke();
            }
            else
            {
                MessageBox.Show("Неправильно указан логин или пароль!");
            }
        });
    }
}
