﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public static class CurrentUser
    {
        private static string _name;

        public static string Name => _name;

        private static string _role;
        public static string Role => _role;
        static CurrentUser()
        {
            _name = "Гость";
            _role = BookShop.Role.Guest;
        }

        public static void SetUser(string name, string role)
        {
            _name = name;
            _role = role;
        }
    }
}