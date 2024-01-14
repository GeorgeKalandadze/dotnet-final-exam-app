using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_magazine
{
    public static class CurrentUser
    {
        public static User LoggedInUser { get; private set; }

        public static void SetLoggedInUser(User user)
        {
            LoggedInUser = user;
        }
    }
}
