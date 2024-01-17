using System.ComponentModel.DataAnnotations;

namespace lab_8.Validations
{
    public static class UserValidation
    {
        public static bool NameIsValid(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return true;
            return false;
        }
        public static bool EmailIsValid(string email)
        {
            if (!string.IsNullOrEmpty(email) && email.Contains('@'))
                return true;
            return false;
        }
        public static bool PasswordIsValid(string password)
        {
            if (!string.IsNullOrEmpty(password) && password.Length >= 8)
                return true;
            return false;
        }

        public static bool AddressIsValid(string address)
        {
            if (!string.IsNullOrEmpty(address))
                return true;
            return false;
        }

        public static bool UserIsValid(string name, string email, string password, string address)
        {
            return NameIsValid(name)
                && EmailIsValid(email)
                && PasswordIsValid(password)
                && AddressIsValid(address);
        }

    }
}
