using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public static class EntireUser
    {
        private static int _id;
        public static int Id => _id;
        static EntireUser()
        {
            SignOut();
        }
        public static void SignOut()
        {
            _id = 4;
        }

        public static void SetUser(int id)
        {
            _id = id;
        }
    }
}
