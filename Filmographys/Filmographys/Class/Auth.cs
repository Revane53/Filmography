using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmographys.Class
{
    static public class Auth
    {
        static DataTable user;

        static public bool Verification (string login, string password)
        {
            user = Connection.GetTable($"select * from SuperUser;");
            string res = Convert.ToBase64String(Pbkdf2.Pbkdf2.HashData("SHA512", Encoding.ASCII.GetBytes(password), Encoding.ASCII.GetBytes(user.Rows[0][3].ToString()), 350000, 64));
            if (user.Rows[0][1].ToString().Equals(login) && user.Rows[0][2].ToString().Equals(res))
                return true;
            else 
                return false;
        }
    }
}
