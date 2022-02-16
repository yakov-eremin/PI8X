using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalDepartment
{
    static class User
    {
        public static int _idUser;
        public static string _userName;

        public static void SetUser(int idUser, string userName) {
            _idUser = idUser;
            _userName = userName;
        }


    }
}
