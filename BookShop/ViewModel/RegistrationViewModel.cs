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
    public class RegistrationViewModel : BindableBase
    {
        private readonly IUserService _userService;
        public event Action? OnClosed;
        public RegistrationViewModel(IUserService userService)
        {
            this._userService = userService;
            RegisteredUser = new UserDto() { UserName = "", Password = "" };
        }
        public UserDto RegisteredUser { get; set; }

        public ICommand SaveUser => new DelegateCommand<object>((password) =>
        {
            if (!_userService.CheckUserName(RegisteredUser.UserName))
            {

                var pass = (PasswordBox)password;
                RegisteredUser.Password = pass.Password;
                var currentUser = _userService.RegisterUser(RegisteredUser);
                CurrentUser.SetUser(currentUser.UserName, currentUser.Role,currentUser.Balance);
                OnClosed?.Invoke();
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует");
            }
        }, (password) => { return RegisteredUser.IsValid; });
    }
}
