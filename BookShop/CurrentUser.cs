using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public static class CurrentUser
    {
        private static string _name;

        private static string _role;
        private static int _balance;

        public static string Name => _name;
        public static string Role => _role;
        public static int Balance => _balance;
        static CurrentUser()
        {
            SignOut();
        }
        public static void SignOut()
        {
            _name = "Гость";
            _role = Persistence.Constants.Role.Guest;
            _balance = 0;
        }

        public static void SetUser(string name, string role, int balance)
        {
            _name = name;
            _role = role;
            _balance = balance;
        }
    }
}
