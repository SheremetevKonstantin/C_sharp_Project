using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Workspace
    {
        public static bool IsAdmin;
        public static void isAdmin(string S)
        {
            if (S == "admin")
            {
                IsAdmin = true;
            }
            else
            {
                IsAdmin = false;
            }

        }
    }

}
