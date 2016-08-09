using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment
{
    public class UserManagment
    {
        public bool Add(string id, string phone, string email)
        {
            if (!isID(id))
            {
                throw new Exception("Can't add new user with id length less than 4");
            }

            if (!isPhoneNumber(phone))
            {
                throw new Exception("Can't add phone that do not match the pattern");
            }

            if(!isEmailAdress(email))
            {
                throw new Exception("Can't email");
            }

            return true;
        }

        private bool isID(string id)
        {
            string pattern = @"^[a-z]{4,}$";

            return Regex.IsMatch(id, pattern, RegexOptions.IgnoreCase);
        }

        private bool isPhoneNumber(string phone)
        {
            string pattern = @"^\+38\d{10}$";

            return Regex.IsMatch(phone, pattern);
        }

        private bool isEmailAdress(string email)
        {
            string pattern = @"^[a-z_]{3,}@[a-z]{2,}\.[a-z]{2,}$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}
